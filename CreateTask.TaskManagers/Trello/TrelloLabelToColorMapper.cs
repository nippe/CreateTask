using System;

namespace CreateTask.TaskManagers.Trello
{
  public class TrelloLabelToColorMapper
  {
    public static string MapColor(string tag) {
      if(string.Compare(tag, "Personal", StringComparison.OrdinalIgnoreCase) == 0) {
        return "green";
      }

      if (string.Compare(tag, "Business", StringComparison.OrdinalIgnoreCase) == 0)
      {
        return "blue";
      }

      if (string.Compare(tag, "Hus", StringComparison.OrdinalIgnoreCase) == 0)
      {
        return "yellow";
      }

      return string.Empty;
    }
  }
}