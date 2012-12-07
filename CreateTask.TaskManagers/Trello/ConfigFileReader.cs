using System.IO;
using System.Xml.Linq;

namespace CreateTask.TaskManagers.Trello
{
  internal class ConfigFileReader
  {
    private readonly XDocument confDoc;
    private readonly string configFile;

    public ConfigFileReader(string configFile) {
      if (File.Exists(configFile + ".user")) {
        this.configFile = configFile + ".user";
      }
      else {
        this.configFile = configFile;
      }
      confDoc = XDocument.Load(this.configFile);
    }

    public string IdList {
      get { return confDoc.Root.Element("idList").Value; }
    }

    public string Key {
      get { return confDoc.Root.Element("key").Value; }
    }

    public string Token {
      get { return confDoc.Root.Element("token").Value; }
    }

    public void WriteToken(string newToken) {
      confDoc.Root.Element("token").Value = newToken;
      confDoc.Save(configFile);
    }
  }
}