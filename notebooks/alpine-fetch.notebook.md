```html {"run_on_load":true}

  <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js"></script>

  <div x-data="{users: []}"
       x-init="fetch('https://jsonplaceholder.typicode.com/users')
                      .then(response => response.json())
                      .then(data => users = data)">
       
    <table class="table">
      <thead>
        <tr>          
          <th>Name</th>
          <th>email</th>
        </tr>
      </thead>
      <template x-for="item in users" :key="item">
        <tbody>
          <tr>
            <td x-text="item.name"></td>
            <td x-text="item.email"></td>
          </tr>
        </tbody>
      </template>
    </table>
  </div>

```