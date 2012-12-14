using System.Collections.Generic;
using CreateTask.Interfaces;
using CreateTask.Logic;
using Moq;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class PatternMatcherUnitTests
  {
    private static List<ITaskManager> SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers() {
      var taskManagers = new List<ITaskManager>();

      var outlookTaskManager = new Mock<ITaskManager>();
      outlookTaskManager.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
      outlookTaskManager.SetupGet(tm => tm.Order).Returns(100);
      outlookTaskManager.SetupGet(tm => tm.FriendlyName).Returns("Outlook Task Manager");

      var trelloTaskManager = new Mock<ITaskManager>();
      trelloTaskManager.SetupGet(tm => tm.CommandLineSwitch).Returns("-trello");
      trelloTaskManager.SetupGet(tm => tm.Order).Returns(1);
      trelloTaskManager.SetupGet(tm => tm.FriendlyName).Returns("Trello Task Manager");

      taskManagers.Add(outlookTaskManager.Object);
      taskManagers.Add(trelloTaskManager.Object);
      return taskManagers;
    }


    [Fact]
    public void GetMatchingProvider_DefaultManager_IsSelected_WhenNotMatch() {
      var args = new[] {"Eat", "my", "kittens", "-tm", "-rtm", "-p"};

      List<ITaskManager> taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Outlook Task Manager", selectedTaskManager.FriendlyName);
    }

    [Fact]
    public void GetMatchingProvider_TrelloManager_IsSelected_WhenTrelloExactMatch() {
      var args = new[] {"Eat", "my", "kittens", "-tm", "-trello", "-p"};
      List<ITaskManager> taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();
      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Trello Task Manager", selectedTaskManager.FriendlyName);
    }

    [Fact]
    public void
      GetMatchingProvider_DefaultManager_IsSelected_WhenThereIsMultipleTaskManagers_ButTheOthersHaveHigherOrderValues() {
      var args = new[] {"Eat", "my", "kittens", "-tm", "-h", "-p"};

      List<ITaskManager> taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

      var fakeTM = new Mock<ITaskManager>();
      fakeTM.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
      fakeTM.SetupGet(tm => tm.Order).Returns(101);
      fakeTM.SetupGet(tm => tm.FriendlyName).Returns("Fake Task Manager");

      taskManagers.Add(fakeTM.Object);

      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Outlook Task Manager", selectedTaskManager.FriendlyName);
    }

    [Fact]
    public void
      GetMatchingProvider_DefaultManager_IsNotSelected_WhenThereIsMultipleTaskManagers_ButTheOthersHaveHigherOrderValues
      () {
      var args = new[] {"Eat", "my", "kittens", "-tm", "-h", "-p"};

      List<ITaskManager> taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

      var fakeTM = new Mock<ITaskManager>();
      fakeTM.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
      fakeTM.SetupGet(tm => tm.Order).Returns(99);
      fakeTM.SetupGet(tm => tm.FriendlyName).Returns("Fake Task Manager");

      taskManagers.Add(fakeTM.Object);

      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Fake Task Manager", selectedTaskManager.FriendlyName);
    }
  }
}