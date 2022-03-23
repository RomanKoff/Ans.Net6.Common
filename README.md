# Ans.Net6.Common

## Classes


#### ConsoleMenu

Sample:

```csharp
var menu = new ConsoleMenu("Menu title");
menu.Add(new ConsoleMenuItem(ConsoleKey.D1, "Action 1 title", Action1));
menu.Release();
```
 

#### DateTimeHelper

Constructor:

```csharp
DateTimeHelper()
```

Properties:

```csharp
DateTime Current { get; } // текущая дата и время
DateTime CurrentYearBegin { get; } // дата начала текущего года
DateTime NextYearBegin { get; } // дата начала следующего года
DateTime Today { get; } // дата сегодня
DateTime Yesterday { get; } // дата вчера
DateTime Tomorrow { get; } // дата завтра
DateTime TomorrowAfter { get; } // дата послезавтра
```

Methods:

```csharp
string GetPassed(
	DateTime datetime,
	bool hasTime,
	bool allowYesterdayTodayTomorrow = true)
```
Возвращает дату (и время) события (для блога)

|--|--|--|
| значение | ru | en |
|--|--|--|
| будет в будущих годах | `d MMMM yyyy г.[ в H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
| будет в этом году | `d MMMM[ в H:mmmm]` | `MMMM d[ at h:mmmm]` |
| завтра | `завтра[ в H:mmmm]` | `Tomorrow[ at h:mmmm]` |
| сегодня | `сегодня[ в H:mmmm]` | `Today[ at h:mmmm]` |
| вчера | `вчера[ в H:mmmm]` | `Yesterday[ в H:mmmm]` |
| было в этом году | `d MMMM[ в H:mmmm]` | `MMMM d[ at h:mmmm]` |
| было в прошлые годы | `d MMMM yyyy г.[ в H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
|--|--|--|
