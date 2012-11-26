using System;
using CreateTask.Entities;
using Xunit;

namespace CreateTask.Console.UnitTests.Entites
{
  public class TaskDtoTests
  {

    [Fact]
    public void TaskDtoShouldConainProperties()
    {
      DateTime startDate = DateTime.Parse("1974-03-25 03:12");
      DateTime dueDate = DateTime.Parse("2012-11-08 11:12");

      TaskDTO t = new TaskDTO();
      t.Subject = "Go do X";
      t.StartDate = startDate;
      t.DueDate = dueDate;

      Assert.Equal("Go do X", t.Subject);
      Assert.Equal(startDate, t.StartDate);
      Assert.Equal(dueDate, t.DueDate);
    }

  }
}
