```javascript connector
async function handleRequest(request) {

  var response = await fetchJSON(`https://adenin.azurewebsites.net/api/materialized/build-status/open?page=1&pageSize=20`);
  if (response.ErrorCode != 0) {
    response.Data._card = {
        title: 'Build Status',
        type: 'build-status'
    };

    return response.Data;
  }

  var items = response.Data.items;
  var buildsFailing = [];
  var failCount = 0;

  for (var i = 0; i < items.length; i++) {
    if (items[i].description !== 'building' && items[i].description !== 'ready') {
        buildsFailing.push(items[i]);
        failCount++;
    }
  }

  items = items.sort(function (a, b) {
      a = new Date(a.date);
      b = new Date(b.date);
      return a > b ? -1 : (a < b ? 1 : 0);
  });

  var response = {};
  response.items = items;
  response.title = 'Build Status';
  response.actionable = failCount > 0;
  response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/netlify.svg';
  response._card = {
    type: 'build-status'
  };

  if (failCount > 0) {
    response.value = failCount;
    response.color = 'red';
    response.date = items[0].date;
    response.description = failCount + ' build'+(failCount > 1 ? 's are' : ' is')+' currently failing.';
    response.briefing = 'Build <b>' + buildsFailing[0].title + '</b> ' + (failCount > 1 ? ('and' + (failCount - 1).toString() + 'other builds are') : 'is') + ' currently failing.';
  } else if (items.length > 0) {
    response.description = 'All builds are succeeding.';
  } else {
    response.description = 'No build status information received.';
  }
  
  return response;
}

```

# Build Status

Get an at-a-glance overview of the status of your application builds

## Benefits

Keep a close eye on the status of your CI pipeline with the Build Monitor Card. Get notifications when builds are triggered, completed or fail, or pin the Card to your dashboard for an easy-access view of the status of your deployments.

## Utterances

1. Are (all) Netlify builds (ok|succeeding)?
2. Are any Netlify builds failing?
3. Is any Netlify build failing?
4. Are there (any) Netlify build errors?

## Logo

![logo](https://www.adenin.com/assets/images/wp-images/logo/netlify.svg)

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
                      "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD///+q/1W/v0CTwR+OwRyOvhiPvxyNwBuNvxqNvxmMvRqNvhiNvhmNvhiMvRmMvhiNvhmMvRmMvhiNvhiNvhmMvRmMvRmNvhiMvRh6zEY/AAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB+VSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR+QV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN+sOYcSSo9UEd4GXSTge61PAnE+Zlc7fDYG9NmYeGvf+0pt5KFMhV9AAAAABJRU5ErkJggg==",
                      "width": "18px",
                      "$when": "${description == \"ready\"}"
                  },
                  {
                      "type": "Image",
                      "backgroundColor": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD/////VVX/QEDgPgjdPgbbPQTbPATcPwTcPgPcOwLcPQLbPALaPALbPALbPAHbPAHbOwHbPAHaPAHaOwHbPAHaOwHaOwHaOwHaOwG+MBvqAAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB+VSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR+QV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN+sOYcSSo9UEd4GXSTge61PAnE+Zlc7fDYG9NmYeGvf+0pt5KFMhV9AAAAABJRU5ErkJggg==",
                      "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAAA2CAMAAAHMnKp5AAAABGdBTUEAALGPC/xhBQAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAANqADAAQAAAABAAAANgAAAADQiwyeAAAATlBMVEUAAAD/////VVX/QEDgPgjdPgbbPQTbPATcPwTcPgPcOwLcPQLbPALaPALbPALbPAHbPAHbOwHbPAHaPAHaOwHbPAHaOwHaOwHaOwHaOwG+MBvqAAAAGXRSTlMAAQMEIS0/QEFXZ22UmJ22v8va3t/q7Pn6s24kUwAAAYxJREFUGBmdwQmCojAARcGXHvYdlMC//0UHwYYoxBaqmNxyJnoANOOuGblmoBmgCZPQ8qAH0MygBVqgGaAJs1oLHmptIJQLKxfIEQFasTCaRKzKoTE8aRHwoF8FoA10ciAXciEXciEXaJNAphWTWAvLopLU4zCdVimuUW8ynkYdiJkYHWsB+VSU8mKQF428MPLpIZUHk0BHLItCOz9sWjkS3pi8scOtDNlJteoMrkAvajaZ3oz8KrTHItaBkZkO1UxaHTNg5NFBJR+QV4i8SuR1R14D8rLIq0FeOb18DJF8AHmkQKJjPFgdCZjpQMbin3YKVlavYhyJHC1vol6LyuBjoqrXi76KDB8lrTzaBI/Y6iMbs/NT6AvFDy8yfSljE1h9zQY8JTolYZbqpJRJpNMiML1O6w25LshpdEGD1QWWQRcM3HXBjVIXlIS6IIRKp1WA6XRSZ5iYVqe0hkWtE2pW8agvjTGuQl8peJeN+sOYcSSo9UEd4GXSTge61PAnE+Zlc7fDYG9NmYeGvf+0pt5KFMhV9AAAAABJRU5ErkJggg==",
                      "width": "18px",
                      "$when": "${description != \"ready\"}"
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
                      "text": "Last build ${int(formatDateTime(utcNow(),'hh')) - int(formatDateTime(date,'hh'))} hours ago is ${description}",
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
                              "title": "✕"
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