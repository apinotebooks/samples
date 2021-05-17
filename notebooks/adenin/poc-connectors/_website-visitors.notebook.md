```javascript connector
async function handleRequest(request) {

    let chart = {
        "configuration": {
            "data": {
                "labels": [
                    "Organic Search",
                    "Direct",
                    "Paid Search",
                    "Referral"
                ],
                "datasets": [
                    {
                        "data": [
                            51.7,
                            31.2,
                            12.5,
                            4.6
                        ]
                    }
                ]
            },
            "options": {
                "title": {
                    "display": true,
                    "text": "Website Visitors"
                }
            }
        },
        "template": "pie-labels",
        "palette": "office.Berlin6"
    };
  
    var response = {};
    response.chart = chart;
    response.title = 'Website Visitors';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'View in Google Analytics';
    response.actionable = false;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/google-analytics.svg';

    response._card = {
      type: 'at-card-chart'
    };
  
    return response;
}

```

# Website Visitors

See a breakdown of website traffic by channel

## Benefits

With the Website Visitors Card, you can see an at-a-glance breakdown of your website traffic by channel.

## Utterances

1. Show (me) (a chart of) (my) website visitors

# Audience
All

# Features
List

```json adaptive-card

```