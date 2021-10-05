```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054889',
        title: 'PTO Request',
        description: '3 days, 10/14 - 10/16',
        requested_by: 'Mohamed Alami',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5e68015d6d3b380006d3b6eb-l.jpg',
        integration: 'SharePoint',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg',
        now: "5 minutes ago",
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054891',
        title: 'Equipment Request',
        description: 'Work from Home - Company PC',
        requested_by: 'Thomas Müller',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801926d3b380006d3c33b-l.jpg',
        integration: 'SAP Concur',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sap-concur.svg',
        now: "2 hours ago",
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054878',
        title: 'Sick leave notice',
        description: 'Scheduled Doctors appointment on 09/06',
        requested_by: 'Fatima Khan',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5f896f545bec830008382c00-l.jpg',
        integration: 'Workday',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/workday.svg',
         now: "2 hours ago",
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054880',
        title: 'Expense Reimbursement',
        description: 'Developer\'s conference travel costs - $230',
        requested_by: 'Ellen Kim',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5f8971ee5bec830008391f96-l.jpg',
        integration: 'SAP Fieldglass',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sap-fieldglass.svg',
         now: "yesterday",
        link: 'https://www.adenin.com/pocdef'
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Approvals';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'Open Approvals app';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/identity/logo_adenin_round.png';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' pending approvals.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + ' from ' + response.items[0].requested_by + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}
```

# Approvals

See and manage pending approvals from your employees

## Utterances

1. What are my (latest|new|pending) approvals?
2. Show (me) my (latest|new|pending) approvals
3. Do I have (any) (new|unread|pending) approvals?

## Logo

![logo](https://www.adenin.com/assets/images/identity/icon_digital_assistant.svg)

## Audience

All

## Features

Notification
List

```json adaptive-card
{
  "type": "AdaptiveCard",
  "body": [
    {
      "type": "Container",
      "bleed": true,
      "items": [
        {
          "type": "ColumnSet",
          "columns": [
            {
              "type": "Column",
              "width": "50px",
              "items": [
                {
                  "type": "Image",
                  "url": "${avatar}",
                  "width": "50px",
                  "style": "Person",
                  "altText": "${requested_by} photo"
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "ColumnSet",
                  "columns": [
                    {
                      "type": "Column",
                      "width": "stretch",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "${requested_by}",
                          "wrap": true,
                          "fontType": "Default",
                          "size": "Medium"
                        }
                      ]
                    },
                    {
                      "type": "Column",
                      "width": "auto",
                      "spacing": "Small",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "${now}",
                          "wrap": true,
                          "isSubtle": true
                        }
                      ]
                    }
                  ]
                },
                {
                  "type": "Container",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "${title}",
                      "wrap": true,
                      "size": "Large",
                      "fontType": "Default",
                      "spacing": "None"
                    },
                    {
                      "type": "TextBlock",
                      "wrap": true,
                      "spacing": "None",
                      "size": "Medium",
                      "text": "${description}"
                    },
                    {
                      "type": "ColumnSet",
                      "columns": [
                        {
                          "type": "Column",
                          "width": "auto",
                          "items": [
                            {
                              "type": "Image",
                              "url": "${thumbnail}",
                              "width": "20px"
                            }
                          ]
                        },
                        {
                          "type": "Column",
                          "width": "stretch",
                          "items": [
                            {
                              "type": "TextBlock",
                              "text": "Submitted via ${integration}",
                              "wrap": true
                            }
                          ],
                          "spacing": "Small"
                        }
                      ],
                      "spacing": "Small"
                    }
                  ],
                  "style": "emphasis",
                  "bleed": true
                }
              ],
              "verticalContentAlignment": "Center"
            }
          ],
          "spacing": "Large",
          "selectAction": {
            "type": "Action.OpenUrl",
            "url": "https://www.adenin.com/pocdef"
          }
        }
      ]
    },
    {
      "type": "ColumnSet",
      "columns": [
        {
          "type": "Column",
          "width": "50px"
        },
        {
          "type": "Column",
          "width": "stretch",
          "items": [
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.Submit",
                  "title": "Quick Approve",
                  "style": "positive",
                  "id": "_success1_You_have_approved_this_request"
                },
                {
                  "type": "Action.ToggleVisibility",
                  "title": "Decline",
                  "targetElements": [
                    {
                      "elementId": "denial-comment",
                      "isVisible": true
                    },
                    {
                      "elementId": "details-box",
                      "isVisible": false
                    }
                  ]
                },
                {
                  "type": "Action.ToggleVisibility",
                  "iconUrl": "https://img.icons8.com/material/48/000000/menu-2--v1.png",
                  "targetElements": [
                    {
                      "elementId": "denial-comment",
                      "isVisible": false
                    },
                    {
                      "elementId": "details-box",
                      "isVisible": true
                    }
                  ]
                }
              ]
            }
          ],
          "backgroundImage": {
            "horizontalAlignment": "Right"
          }
        }
      ]
    },
    {
      "type": "Container",
      "items": [
        {
          "type": "ColumnSet",
          "columns": [
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "Input.Text",
                  "placeholder": "Please enter a reason for the denial...",
                  "isMultiline": true,
                  "id": "denial-reason"
                }
              ]
            },
            {
              "type": "Column",
              "width": "auto",
              "items": [
                {
                  "type": "ActionSet",
                  "actions": [
                    {
                      "type": "Action.Submit",
                      "title": "Submit",
                      "id": "_error_Your_denial_was_submitted"
                    }
                  ]
                }
              ]
            }
          ]
        }
      ],
      "isVisible": false,
      "bleed": true,
      "style": "emphasis",
      "id": "denial-comment"
    },
    {
      "type": "Container",
      "items": [
        {
          "type": "ColumnSet",
          "columns": [
            {
              "type": "Column",
              "width": "50px"
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "ActionSet",
                  "actions": [
                    {
                      "type": "Action.OpenUrl",
                      "title": "Message ${take(split(requested_by, \u0027 \u0027), 1)}",
                      "url": "${link}"
                    },
                    {
                      "type": "Action.OpenUrl",
                      "title": "View details",
                      "url": "${link}"
                    }
                  ]
                }
              ]
            }
          ]
        }
      ],
      "isVisible": false,
      "id": "details-box"
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
