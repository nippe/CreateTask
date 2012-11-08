using System;

namespace OutlookTasks.Console.Entities
{
  public class TaskDTO
  {
    public string Subject { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
  }
}