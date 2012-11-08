using System.Collections.Generic;
using System.Text;
using OutlookTasks.Console.Entities;

namespace OutlookTasks.Console.Logic
{
  public class ArgumentsParser : IArgumentParser
  {
    public TaskDTO ParseCommands(string[] commandLineArguments) {
      return new TaskDTO();
    }

    public string GetSubject(string[] inputstringWithRandomArgs) {
      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < inputstringWithRandomArgs.Length; i++) {
        if (inputstringWithRandomArgs[i].NotPrefixed()) {
          sb.Append(inputstringWithRandomArgs[i]);
          sb.Append(" ");
        }
      }
      return sb.ToString().Trim();
    }
  }

  public static class ExtensionMethods
  {
    public static bool NotPrefixed(this string value) {
      List<string> prefixCharacters = new List<string>();
      prefixCharacters.Add("@");
      prefixCharacters.Add("-");

      return prefixCharacters.Contains( value.Substring(0, 1)) == false;
    }
  }

}