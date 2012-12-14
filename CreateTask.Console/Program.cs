using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CreateTask.Config;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;
using StructureMap;

namespace CreateTask
{
  internal class Program
  {
    private static void Main(string[] args) {
      ContainerBootstrapper.BootstrapStructureMap(args);

      IContainer container = ObjectFactory.Container;
      IList<ITaskManager> taskManagers = container.GetAllInstances<ITaskManager>();

      if (ShouldUsageBeShown(args)) {
        ShowUsage(taskManagers);
        return;
      }

      var argumentParser = ObjectFactory.GetInstance<IArgumentParser>();
      var optionParser = ObjectFactory.GetInstance<IOptionsParser>();

      ITaskBuilder taskBuilder = new TaskBuilder(args, argumentParser, optionParser);
      ITaskDTO taskDto = taskBuilder.CreateTask();
      bool taskCreated = false;

      ITaskManager taskManagerToRun = ProviderMatcher.GetMatchingTaskManager(args, taskManagers);
      taskManagerToRun.CreateTask(taskDto);
    }

    private static void ShowUsage(IEnumerable<ITaskManager> taskManagers) {
      var sb = new StringBuilder();

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

      sb.AppendLine("\t-jan\t\t - January");
      sb.AppendLine("\t-feb\t\t - February");
      sb.AppendLine("\t-mar\t\t - March");
      sb.AppendLine("\t-apr\t\t - April");
      sb.AppendLine("\t-may/-maj\t - May");
      sb.AppendLine("\t-jun\t\t - June");
      sb.AppendLine("\t-jul\t\t - July");
      sb.AppendLine("\t-aug\t\t - August");
      sb.AppendLine("\t-sep\t\t - September");
      sb.AppendLine("\t-oct/-okt\t\t - October");
      sb.AppendLine("\t-nov\t\t - November");
      sb.AppendLine("\t-dec\t\t - December");


      sb.AppendLine("");
      sb.AppendLine("Available Task Managers:");
      foreach (ITaskManager taskManager in taskManagers) {
        sb.Append("\t");
        sb.AppendLine(taskManager.FriendlyName);
      }
      MessageBox.Show(sb.ToString());
    }

    private static bool ShouldUsageBeShown(string[] args) {
      foreach (string s in args) {
        if (string.Compare(s, "-help", StringComparison.OrdinalIgnoreCase) == 0 ||
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