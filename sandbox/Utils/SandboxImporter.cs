using NiL.JS;
using NiL.JS.Core;
using sandbox.Resolvers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace sandbox.Utils
{
    public static class SandboxImporter
    {
        public static async Task<JSValue> Import(string moduleName)
        {
            try
            {
                var modulePath = ModuleMapper.GetPath(moduleName);

                if (modulePath is null)
                {
                    return JSValue.Undefined;
                }

                var resolvedPath = Path.Join(Directory.GetCurrentDirectory(), modulePath);

                if (!File.Exists(resolvedPath))
                {
                    return JSValue.Undefined;
                }

                var code = await File.ReadAllTextAsync(resolvedPath);
                var module = new Module(resolvedPath, code);

                module.ModuleResolversChain.Add(new NamedPackageModuleResolver());
                module.ModuleResolversChain.Add(new RelativePathModuleResolver());

                module.Run();

                return module.Exports.CreateExportList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return JSValue.Undefined;
            }
        }
    }
}
