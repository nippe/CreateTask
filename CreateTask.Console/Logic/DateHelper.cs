using System;

namespace CreateTask.Logic
{
  public class DateHelper
  {
    private DateTime currentDate;

    public DateHelper() {
      currentDate = DateTime.Today;
    }

    public DateHelper(DateTime CurrentDate) {
      currentDate = CurrentDate;
    }

    public DateTime CurrentDate {
      get { return currentDate;}
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

    public DateTime GetNextTuesday() {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Tuesday));
    }

    public DateTime GetNextWednsday() {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Wednesday));
    }

    public DateTime GetNextThursday()
    {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Thursday));
    }

    public DateTime GetNextFriday()
    {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Friday));
    }

    public DateTime GetNextSaturday()
    {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Saturday));
    }

    public DateTime GetNextSunday()
    {
      return currentDate.AddDays(NumberOfDayToNext(DayOfWeek.Sunday));
    }




    private double NumberOfDayToNext(DayOfWeek dayOfWeek)
    {
      int faktor = 7;
      if (currentDate.DayOfWeek < dayOfWeek)
      {
        faktor = 0;
      }
      return (faktor - (double)currentDate.DayOfWeek + (double)dayOfWeek);
    }


    
  }
}