using CreateTask.Entities;

namespace CreateTask.Interfaces
{
  public interface ITaskManager
  {
    string CommandLineSwitch { get; }
    string FriendlyName { get; }
    int Order { get; }
    void CreateTask(ITaskDTO taskData);
  }
}