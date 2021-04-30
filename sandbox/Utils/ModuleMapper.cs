namespace sandbox.Utils
{
    public static class ModuleMapper
    {
        public static string GetPath(string moduleName) => moduleName switch
        {
            "https://esm.run/moment" => "node_modules/moment/dist/moment.js",
            "https://esm.run/crypto-esm" => "node_modules/crypto-esm/dist/crypto-esm.mjs",
            _ => null
        };
    }
}
