using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateTask.Logic;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class DateHelperTests
  {
    [Fact]
    public void DefaultConstructor_Should_Set_CurrentDate_To_Today() {
      DateHelper dh = new DateHelper();

      Assert.Equal(DateTime.Today, dh.CurrentDate);
    }
  }
}
