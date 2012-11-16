using System;
using System.Collections.Generic;

namespace OutlookTasks.Console.Logic
{
  public class OptionsParser
  {
    private IList<string> _options;
    private DateTime _dueDate = DateTime.Today;

    public OptionsParser(IList<string> options) {
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
    }

    public DateTime DueDate {
      get { return _dueDate; }
    }
  }
}