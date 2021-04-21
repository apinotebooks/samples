---
ConnectorName: local
_ClientId: u7oj6xkjzu4ysa1pxt54jtlykk34978f
_AccessCodeServiceEndpoint: https://app.adenin.com/oauth2/authorize
_AccessTokenServiceEndpoint: https://app.adenin.com/oauth2/token
---
```javascript worker

async function handleRequest(request) {

  var response = await fetchJSON(`https://app.adenin.com/api/session/myprofile`, { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  }); 
                                       
  return response;
}

```