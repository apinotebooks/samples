```json adaptive-form {"run_on_load":true}
{
    "type": "AdaptiveCard",
    "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
    "version": "1.2",
    "body": [
        {
            "type": "Input.Text",
            "label": "Number of items to skip / nextPageToken",
            "value": "0",
            "id": "$nextPageToken"
        }
    ],
    "actions": [
        {
            "type": "Action.Submit",
            "title": "Submit",
            "associatedInputs": "auto"
        }
    ]
}
```
```javascript worker
async function handleRequest(request) {
  var response = await fetchJSON(`https://adenin.azurewebsites.net/api/gateway/collection-hubspot/leads-new`); 
  return response;
}
```
# New Leads

Get a list of *new* leads assigned to you.

## Benefits

Easily monitor new Hubspot contacts by placing this Card on your Board or asking your Assistant to bring it up for you. This way you can stay up-to-date in realtime and without having to constantly check your inbox for updates.

## Utterances

1. Show me (my) new Hubspot (leads|contacts)
2. (What|Which) Hubspot (leads|contacts) are new?
3. What are the new Hubspot (leads|contacts)?
4. (What|Which) (leads|contacts) are new in Hubspot?

## Audience

All

## Features

Notifications

## Screenshots

1. ![List of new contacts in Hubspot CRM](https://www.adenin.com/assets/images/wp-images/2020/07/Hubspot-New-Leads-l.png)

## Required Scopes

+ contacts
