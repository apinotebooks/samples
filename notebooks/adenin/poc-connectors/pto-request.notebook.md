```javascript connector
async function handleRequest(request) {
  var response = {};

  var items = {
    description: "200 hours total, 80 hours remaining, 12 hours planned",
    total_allowance: "200",
    charitable_leave_allowance: "8",
    remaining_allowance: "80",
    planned_allowance: "12",
    remaining_public_holiday_count: "16",
  };

  response.items = items;
  response.title = "PTO allowance";
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

## Audience

All

## Features

Notification
List

## Configuration

- card1x1 compact
- card2x1 compact
- maxWidth 2
- defaultWidth 2
- defaultHeight 2

```json adaptive-card
{
  "type": "AdaptiveCard",
  "body": [
    {
      "type": "Container",
      "$data": "${items}",
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
          "type": "Action.Submit",
          "title": "Request PTO",
          "data": {
            "msteams": {
              "type": "imBack",
              "value": "I want to request PTO"
            }
          }
        },
        {
          "type": "Action.OpenUrl",
          "title": "PTO help",
          "url": "https://www.adenin.com/pocdef",
          "iconUrl": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABmJLR0QA/wD/AP\u002BgvaeTAAACcklEQVRoge2ZP2gTURzHv79LSJqiFt3ERedi50adBbvWAyENSUtdFP8MGap7IEsF6WDBVo7SSiGu1qGDWxvHDt1rEJ1EuEKkwbufQwyU5t67XN57d0XuM4W8d\u002B/3\u002BXLvfnlHgJSUlJQkobAJD6r717PMLxg0A\u002BAqgIxhJw/ADxB99MCNbad4JJssDVCqtO4C/AHARZ2GETgmotlNZ3pXNEEYoFz\u002BcsO3/AMkJ9/H5aw/9X799tegQUt0FVveEpKXB4BL9MdaEg2KA/T2/HlB6CIMgN4De164JhrISi5S7Db8stuZWG42J7vDzLbtw1y\u002B4NaYUI/iIrsDSnQ7JyvDygNAsznZ/TnxazlqHWMB8oWxp7Z9mItyzaeVmZOodWRbSAkm1HPjbr1U2Q8cBuHRllNcVa1j7A5I0CYPxB/AB/HiaflSdW9BZcE4AzAIj7ecW\u002B/6X5SqewtgequyaFwBBrbNKXklhzgCGJOHjgVCMCoPXYsIMC4PnQudIRZ56F7sH8GtUiLf/8W\u002B92QnH7WY7gA\u002BiB8KWqWwVr7g1mz784Ur7uVa1II6jxIDfX6u0ppn5tBt0zt2jAWdQkPRdQcG9vxcpTXP4DWNNQLRsXhi8tBQIFF5qBZh4PnZbhOnPFQLZfzx9f5nU30\u002BDKUuxNR5Vi4fvGb6vcjMr5DA\u002B4ViANSZOiO1P10k8Uamlf86gBebRThCF1mA7wZERoPxTTQkDkC0Y0RmBIggdBEG8MANAMdGjKLhWuw1RIPCANtO8YiIZgG4RrSGwyWi\u002Bxsbd9qiCdIutOlM73LWnwKwCqCNeB5sD0CbgDcZ9m7K/p1JSUlJSZ6/alDy5Hkrg9cAAAAASUVORK5CYII="
        }
      ]
    },
    {
      "type": "TextBlock",
      "text": "This card is empty",
      "wrap": true,
      "$when": "${count(items)==0}"
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
          "text": "${items.description}",
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
