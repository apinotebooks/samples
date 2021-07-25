```javascript connector
async function handleRequest(request) {

    var response = {};
    response.ErrorCode = 542;
    response.ErrorText = "Flux capacitor overheated";
  
    return response;
}

```

# Error 500

Shows the current time in UTC

## Utterances

1. start flux capacitor
2. show error 500

## Logo

![logo](https://www.adenin.com/assets/images/identity/icon_digital_assistant.svg)

```json adaptive-card
{
  "type": "AdaptiveCard",
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2",
  "body": [
    {
      "type": "TextBlock",
      "text": "${current_date}",
      "wrap": true
    }
  ]
}
```
