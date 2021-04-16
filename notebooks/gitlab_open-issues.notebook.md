---
ConnectorName: gitlab
_ClientId: 602fe7475c86be83c0575169db95760b743721aadbf4a7395b01b1079466e4bf
_AccessCodeServiceEndpoint: https://gitlab.com/oauth/authorize
_AccessTokenServiceEndpoint: https://gitlab.com/oauth/token
_Scopes: api openid
---

```json adaptive-form {"run_on_load":true}
{
    "type": "AdaptiveCard",
    "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
    "version": "1.2",
    "body": [
        {
            "type": "Input.Text",
            "label": "Number of items to return",
            "value": "10",
            "id": "$perPage"
        }
    ],
    "actions": [
        {
            "type": "Action.Submit",
            "title": "Submit",
            "associatedInputs": "auto"
        }
    ]
}
```
```javascript connector

async function handleRequest(request) {

  // use luxon (as the successor of momentjs) to format dates
  let {DateTime} = await import('https://esm.run/luxon');

  var response = await fetch(`https://gitlab.com/api/v4/issues?state=opened&scope=assigned_to_me&per_page=${request['$perPage']}`, { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  });

  var json = await response.json();

  var items = [];
  var value = json.length;

  for(var i=0; i<value; i++) {
    var raw = json[i];
    var item = {
        id: raw.id,
        title: raw.title,
        description: raw.description,
        date: raw.created_at,
        link: raw.web_url,
        thumbnail: raw.author.avatar_url ? raw.author.avatar_url : null,
        imageIsAvatar: raw.author.avatar_url ? true : false
    };
    if (!item.imageIsAvatar) {
        var text = raw.author.name;

        if (text.length > 2) {
            var split = text.split(' ');
            text = '';

            for (var j = 0; j < split.length && j < 3; j++) {
                if (split[j] && split[j][0]) text += split[j][0];
            }
        }

        item.thumbnail = 'https://app.adenin.com/avatar/' + text;
        item.imageIsAvatar = true;
    }

    items.push(item);
  }
  
  var user = await fetch('https://gitlab.com/api/v4/user', { 
    'credentials': 'omit',
    headers: {    
      'Authorization': 'Bearer ' + request._token
    }
  });
  user = await user.json();
    
  var model = {
	title: 'Open Issues',
	thumbnail: 'https://www.adenin.com/assets/images/wp-images/logo/gitlab.svg',
	actionable: false,
	link: 'https://gitlab.com/dashboard/issues?assignee_username=' + user.username,
	linkLabel: 'All Issues',
	value: value,
	items: items,
	_card: {
	    title: 'Open Issues',
	    type: 'status-list'
	}
  };

  return model;
}

```

# Gitlab test

Testing Gitlab PKCE connector
