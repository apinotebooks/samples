---
ConnectorName: local
_ClientId: u7oj6xkjzu4ysa1pxt54jtlykk34978f
_AccessCodeServiceEndpoint: https://localhost:44367/oauth2/authorize
_AccessTokenServiceEndpoint: https://localhost:44367/oauth2/token
---
```javascript worker

async function handleRequest(request, context) {
   debugger;   
  var response = await fetchJSON(`https://localhost:44367/api/session/myprofile`, {     
    headers: {    
      'Authorization': 'Bearer ' + context.token
    }
  }); 
  console.log(context.token);         
  return response;
}

```