```javascript worker {"run_on_load":true}

async function handleRequest(request) {

   // use httpbin to generate a dynamic response
   var response = await fetch(`https://httpbin.org/get?name=world`, { 
    'credentials': 'omit'
  });

  var json = await response.json();
  
  var response = { name: json.args.name };
  
  return response;
}

```