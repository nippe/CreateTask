using System;
using CreateTask.Logic;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class DateHelperTests
  {
    [Fact]
    public void DefaultConstructor_Should_Set_CurrentDate_To_Today() {
      var dh = new DateHelper();

      Assert.Equal(DateTime.Today, dh.CurrentDate);
    }
  }
}