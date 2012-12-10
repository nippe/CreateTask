using CreateTask.Entities;

namespace CreateTask.Interfaces
{
  public interface ITaskManager
  {
    void CreateTask(ITaskDTO taskData);
    string CommandLineSwitch { get; }
    string FriendlyName { get; }
  }
}
