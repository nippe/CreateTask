using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;
using CreateTask.TaskManagers.Trello;
using RestSharp;

namespace CreateTask.TaskManagers
{
    public class TrelloTaskManager : ITaskManager
    {
      public void CreateTask(ITaskDTO td) {
        string key = "1b6f97cd8ec872ec8eb61347acc2de5d";
        string token = "cefe47b41c70db104e5f2b5ad31fb9d0a70cc17a2cbb1028d4f0e0cd8b03163b";
        string idList = "4ff02e8d3692811f7a60c058";

        
        RestClient client = new RestClient(TrelloConfig.TrelloBaseUrl);

        IRestRequest createCardRequest = new RestRequest(TrelloConfig.Resourse_Cards);
        createCardRequest.Method = Method.POST;
        createCardRequest.RequestFormat = DataFormat.Json;
        createCardRequest.AddParameter("name", td.Subject);
        createCardRequest.AddParameter("idList", idList);
        //createCardRequest.AddParameter("due", td.DueDate); // Available at create?
        createCardRequest.AddParameter("key", key);
        createCardRequest.AddParameter("token", token);

        var createResponse = client.Execute<TrelloCard>(createCardRequest);
        TrelloCard card = createResponse.Data;  


        IRestRequest addLabelsRequest = new RestRequest(string.Format("{0}/{1}/{2}", TrelloConfig.Resourse_Cards, card.id, "lables"));
        addLabelsRequest.AddParameter("value", "orange");
        addLabelsRequest.AddParameter("key", key);
        addLabelsRequest.AddParameter("token", token);

        client.Execute(addLabelsRequest);

        //Add labels


      }
    }



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
