```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054889',
        title: 'Grand Opening of a New Plant in China',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054889/tp1000126.jpeg?format=jpeg&width=150&height=150&mode=crop&quality=98',
        description: 'On Monday, the new plant of Toaster Inc. was officially opened at Chuansha, Shanghai. ',
        ago: "30 minutes ago"
      },
      {
        id: '1054891',
        title: 'Opening of new logistics and distribution center',
        link: 'https://www.adenin.com/pocdef',
        description: 'The new 10,000 square meter distribution centre in Edison, New Jersey will offer a wide range of logistics services. Together the two Toaster warehouse facilities reinforce the company’s existing network of 19 locations in the USA.',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054891/tp1000126.jpeg?format=jpeg&width=150&height=150&mode=crop&quality=98',
        ago: "1 day ago"
      },
      {
        id: '1054878',
        title: 'New Wi-Fi enabled product line',
        link: 'https://www.adenin.com/pocdef',
        description: 'We called our new series “Toasti-Fi” because consumers should have access to their home appliances everywhere and anytime. With “Toasti-Fi” we help our customers to stay connected to their home, no matter where they are.',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054878/tp1000126.png?format=jpeg&width=150&height=150&mode=crop&quality=98',
        ago: "2 days ago"
      }
    ]; 

    var value = items.length;
    var response = {};

    response.items = items;
    response.title = 'Corporate News';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All News';
    response.actionable = value > 0;

    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have 3 news items.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    }; 

    return response;
}

```

# Corp News

See the latest company news

## Benefits

The News Card shows the user a list of the most recent news items from a connected source, such as the company intranet. The list shows 3 items by default and the user can click the expand icon to make the list larger.

## Utterances

1. What’s new?
2. What are my news?
3. (Show me|read) (my|corporate|company) news

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg)

## Audience

All

## Features

Notification
List

