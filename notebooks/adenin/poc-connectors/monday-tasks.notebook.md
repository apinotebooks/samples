```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054880',
        title: 'New website design',
        ago: '32 minutes ago',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
        link: 'https://www.adenin.com/pocdef',
        project: 'Website rebrand 2021',
        priority: '5',
        progress: '0.25',
        assigned_to: {
            name: 'Jennifer Miller',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
            team: 'Marketing',
        },
        created_by: {
            name: 'Mina Heydari',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e68014d6d3b380006d3b355-l.jpg',
            team: 'Design'
        }
      },
      {
        id: '1054893',
        title: 'Facebook ad copy',
        ago: '2 hours ago',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
        link: 'https://www.adenin.com/pocdef',
        project: 'Website rebrand 2021',
        priority: '2',
        progress: '0',
        assigned_to: {
            name: 'Jennifer Miller',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
            team: 'Marketing',
        },
        created_by: {
            name: 'Terry Nguyen',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6887c36d3b380006f1da63-l.jpg',
            team: 'Marketing'
        }
      },
      {
        id: '1054878',
        title: 'Generate new PDFs',
        ago: 'yesterday',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
        link: 'https://www.adenin.com/pocdef',
        project: 'June 2021 campaigns',
        priority: '3',
        progress: '0.86',
        assigned_to: {
            name: 'Jennifer Miller',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
            team: 'Marketing',
        },
        created_by: {
            name: 'Terry Nguyen',
            thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6887c36d3b380006f1da63-l.jpg',
            team: 'Marketing'
        }
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Monday.com Tasks';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All Tasks';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/monday.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' Monday.com tasks.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# Tasks

See a list of your current tasks from Monday.com

## Benefits

See an at-a-glance overview of your current tasks with valuable information like due dates and priorities. Click on a task to open it in the source app directly. An optional form allows you to directly create tasks from your Assistant, too, so you don't have to break your workflow. If you enable notifications, you will receive instant updates about new tasks.

## Utterances

1. Show (me) (all) (my) (new|latest) (monday|monday.com) (to dos|to-dos|tasks|things to do|reminders)
2. Do I have (any) (new|recent) (monday|monday.com) (to dos|to-dos|tasks|things to do|reminders)?
3. What are my (current) (monday|monday.com) (to dos|to-dos|tasks|things to do|reminders)?

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/monday.svg)

## Audience

All

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
              "width": "auto",
              "items": [
                {
                  "type": "Image",
                  "selectAction": {
                    "type": "Action.ToggleVisibility",
                    "targetElements": [
                      "${id}-unchecked",
                      "${id}-checked"
                    ]
                  },
                  "url": "data:image/svg\u002Bxml,%3Csvg xmlns=\u0027http://www.w3.org/2000/svg\u0027 viewBox=\u00270 0 16 16\u0027%3E%3Cpath fill=\u0027%23c2e8ff\u0027 d=\u0027M2.077,14.5c-0.318,0-0.577-0.259-0.577-0.577V2.077C1.5,1.759,1.759,1.5,2.077,1.5h11.846 c0.318,0,0.577,0.259,0.577,0.577v11.846c0,0.318-0.259,0.577-0.577,0.577H2.077z\u0027/%3E%3Cpath fill=\u0027%237496c4\u0027 d=\u0027M13.923,2C13.965,2,14,2.035,14,2.077v11.846C14,13.965,13.965,14,13.923,14H2.077 C2.035,14,2,13.965,2,13.923V2.077C2,2.035,2.035,2,2.077,2H13.923 M13.923,1H2.077C1.482,1,1,1.482,1,2.077v11.846 C1,14.518,1.482,15,2.077,15h11.846C14.518,15,15,14.518,15,13.923V2.077C15,1.482,14.518,1,13.923,1L13.923,1z\u0027/%3E%3C/svg%3E",
                  "id": "${id}-unchecked",
                  "width": "20px"
                },
                {
                  "type": "Image",
                  "selectAction": {
                    "type": "Action.ToggleVisibility",
                    "targetElements": [
                      "${id}-unchecked",
                      "${id}-checked"
                    ]
                  },
                  "url": "data:image/svg\u002Bxml,%3Csvg xmlns=\u0027http://www.w3.org/2000/svg\u0027 viewBox=\u00270 0 16 16\u0027%3E%3Cpath fill=\u0027%238bb7f0\u0027 d=\u0027M2.1,14.5c-0.3,0-0.6-0.3-0.6-0.6V2.1c0-0.3,0.3-0.6,0.6-0.6h11.8c0.3,0,0.6,0.3,0.6,0.6v11.8 c0,0.3-0.3,0.6-0.6,0.6H2.1z\u0027/%3E%3Cpath fill=\u0027%234e7ab5\u0027 d=\u0027M13.9,2C14,2,14,2,13.9,2L14,13.9c0,0,0,0.1-0.1,0.1H2.1C2,14,2,14,2,13.9V2.1C2,2,2,2,2.1,2H13.9 M13.9,1H2.1C1.5,1,1,1.5,1,2.1v11.8C1,14.5,1.5,15,2.1,15h11.8c0.6,0,1.1-0.5,1.1-1.1V2.1C15,1.5,14.5,1,13.9,1L13.9,1z\u0027/%3E%3Cpath fill=\u0027%23fff\u0027 d=\u0027M6.8 11L4.1 8.4 4.9 7.7 6.8 9.6 11.7 4.8 12.4 5.5z\u0027/%3E%3C/svg%3E",
                  "width": "20px",
                  "id": "${id}-checked",
                  "isVisible": false
                }
              ]
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "Updated ${ago}",
                  "wrap": true,
                  "size": "Small",
                  "weight": "Bolder",
                  "color": "Good"
                },
                {
                  "type": "TextBlock",
                  "text": "${project}: ${title}",
                  "wrap": true,
                  "size": "Large",
                  "spacing": "Small"
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
                          "url": "${created_by.thumbnail}",
                          "width": "30px",
                          "style": "Person"
                        }
                      ]
                    },
                    {
                      "type": "Column",
                      "width": "stretch",
                      "items": [
                        {
                          "type": "TextBlock",
                          "text": "Assigned to you by",
                          "wrap": true,
                          "size": "Small"
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
                                  "text": "${created_by.name}",
                                  "wrap": true,
                                  "spacing": "None"
                                }
                              ]
                            },
                            {
                              "type": "Column",
                              "width": "auto",
                              "items": [
                                {
                                  "type": "TextBlock",
                                  "text": "${created_by.team}",
                                  "wrap": true,
                                  "isSubtle": true
                                }
                              ]
                            }
                          ],
                          "spacing": "None"
                        }
                      ]
                    }
                  ],
                  "separator": true
                }
              ]
            }
          ]
        }
      ]
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
