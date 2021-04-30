```javascript worker {"run_on_load":true}
async function handleRequest(request) {
    const moment = await sandboxImport('https://esm.run/moment');
    const CryptoESM = await sandboxImport('https://esm.run/crypto-esm');

    const time = moment.default("20111031", "YYYYMMDD").fromNow();
    const hash = CryptoESM.default.MD5(time).toString();

    return { time, hash };
}
```
