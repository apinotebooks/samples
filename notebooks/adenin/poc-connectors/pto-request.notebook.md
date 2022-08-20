```javascript connector
async function handleRequest(request) {
  
  var response = {
    description: "200 hours total, 80 hours remaining, 12 hours planned",
    total_allowance: "200",
    charitable_leave_allowance: "8",
    remaining_allowance: "80",
    planned_allowance: "12",
    remaining_public_holiday_count: "16",
  };

  response.title = "PTO Request";
  response.link = "https://www.adenin.com/pocdef";
  response.linkLabel = "Request PTO";
  response.actionable = false;
  response.thumbnail =
    "https://www.adenin.com/assets/images/wp-images/logo/workday.svg";

  return response;
}
```

# Request PTO

Submit a personal time off (PTO) request.

## Benefits

Get an at-a-glance view of your current personal time off allowance, including planned time. Use the handy shortcut buttons to quickly create a new leave request.

## Utterances

1. I want to request (PTO|time off)
2. I want to submit a (PTO|time off) request

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/workday.svg)

## Features

List

## Configuration

- maxWidth 2
- defaultWidth 2
- defaultHeight 2

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
      "type": "Container",
      "bleed": true,
      "style": "emphasis",
      "items": [
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
              "title": "Submit PTO request",
              "id": "_success_Your_PTO_request_was_submitted"
            }
          ]
        }
      ],
      "id": "request-pto"
    },
    {
      "type": "Container",
      "items": [
        {
          "type": "TextBlock",
          "text": "${string(count(items))}",
          "id": "counter"
        },
        {
          "type": "TextBlock",
          "text": "${description}",
          "id": "heading"
        },
        {
          "type": "TextBlock",
          "text": "${_compact.description}",
          "id": "description"
        },
        {
          "type": "TextBlock",
          "text": "${_compact.imageUrl}",
          "id": "imageUrl"
        },
        {
          "type": "TextBlock",
          "text": "${linkLabel}",
          "id": "buttonLabel"
        },
        {
          "type": "TextBlock",
          "text": "${link}",
          "id": "buttonUrl"
        },
        {
          "type": "TextBlock",
          "text": "${_compact.buttonLabel2}",
          "id": "buttonLabel2"
        },
        {
          "type": "TextBlock",
          "text": "${_compact.buttonUrl2}",
          "id": "buttonUrl2"
        }
      ],
      "id": "expressions",
      "isVisible": false
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
