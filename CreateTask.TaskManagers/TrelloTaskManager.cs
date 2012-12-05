using System;
using System.Collections.Generic;
using System.Globalization;
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
        string token = "e61f7ea5c20d09c59f956c92423f7571587ad1674df9ed8cc57ab5f5eb9e6f1e";
        string idList = "4ff02e8d3692811f7a60c058";

        RestClient client = new RestClient("https://api.trello.com/1");

        IRestRequest createCardRequest = new RestRequest(TrelloConfig.Resourse_Cards);
        createCardRequest.Method = Method.POST;
        createCardRequest.AddParameter(TrelloConfig.ParameterNames.Name, td.Subject);               
        createCardRequest.AddParameter(TrelloConfig.ParameterNames.IdList, TrelloConfig.ListId);
        createCardRequest.AddParameter(TrelloConfig.ParameterNames.Key, key);
        createCardRequest.AddParameter(TrelloConfig.ParameterNames.Token, token);

        var createResponse = client.Execute<TrelloCard>(createCardRequest);
        TrelloCard card = createResponse.Data;

        IRestRequest addLabelsRequest = new RestRequest(
          string.Format("{0}/{1}{2}", 
            TrelloConfig.Resourse_Cards, 
            card.id, 
            TrelloConfig.Resourse_Labels)
        );
        addLabelsRequest.Method = Method.POST;
        addLabelsRequest.AddParameter(TrelloConfig.ParameterNames.Value, "orange");
        addLabelsRequest.AddParameter(TrelloConfig.ParameterNames.Key, key);
        addLabelsRequest.AddParameter(TrelloConfig.ParameterNames.Token, token);
        var labelResult = client.Execute(addLabelsRequest);

        IRestRequest dueDateReq = new RestRequest(string.Format("{0}/{1}/due", TrelloConfig.Resourse_Cards, card.id));
        dueDateReq.Method = Method.PUT;
        dueDateReq.AddParameter(TrelloConfig.ParameterNames.Key, key);
        dueDateReq.AddParameter(TrelloConfig.ParameterNames.Token, token);
        dueDateReq.AddParameter(TrelloConfig.ParameterNames.Value, td.DueDate.ToString(CultureInfo.InvariantCulture)); 

        var dueResp = client.Execute(dueDateReq);

        
        //RestClient client = new RestClient(TrelloConfig.TrelloBaseUrl);

        //IRestRequest createCardRequest = new RestRequest(TrelloConfig.Resourse_Cards);
        //createCardRequest.Method = Method.POST;
        //createCardRequest.RequestFormat = DataFormat.Json;
        //createCardRequest.AddParameter("name", td.Subject);
        //createCardRequest.AddParameter("idList", idList);
        ////createCardRequest.AddParameter("due", td.DueDate); // Available at create?
        //createCardRequest.AddParameter("key", key);
        //createCardRequest.AddParameter("token", token);

        //var createResponse = client.Execute<TrelloCard>(createCardRequest);
        //TrelloCard card = createResponse.Data;  


        //IRestRequest addLabelsRequest = new RestRequest(string.Format("{0}/{1}/{2}", TrelloConfig.Resourse_Cards, card.id, "lables"));
        //addLabelsRequest.AddParameter("value", "orange");
        //addLabelsRequest.AddParameter("key", key);
        //addLabelsRequest.AddParameter("token", token);

        //client.Execute(addLabelsRequest);

        ////Add labels


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
