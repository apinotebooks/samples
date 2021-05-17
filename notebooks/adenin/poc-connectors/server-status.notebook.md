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
Notification
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
                  "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD///\u002Bq/1W/v0CTwR\u002BOwRyOvhiPvxyNwBuNvxqNvxmMvRqNvhiNvhmNvhiMvRmMvhiNvhmMvRmMvhiNvhiNvhmMvRmMvRmNvhiMvRh6zEY/AAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB\u002BVSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR\u002BQV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN\u002BsOYcSSo9UEd4GXSTge61PAnE\u002BZlc7fDYG9NmYeGvf\u002B0pt5KFMhV9AAAAABJRU5ErkJggg==",
                  "width": "18px",
                  "$when": "${color == \u0022green\u0022}"
                },
                {
                  "type": "Image",
                  "backgroundColor": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD/////VVX/QEDgPgjdPgbbPQTbPATcPwTcPgPcOwLcPQLbPALaPALbPALbPAHbPAHbOwHbPAHaPAHaOwHbPAHaOwHaOwHaOwHaOwG\u002BMBvqAAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB\u002BVSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR\u002BQV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN\u002BsOYcSSo9UEd4GXSTge61PAnE\u002BZlc7fDYG9NmYeGvf\u002B0pt5KFMhV9AAAAABJRU5ErkJggg==",
                  "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD/////VVX/QEDgPgjdPgbbPQTbPATcPwTcPgPcOwLcPQLbPALaPALbPALbPAHbPAHbOwHbPAHaPAHaOwHbPAHaOwHaOwHaOwHaOwG\u002BMBvqAAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB\u002BVSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR\u002BQV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN\u002BsOYcSSo9UEd4GXSTge61PAnE\u002BZlc7fDYG9NmYeGvf\u002B0pt5KFMhV9AAAAABJRU5ErkJggg==",
                  "width": "18px",
                  "$when": "${color != \u0022green\u0022}"
                }
              ],
              "verticalContentAlignment": "Center"
            },
            {
              "type": "Column",
              "width": "stretch",
              "items": [
                {
                  "type": "TextBlock",
                  "text": "${title}",
                  "wrap": true,
                  "weight": "Bolder"
                },
                {
                  "type": "TextBlock",
                  "text": "${status} as of ${int(formatDateTime(date,\u0027hh\u0027)) - int(formatDateTime(utcNow(),\u0027hh\u0027))} hours ago",
                  "wrap": true,
                  "isSubtle": true,
                  "spacing": "Small"
                }
              ]
            },
            {
              "type": "Column",
              "width": "auto",
              "items": [
                {
                  "type": "ActionSet",
                  "actions": [
                    {
                      "type": "Action.Submit",
                      "title": "\u2715"
                    }
                  ]
                }
              ],
              "backgroundImage": {
                "verticalAlignment": "Center"
              },
              "verticalContentAlignment": "Center"
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
