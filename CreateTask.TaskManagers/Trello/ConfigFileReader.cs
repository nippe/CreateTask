using System.Xml.Linq;

namespace CreateTask.TaskManagers.Trello
{
  internal class ConfigFileReader
  {
    private XDocument confDoc;

    public ConfigFileReader(string configFile) {
      confDoc = XDocument.Load(configFile);
    }

    public string IdList {
      get {return confDoc.Root.Element("idList").Value; }
    }

    public string Key {
      get { return confDoc.Root.Element("key").Value; }
    }

    public string Token {
      get { return confDoc.Root.Element("token").Value; }
    }
  }
}