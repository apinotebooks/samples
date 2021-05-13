```javascript connector
async function handleRequest(request) {

    let items = [
        {
            title: 'Leave status',
            description: '200 hours total, 80 hours remaining, 12 hours planned',
            total_allowance: '200',
            charitable_leave_allowance: '8',
            remaining_allowance: '80',
            planned_allowance: '12',
            remaining_public_holiday_count: '16'
        }
    ];

    var response = {};
    response.items = items;
    response.title = 'PTO Status';
    response.link = 'https://www.adenin.com/pocdef';
    response.linkLabel = 'Request PTO';
    response.actionable = false;
    response.thumbnail = 'https://www.adenin.com/assets/images/wp-images/logo/workday.svg';

    response._card = {
      type: 'status-list'
    };
  
    return response;
}

```

# PTO Status

See your current personal time off allowance, including planned time

## Benefits

Get an at-a-glance view of your current personal time off allowance, including planned time. Use the handy shortcut buttons to quickly create a new leave request.

## Utterances

1. Show (me) (my) (PTO|leave|time off) (allowance|status)
2. Show (me) (my) remaining (PTO|leave|time off)
3. How much PTO do I have (left)?

# Audience
All

# Features
List

```json adaptive-card

```