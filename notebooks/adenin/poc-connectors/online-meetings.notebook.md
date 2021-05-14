```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: 1,
        title: 'Board Meeting',
        description: 'Performance review for Q3',
        link: 'https://www.adenin.com/pocdef',
        ago: "in 30 minutes",        
        duration: "1 hour",
        location: 'Microsoft Teams',
        onlineMeetingUrl: 'https://www.adenin.com/pocdef',
        organizer: {
          name: 'Jennifer Miller',
          avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg'
        },
        attendees: [
          {
            name: 'Jennifer Miller',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg',
          },
          {
            name: 'Yousef Ali',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5f896d365bec830008375f28-l.jpg',
          },
          {
            name: 'Gabrielle Williams',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5f8975995bec8300083a6f03-l.jpg',
          }
        ]
      },
      {
        id: 2,
        title: 'UI/UX Rebrand Briefing',
        description: 'Setting some time aside to discuss the upcoming app rebrand',
        link: 'https://www.adenin.com/pocdef',
        ago: "in 2 hours",
        duration: "30 minutes",
        onlineMeetingUrl: 'https://www.adenin.com/pocdef',
        location: 'Cisco Webex',
        organizer: {
          name: 'Inger Olsen',
          avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6869016d3b380006ead99f-l.jpg'
        },
        attendees: [
          {
            name: 'Inger Olsen',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6869016d3b380006ead99f-l.jpg',
          },
          {
            name: 'Terry Nguyen',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6887c36d3b380006f1da63-l.jpg',
          },
          {
            name: 'Antonio Rossi',
            avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801c46d3b380006d3cedb-l.jpg',
          }
        ]
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Online Meetings';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'View Calendar';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/office-365.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date;
      response.description = items.length > 1 ? ('You have ' + items.length + ' events today.') : 'You have 1 event today.';
      response.briefing = response.description + ' The next is <b>' + response.items[0].title + '</b>.';
    }

    response._card = {
      type: 'events-today'
    };
  
    return response;
}

```

# Online Meetings

See upcoming events for the day in one Card and join online meeting with just one click

## Benefits

See a timeline of your upcoming meetings for the day, including useful details such as attendees or duration. Online meetings can be directly started with the *Join meeting* button which adds convenience over having to manually look for it in the event description.

## Utterances

1. What (events|meetings|invites) are (coming up|next) (today) in my Outlook calendar?
2. When will my next Outlook (meeting|invite|appointment) (start|begin)?
3. When is my next Outlook (meeting|invite|appointment)?
4. What's next on (my|the) Outlook (schedule|agenda|calendar)?
5. Show me my (next|upcoming) Outlook (meetings|events|appointments)
6. Start my next Outlook (call|meeting|invite)

## Audience

All


```json adaptive-card

```
