---
_Scopes: User.Read Calendars.Read
_ClientId: 798429c7-66a7-462b-9bc7-88e124e680b0
_ProdToken: office-365
_AccessCodeServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/authorize
_AccessTokenServiceEndpoint: https://login.microsoftonline.com/common/oauth2/v2.0/token
ConnectorName: office-365
---

```javascript connector
async function handleRequest(request, context) {
  const timeZone =
    context && context.UserTimezone ? context.UserTimezone : "system";

  const now = new Date();

  const urlRegex =
    /(https?)\:\/\/[A-Za-z0-9\.\-]+(\/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*/gi;
  const specialCharRegex = /[^a-zA-z\s]/;

  const stripSpecialChars = (input) => {
    if (!input) return "";
    const index = input.search(specialCharRegex);
    if (index === -1) return input;
    return input.substring(0, index).trim();
  };

  const parseUrl = (text) => {
    text = text.replace(/\n|\r/g, " ");
    const matches = text.match(urlRegex);

    if (!matches || !matches.length) return null;

    for (let i = 0; i < matches.length; i++) {
      const match = matches[i];
      if (
        match.includes("webex") ||
        match.includes("gotomeet") ||
        match.includes("gotomeeting") ||
        match.includes("zoom") ||
        match.includes("skype") ||
        match.includes("teams")
      ) {
        return match;
      }
    }
    return matches[0];
  };

  const avatarLink = (text, email) => {
    const baseUrl = "https://app.adenin.com/";
    if (!text) return `${baseUrl}avatar`;

    if (text.length > 2) {
      const split = text.split(" ");
      text = "";

      for (let i = 0; i < split.length && i < 3; i++) {
        if (split[i] && split[i][0]) text += split[i][0];
      }
    }

    const platformAvatar = `${baseUrl}avatar/${encodeURIComponent(text)}`;

    if (
      !email ||
      (typeof email !== "string" && !(email instanceof String)) ||
      !/^[ -~]+$/.test(text)
    )
      return platformAvatar;

    const gravatarBaseUrl = "https://www.gravatar.com/avatar/";

    email = email.toLowerCase().trim();
    const hash = MD5(email);
    return `${gravatarBaseUrl}${hash}?s=192&d=${encodeURIComponent(
      platformAvatar
    )}`;
  };

  const convertItem = (raw) => {
    const item = {
      id: raw.id,
      title: raw.subject,
      link: raw.webLink,
      isCancelled: raw.isCancelled,
      isRecurring: raw.recurrence ? true : false,
    };

    item.description = raw.bodyPreview.replace(/\r/g, "");
    item.description = item.description.replace(/\n/g, "<br/>");

    item.startDate = dateConvertTimezone(
      raw.start.dateTime,
      raw.start.timeZone,
      timeZone
    );
    item.endDate = dateConvertTimezone(
      raw.end.dateTime,
      raw.end.timeZone,
      timeZone
    );

    const when = humanizeRelative(item.startDate);
    const duration = humanizeDuration(item.startDate, item.endDate);

    if (duration.includes("day")) {
      item.isAllDay = true;
      item.when = "Now";
    } else {
      item.when = when;
    }

    if (
      raw.location &&
      raw.location.coordinates &&
      raw.location.coordinates.latitude
    ) {
      item.location = {
        link: `https://www.google.com/maps/search/?api=1&query=${raw.location.coordinates.latitude},${raw.location.coordinates.longitude}`,
        title: raw.location.displayName,
      };
    } else if (raw.location.displayName && !raw.onlineMeetingUrl) {
      const url = parseUrl(raw.location.displayName);

      if (url !== null) {
        item.onlineMeetingUrl = url;
        item.location = null;
      }
    } else {
      item.location = null;
    }

    if (!item.onlineMeetingUrl) {
      const url = parseUrl(raw.body.content);

      if (url !== null) item.onlineMeetingUrl = url;
    }

    if (item.onlineMeetingUrl) {
      // parse out which type of meeting
      const providers = [
        { name: "Webex", match: "webex" },
        { name: "GoToMeeting", match: "gotomeet" },
        { name: "Zoom", match: "zoom" },
        { name: "Skype", match: "skype" },
        { name: "Microsoft Teams", match: "teams" },
      ];
      const provider = providers.find((p) =>
        item.onlineMeetingUrl.includes(p.match)
      );
      item.meetingType = provider.name;
    }

    if (raw.type == "occurrence") {
      item.recurring = true;
    }

    const organizerName = stripSpecialChars(raw.organizer.emailAddress.name);

    item.thumbnail = avatarLink(
      organizerName,
      raw.organizer.emailAddress.address
    );
    //item.thumbnail = 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg';
    item.imageIsAvatar = true;
    item.organizer = {
      avatar: item.thumbnail,
      email: raw.organizer.emailAddress.address,
      name: organizerName,
    };

    item.attendees = [];

    if (raw.attendees.length > 0) {
      for (let j = 0; j < raw.attendees.length; j++) {
        const attendeeName = stripSpecialChars(
          raw.attendees[j].emailAddress.name
        );
        const attendee = {
          email: raw.attendees[j].emailAddress.address,
          name: attendeeName,
          avatar: avatarLink(
            attendeeName,
            raw.attendees[j].emailAddress.address
          ),
          //avatar: 'https://www.adenin.com/assets/images/generated_photos/5e6801626d3b380006d3b82f-l.jpg'
        };

        if (attendee.email === item.organizer.email) {
          attendee.response = "organizer";
        } else if (raw.attendees[j].status.response !== "none") {
          attendee.response =
            raw.attendees[j].status.response === "accepted"
              ? "accepted"
              : "declined";
        }

        item.attendees.push(attendee);
      }
    } else {
      item.attendees = null;
    }

    switch (raw.responseStatus.response) {
      case "none":
        break;
      case "organizer":
        item.response = {
          status: "organizer",
        };
        break;
      default:
        item.response = {
          status:
            raw.responseStatus.response === "accepted"
              ? "accepted"
              : "declined",
          date: raw.responseStatus.time,
        };
    }

    return item;
  };

  let dayStart = new Date();
  dayStart.setHours(0);
  dayStart.setMinutes(0);
  dayStart.setSeconds(0);
  dayStart = dateToIsoUri(dayStart);

  let dayEnd = new Date();
  dayEnd.setHours(23);
  dayEnd.setMinutes(59);
  dayEnd.setSeconds(59);
  dayEnd = dateToIsoUri(dayEnd);

  const json = await fetchJSON(
    `https://graph.microsoft.com/v1.0/me/calendarView?startDateTime=${dayStart}&endDateTime=${dayEnd}`,
    {
      credentials: "omit",
      headers: {
        Authorization: "Bearer " + context.token,
      },
    }
  );

  if (json.error && json.error.message) {
    return {
      ErrorMessage: json.error.message,
      ErrorCode: json.error.code == "InvalidAuthenticationToken" ? 461 : 500,
    };
  }

  if (!json.value) {
    return {
      items: [],
    };
  }

  const response = {};
  let items = [];
  let pastCount = 0;
  let allDayCount = 0;

  for (let i = 0; i < json.value.length; i++) {
    const raw = json.value[i];

    if (raw.isCancelled) continue;

    const item = convertItem(raw);

    const startTime = new Date(
      dateConvertTimezone(raw.start.dateTime, raw.start.timeZone, timeZone)
    );
    const endTime = new Date(
      dateConvertTimezone(raw.end.dateTime, raw.end.timeZone, timeZone)
    );
    const halfAnHourAgo = new Date().setMinutes(now.getMinutes() - 30);

    if (
      (now.getDate() == startTime.getDate() || item.isAllDay) &&
      endTime > halfAnHourAgo
    ) {
      if (endTime < now) {
        pastCount++;
        item.isPast = true;
      }

      if (item.isAllDay) allDayCount++;

      items.push(item);
    }
  }

  items = items.sort((a, b) => new Date(a.startDate) - new Date(b.startDate));

  const value = items.length - pastCount;

  response.items = items;
  response.value = value;
  response.pastCount = pastCount;
  response.allDayCount = allDayCount;
  response.actionable = value > 0;

  if (value > 0) {
    let first;
    if (value > allDayCount) {
      // if there's other events than 'all day' ones, they get preference in the notification
      first = items[pastCount + allDayCount];
    } else {
      // else the first all day event goes into the notification
      first = items[pastCount];
    }

    response.description =
      value > 1 ? `You have ${value} events today.` : "You have 1 event today.";
    response.briefing = response.description;

    if (value > allDayCount) {
      response.briefing += ` The next is '${first.title}' ${humanizeRelative(
        first.startDate
      )}`;
    } else {
      response.briefing += ` The first is '${first.title}' which lasts all day`;
    }
  } else {
    response.description = "You have no events today.";
  }

  return response;
}
```

# Today's Events

See upcoming meetings, appointments, and events from your Office 365 connected apps

## Benefits

See upcoming meetings, appointments, and events from your Office 365 connected apps

## Utterances

1. Show me (my) upcoming (meetings|appointments|events)
2. When is my next meeting?

## Logo

![logo](/logos/today's events.png)

## Audience

All

## Features

Notification

## Configuration

- defaultHeight 2
- minHeight 1.5
- maxHeight 4

```json adaptive-card
{
  "type": "AdaptiveCard",
  "body": [
    {
      "type": "Container",
      "bleed": true
    }
  ],
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
  "version": "1.2"
}
```
