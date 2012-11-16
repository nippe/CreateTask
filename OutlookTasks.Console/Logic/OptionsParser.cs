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

    public OptionsParser(IList<string> options) {
      _dateHelper = new DateHelper(DateTime.Today);
      _options = options;

      ParseOptions();
    }

    public OptionsParser(List<string> options, DateTime currentDate) : this(options) {
      _dateHelper = new DateHelper(currentDate);
      _currentDate = currentDate;
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
    }


    public DateTime DueDate {
      get { return _dueDate; }
    }
  }
}