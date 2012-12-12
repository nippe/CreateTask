using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateTask.Interfaces;
using CreateTask.Logic;
using Moq;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class PatternMatcherUnitTests
  {


    private static List<ITaskManager> SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers()
    {
      List<ITaskManager> taskManagers = new List<ITaskManager>();

      Mock<ITaskManager> outlookTaskManager = new Moq.Mock<ITaskManager>();
      outlookTaskManager.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
      outlookTaskManager.SetupGet(tm => tm.Order).Returns(100);
      outlookTaskManager.SetupGet(tm => tm.FriendlyName).Returns("Outlook Task Manager");

      Mock<ITaskManager> trelloTaskManager = new Moq.Mock<ITaskManager>();
      trelloTaskManager.SetupGet(tm => tm.CommandLineSwitch).Returns("-trello");
      trelloTaskManager.SetupGet(tm => tm.Order).Returns(1);
      trelloTaskManager.SetupGet(tm => tm.FriendlyName).Returns("Trello Task Manager");

      taskManagers.Add(outlookTaskManager.Object);
      taskManagers.Add(trelloTaskManager.Object);
      return taskManagers;
    }


  
    [Fact]
    public void GetMatchingProvider_DefaultManager_IsSelected_WhenNotMatch() {
      string[] args = new string[] { "Eat", "my", "kittens", "-tm", "-rtm", "-p" };
      
      var taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Outlook Task Manager", selectedTaskManager.FriendlyName);
    }

    [Fact]
    public void GetMatchingProvider_TrelloManager_IsSelected_WhenTrelloExactMatch() {
      string[] args = new string[] { "Eat", "my", "kittens", "-tm", "-trello", "-p" };
      var taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();
      ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);

      Assert.Equal("Trello Task Manager", selectedTaskManager.FriendlyName);
    }

   [Fact]
    public void GetMatchingProvider_DefaultManager_IsSelected_WhenThereIsMultipleTaskManagers_ButTheOthersHaveHigherOrderValues() {
      string[] args = new string[] { "Eat", "my", "kittens", "-tm", "-h", "-p" };
     
     var taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

     Mock<ITaskManager> fakeTM = new Moq.Mock<ITaskManager>();
     fakeTM.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
     fakeTM.SetupGet(tm => tm.Order).Returns(101);
     fakeTM.SetupGet(tm => tm.FriendlyName).Returns("Fake Task Manager");

     taskManagers.Add(fakeTM.Object);
     
     ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);
     
      Assert.Equal("Outlook Task Manager", selectedTaskManager.FriendlyName);
    }

   [Fact]
    public void GetMatchingProvider_DefaultManager_IsNotSelected_WhenThereIsMultipleTaskManagers_ButTheOthersHaveHigherOrderValues() {
      string[] args = new string[] { "Eat", "my", "kittens", "-tm", "-h", "-p" };
     
     var taskManagers = SetupTaskManagerListWithOutlookDefaultAndTrelloTaskManagers();

     Mock<ITaskManager> fakeTM = new Moq.Mock<ITaskManager>();
     fakeTM.SetupGet(tm => tm.CommandLineSwitch).Returns("*");
     fakeTM.SetupGet(tm => tm.Order).Returns(99);
     fakeTM.SetupGet(tm => tm.FriendlyName).Returns("Fake Task Manager");

     taskManagers.Add(fakeTM.Object);
     
     ITaskManager selectedTaskManager = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);
     
      Assert.Equal("Fake Task Manager", selectedTaskManager.FriendlyName);
    }

 
  }
}
