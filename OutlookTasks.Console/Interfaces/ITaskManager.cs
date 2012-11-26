using CreateTask.Entities;

namespace CreateTask.Interfaces
{
  public interface ITaskManager
  {
    void CreateTask(ITaskDTO td);
  }
}
