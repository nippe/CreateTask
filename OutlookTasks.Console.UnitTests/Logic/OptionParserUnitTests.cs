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

      [Fact]
      public void MoFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-mo"});

        Assert.Equal(DateTime.Parse("2012-11-19"), optionsParser.DueDate);
      }


      [Fact]
      public void MFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-m"});

        Assert.Equal(DateTime.Parse("2012-11-19"), optionsParser.DueDate);
      }


      [Fact]
      public void TuFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-tu"});

        Assert.Equal(DateTime.Parse("2012-11-20"), optionsParser.DueDate);
      }


      [Fact]
      public void TiFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-tu"});

        Assert.Equal(DateTime.Parse("2012-11-20"), optionsParser.DueDate);
      }


      [Fact]
      public void WeFlag_ShouldReturn_ComingMonday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-we"});

        Assert.Equal(DateTime.Parse("2012-11-21"), optionsParser.DueDate);
      }
      
      [Fact]
      public void OnFlag_ShouldReturn_ComingWdnesday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-on"});

        Assert.Equal(DateTime.Parse("2012-11-21"), optionsParser.DueDate);
      }


      [Fact]
      public void ToFlag_ShouldReturn_ComingThursday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-to"});

        Assert.Equal(DateTime.Parse("2012-11-22"), optionsParser.DueDate);
      }
      
      [Fact]
      public void ThFlag_ShouldReturn_ComingThursday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-th"});

        Assert.Equal(DateTime.Parse("2012-11-22"), optionsParser.DueDate);
      }


      [Fact]
      public void FrFlag_ShouldReturn_ComingFriday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-fr"});

        Assert.Equal(DateTime.Parse("2012-11-23"), optionsParser.DueDate);
      }
      
     [Fact]
      public void SaFlag_ShouldReturn_ComingMSaturday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-sa"});

        Assert.Equal(DateTime.Parse("2012-11-24"), optionsParser.DueDate);
      }


     [Fact]
      public void LöFlag_ShouldReturn_ComingSaturday() {
        DateTime dateOfExecuting = DateTime.Parse("2012-11-16");
        OptionsParser optionsParser = new OptionsParser(new List<string>{"-lö"});

        Assert.Equal(DateTime.Parse("2012-11-24"), optionsParser.DueDate);
      }


      

    }
  }
}
