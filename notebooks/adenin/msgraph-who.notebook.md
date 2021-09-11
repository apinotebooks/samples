---
_Scopes: User.Read
_ClientId: b75fd212-b8ef-44ce-8e3c-585419557ea7
ConnectorName: o365
_AccessCodeServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/authorize
_AccessTokenServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/token
_ProdToken: o365
---
```javascript connector
async function handleRequest(request, context) {

    var response = await fetchJSON("https://graph.microsoft.com/v1.0/me", { 
      'credentials': 'omit',
      headers: {    
        'Authorization': 'Bearer ' + context.token
      }
    });
  
    return response;
}

```

# O365 Who Am I

Shows the name of the current MS Graph user

## Benefits

Who am I ?

## Utterances

1. Who am I?

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
