using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlookTasks.Console.Logic;
using Xunit;

namespace OutlookTasks.Console.UnitTests.Logic
{
  class OptionParserUnitTests
  {
    public class DateTests
    {
      [Fact] 
      public void TodayFlag_ShouldReturn_TodaysDate() {
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-td"});
        Assert.Equal(DateTime.Today, optionsParser.DueDate);
      }

      [Fact]
      public void TmFlag_shouldRetrun_TomorrowsDate() {
        OptionsParser optionsParser = new OptionsParser(new List<string> { "-tm" });
        Assert.Equal(DateTime.Today.AddDays(1), optionsParser.DueDate);
      }


    }
  }
}
