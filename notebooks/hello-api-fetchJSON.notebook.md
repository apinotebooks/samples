```javascript worker {"run_on_load":true}

// prototype to debug fetchJSON
async function fetchJSON_(url, options) {
  
   var response = await fetch(url, options);

   // todo: add error handling

  var json = await response.json();

  return json;
  
}

async function handleRequest(request) {

   // use httpbin to generate a dynamic response
   var json = await fetchJSON(`https://httpbin.org/get?name=world`, { 
    'credentials': 'omit'
  });

  var response = { name: json.args.name };
  
  return response;
}

```