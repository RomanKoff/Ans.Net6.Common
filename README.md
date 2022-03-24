# Ans.Net6.Common


## Extensions 

```csharp
// string
string TrimEnd(this string source, string trimString)
string GetFirstUpper(this string source, bool forcedToLower)
string GetFirstLower(this string source, bool forcedToUpper)
string GetStartWithACapital(this string source, CultureInfo cultureInfo)
string GetStartWithACapital(this string source)
string GetScreening(this string source, 	string mask)
string GetScreeningW(this string source, string mask)
string GetReScreening(this string source, string mask)
string GetLeft(this string source, char find)
string GetLeft(this string source, string find)
string GetLeft(this string source, int count)
string GetRight(this string source, char find)
string GetRight(this string source, string find)
string GetRight(this string source, int count)
string GetBackTo(this string source, char find, int skip = 0)
string GetCrop(this string source, int startIndex, int length, string beginCropMask, string endCropMask)
string GetSafeText(this string source)
string GetTag(this string source, string before, string after, StringComparison comparisonType = StringComparison.InvariantCulture)
string GetTagAndCut(this string source, string before, string after, StringComparison comparisonType = StringComparison.InvariantCulture)
string GetReplaceRecursively(this string source, string oldText, string newText)
string GetReplaceSpecChars(this string source)
```



## Supports

```csharp
// SuppString
string SuppString.Join(string templateResult, string templateItem, string itemsSeparator, params string[] data)
string SuppString.Join(string templateResult, string templateItem, string itemsSeparator, string data, string dataSeparator)
KeyValuePair<string, string> SuppString.GetPair(string definition, string separator)
KeyValuePair<string, string> SuppString.GetPair(string definition)

// SuppRegex
string SuppRegex.ParamEncode(	string source)
```


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

| значение | формат ru | формат en |
|--|--|--|
| будет в будущих годах | `d MMMM yyyy г.[ в H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
| будет в этом году | `d MMMM[ в H:mmmm]` | `MMMM d[ at h:mmmm]` |
| завтра | `завтра[ в H:mmmm]` | `Tomorrow[ at h:mmmm]` |
| сегодня | `сегодня[ в H:mmmm]` | `Today[ at h:mmmm]` |
| вчера | `вчера[ в H:mmmm]` | `Yesterday[ в H:mmmm]` |
| было в этом году | `d MMMM[ в H:mmmm]` | `MMMM d[ at h:mmmm]` |
| было в прошлые годы | `d MMMM yyyy г.[ в H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
