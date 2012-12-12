using System;
using System.Collections.Generic;
using CreateTask.Interfaces;
using System.Linq;

namespace CreateTask.Logic
{
  public class ProviderMatcher
  {
    public static bool IsMatch(string[] args, string pattern) {
      foreach (string option in args) {
        if(string.Compare(option, pattern, StringComparison.OrdinalIgnoreCase)==0) {
          return true;
        }
      }
      return false;
    }


    public static ITaskManager GetMatchingTaskManager(string[] args, IList<ITaskManager> taskManagers) {
      foreach (string option in args) {
        ITaskManager matchingTaskManager =
          taskManagers.FirstOrDefault(tm => string.Compare(tm.CommandLineSwitch, option, StringComparison.OrdinalIgnoreCase) == 0);
        if (matchingTaskManager != null) {
          return matchingTaskManager;
        }
      }

      return taskManagers.Where(t => t.CommandLineSwitch == "*").OrderBy(tm => tm.Order).First();
    }
  }
}