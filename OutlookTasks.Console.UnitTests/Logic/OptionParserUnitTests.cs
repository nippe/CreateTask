using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlookTasks.Console.Logic;
using Xunit;

namespace OutlookTasks.Console.UnitTests.Logic
{
  public class OptionParserUnitTests
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

      [Fact]
      public void TwFlag_ShoudReturn_LastDayOfWeek_SE() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");        
        OptionsParser optionsParser = new OptionsParser(new List<string> { "-tw" }, dateOfExecuting);

        DateTime expectedLastDayOfWeek = DateTime.Parse("2012-11-18");

        Assert.Equal(expectedLastDayOfWeek, optionsParser.DueDate);
      }

      [Fact]
      public void NwFlag_ShoudReturn_LastDayOfNextWeek_SE()
      {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string> { "-nw" }, dateOfExecuting);
        DateTime expectedLastDayOfWeek = DateTime.Parse("2012-11-25");

        Assert.Equal(expectedLastDayOfWeek, optionsParser.DueDate);
      }

    }
  }
}
