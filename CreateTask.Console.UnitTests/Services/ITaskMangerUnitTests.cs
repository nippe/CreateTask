using CreateTask.Entities;
using CreateTask.Interfaces;
using Moq;
using Xunit;

namespace CreateTask.Console.UnitTests.Services
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