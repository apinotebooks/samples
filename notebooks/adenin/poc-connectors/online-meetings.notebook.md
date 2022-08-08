```javascript connector
async function handleRequest(request) {
  let items = [
    {
      id: 1,
      title: "Board Meeting",
      description: "Performance review for Q3",
      link: "https://www.adenin.com/pocdef",
      ago: "in 30 minutes",
      duration: "1 hour",
      location: "Microsoft Teams",
      onlineMeetingUrl: "https://www.adenin.com/pocdef",
      organizer: {
        name: "Jennifer Miller",
        avatar:
          "https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg",
      },
      attendees: [
        {
          name: "Jennifer Miller",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg",
        },
        {
          name: "Yousef Ali",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5f896d365bec830008375f28-l.jpg",
        },
        {
          name: "Gabrielle Williams",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5f8975995bec8300083a6f03-l.jpg",
        },
      ],
    },
    {
      id: 2,
      title: "UI/UX Rebrand Briefing",
      description:
        "Setting some time aside to discuss the upcoming app rebrand",
      link: "https://www.adenin.com/pocdef",
      ago: "in 2 hours",
      duration: "30 minutes",
      onlineMeetingUrl: "https://www.adenin.com/pocdef",
      location: "Cisco Webex",
      organizer: {
        name: "Inger Olsen",
        avatar:
          "https://www.adenin.com/assets/images/generated_photos/5e6869016d3b380006ead99f-l.jpg",
      },
      attendees: [
        {
          name: "Inger Olsen",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5e6869016d3b380006ead99f-l.jpg",
        },
        {
          name: "Terry Nguyen",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5e6887c36d3b380006f1da63-l.jpg",
        },
        {
          name: "Antonio Rossi",
          avatar:
            "https://www.adenin.com/assets/images/generated_photos/5e6801c46d3b380006d3cedb-l.jpg",
        },
      ],
    },
  ];

  var value = items.length;
  var response = {};
  response.items = items;
  response.title = "Online Meetings";
  response.link = "https://www.adenin.com/pocdef";
  response.linkLabel = "View Calendar";
  response.actionable = value > 0;
  response.thumbnail =
    "https://www.adenin.com/assets/images/wp-images/logo/office-365.svg";

  if (value > 0) {
    response.value = value;
    response.date = items[0].date;
    response.description =
      items.length > 1
        ? "You have " + items.length + " events today."
        : "You have 1 event today.";
    response.briefing =
      response.description +
      " The next is <b>" +
      response.items[0].title +
      "</b>.";
  }

  response._card = {
    type: "events-today",
  };

  return response;
}
```

# Online Meetings

See upcoming events for the day in one Card and join online meeting with just one click

## Benefits

See a timeline of your upcoming meetings for the day, including useful details such as attendees or duration. Online meetings can be directly started with the _Join meeting_ button which adds convenience over having to manually look for it in the event description.

## Utterances

1. What (events|meetings|invites) are (coming up|next) (today) in my Outlook calendar?
2. When will my next Outlook (meeting|invite|appointment) (start|begin)?
3. When is my next Outlook (meeting|invite|appointment)?
4. What's next on (my|the) Outlook (schedule|agenda|calendar)?
5. Show me my (next|upcoming) Outlook (meetings|events|appointments)
6. Start my next Outlook (call|meeting|invite)

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/office-365.svg)

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
  "version": "1.2",
  "body": [
    {
      "type": "ColumnSet",
      "$data": "${items}",
      "columns": [
        {
          "type": "Column",
          "width": "75px",
          "items": [
            {
              "type": "TextBlock",
              "text": "${ago}",
              "wrap": true,
              "horizontalAlignment": "Right",
              "weight": "Bolder",
              "isSubtle": true,
              "color": "Good"
            }
          ]
        },
        {
          "type": "Column",
          "width": "49px",
          "backgroundImage": {
            "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAAYCAIAAAC0rgCNAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTZEaa/1AAAAEElEQVQYV2NoaGigHW5oAADAuiQBWxz13QAAAABJRU5ErkJggg==",
            "fillMode": "RepeatVertically",
            "horizontalAlignment": "Center",
            "verticalAlignment": "Center"
          },
          "items": [
            {
              "type": "Image",
              "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYBAMAAAASWSDLAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwQAADsEBuJFr7QAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4xNkRpr/UAAAAbUExURf///4CAgICAgICAgICAgICAgICAgICAgICAgK5UnXcAAAAIdFJOUwBMVIePw/f799S5VQAAAD9JREFUGNNjYKAtYAxLFYBzLDo6muESHUAAk2IFcQKgHDYQJwHKYQdxCrApYwJxFGDGeXR0tMDtYQovVaCxvwAJCxPcs9XnIAAAAABJRU5ErkJggg==",
              "width": "35px",
              "spacing": "None"
            }
          ],
          "spacing": "None",
          "bleed": true
        },
        {
          "type": "Column",
          "width": "stretch",
          "items": [
            {
              "type": "TextBlock",
              "wrap": true,
              "weight": "Bolder",
              "isSubtle": true,
              "text": "${title}",
              "size": "Large"
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
                      "text": "${duration}",
                      "wrap": true,
                      "isSubtle": true,
                      "spacing": "None"
                    }
                  ]
                },
                {
                  "type": "Column",
                  "width": "stretch",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "${location}",
                      "wrap": true,
                      "isSubtle": true,
                      "horizontalAlignment": "Right"
                    }
                  ]
                }
              ],
              "spacing": "None"
            },
            {
              "type": "ColumnSet",
              "columns": [
                {
                  "type": "Column",
                  "$data": "${attendees}",
                  "width": "auto",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${avatar}",
                      "width": "35px",
                      "height": "35px",
                      "style": "Person",
                      "altText": "${name}",
                      "spacing": "None"
                    }
                  ],
                  "spacing": "Small"
                }
              ]
            },
            {
              "type": "TextBlock",
              "text": "${description}",
              "wrap": true
            },
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.OpenUrl",
                  "title": "Join meeting",
                  "style": "positive",
                  "url": "${link}"
                },
                {
                  "type": "Action.ToggleVisibility",
                  "title": "Change RSVP",
                  "targetElements": [
                    "items_${$index} change_rsvp"
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
                  "type": "Input.ChoiceSet",
                  "choices": [
                    {
                      "title": "Maybe",
                      "value": "Maybe"
                    },
                    {
                      "title": "Decline",
                      "value": "Decline"
                    }
                  ],
                  "placeholder": "Change my RSVP to...",
                  "id": "items_${$index} rsvp_status"
                },
                {
                  "type": "ActionSet",
                  "actions": [
                    {
                      "type": "Action.Submit",
                      "title": "Submit",
                      "id": "items_${$index} _success_Your_attendance_has_been_updated"
                    }
                  ]
                }
              ],
              "id": "items_${$index} change_rsvp",
              "isVisible": false
            }
          ],
          "verticalContentAlignment": "Center",
          "spacing": "None",
          "bleed": true
        }
      ],
      "bleed": true
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
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json"
}
```
