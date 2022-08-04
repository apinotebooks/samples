```javascript connector
async function handleRequest(request) {
  let items = [
    {
      id: "1054875",
      title: "Locked out of my account, no access to email.",
      description:
        "I am unable to access my account. When I enter my password I get an error message saying my account has been locked and to contact support.",
      priority: "High",
      category: "User Accounts",
      status: "Open",
      created_date: "2021-05-13T08:44:30.524Z",
      ago: "2 hours ago",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/generated_photos/5f8971ee5bec830008391f96-l.jpg",
      contact: {
        name: "Ellen Kim",
        company: "Designplus.io",
      },
    },
    {
      id: "1054889",
      title: "Guest WiFi access",
      description:
        "The credentials for the guest WiFi network listed on the Intranet don't work.",
      status: "Open",
      category: "Services",
      priority: "Normal",
      created_date: "2021-05-11T09:013:23.000Z",
      ago: "2 days ago",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg",
      contact: {
        name: "Thomas Müller",
        company: "Coffee Craft",
      },
    },
    {
      id: "1054893",
      title: "Software version upgrade",
      description:
        "I would like to upgrade our software to the latest version to take advantage of the new features. Can you assist with that please?",
      status: "Open",
      priority: "Low",
      category: "Technical Support",
      created_date: "2021-05-10T09:013:23.000Z",
      ago: "3 days ago",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg",
      contact: {
        name: "Isaac Cohen",
        company: "Purple Security",
      },
    },
  ];

  var value = items.length;
  var response = {};
  response.items = items;
  response.title = "Zendesk Tickets";
  response.link = "https://www.adenin.com/pocdef";
  response.linkLabel = "All tickets";
  response.actionable = value > 0;
  response.thumbnail =
    "https://www.adenin.com/assets/images/wp-images/logo/zendesk.svg";

  if (value > 0) {
    response.value = value;
    response.date = items[0].date; // items are alrady sorted ascending
    response.description = "You have " + value + " open Zendesk tickets.";
    response.briefing =
      response.description +
      " The latest is <b>" +
      response.items[0].title +
      "</b>.";
  }

  response._card = {
    type: "status-list",
  };

  return response;
}
```

# Zendesk tickets

See your open tickets

## Benefits

Pin the Open Tickets Card to your Board to keep track of your latest open tickets, or get live notifications whenever new tickets arrive. Digital Assistant makes it easy to stay on top of your tickets in one place, making it useful for both support agents and supervising managers.

## Utterances