```json adaptive-card
{
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "type": "AdaptiveCard",
  "version": "1.2",
  "body": [
    {
      "speak": "Tom\u0027s Pie is a Pizza restaurant which is rated 9.3 by customers.",
      "type": "ColumnSet",
      "columns": [
        {
          "type": "Column",
          "width": 2,
          "items": [
            {
              "type": "TextBlock",
              "text": "${ago}"
            },
            {
              "type": "TextBlock",
              "text": "${title}",
              "weight": "Bolder",
              "size": "ExtraLarge",
              "spacing": "None",
              "wrap": true,
              "maxLines": 3
            },
            {
              "type": "TextBlock",
              "text": "${description}",
              "isSubtle": true,
              "spacing": "None",
              "wrap": true,
              "maxLines": 3
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
                      "url": "https://demo.adenin.com/dm/50/1015122-picture.jpg.jpg?",
                      "style": "Person",
                      "width": "30px"
                    }
                  ]
                },
                {
                  "type": "Column",
                  "width": "stretch",
                  "items": [
                    {
                      "type": "TextBlock",
                      "text": "**Anna Larsen** posted on Internal Comms Blog",
                      "size": "Small",
                      "wrap": true,
                      "maxLines": 3
                    }
                  ],
                  "verticalContentAlignment": "Center",
                  "spacing": "Small"
                }
              ],
              "spacing": "Small"
            }
          ]
        },
        {
          "type": "Column",
          "width": 1,
          "items": [
            {
              "type": "Image",
              "url": "${thumbnail}",
              "size": "auto"
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
              "type": "Image",
              "url": "https://img.icons8.com/material-two-tone/48/000000/thumb-up--v1.png",
              "width": "20px",
              "spacing": "None",
              "id": "Like"
            },
            {
              "type": "Image",
              "url": "data:image/svg\u002Bxml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHg9IjBweCIgeT0iMHB4Igp3aWR0aD0iNDgiIGhlaWdodD0iNDgiCnZpZXdCb3g9IjAgMCAxNzIgMTcyIgpzdHlsZT0iIGZpbGw6IzAwMDAwMDsiPjxnIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0ibm9uemVybyIgc3Ryb2tlPSJub25lIiBzdHJva2Utd2lkdGg9IjEiIHN0cm9rZS1saW5lY2FwPSJidXR0IiBzdHJva2UtbGluZWpvaW49Im1pdGVyIiBzdHJva2UtbWl0ZXJsaW1pdD0iMTAiIHN0cm9rZS1kYXNoYXJyYXk9IiIgc3Ryb2tlLWRhc2hvZmZzZXQ9IjAiIGZvbnQtZmFtaWx5PSJub25lIiBmb250LXdlaWdodD0ibm9uZSIgZm9udC1zaXplPSJub25lIiB0ZXh0LWFuY2hvcj0ibm9uZSIgc3R5bGU9Im1peC1ibGVuZC1tb2RlOiBub3JtYWwiPjxwYXRoIGQ9Ik0wLDE3MnYtMTcyaDE3MnYxNzJ6IiBmaWxsPSJub25lIj48L3BhdGg\u002BPGcgZmlsbD0iIzM0OThkYiI\u002BPHBhdGggZD0iTTE0LjMzMzMzLDcxLjY2NjY3aDQzdjcxLjY2NjY3aC00M3oiIG9wYWNpdHk9IjAuMyI\u002BPC9wYXRoPjxwYXRoIGQ9Ik01MC4xNjY2Nyw2NC41aC00M3Y4Nmg0M2M3LjkxOTE3LDAgMTQuMzMzMzMsLTYuNDE0MTcgMTQuMzMzMzMsLTE0LjMzMzMzdi01Ny4zMzMzM2MwLC03LjkxOTE3IC02LjQxNDE3LC0xNC4zMzMzMyAtMTQuMzMzMzMsLTE0LjMzMzMzek01MC4xNjY2NywxMzYuMTY2NjdoLTI4LjY2NjY3di01Ny4zMzMzM2gyOC42NjY2N3oiPjwvcGF0aD48cGF0aCBkPSJNMTUwLjUsNTcuMzMzMzNoLTQ1LjUxNTVsNi43MDgsLTMwLjc4OGMxLjA0NjMzLC00LjgwODgzIC0wLjQ0NDMzLC05LjgxODMzIC0zLjk1NiwtMTMuMjY1NWwtNi4yMDYzMywtNi4xMTMxN2wtNDcuMTc4MTcsNDcuMjY0MTdjLTIuNjgwMzMsMi42ODc1IC00LjE4NTMzLDYuMzM1MzMgLTQuMTg1MzMsMTAuMTI2NXY3MS42MDkzM2MwLDcuOTE5MTcgNi40MTQxNywxNC4zMzMzMyAxNC4zMzMzMywxNC4zMzMzM2g2NC40NDk4M2M1LjcyNjE3LDAgMTAuOTA3NjcsLTMuNDExMzMgMTMuMTcyMzMsLTguNjc4ODNsMjEuNTUwMTcsLTUwLjE3MzgzYzAuNzY2ODMsLTEuNzg0NSAxLjE2MSwtMy43MTIzMyAxLjE2MSwtNS42NTQ1di0xNC4zMjYxN2MwLC03LjkxOTE3IC02LjQxNDE3LC0xNC4zMzMzMyAtMTQuMzMzMzMsLTE0LjMzMzMzek0xNTAuNSw4NS45OTI4M2wtMjEuNTUwMTcsNTAuMTczODNoLTY0LjQ0OTgzdi03MS42MDkzM2wzMS4wMTAxNywtMzEuMDY3NWwtNC41MjkzMywyMC43OTA1bC0zLjc4NCwxNy4zODYzM2gxNy43OTQ4M2g0NS41MDgzM3oiPjwvcGF0aD48L2c\u002BPC9nPjwvc3ZnPg==",
              "width": "20px",
              "spacing": "None",
              "isVisible": false,
              "id": "LikeClicked"
            }
          ]
        },
        {
          "type": "Column",
          "width": "stretch",
          "items": [
            {
              "type": "TextBlock",
              "text": "14 people like this",
              "wrap": true,
              "id": "14Likes"
            },
            {
              "type": "TextBlock",
              "text": "15 people like this",
              "wrap": true,
              "spacing": "None",
              "isVisible": false,
              "weight": "Bolder",
              "id": "15Likes"
            }
          ],
          "spacing": "Small"
        },
        {
          "type": "Column",
          "width": "auto",
          "items": [
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.ToggleVisibility",
                  "title": "Like",
                  "targetElements": [
                    "Like",
                    "LikeClicked",
                    "14Likes",
                    "15Likes"
                  ]
                },
                {
                  "type": "Action.ToggleVisibility",
                  "title": "Comment",
                  "targetElements": [
                    "CommentSection"
                  ]
                }
              ]
            }
          ]
        }
      ]
    },
    {
      "type": "Container",
      "items": [
        {
          "type": "Input.Text",
          "placeholder": "What do you think?",
          "id": "comment-input"
        },
        {
          "type": "ActionSet",
          "actions": [
            {
              "type": "Action.Submit",
              "title": "Submit",
              "id": "_success1_Your_comment_was_submitted"
            }
          ]
        }
      ],
      "isVisible": false,
      "id": "CommentSection",
      "style": "emphasis"
    }
  ]
}
```
