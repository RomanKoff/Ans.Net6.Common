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
DateTime Current { get; } // ������� ���� � �����
DateTime CurrentYearBegin { get; } // ���� ������ �������� ����
DateTime NextYearBegin { get; } // ���� ������ ���������� ����
DateTime Today { get; } // ���� �������
DateTime Yesterday { get; } // ���� �����
DateTime Tomorrow { get; } // ���� ������
DateTime TomorrowAfter { get; } // ���� �����������
```

Methods:

```csharp
string GetPassed(
	DateTime datetime,
	bool hasTime,
	bool allowYesterdayTodayTomorrow = true)
```
���������� ���� (� �����) ������� (��� �����)

|--|--|--|
| �������� | ru | en |
|--|--|--|
| ����� � ������� ����� | `d MMMM yyyy �.[ � H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
| ����� � ���� ���� | `d MMMM[ � H:mmmm]` | `MMMM d[ at h:mmmm]` |
| ������ | `������[ � H:mmmm]` | `Tomorrow[ at h:mmmm]` |
| ������� | `�������[ � H:mmmm]` | `Today[ at h:mmmm]` |
| ����� | `�����[ � H:mmmm]` | `Yesterday[ � H:mmmm]` |
| ���� � ���� ���� | `d MMMM[ � H:mmmm]` | `MMMM d[ at h:mmmm]` |
| ���� � ������� ���� | `d MMMM yyyy �.[ � H:mmmm]` | `MMMM d, yyyy[ at h:mmmm]` |
|--|--|--|
