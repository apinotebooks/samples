```javascript connector
async function handleRequest(request) {

    let items = [
      {
        id: '123',
        title: 'HR Portal',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg',
      },
      {
        id: '121',
        title: 'Office 365',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/office-365.svg',
      },
      {
        id: '133',
        title: 'SharePoint Sites',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/sharepoint-online.svg',
      },
      {
        id: '131',
        title: 'Asana',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/asana.svg',
      },
      {
        id: '321',
        title: 'Zoom',
        link: 'https://www.adenin.com/pocdef',
        thumbnail: 'https://app.adenin.com/avatar/ZM',
      },
    ];
  
    var value = items.length;
    var response = {};
    response.items = items;
    response.title = 'My Bookmarks';
    response.actionable = false;
    response["_pageSize"] = 5;
    response.thumbnail = 'https://www.adenin.com/assets/images/identity/Icon_Digital_Assistant.svg';

    response._card = {
      type: 'cloud-files'
    };
  
    return response;
}

```

# My Bookmarks

See a list of bookmarked links for easy access

## Benefits

This Card is a convenient shortcut to a set of bookmarked links.

## Utterances

1. Show (me) (my) (bookmarks|favorites)

# Audience
All

# Features
List

```json adaptive-card

```