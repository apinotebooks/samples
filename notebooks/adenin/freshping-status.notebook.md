```javascript connector
async function handleRequest(request) {

  var response = await fetchJSON(`https://adenin.azurewebsites.net/api/materialized/server-status/open?page=1&pageSize=20`);
  if (response.ErrorCode != 0) {
    response.Data._card = {
        title: 'Freshping Server Status',
        type: 'status-list'
    };

    return response.Data;
  }

  var items = response.Data.items;
  var serversDown = [];
  var downCount = 0;

  for (var i = 0; i < items.length; i++) {
    if (!items[i].description) {
      // check in title for description
      let arr = items[i].title.split(":");
      if (arr.length > 1) {
        items[i].status = arr[arr.length - 1].trim();
      } else {
        items[i].status = "Unknown";
      }
    } else {
      items[i].status = items[i].description;
    }

    if (!items[i].color) {
      if (items[i].status == 'Available') {
        items[i].color = "green";
      } else if (items[i].status == "Not Responding") {
        items[i].color = "red";
      } else {
        items[i].color = "grey";
      }
    }

    if (items[i].status == 'Not Responding') {
        serversDown.push(items[i]);
        downCount++;
    }
  }

  var response = {};
  response.items = items;
  response.title = 'Freshping Server Status';
  response.link = 'https://app.freshping.io';
  response.linkLabel = 'Go to Freshping';
  response.actionable = downCount > 0 || items.length == 0;
  response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/freshping.svg';
  response._card = {
    type: 'status-list'
  };

  if (downCount > 0) {
    response.value = downCount;
    response.date = items[0].date; // items are alrady sorted ascending
    response.description = downCount + ' server'+(downCount > 1 ? 's are' : ' is')+' currently down.';
    response.briefing = 'Server <b>' + serversDown[0].title + '</b> ' + (downCount > 1 ? ('and' + (downCount - 1).toString() + 'other servers are') : 'is') + ' currently down.';
  } else if (items.length > 0) {
    response.description = 'All servers are running.';
  } else {
    response.description = 'No server status information received.';
  }
  
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

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/freshping.svg)

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
                  "text": "${status} as of ${formatDateTime(date,\u0027dd MMMM yyyy\u0027)}",
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