using System;

namespace OutlookTasks.Console.Entities
{
  public interface ITaskDTO
  {
    string Subject { get; set; }
    DateTime StartDate { get; set; }
    DateTime DueDate { get; set; }
  }

  public class TaskDTO : ITaskDTO
  {
    public string Subject { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
  }
}