1. Show (me) (my) open Zendesk (cases|tickets|issues)
2. Do I have any (open|due|assigned) Zendesk (cases|tickets|issues)?
3. Show me (my) (open|due|assigned) Zendesk (cases|tickets|issues)

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/zendesk.svg)

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
              "width": "auto",
              "items": [
                {
                  "type": "Image",
                  "url": "data:image/svg\u002Bxml,%3Csvg xmlns=\u0027http://www.w3.org/2000/svg\u0027 viewBox=\u00270 0 16 16\u0027%3E%3Cpath fill=\u0027%23fff\u0027 d=\u0027M5.8,15.5c-0.1,0-0.2,0-0.2-0.1l-5-5c-0.1-0.1-0.1-0.3,0-0.4l5.5-5.5c0.1-0.1,0.2-0.1,0.2-0.1 l0.5,0l0-0.5c0-0.1,0-0.1,0.1-0.2l3.1-3.1c0.1-0.1,0.1-0.1,0.2-0.1s0.2,0,0.2,0.1l5,5c0.1,0.1,0.1,0.3,0,0.4l-3.1,3.1 c-0.1,0.1-0.1,0.1-0.2,0.1l-0.5,0l0,0.5c0,0.1,0,0.2-0.1,0.2l-5.5,5.5C6,15.5,5.9,15.5,5.8,15.5z\u0027/%3E%3Cpath fill=\u0027%23788b9c\u0027 d=\u0027M10.2,1.1l4.8,4.8L12,8.7l-0.8,0l0,0.8l-5.3,5.3l-4.8-4.8l5.3-5.3l0.8,0l0-0.8L10.2,1.1 M10.2,0 C10,0,9.7,0.1,9.6,0.2L6.5,3.3C6.4,3.5,6.3,3.7,6.3,3.9c-0.2,0-0.4,0.1-0.5,0.2L0.2,9.6c-0.3,0.3-0.3,0.8,0,1.2l5,5 C5.4,15.9,5.6,16,5.8,16s0.4-0.1,0.6-0.2l5.5-5.5c0.1-0.1,0.2-0.3,0.2-0.5c0.2,0,0.4-0.1,0.5-0.2l3.1-3.1c0.3-0.3,0.3-0.8,0-1.2 l-5-5C10.6,0.1,10.4,0,10.2,0L10.2,0z\u0027/%3E%3Cpath fill=\u0027%23788b9c\u0027 d=\u0027M6.5 4.3H7.5V5.699999999999999H6.5z\u0027 transform=\u0027rotate(-45.001 7 5)\u0027/%3E%3Cpath fill=\u0027%23788b9c\u0027 d=\u0027M8.5 6.3H9.5V7.699999999999999H8.5z\u0027 transform=\u0027rotate(-45.001 9 7)\u0027/%3E%3Cpath fill=\u0027%23788b9c\u0027 d=\u0027M10.5 8.3H11.5V9.700000000000001H10.5z\u0027 transform=\u0027rotate(-45.001 11 9)\u0027/%3E%3Cpath fill=\u0027%23788b9c\u0027 d=\u0027M3.5 11c-.1 0-.3 0-.4-.1-.2-.2-.2-.5 0-.7l3-3C6.3 7 6.7 7 6.9 7.1s.2.5 0 .7l-3 3C3.8 11 3.6 11 3.5 11zM9.5 5C9.4 5 9.2 5 9.1 4.9 9 4.7 9 4.3 9.1 4.1l1-1c.2-.2.5-.2.7 0s.2.5 0 .7l-1 1C9.8 5 9.6 5 9.5 5zM11.5 7c-.1 0-.3 0-.4-.1-.2-.2-.2-.5 0-.7l1-1c.2-.2.5-.2.7 0s.2.5 0 .7l-1 1C11.8 7 11.6 7 11.5 7zM5.5 13c-.1 0-.3 0-.4-.1-.2-.2-.2-.5 0-.7l2-2c.2-.2.5-.2.7 0s.2.5 0 .7l-2 2C5.8 13 5.6 13 5.5 13z\u0027/%3E%3C/svg%3E",
                  "width": "16px"
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "Ticket #${id}",
                  "wrap": true,
                  "size": "Small"
                }
              ],
              "spacing": "Small",
              "backgroundImage": {
                "verticalAlignment": "Center"
              },
              "verticalContentAlignment": "Center"
            },
            {
              "type": "Column",
              "width": "auto",
              "items": [
                {
                  "type": "Image",
                  "url": "data:image/svg\u002Bxml,%3Csvg xmlns=\u0027http://www.w3.org/2000/svg\u0027 viewBox=\u00270 0 16 16\u0027%3E%3Cpath fill=\u0027%238bb7f0\u0027 d=\u0027M7.5 0.5A7 7 0 1 0 7.5 14.5A7 7 0 1 0 7.5 0.5Z\u0027/%3E%3Cpath fill=\u0027%234e7ab5\u0027 d=\u0027M7.5,1C11.084,1,14,3.916,14,7.5S11.084,14,7.5,14S1,11.084,1,7.5S3.916,1,7.5,1 M7.5,0 C3.358,0,0,3.358,0,7.5S3.358,15,7.5,15S15,11.642,15,7.5S11.642,0,7.5,0L7.5,0z\u0027/%3E%3Cpath fill=\u0027%23fff\u0027 d=\u0027M7.5 3.83A.67.67 0 1 0 7.5 5.17.67.67 0 1 0 7.5 3.83zM8 10L8 6 6.329 6 6.329 7 7 7 7 10 6 10 6 11 9 11 9 10z\u0027/%3E%3C/svg%3E",
                  "width": "16px"
                }
              ]
            },
            {
              "type": "Column",
              "width": "auto",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "${priority} priority",
                  "wrap": true,
                  "size": "Small"
                }
              ],
              "spacing": "Small"
            }
          ]
        },
        {
          "type": "ColumnSet",
          "columns": [
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "${title}",
                  "wrap": true,
                  "size": "Large",
                  "spacing": "Small"
                }
              ],
              "spacing": "Small",
              "backgroundImage": {
                "verticalAlignment": "Center"
              },
              "verticalContentAlignment": "Center"
            }
          ]
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
                  "style": "Person",
                  "width": "35px"
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "Opened ${ago}",
                  "wrap": true,
                  "spacing": "None"
                },
                {
                  "type": "TextBlock",
                  "text": "**${contact.name}**  from ${contact.company}",
                  "wrap": true,
                  "spacing": "None"
                }
              ]
            }
          ]
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
                  "text": "${description}",
                  "wrap": true,
                  "separator": true,
                  "spacing": "Large"
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
              "title": "Reply to ${contact.name}",
              "targetElements": [
                {
                  "elementId": "reply-box",
                  "isVisible": true
                },
                {
                  "elementId": "comment-box",
                  "isVisible": false
                },
                {
                  "elementId": "resolution-box",
                  "isVisible": false
                }
              ]
            },
            {
              "type": "Action.ToggleVisibility",
              "title": "Comment",
              "targetElements": [
                {
                  "elementId": "reply-box",
                  "isVisible": false
                },
                {
                  "elementId": "comment-box",
                  "isVisible": true
                },
                {
                  "elementId": "resolution-box",
                  "isVisible": false
                }
              ]
            },
            {
              "type": "Action.ToggleVisibility",
              "title": "Mark as closed",
              "targetElements": [
                {
                  "elementId": "reply-box",
                  "isVisible": false
                },
                {
                  "elementId": "comment-box",
                  "isVisible": false
                },
                {
                  "elementId": "resolution-box",
                  "isVisible": true
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
          "type": "Input.Text",
          "placeholder": "Write a message",
          "isMultiline": true,
          "id": "message"
        },
        {
          "type": "ActionSet",
          "actions": [
            {
              "type": "Action.Submit",
              "title": "Send message",
              "id": "_success1_Your_message_was_sent"
            }
          ]
        }
      ],
      "id": "reply-box",
      "isVisible": false
    },
    {
      "type": "Container",
      "style": "emphasis",
      "bleed": true,
      "items": [
        {
          "type": "Input.Text",
          "placeholder": "Enter a comment...",
          "isMultiline": true,
          "id": "comment"
        },
        {
          "type": "ActionSet",
          "actions": [
            {
              "type": "Action.Submit",
              "title": "Comment",
              "id": "_success2_Your_comment_was_posted"
            }
          ]
        }
      ],
      "id": "comment-box",
      "isVisible": false
    },
    {
      "type": "Container",
      "style": "emphasis",
      "bleed": true,
      "items": [
        {
          "type": "Input.Text",
          "isMultiline": true,
          "placeholder": "Describe the resolution (optional)...",
          "id": "resolution"
        },
        {
          "type": "ActionSet",
          "actions": [
            {
              "type": "Action.Submit",
              "title": "Close case",
              "id": "_success3_You_have_closed_this_case"
            }
          ]
        }
      ],
      "id": "resolution-box",
      "isVisible": false
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
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
