```javascript connector
async function handleRequest(request) {
  let items = [
    {
      id: "123",
      title: "HR Portal",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.png",
    },
    {
      id: "121",
      title: "Office 365",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/wp-images/logo/office-365.png",
    },
    {
      id: "133",
      title: "SharePoint Sites",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.png",
    },
    {
      id: "131",
      title: "Asana",
      link: "https://www.adenin.com/pocdef",
      thumbnail:
        "https://www.adenin.com/assets/images/wp-images/logo/asana.png",
    },
    {
      id: "321",
      title: "Zoom",
      link: "https://www.adenin.com/pocdef",
      thumbnail: "https://www.adenin.com/assets/images/wp-images/logo/zoom.png",
    },
  ];

  var value = items.length;
  var response = {};
  response.items = items;
  response.title = "My Bookmarks";
  response.actionable = false;
  response["_pageSize"] = 5;
  response.thumbnail =
    "https://www.adenin.com/assets/images/identity/Icon_Digital_Assistant.svg";

  response._card = {
    type: "cloud-files",
  };

  return response;
}
```

# Bookmarks

See a list of bookmarked links for easy access

## Benefits

This Card is a convenient shortcut to a set of bookmarked links.

## Utterances

1. Show (me) (my) (bookmarks|favorites)

## Logo

![logo](https://www.adenin.com/assets/images/identity/Icon_Digital_Assistant.svg)

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
                  "type": "Container",
                  "style": "emphasis",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${items[0].thumbnail}",
                      "width": "40px",
                      "horizontalAlignment": "Center"
                    },
                    {
                      "type": "TextBlock",
                      "text": "${items[0].title}",
                      "wrap": true,
                      "spacing": "Small",
                      "horizontalAlignment": "Center"
                    }
                  ],
                  "selectAction": {
                    "type": "Action.OpenUrl",
                    "id": "bookmark-${items[0].id}",
                    "url": "${items[0].link}"
                  }
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "Container",
                  "style": "emphasis",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${items[1].thumbnail}",
                      "width": "40px",
                      "horizontalAlignment": "Center"
                    },
                    {
                      "type": "TextBlock",
                      "text": "${items[1].title}",
                      "wrap": true,
                      "spacing": "Small",
                      "horizontalAlignment": "Center"
                    }
                  ],
                  "selectAction": {
                    "type": "Action.OpenUrl",
                    "id": "bookmark-${items[1].id}",
                    "url": "${items[1].link}"
                  }
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
              "width": "stretch",
              "items": [
                {
                  "type": "Container",
                  "style": "emphasis",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${items[2].thumbnail}",
                      "width": "40px",
                      "horizontalAlignment": "Center"
                    },
                    {
                      "type": "TextBlock",
                      "text": "${items[2].title}",
                      "spacing": "Small",
                      "horizontalAlignment": "Center"
                    }
                  ],
                  "selectAction": {
                    "type": "Action.OpenUrl",
                    "id": "bookmark-${items[2].id}",
                    "url": "${items[2].link}"
                  }
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "Container",
                  "style": "emphasis",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${items[3].thumbnail}",
                      "width": "40px",
                      "horizontalAlignment": "Center"
                    },
                    {
                      "type": "TextBlock",
                      "text": "${items[3].title}",
                      "wrap": true,
                      "spacing": "Small",
                      "horizontalAlignment": "Center"
                    }
                  ],
                  "selectAction": {
                    "type": "Action.OpenUrl",
                    "id": "bookmark-${items[3].id}",
                    "url": "${items[3].link}"
                  }
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "Container",
                  "style": "emphasis",
                  "items": [
                    {
                      "type": "Image",
                      "url": "${items[4].thumbnail}",
                      "width": "40px",
                      "horizontalAlignment": "Center"
                    },
                    {
                      "type": "TextBlock",
                      "text": "${items[4].title}",
                      "wrap": true,
                      "spacing": "Small",
                      "horizontalAlignment": "Center"
                    }
                  ],
                  "selectAction": {
                    "type": "Action.OpenUrl",
                    "id": "bookmark-${items[4].id}",
                    "url": "${items[4].link}"
                  }
                }
              ]
            }
          ]
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
