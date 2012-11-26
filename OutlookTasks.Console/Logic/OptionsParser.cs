using System;
using System.Collections.Generic;

namespace OutlookTasks.Console.Logic
{
  public class OptionsParser
  {
    private IList<string> _options;
    private DateTime _dueDate = DateTime.Today;
    private DateTime _currentDate = DateTime.Today;
    private readonly DateHelper _dateHelper;

    public OptionsParser(IList<string> options) : this(options, DateTime.Today) {
    }

    public OptionsParser(IList<string> options, DateTime currentDate) {
      _dateHelper = new DateHelper(currentDate);
      _currentDate = currentDate;
      _options = options;

      ParseOptions();
    }

    private void ParseOptions() {
      ParseDueDate();
    }

    private void ParseDueDate() {
      if(_options.Contains("-tm")) {
        _dueDate = DateTime.Today.AddDays(1);
      }
      else if(_options.Contains("-tw")) {
        _dueDate = _dateHelper.GetLastDateOfWeek();
      }
      else if(_options.Contains("-nw")) {
        _dueDate = _dateHelper.GetLastDayOfNextWeek();
      }
      else if (_options.Contains("-mo") || _options.Contains("-m")) {
        _dueDate = _dateHelper.GetNextMonday();
      }
      else if (_options.Contains("-tu") || _options.Contains("-ti"))
      {
        _dueDate = _dateHelper.GetNextTuesday();
      }
      else if (_options.Contains("-we") || _options.Contains("-on"))
      {
        _dueDate = _dateHelper.GetNextWednsday();
      }
      else if (_options.Contains("-to") || _options.Contains("-th"))
      {
        _dueDate = _dateHelper.GetNextThursday();
      }
      else if (_options.Contains("-fr"))
      {
        _dueDate = _dateHelper.GetNextFriday();
      }
      else if (_options.Contains("-sa") || _options.Contains("-lö"))
      {
        _dueDate = _dateHelper.GetNextSaturday();
      }      
      else if (_options.Contains("-su") || _options.Contains("-sö"))
      {
        _dueDate = _dateHelper.GetNextSunday();
      }
      else if (_options.Contains("-jan")) {
        _dueDate = GetFirstDayInGivenMonth(Month.January);
      }
    }

    private DateTime GetFirstDayInGivenMonth(Month month) {
      int year = _currentDate.Year;
      
      if (_currentDate.Month < (int)month)
      {
        //this year
      }
      else {
        //Next year
        year++;
      }

      return new DateTime(year, (int)month, 1);
    }


    public DateTime DueDate {
      get { return _dueDate; }
    }
  }

  public enum Month{
    January = 1
  }
}