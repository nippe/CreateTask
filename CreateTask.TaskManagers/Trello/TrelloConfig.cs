using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTask.TaskManagers.Trello
{
  class TrelloConfig
  {
    internal static string TrelloBaseUrl = "https://api.trello.com/1";
    internal static string Resourse_Cards = "/cards";
    internal static string Resourse_Labels = "/labels";

    internal static class ParameterNames
    {
      internal static string Key = "key";
      internal static string Token = "token";
      internal static string Value = "value";
      internal static string IdList = "idList";

      internal static string Name = "name";
    }

    public static string ListId {
      get { return "4fd610aeacd4c77f791fbb1c"; }
    }
  }
}
