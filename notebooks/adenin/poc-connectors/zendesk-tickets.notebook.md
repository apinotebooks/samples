```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054875',
        title: 'Locked out of my account, no access to email.',
        description: 'I am unable to access my account. When I enter my password I get an error message saying my account has been locked and to contact support.',
        priority: 'High',
        category: 'User Accounts',
        status: 'Open',
        created_date: '2021-05-13T08:44:30.524Z',
        ago: "2 hours ago",
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5f8971ee5bec830008391f96-l.jpg',
        contact: {
          name: 'Ellen Kim',
          company: 'Designplus.io',
        }
      },
      {
        id: '1054889',
        title: 'Guest WiFi access',
        description: 'The credentials for the guest WiFi network listed on the Intranet don\'t work.',
        status: 'Open',
        category: 'Services',
        priority: 'Normal',
        created_date: '2021-05-11T09:013:23.000Z',
        ago: "2 days ago",
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg',
        contact: {
          name: 'Thomas Müller',
          company: 'Coffee Craft',
        }
      },
      {
        id: '1054893',
        title: 'Software version upgrade',
        description: 'I would like to upgrade our software to the latest version to take advantage of the new features. Can you assist with that please?',
        status: 'Open',
        priority: 'Low',
        category: 'Technical Support',
        created_date: '2021-05-10T09:013:23.000Z',
        ago: "3 days ago",
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg',
        contact: {
          name: 'Isaac Cohen',
          company: 'Purple Security',
        }
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Zendesk Tickets';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All tickets';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/zendesk.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' open Zendesk tickets.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# Open Tickets

See your open tickets

## Benefits

Pin the Open Tickets Card to your Board to keep track of your latest open tickets, or get live notifications whenever new tickets arrive. Digital Assistant makes it easy to stay on top of your tickets in one place, making it useful for both support agents and supervising managers.

## Utterances

1. Show (me) (my) open Freshdesk (cases|tickets|issues)
2. Do I have any (open|due|assigned) Freshdesk (cases|tickets|issues)?
3. Show me (my) (open|due|assigned) Freshdesk (cases|tickets|issues)

# Audience
All

# Features
List

```json adaptive-card

```