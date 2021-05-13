```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054880',
        title: 'New website design',
        created_date: '2021-05-13T08:44:30.524Z',
        date: "2021-05-15T11:56:00.000Z",
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
        created_date: '2021-04-28T08:44:30.524Z',
        date: "2021-05-15T09:04:00.000Z"
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
        created_date: '2021-05-13T08:44:30.524Z',
        date: "2021-05-14T09:04:00.000Z",
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

# Monday.com Tasks

See a list of your current tasks from Monday.com

## Benefits

See an at-a-glance overview of your current tasks with valuable information like due dates and priorities. Click on a task to open it in the source app directly. An optional form allows you to directly create tasks from your Assistant, too, so you don't have to break your workflow. If you enable notifications, you will receive instant updates about new tasks.

## Utterances

1. Show (me) (all) my (new|latest) (to dos|to-dos|tasks|things to do|reminders)
2. Do I have (new|recent) (to dos|to-dos|tasks|things to do|reminders)?
3. What are my (current) (to dos|to-dos|tasks|things to do|reminders)?

# Audience
All

# Features
List

```json adaptive-card

```