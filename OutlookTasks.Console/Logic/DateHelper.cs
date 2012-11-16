using System;

namespace OutlookTasks.Console.Logic
{
  public class DateHelper
  {
    private DateTime currentDate;

    public DateHelper() {
    }

    public DateHelper(DateTime CurrentDate) {
      currentDate = CurrentDate;
    }

    public DateTime GetLastDayOfNextWeek() {
      return currentDate.AddDays(14 - (int) (currentDate.DayOfWeek));
    }

    public DateTime GetLastDateOfWeek() {
      return currentDate.AddDays(7 - (int)(currentDate.DayOfWeek));
    }
  }
}