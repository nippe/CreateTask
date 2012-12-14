using System;
using System.Collections.Generic;
using CreateTask.Entities;
using CreateTask.Interfaces;
using Moq;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class TaaskBuilderUnitTests
  {
    private string[] args = "Köp soffa till sovrummet -p -tm".Split(' ');

    [Fact]
    public void CreateTask_ReturnsCorrect_DueDateAndSubjectAndTags() {
      string[] args = "Köp vin till festen -p -tm".Split(' ');

      var argumentsParserMock = new Mock<IArgumentParser>();
      argumentsParserMock.Setup(a => a.GetSubject(It.IsAny<string[]>())).Returns("Köp vin till festen");

      var optionsParserMock = new Mock<IOptionsParser>();
      optionsParserMock.SetupGet(o => o.DueDate).Returns(DateTime.Parse("2012-11-16"));
      optionsParserMock.SetupGet(o => o.Tags).Returns(new List<string> {"Personal"});

      ITaskBuilder tb = new TaskBuilder(args, argumentsParserMock.Object, optionsParserMock.Object);

      ITaskDTO task = tb.CreateTask();

      Assert.Equal(DateTime.Parse("2012-11-16"), task.DueDate);
      Assert.Equal("Köp vin till festen", task.Subject);
      argumentsParserMock.VerifyAll();
      optionsParserMock.VerifyAll();
    }
  }
}