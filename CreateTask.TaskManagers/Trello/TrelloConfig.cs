﻿namespace CreateTask.TaskManagers.Trello
{
  internal class TrelloConfig
  {
    private static ConfigFileReader _configFileReader = null;
    private static string ConfigFile = "TrelloConfig.xml";

    internal static string TrelloBaseUrl = "https://api.trello.com/1";

    public static string ListId {
      get {
        return LocalConfigFileReader.IdList;
      }
    }

    protected static ConfigFileReader LocalConfigFileReader {
      get { 
        if(_configFileReader == null) {
          _configFileReader = new ConfigFileReader(ConfigFile);
        }
        return _configFileReader;
      }
    }

    public static string Key {
      get { return new ConfigFileReader(ConfigFile).Key; }
    }

    public static string Token {
      get { return new ConfigFileReader(ConfigFile).Token; }
    }

    #region Nested type: ParameterNames

    internal static class ParameterNames
    {
      internal static string Key = "key";
      internal static string Token = "token";
      internal static string Value = "value";
      internal static string IdList = "idList";

      internal static string Name = "name";
    }

    #endregion

    #region Nested type: Resourses

    internal static class Resourses
    {
      internal static string Cards = "/cards";
      internal static string Labels = "/labels";
    }

    #endregion

    public static void WriteToken(string newToken) {
      new ConfigFileReader(ConfigFile).WriteToken(newToken);
    }
  }
}