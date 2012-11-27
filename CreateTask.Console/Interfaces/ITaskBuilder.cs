using CreateTask.Entities;

namespace CreateTask.Interfaces
{
  public interface ITaskBuilder
  {
    ITaskDTO CreateTask();
  }
}