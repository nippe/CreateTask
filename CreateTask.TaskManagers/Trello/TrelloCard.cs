using System.Collections.Generic;

namespace CreateTask.TaskManagers.Trello
{
  public class TrelloCard
  {
    public string id { get; set; }
    public Badges badges { get; set; }
    public List<object> checkItemStates { get; set; }
    public bool closed { get; set; }
    public string desc { get; set; }
    public object due { get; set; }
    public string idBoard { get; set; }
    public List<object> idChecklists { get; set; }
    public string idList { get; set; }
    public List<object> idMembers { get; set; }
    public int idShort { get; set; }
    public object idAttachmentCover { get; set; }
    public bool manualCoverAttachment { get; set; }
    public List<object> labels { get; set; }
    public string name { get; set; }
    public int pos { get; set; }
    public string url { get; set; }
  }
}