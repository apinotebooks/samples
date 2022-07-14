---
url: https://graph.microsoft.com/v1.0/me
_Scopes: User.Read
_ClientId: b75fd212-b8ef-44ce-8e3c-585419557ea7
_ProdToken: o365
ConnectorName: o365
_AccessCodeServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/authorize
_AccessTokenServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/token

---
```javascript connector
async function handleRequest(request, context) {

   var response = await fetchJSON(context.config.url, {       
     headers: {    
       'Authorization': 'Bearer ' + context.token
     }
   });

   if (response.error) {
     if(response.error.code=="InvalidAuthenticationToken") {
       return { ErrorCode: 461 } 
     } else {
       return { ErrorCode: 500, ErrorText: response.error}
     }
   }
  
   return response;
}

```

# O365 Who Am I

Shows the name of the current MS Graph user

## Benefits

Who am I ?

## Utterances

1. Who am I?

## Configuration


```json adaptive-card
{
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "type": "AdaptiveCard",
  "version": "1.2",
  "body": [
    {
      "type": "TextBlock",
      "text": "Hello ${givenName}",
      "wrap": true
    }
  ]
}
```
