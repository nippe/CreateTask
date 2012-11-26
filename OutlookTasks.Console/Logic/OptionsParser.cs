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
    private IList<string> _tags = new List<string>();
     
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
      ParseTags();
    }

    private void ParseTags() {
      if(_options.Contains("-p")) {
        _tags.Add(Constants.TagNames.Personal);
      }

      if(_options.Contains("-b") || _options.Contains("-w")) {
        _tags.Add(Constants.TagNames.Business);
      }

      if(_options.Contains("-f")) {
        _tags.Add(Constants.TagNames.Family);
      }

      if(_options.Contains("-h")) {
        _tags.Add(Constants.TagNames.House);
      }

      if(_options.Contains("-i")) {
        _tags.Add(Constants.TagNames.Information);
      }

      if(_options.Contains("-t")) {
        _tags.Add(Constants.TagNames.TravelTime);
      }





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
      else if (_options.Contains("-feb")) {
        _dueDate = GetFirstDayInGivenMonth(Month.February);
      }
      else if (_options.Contains("-mar")) {
        _dueDate = GetFirstDayInGivenMonth(Month.March);
      }
      else if (_options.Contains("-apr")) {
        _dueDate = GetFirstDayInGivenMonth(Month.April);
      }
      else if (_options.Contains("-may") || _options.Contains("-maj")) {
        _dueDate = GetFirstDayInGivenMonth(Month.May);
      }
      else if (_options.Contains("-jun")) {
        _dueDate = GetFirstDayInGivenMonth(Month.June);
      }
      else if (_options.Contains("-jul")) {
        _dueDate = GetFirstDayInGivenMonth(Month.July);
      }
      else if (_options.Contains("-aug")) {
        _dueDate = GetFirstDayInGivenMonth(Month.August);
      }
      else if (_options.Contains("-sep")) {
        _dueDate = GetFirstDayInGivenMonth(Month.September);
      }
      else if (_options.Contains("-oct") || _options.Contains("-okt")) {
        _dueDate = GetFirstDayInGivenMonth(Month.October);
      }
      else if (_options.Contains("-nov")) {
        _dueDate = GetFirstDayInGivenMonth(Month.November);
      }
      else if (_options.Contains("-dec")) {
        _dueDate = GetFirstDayInGivenMonth(Month.December);
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

    public IList<string> Tags {
      get { return _tags; }
    }
  }

  public enum Month{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November= 11,
    December = 12
  }
}