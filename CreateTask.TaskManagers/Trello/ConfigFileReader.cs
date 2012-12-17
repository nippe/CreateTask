using System.IO;
using System.Xml.Linq;

namespace CreateTask.TaskManagers.Trello
{
  internal class ConfigFileReader
  {
    private readonly XDocument confDoc;
    private readonly string configFile;
    private readonly string key_idList = "idList";
    private readonly string key_key = "key";
    private readonly string key_token = "token";

    public ConfigFileReader(string configFile) {
      if (File.Exists(configFile + ".user")) {
        this.configFile = configFile + ".user";
      }
      else {
        this.configFile = configFile;
      }

      if (File.Exists(this.configFile) == false) {
        var newFile = new XDocument(new XDeclaration("1.0", "utf-8", ""),
                                    new XElement("TrelloConfig",
                                                 new XElement(key_key, ""),
                                                 new XElement(key_token, ""),
                                                 new XElement(key_idList, "")
                                      )
          );
        newFile.Save(this.configFile);
      }
      confDoc = XDocument.Load(this.configFile);
    }

    public string IdList {
      get {
        EnsureElementValueExists(key_idList);
        return confDoc.Root.Element(key_idList).Value;
      }
    }

    public string Key {
      get {
        EnsureElementValueExists(key_key);
        return confDoc.Root.Element(key_key).Value;
      }
    }

    public string Token {
      get { return confDoc.Root.Element(key_token).Value; }
    }

    private void EnsureElementValueExists(string elementName) {
      if (string.IsNullOrEmpty(confDoc.Root.Element(elementName).Value)) {
        string newKey = string.Empty;
        InputBox.Show(elementName + " missing",
                      string.Format("Hi there, we're missing your {0} for Trello. Please enter it below.", elementName),
                      ref newKey);
        confDoc.Root.Element(elementName).Value = newKey;
        confDoc.Save(configFile);
      }
    }

    public void WriteToken(string newToken) {
      confDoc.Root.Element("token").Value = newToken;
      confDoc.Save(configFile);
    }
  }
}