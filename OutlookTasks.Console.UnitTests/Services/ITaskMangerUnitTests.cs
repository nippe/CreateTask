using System;
using Moq;
using OutlookTasks.Console.Entities;
using OutlookTasks.Console.Interfaces;
using Xunit;

namespace OutlookTasks.Console.UnitTests.Services
{
  public class ITaskMangerUnitTests
  {
    [Fact]
    public void ITaskManager_Should_Implement_Create_Method() {
      var tm = new Mock<ITaskManager>();
      ITaskDTO td = new TaskDTO();
      tm.Object.CreateTask(td);

      Assert.True(true);
    }
  }
}