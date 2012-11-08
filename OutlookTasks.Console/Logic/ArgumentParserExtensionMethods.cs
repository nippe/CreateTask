using System.Collections.Generic;

namespace OutlookTasks.Console.Logic
{
  public static class ArgumentParserExtensionMethods
  {
    public static bool NotPrefixed(this string value) {
      IList<string> prefixCharacters = new List<string> {"@", "-"};
      return prefixCharacters.Contains( value.Substring(0, 1)) == false;
    }
  }
}