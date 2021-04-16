```javascript worker

async function handleRequest(request) {
    var response = request;
    response.step1 = true;
    return response;
}

```
```javascript worker

async function handleRequest(request) {
    var response = request;
    response.step2 = true;
    return response;
}
```