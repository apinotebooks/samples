```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '32116',
        title: 'Sunil Hussain',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5f896a9b5bec830008365b3f-l.jpg',
        description: 'Qatar Charter Air ',
        ago: "12 minutes ago",
        created_date: '2021-05-13T08:44:30.524Z',
        contact_info: {
          email: 's.hussain@qcair.com',
          phone_number: '917-464-0537',
          job_title: 'Customer Service Lead',
        },
        status: 'Open',
        page_first_seen: 'https://www.adenin.com/digital-assistant/',
        last_activity: 'Submitted contact form',
        last_activity_time: '2021-05-13T08:44:30.524Z',
      },
      {
        id: '32101',
        title: 'Dimitrios Vasileiou',
        link: 'https://www.adenin.com/pocdef',
        description: 'Cogent Data',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg',
        ago: "1 day ago",
        created_date: '2021-05-11T15:01:23.000Z',
        contact_info: {
          email: 'vasileiou.d.a@cogentdata.ai',
          phone_number: '404-932-7746',
          job_title: 'Digital Transformation Lead',
        },
        status: 'Interested',
        page_first_seen: 'https://www.adenin.com/',
        last_activity: 'Requested demo',
        last_activity_time: '2021-05-12T15:16:41.000Z',
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Salesforce Leads';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All Leads';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/salesforce.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' Salesforce leads.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```
# Salesforce Leads

See your currently open leads
## Benefits

With the Leads Card you have lists of your new and open contacts directly at your fingertips. All the contacts data is directly taken from your CRM application and you can enable to be notified whenever new contacts are received.
## Utterances
1. Show (me) (my) open leads (from|in) Salesforce
2. Show (me) (my) open Salesforce leads

## Audience
All

## Features
Notification
List
```json adaptive-card
{
  "type": "AdaptiveCard",
  "padding": "none",
  "body": [
    {
      "type": "Container",
      "padding": {
        "top": "none",
        "left": "default",
        "bottom": "default",
        "right": "default"
      },
      "items": [
        {
          "type": "Container",
          "items": [
            {
              "type": "ColumnSet",
              "spacing": "Large",
              "separator": true,
              "columns": [
                {
                  "type": "Column",
                  "verticalContentAlignment": "Center",
                  "items": [
                    {
                      "type": "Image",
                      "horizontalAlignment": "Center",
                      "style": "Person",
                      "width": "32px",
                      "altText": "Photo of ${title}",
                      "url": "${thumbnail}"
                    }
                  ],
                  "width": "32px"
                },
                {
                  "type": "Column",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "**${title}** \n${toLower(last_activity)} ${ago}",
                      "wrap": true
                    },
                    {
                      "type": "ColumnSet",
                      "columns": [
                        {
                          "type": "Column",
                          "width": "auto",
                          "items": [
                            {
                              "type": "TextBlock",
                              "text": "${contact_info.job_title}",
                              "wrap": true,
                              "weight": "Bolder",
                              "isSubtle": true
                            }
                          ]
                        },
                        {
                          "type": "Column",
                          "width": "stretch",
                          "items": [
                            {
                              "type": "TextBlock",
                              "text": "${description}",
                              "wrap": true,
                              "isSubtle": true
                            }
                          ],
                          "spacing": "Large"
                        }
                      ],
                      "spacing": "None"
                    }
                  ],
                  "width": "stretch"
                }
              ]
            },
            {
              "type": "ColumnSet",
              "columns": [
                {
                  "type": "Column",
                  "width": "100px",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "**Current status:**",
                      "wrap": true
                    }
                  ]
                },
                {
                  "type": "Column",
                  "width": "stretch",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "${toUpper(status)}",
                      "wrap": true,
                      "weight": "Bolder",
                      "color": "${if(status == \u0027Open\u0027, \u0027attention\u0027, \u0027good\u0027)}"
                    }
                  ]
                }
              ]
            },
            {
              "type": "FactSet",
              "facts": [
                {
                  "title": "Email",
                  "value": "${contact_info.email}"
                },
                {
                  "title": "Phone",
                  "value": "${contact_info.phone_number}"
                },
                {
                  "title": "First page seen",
                  "value": "${page_first_seen}"
                }
              ]
            }
          ]
        }
      ]
    },
    {
      "type": "ActionSet",
      "actions": [
        {
          "type": "Action.ToggleVisibility",
          "title": "Comment",
          "targetElements": [
            {
              "elementId": "toggle-comment",
              "isVisible": true
            },
            {
              "elementId": "toggle-message",
              "isVisible": false
            },
            {
              "elementId": "toggle-mark_as",
              "isVisible": false
            }
          ]
        },
        {
          "type": "Action.ToggleVisibility",
          "title": "Send message",
          "targetElements": [
            {
              "elementId": "toggle-comment",
              "isVisible": false
            },
            {
              "elementId": "toggle-message",
              "isVisible": true
            },
            {
              "elementId": "toggle-mark_as",
              "isVisible": false
            }
          ]
        },
        {
          "type": "Action.ToggleVisibility",
          "title": "Mark as",
          "targetElements": [
            {
              "elementId": "toggle-comment",
              "isVisible": false
            },
            {
              "elementId": "toggle-message",
              "isVisible": false
            },
            {
              "elementId": "toggle-mark_as",
              "isVisible": true
            }
          ]
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
                  "placeholder": "Write a comment...",
                  "isMultiline": true,
                  "id": "write-commnt"
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
                      "title": "Comment"
                    }
                  ]
                }
              ]
            }
          ]
        }
      ],
      "style": "emphasis",
      "bleed": true,
      "id": "toggle-comment",
      "isVisible": false
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
                  "placeholder": "Send message to ${title}...",
                  "isMultiline": true,
                  "id": "send-message-to-lead"
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
                      "title": "Send",
                      "style": "positive"
                    }
                  ]
                }
              ]
            }
          ]
        }
      ],
      "style": "emphasis",
      "bleed": true,
      "id": "toggle-message",
      "isVisible": false
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
                  "type": "Input.ChoiceSet",
                  "choices": [
                    {
                      "title": "Open",
                      "value": "Open"
                    },
                    {
                      "title": "Interested",
                      "value": "Interested"
                    },
                    {
                      "title": "Contacted",
                      "value": "Contacted"
                    },
                    {
                      "title": "Evaluating",
                      "value": "Evaluating"
                    },
                    {
                      "title": "Converted",
                      "value": "Converted"
                    },
                    {
                      "title": "Closed",
                      "value": "Closed"
                    }
                  ],
                  "placeholder": "Mark ${title} as...",
                  "id": "mark-lead-as"
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
                      "title": "Submit"
                    }
                  ]
                }
              ]
            }
          ]
        }
      ],
      "style": "emphasis",
      "bleed": true,
      "id": "toggle-mark_as",
      "isVisible": false
    }
  ],
  "version": "1.2",
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json"
}
```
