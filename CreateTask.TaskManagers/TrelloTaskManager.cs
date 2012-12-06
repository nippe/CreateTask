using System.Globalization;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.TaskManagers.Trello;
using RestSharp;

namespace CreateTask.TaskManagers
{
  public class TrelloTaskManager : ITaskManager
  {
    #region ITaskManager Members

    public void CreateTask(ITaskDTO taskData) {
      var client = new RestClient("https://api.trello.com/1");

      IRestRequest createCardRequest = new RestRequest(TrelloConfig.Resourses.Cards);
      createCardRequest.Method = Method.POST;
      createCardRequest.AddParameter(TrelloConfig.ParameterNames.Name, taskData.Subject);
      createCardRequest.AddParameter(TrelloConfig.ParameterNames.IdList, TrelloConfig.ListId);
      SetKeyAndTokenParametersOnRequest(createCardRequest);

      IRestResponse<TrelloCard> createResponse = client.Execute<TrelloCard>(createCardRequest);
      TrelloCard card = createResponse.Data;

      IRestRequest addLabelsRequest = new RestRequest(
        string.Format("{0}/{1}{2}",
                      TrelloConfig.Resourses.Cards,
                      card.id,
                      TrelloConfig.Resourses.Labels)
        );
      addLabelsRequest.Method = Method.POST;
      addLabelsRequest.AddParameter(TrelloConfig.ParameterNames.Value, "orange");
      SetKeyAndTokenParametersOnRequest(addLabelsRequest);
      IRestResponse labelResult = client.Execute(addLabelsRequest);

      IRestRequest dueDateReq = new RestRequest(string.Format("{0}/{1}/due", TrelloConfig.Resourses.Cards, card.id));
      dueDateReq.Method = Method.PUT;
      SetKeyAndTokenParametersOnRequest(dueDateReq);
      dueDateReq.AddParameter(TrelloConfig.ParameterNames.Value, taskData.DueDate.ToString(CultureInfo.InvariantCulture));

      IRestResponse dueResp = client.Execute(dueDateReq);

      //TODO: Verify status else throw exception
    }

    #endregion

    private void SetKeyAndTokenParametersOnRequest(IRestRequest request) {
      request.AddParameter(TrelloConfig.ParameterNames.Key, TrelloConfig.Key);
      request.AddParameter(TrelloConfig.ParameterNames.Token, TrelloConfig.Token);
    }
  }
}