```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '1054889',
        title: 'Grand Opening of a New Plant in China',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054889/tp1000126.jpeg?format=jpeg&width=150&height=150&mode=crop&quality=98',
        description: 'On Monday, the new plant of Toaster Inc. was officially opened at Chuansha, Shanghai. ',
        ago: "30 minutes ago"
      },
      {
        id: '1054891',
        title: 'Opening of new logistics and distribution center',
        link: 'https://www.adenin.com/pocdef',
        description: 'The new 10,000 square meter distribution centre in Edison, New Jersey will offer a wide range of logistics services. Together the two Toaster warehouse facilities reinforce the company’s existing network of 19 locations in the USA.',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054891/tp1000126.jpeg?format=jpeg&width=150&height=150&mode=crop&quality=98',
        ago: "1 day ago"
      },
      {
        id: '1054878',
        title: 'New Wi-Fi enabled product line',
        link: 'https://www.adenin.com/pocdef',
        description: 'We called our new series “Toasti-Fi” because consumers should have access to their home appliances everywhere and anytime. With “Toasti-Fi” we help our customers to stay connected to their home, no matter where they are.',
        thumbnail: 'https://my.digitalassistant.app/rimage/demo.adenin.com/images/t0001054878/tp1000126.png?format=jpeg&width=150&height=150&mode=crop&quality=98',
        ago: "2 days ago"
      }
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'News Feed';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'All News';
    response.actionable = value > 0;

    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg';

    if (value > 0) {
      response.value = value;
      response.date = items[0].date; // items are alrady sorted ascending
      response.description = 'You have 3 news items.';
      response.briefing = response.description + ' The latest is <b>' + response.items[0].title + '</b>.';
    } 

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# News Feed

See the latest company news

## Benefits

The News Card shows the user a list of the most recent news items from a connected source, such as the company intranet. The list shows 3 items by default and the user can click the expand icon to make the list larger.

## Utterances

1. What’s new?
2. What are my news?
3. (Show me|read) (my|corporate|company) news

## Audience

All

## Features

Notifications

## Screenshots

1. ![Shows a list of news items in a Card](https://www.adenin.com/assets/images/wp-images/2019/01/News-Card.png)
2. ![See company-issued news with links to external sources](https://www.adenin.com/assets/images/wp-images/2019/01/my.nowassistant.com_App-3-2.png)
