```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '32116',
        title: 'Sunil Hussain',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5f896a9b5bec830008365b3f-l.jpg',
        description: 'Qatar Charter Air ',
        ago: "12 minutes ago",
        created_date: '2021-05-13T08:44:30.524Z',
        contact_info: {
          email: 's.hussain@qcair.com',
          phone_number: '917-464-0537',
          job_title: 'Customer Service Lead',
        },
        status: 'Open',
        page_first_seen: 'https://www.adenin.com/digital-assistant/',
        last_activity: 'Submitted contact form',
        last_activity_time: '2021-05-13T08:44:30.524Z',
      },
      {
        id: '32101',
        title: 'Dimitrios Vasileiou',
        link: 'https://www.adenin.com/pocdef',
        description: 'Cogent Data',
        thumbnail: 'https://www.adenin.com/assets/images/generated_photos/5e6801a36d3b380006d3c72f-l.jpg',
        ago: "1 day ago",
        created_date: '2021-05-11T15:01:23.000Z',
        contact_info: {
          email: 'vasileiou.d.a@cogentdata.ai',
          phone_number: '404-932-7746',
          job_title: 'Digital Transformation Lead',
        },
        status: 'Interested',
        page_first_seen: 'https://www.adenin.com/',
        last_activity: 'Requested demo',
        last_activity_time: '2021-05-12T15:16:41.000Z',
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'Salesforce Leads';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All Leads';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/salesforce.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have ' + value + ' Salesforce leads.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# Open Leads

See your currently open leads

## Benefits

With the Leads Card you have lists of your new and open contacts directly at your fingertips. All the contacts data is directly taken from your CRM application and you can enable to be notified whenever new contacts are received.

## Utterances

1. Show (me) (my) open leads (from|in) Salesforce
2. Show (me) (my) open Salesforce leads

# Audience
All

# Features
List

```json adaptive-card

```