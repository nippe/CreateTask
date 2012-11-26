using System.Reflection;
using System.Windows.Forms;
using CreateTask.Entities;
using CreateTask.Interfaces;
using Microsoft.Office.Interop.Outlook;
using Application = Microsoft.Office.Interop.Outlook.Application;

namespace CreateTask.Logic
{
  public class OutlookTaskManager : ITaskManager
  {
    public void CreateTask(ITaskDTO taskData) {
      NameSpace ns = null;

      try {
        Application application = new Application();
        ns = application.GetNamespace("mapi");
        ns.Logon("Outlook", Missing.Value, false, true);

        TaskItem task = application.CreateItem(OlItemType.olTaskItem) as TaskItem;

        if(task != null) {
          task.Assign();
          task.Subject = taskData.Subject;
          task.DueDate = taskData.DueDate;
          task.StartDate = taskData.DueDate;
          task.Save();
        }
      } catch(System.Exception ex) {
        MessageBox.Show(ex.Message);
      }
      finally {
        if (ns != null) {
          ns.Logoff();
        }
      }
    }
  }
}
