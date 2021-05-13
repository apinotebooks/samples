```javascript connector
async function handleRequest(request) {

    let {DateTime} = await import('https://esm.run/luxon');
    var dt = DateTime.now();

    let items = [
      {
        id: '1054889',
        title: 'PTO Request',
        description: '3 days, 10/14 - 10/16',
        requested_by: 'Mohamed Alami',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5e68015d6d3b380006d3b6eb-l.jpg',
        integration: 'SharePoint',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg',
        date: dt,
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054891',
        title: 'Equipment Request',
        description: 'Work from Home - Company PC',
        requested_by: 'Thomas Müller',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801926d3b380006d3c33b-l.jpg',
        integration: 'SAP Concur',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sap-concur.svg',
        date: dt,
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054878',
        title: 'Sick leave notice',
        description: 'Scheduled Doctors appointment on 09/06',
        requested_by: 'Fatima Khan',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5f896f545bec830008382c00-l.jpg',
        integration: 'Workday',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/workday.svg',
        date: dt,
        link: 'https://www.adenin.com/pocdef'
      },
      {
        id: '1054880',
        title: 'Expense Reimbursement',
        description: 'Developer\'s conference travel costs - $230',
        requested_by: 'Ellen Kim',
        avatar: 'https://www.adenin.com/assets/images/generated_photos/5f8971ee5bec830008391f96-l.jpg',
        integration: 'SAP Fieldglass',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sap-fieldglass.svg',
        date: dt,
        link: 'https://www.adenin.com/pocdef'
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Approvals';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'Open Approvals app';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/identity/logo_adenin_round.png';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' pending approvals.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + ' from ' + response.items[0].requested_by + '</b>.';
    } 

    response._card = {
      type: 'my-approvals'
    };
  
    return response;
}

```

# Approvals

See and manage pending approvals from your employees

## Utterances

1. What are my (latest|new|pending) approvals?
2. Show (me) my (latest|new|pending) approvals
3. Do I have (any) (new|unread|pending) approvals?

## Audience

All

## Features

Notifications

```json adaptive-card

```