namespace CreateTask.TaskManagers.Trello
{
  public class Badges
  {
    public int votes { get; set; }
    public bool viewingMemberVoted { get; set; }
    public bool subscribed { get; set; }
    public string fogbugz { get; set; }
    public int checkItems { get; set; }
    public int checkItemsChecked { get; set; }
    public int comments { get; set; }
    public int attachments { get; set; }
    public bool description { get; set; }
    public object due { get; set; }
  }
}