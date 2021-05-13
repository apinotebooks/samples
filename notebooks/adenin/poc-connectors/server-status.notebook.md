```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: 'Copernicus',
        title: 'Copernicus',
        link: 'https://www.adenin.com/pocdef',
        date: '2021-05-13T08:44:30.524Z',
        color: "green",
        _type: "server-status",
        status: "Operational"
      },
      {
        id: 'Janssen',
        title: 'Janssen',
        link: 'https://www.adenin.com/pocdef',
        date: '2021-05-13T08:44:30.524Z',
        color: "yellow",
        _type: "server-status",
        status: "Partial Outage"
      },
      {
        id: 'Petavius',
        title: 'Petavius',
        link: 'https://www.adenin.com/pocdef',
        date: '2021-05-13T08:44:30.524Z',
        color: "green",
        _type: "server-status",
        status: "Operational"
      },
      {
        id: 'Seleucus',
        title: 'Seleucus',
        link: 'https://www.adenin.com/pocdef',
        date: '2021-05-13T08:44:30.524Z',
        color: "red",
        _type: "server-status",
        status: "Major Outage"
      },
      {
        id: 'Vendelinus',
        title: 'Vendelinus',
        link: 'https://www.adenin.com/pocdef',
        date: '2021-05-13T08:44:30.524Z',
        color: "green",
        _type: "server-status",
        status: "Operational"
      },
    ];
  
    var value = items.filter(function(item) {
        return item['color'] == "red"
    }).length;
    var serversDown = items.filter(function(item) {
        return item['color'] == "red"
    });
    var response = {};
    response.items = items;
    response.title = 'Server Status';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'DevOps Dashboard';
    response.actionable = value > 0;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/freshping.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = value + ' server'+(value > 1 ? 's' : '')+' is currently down.';
      response.briefing = 'Server <b>' + serversDown[0].title + '</b> ' + (value > 1 ? ('and' + (value - 1).toString() + 'other servers are') : 'is') + ' currently down.';
    }

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# Server Status

Get an at-a-glance overview of the status of your web, application, mail servers and more

## Benefits

Get a quick overview over IT infrastructure with this list of available servers along with their current status. By subscribing, users will receive notifications when the status of a server changes, so they can take immediate remedial action.

## Utterances

1. Are all Freshping servers (up|running)?
2. Are (there) any Freshping servers down?
3. Is any Freshping server down?
4. Are there (any) (current|recent) Freshping (server) outages?

## Audience

All

## Features

Notifications
List

```json adaptive-card

```