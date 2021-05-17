```javascript connector
async function handleRequest(request) {

    let items = [
        {
            title: 'Leave status',
            description: '200 hours total, 80 hours remaining, 12 hours planned',
            total_allowance: '200',
            charitable_leave_allowance: '8',
            remaining_allowance: '80',
            planned_allowance: '12',
            remaining_public_holiday_count: '16'
        }
    ];

    var response = {};
    response.items = items;
    response.title = 'PTO Status';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'Request PTO';
    response.actionable = false;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/workday.svg';

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# PTO allowance

See your current personal time off allowance, including planned time

## Benefits

Get an at-a-glance view of your current personal time off allowance, including planned time. Use the handy shortcut buttons to quickly create a new leave request.

## Utterances

1. Show (me) (my) (PTO|leave|time off) (allowance|status)
2. Show (me) (my) remaining (PTO|leave|time off)
3. How much PTO do I have (left)?

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/workday.svg)

## Features

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
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "${remaining_allowance}",
                  "wrap": true,
                  "horizontalAlignment": "Center",
                  "size": "ExtraLarge",
                  "color": "Accent",
                  "weight": "Bolder"
                },
                {
                  "type": "TextBlock",
                  "text": "Remaining hours",
                  "wrap": true,
                  "horizontalAlignment": "Center",
                  "size": "Small",
                  "spacing": "None"
                }
              ],
              "verticalContentAlignment": "Center",
              "style": "emphasis",
              "bleed": true
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "Along with",
                  "wrap": true,
                  "size": "Small",
                  "isSubtle": true
                },
                {
                  "type": "ColumnSet",
                  "columns": [
                    {
                      "type": "Column",
                      "width": "35px",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "3",
                          "wrap": true,
                          "horizontalAlignment": "Right",
                          "size": "Large"
                        }
                      ],
                      "verticalContentAlignment": "Center"
                    },
                    {
                      "type": "Column",
                      "width": "stretch",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "Public Holidays",
                          "wrap": true
                        }
                      ],
                      "spacing": "Small",
                      "verticalContentAlignment": "Center"
                    }
                  ],
                  "separator": true,
                  "spacing": "Medium"
                },
                {
                  "type": "ColumnSet",
                  "columns": [
                    {
                      "type": "Column",
                      "width": "35px",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "2",
                          "wrap": true,
                          "horizontalAlignment": "Right",
                          "size": "Large"
                        }
                      ],
                      "verticalContentAlignment": "Center"
                    },
                    {
                      "type": "Column",
                      "width": "stretch",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "Days of Charitable Leave",
                          "wrap": true
                        }
                      ],
                      "verticalContentAlignment": "Center",
                      "spacing": "Small"
                    }
                  ],
                  "spacing": "None"
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
          "title": "Request PTO",
          "targetElements": [
            "request-pto"
          ]
        },
        {
          "type": "Action.OpenUrl",
          "title": "PTO help",
          "url": "https://www.adenin.com/pocdef"
        }
      ]
    },
    {
      "type": "Container",
      "bleed": true,
      "style": "emphasis",
      "items": [
        {
          "type": "TextBlock",
          "text": "Start a new PTO request",
          "wrap": true,
          "size": "Large",
          "color": "Accent"
        },
        {
          "type": "TextBlock",
          "text": "From",
          "wrap": true,
          "size": "Small"
        },
        {
          "type": "Input.Date",
          "spacing": "None",
          "id": "from-date"
        },
        {
          "type": "TextBlock",
          "text": "To",
          "wrap": true,
          "size": "Small",
          "spacing": "Small"
        },
        {
          "type": "Input.Date",
          "spacing": "None",
          "id": "to-date"
        },
        {
          "type": "TextBlock",
          "text": "Type of PTO",
          "wrap": true,
          "size": "Small",
          "spacing": "Small"
        },
        {
          "type": "Input.ChoiceSet",
          "choices": [
            {
              "title": "Annual Leave",
              "value": "Choice 1"
            },
            {
              "title": "Parental Leave",
              "value": "Choice 2"
            },
            {
              "title": "Compassionate Leave",
              "value": "Choice 3"
            },
            {
              "title": "Jury Duty",
              "value": "Choice 4"
            },
            {
              "title": "Sick Leave",
              "value": "Choice 5"
            }
          ],
          "placeholder": "Placeholder text",
          "spacing": "Small",
          "style": "expanded",
          "id": "type-of-pto"
        },
        {
          "type": "TextBlock",
          "text": "Comment",
          "wrap": true,
          "spacing": "Small",
          "size": "Small"
        },
        {
          "type": "Input.Text",
          "placeholder": "Optional",
          "spacing": "None",
          "isMultiline": true,
          "id": "comment"
        },
        {
          "type": "ActionSet",
          "actions": [
            {
              "type": "Action.Submit",
              "title": "Submit PTO request"
            }
          ]
        }
      ],
      "id": "request-pto",
      "isVisible": false
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
