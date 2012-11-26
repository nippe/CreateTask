using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlookTasks.Console.Entities;

namespace OutlookTasks.Console.Interfaces
{
  public interface ITaskManager
  {
    void CreateTask(ITaskDTO td);
  }
}
