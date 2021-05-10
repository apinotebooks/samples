---
ConnectorName: adenin
_ClientId: u7oj6xkjzu4ysa1pxt54jtlykk34978f
_AccessCodeServiceEndpoint: https://adenin.azurewebsites.net/oauth2/authorize
_AccessTokenServiceEndpoint: https://adenin.azurewebsites.net/oauth2/token
---
```javascript worker

async function handleRequest(request) {

  var response = await fetchJSON(`https://adenin.azurewebsites.net/api/gateway/card/eeb4c18b-e3ee-4fa7-82a1-2c34f63eea37
`, { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  }); 
  
  console.log(response.Data._hash);

  var ids="";

  for(var i=0;i<response.Data.items.length;i++) {
    ids = ids + ";" + response.Data.items[i].id;
  }

console.log(ids);
  
  return response;
}

```