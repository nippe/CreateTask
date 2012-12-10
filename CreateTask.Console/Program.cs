using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using CreateTask.Config;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;
using StructureMap;

namespace CreateTask
{
  class Program
  {
    static void Main(string[] args)
    {
      ContainerBootstrapper.BootstrapStructureMap(args);

      IContainer container = ObjectFactory.Container;
      var taskManagers = container.GetAllInstances<ITaskManager>();

      if(ShouldUsageBeShown(args)) {
        ShowUsage(taskManagers);
        return;
      }

      IArgumentParser argumentParser = ObjectFactory.GetInstance<IArgumentParser>();
      IOptionsParser optionParser = ObjectFactory.GetInstance<IOptionsParser>();

      ITaskBuilder taskBuilder = new TaskBuilder(args, argumentParser, optionParser);
      ITaskDTO taskDto = taskBuilder.CreateTask();

      foreach (ITaskManager taskManager in taskManagers) {
        if(taskManager.GetType().ToString().Contains("Trello")) {
          if( argumentParser.GetOptions(args).Contains("-trello")) {
            taskManager.CreateTask(taskDto);                       
          }
        }
        else {
          if (!argumentParser.GetOptions(args).Contains("-trello")) {
            taskManager.CreateTask(taskDto);
          }
        }
      }
    }

    private static void ShowUsage(IEnumerable<ITaskManager> taskManagers) {
      StringBuilder sb = new StringBuilder();

      sb.AppendLine("ct.exe <subject> [options]");
      sb.AppendLine();

      sb.AppendLine("Date options:");
      sb.AppendLine("\t-td\t\t - Today");
      sb.AppendLine("\t-tm\t\t - Tomorrow");
      sb.AppendLine("\t-tw\t\t - This Week");
      sb.AppendLine("\t-nw\t\t - Next Week");
      sb.AppendLine("\t-mo/-må\t\t - Monday");
      sb.AppendLine("\t-tu/-ti\t\t - Tuesday");
      sb.AppendLine("\t-we/-on\t\t - Wednesday");
      sb.AppendLine("\t-th/-to\t\t - Thursday");
      sb.AppendLine("\t-fr\t\t - Friday");
      sb.AppendLine("\t-sa/-lö\t\t - Saturday");
      sb.AppendLine("\t-su/-sö\t\t - Sunday");
      

      sb.AppendLine("");
      sb.AppendLine("Available Task Managers:");
      foreach (ITaskManager taskManager in taskManagers) {
        sb.Append("\t");
        sb.AppendLine(taskManager.GetType().ToString());
      }
      MessageBox.Show(sb.ToString());
    }

    private static bool ShouldUsageBeShown(string[] args) {
      foreach (string s in args) {
        if(string.Compare(s, "-help", StringComparison.OrdinalIgnoreCase) == 0 ||
          string.Compare(s, "--help", StringComparison.OrdinalIgnoreCase) == 0 ||
          string.Compare(s, "-?", StringComparison.OrdinalIgnoreCase) == 0 ||
          string.Compare(s, "/?", StringComparison.OrdinalIgnoreCase) == 0) {
          return true;
        }
      }
      return false;
    }
  }
}
