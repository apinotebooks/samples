```html {"run_on_load":true}

  <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js"></script>

  <div x-data="{myForData: sourceData}">
    <table class="table">
      <thead>
        <tr>          
          <th>Name</th>
          <th>Salary</th>
        </tr>
      </thead>
      <template x-for="item in myForData" :key="item">
        <tbody>
          <tr>
            <td x-text="item.employee_name"></td>
            <td x-text="'$'+item.employee_salary"></td>
          </tr>
        </tbody>
      </template>
    </table>
  </div>

  <script>
    var sourceData = [
      {
        id: "1",
        employee_name: "Tiger Nixon",
        employee_salary: 3208,
        employee_age: 61,
        profile_image: "https://randomuser.me/api/portraits/men/1.jpg",
      },
      {
        id: "2",
        employee_name: "Garrett Winters",
        employee_salary: 1787.50,
        employee_age: 63,
        profile_image: "https://randomuser.me/api/portraits/men/2.jpg",
      }
    ];
  </script>
```