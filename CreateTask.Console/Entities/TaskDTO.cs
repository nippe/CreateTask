using System;
using System.Collections.Generic;

namespace CreateTask.Entities
{
  public interface ITaskDTO
  {
    string Subject { get; set; }
    DateTime StartDate { get; set; }
    DateTime DueDate { get; set; }
    IList<string> Tags { get; set; }
  }

  public class TaskDTO : ITaskDTO
  {
    public string Subject { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public IList<string> Tags { get; set; }
  }
}