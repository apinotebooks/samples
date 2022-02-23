```javascript connector
async function handleRequest(request) {

    var response = {            
            description: '200 hours total, 80 hours remaining, 12 hours planned',
            total_allowance: '200',
            charitable_leave_allowance: '8',
            remaining_allowance: '80',
            planned_allowance: '12',
            remaining_public_holiday_count: '16'
    }    

    response.title = 'PTO allowance';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'Request PTO';
    response.actionable = false;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/workday.svg';
  
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
          "iconUrl": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABmJLR0QA/wD/AP+gvaeTAAACcklEQVRoge2ZP2gTURzHv79LSJqiFt3ERedi50adBbvWAyENSUtdFP8MGap7IEsF6WDBVo7SSiGu1qGDWxvHDt1rEJ1EuEKkwbufQwyU5t67XN57d0XuM4W8d+/3+XLvfnlHgJSUlJQkobAJD6r717PMLxg0A+AqgIxhJw/ADxB99MCNbad4JJssDVCqtO4C/AHARZ2GETgmotlNZ3pXNEEYoFz+csO3/AMkJ9/H5aw/9X799tegQUt0FVveEpKXB4BL9MdaEg2KA/T2/HlB6CIMgN4De164JhrISi5S7Db8stuZWG42J7vDzLbtw1y+4NaYUI/iIrsDSnQ7JyvDygNAsznZ/TnxazlqHWMB8oWxp7Z9mItyzaeVmZOodWRbSAkm1HPjbr1U2Q8cBuHRllNcVa1j7A5I0CYPxB/AB/HiaflSdW9BZcE4AzAIj7ecW+/6X5SqewtgequyaFwBBrbNKXklhzgCGJOHjgVCMCoPXYsIMC4PnQudIRZ56F7sH8GtUiLf/8W+92QnH7WY7gA+iB8KWqWwVr7g1mz784Ur7uVa1II6jxIDfX6u0ppn5tBt0zt2jAWdQkPRdQcG9vxcpTXP4DWNNQLRsXhi8tBQIFF5qBZh4PnZbhOnPFQLZfzx9f5nU30+DKUuxNR5Vi4fvGb6vcjMr5DA+4ViANSZOiO1P10k8Uamlf86gBebRThCF1mA7wZERoPxTTQkDkC0Y0RmBIggdBEG8MANAMdGjKLhWuw1RIPCANtO8YiIZgG4RrSGwyWi+xsbd9qiCdIutOlM73LWnwKwCqCNeB5sD0CbgDcZ9m7K/p1JSUlJSZ6/alDy5Hkrg9cAAAAASUVORK5CYII="
        }
      ]
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
