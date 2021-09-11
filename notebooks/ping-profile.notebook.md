---
ConnectorName: ping
_ClientId: ecd240b8-233f-464f-9fb1-111b833e931d
_AccessCodeServiceEndpoint: https://auth.pingone.eu/39d996c9-1075-4e29-a9f3-accd91878ff8/as/authorize
_AccessTokenServiceEndpoint: https://auth.pingone.eu/39d996c9-1075-4e29-a9f3-accd91878ff8/as/token
---
```javascript worker

async function handleRequest(request) {

  var response = await fetchJSON(`https://auth.pingone.eu/39d996c9-1075-4e29-a9f3-accd91878ff8/as/userinfo`, { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  }); 

console.log("request",request);
  
  return response;
}

```