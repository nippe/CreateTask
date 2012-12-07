using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
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

      IRestResponse<TrelloCard> createResponse = CreateCard(taskData, client);

      if (createResponse.StatusCode == HttpStatusCode.Unauthorized) {
        Process.Start(
          string.Format(
            "https://trello.com/1/authorize?key={0}&name=CreateTask&expiration=1day&response_type=token&scope=read,write",
            TrelloConfig.Key));

        string newToken = null;
        if (
          InputBox.Show("Token not valid", "Allow the new token in your webbrowser and paste it in here.", ref newToken) ==
          DialogResult.OK) {
          TrelloConfig.WriteToken(newToken);
          createResponse = CreateCard(taskData, client);
        }
        else {
          MessageBox.Show("Exiting CreateTask", "Exiting", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      TrelloCard card = createResponse.Data;
      string label = "orange"; //Un-prioratized
      var labelResult = AddLabelToCard(card, label, client);

      foreach (string tag in taskData.Tags) {
        string labelColor = TrelloLabelToColorMapper.MapColor(tag);
        AddLabelToCard(card, labelColor, client);
      }

      IRestRequest dueDateReq = new RestRequest(string.Format("{0}/{1}/due", TrelloConfig.Resourses.Cards, card.id));
      dueDateReq.Method = Method.PUT;
      SetKeyAndTokenParametersOnRequest(dueDateReq);
      dueDateReq.AddParameter(TrelloConfig.ParameterNames.Value, taskData.DueDate.ToString(CultureInfo.InvariantCulture));

      IRestResponse dueResp = client.Execute(dueDateReq);

      //TODO: Verify status else throw exception
    }

    private IRestResponse AddLabelToCard(TrelloCard card, string label, RestClient client) {
      IRestRequest addLabelsRequest = new RestRequest(
        string.Format("{0}/{1}{2}",
                      TrelloConfig.Resourses.Cards,
                      card.id,
                      TrelloConfig.Resourses.Labels)
        );

      addLabelsRequest.Method = Method.POST;
      addLabelsRequest.AddParameter(TrelloConfig.ParameterNames.Value, label);
      SetKeyAndTokenParametersOnRequest(addLabelsRequest);
      IRestResponse labelResult = client.Execute(addLabelsRequest);
      return labelResult;
    }

    #endregion

    private IRestResponse<TrelloCard> CreateCard(ITaskDTO taskData, RestClient client) {
      IRestRequest createCardRequest = new RestRequest(TrelloConfig.Resourses.Cards);
      createCardRequest.Method = Method.POST;
      createCardRequest.AddParameter(TrelloConfig.ParameterNames.Name, taskData.Subject);
      createCardRequest.AddParameter(TrelloConfig.ParameterNames.IdList, TrelloConfig.ListId);
      SetKeyAndTokenParametersOnRequest(createCardRequest);

      IRestResponse<TrelloCard> createResponse = client.Execute<TrelloCard>(createCardRequest);
      return createResponse;
    }

    private void SetKeyAndTokenParametersOnRequest(IRestRequest request) {
      request.AddParameter(TrelloConfig.ParameterNames.Key, TrelloConfig.Key);
      request.AddParameter(TrelloConfig.ParameterNames.Token, TrelloConfig.Token);
    }
  }
}