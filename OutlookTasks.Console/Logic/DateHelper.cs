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

    public DateTime GetNextMonday() {
      return currentDate.AddDays( NumberOfDayToNext(DayOfWeek.Monday));
    }



    private static double NumberOfDayToNext(DayOfWeek dayOfWeek)
    {
      int faktor = 7;
      if (DateTime.Today.DayOfWeek < dayOfWeek)
      {
        faktor = 0;
      }
      return (faktor - (double)DateTime.Today.DayOfWeek + (double)dayOfWeek);
    }
  }
}