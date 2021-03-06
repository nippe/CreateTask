using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CreateTask.Entities;
using CreateTask.Interfaces;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Exception = System.Exception;

namespace CreateTask.TaskManagers
{
  public class OutlookTaskManager : ITaskManager
  {
    #region ITaskManager Members

    public void CreateTask(ITaskDTO taskData) {
      NameSpace ns = null;

      try {
        var application = new Application();
        ns = application.GetNamespace("mapi");
        ns.Logon("Outlook", Missing.Value, false, true);

        var task = application.CreateItem(OlItemType.olTaskItem) as TaskItem;

        if (task != null) {
          task.Assign();
          task.Subject = taskData.Subject;
          task.DueDate = taskData.DueDate;
          task.StartDate = taskData.DueDate;
          task.Categories = string.Join(";", taskData.Tags.ToArray());
          task.Importance = GetOutlookPriority(taskData.Importance);
          task.Save();
        }
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
      finally {
        if (ns != null) {
          ns.Logoff();
        }
      }
    }


    public string CommandLineSwitch {
      get { return "*"; }
    }

    public string FriendlyName {
      get { return "Microsoft Outlook Task Manager"; }
    }

    public int Order {
      get { return 100; }
    }

    #endregion

    private OlImportance GetOutlookPriority(TaskPriority importance) {
      switch (importance) {
        case TaskPriority.High:
          return OlImportance.olImportanceHigh;
          break;
        case TaskPriority.Low:
          return OlImportance.olImportanceLow;
          break;
        default:
          return OlImportance.olImportanceNormal;
      }
    }
  }
}