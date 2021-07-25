```javascript connector
async function handleRequest(request) {

    var response = {};
    response.date = new Date().toUTCString();   
    response.current_date = new Date().toUTCString();
    response.title = 'UTC Time';
    response.thumbnail = 'https://www.adenin.com/assets/images/identity/Icon_Digital_Assistant.svg';  
  
    return response;
}

```

# UTC Time

Shows the current time in UTC

## Utterances

1. What's the time
2. Current time
3. UTC time

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
