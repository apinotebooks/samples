---
ConnectorName: local
_ClientId: u7oj6xkjzu4ysa1pxt54jtlykk34978f
_AccessCodeServiceEndpoint: https://adenin-blue.azurewebsites.net//oauth2/authorize
_AccessTokenServiceEndpoint: https://adenin-blue.azurewebsites.net//oauth2/token
---
```javascript worker

async function handleRequest(request) {

  var response = await fetchJSON(`https://adenin-blue.azurewebsites.net/api/FeatureLog/FeatureUsage`, { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  }); 
                                       
  return response;
}

```