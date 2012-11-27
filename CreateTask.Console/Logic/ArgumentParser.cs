using System.Collections.Generic;
using System.Text;
using CreateTask.Entities;
using CreateTask.Interfaces;

namespace CreateTask.Logic
{
  public class ArgumentParser : IArgumentParser
  {
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

    public IList<string> GetOptions(string[] args) {
      IList<string> options = new List<string>();
      
      //TODO: Refactor to COnstans/COnfiguration static...
      IList<string> prefixCharacters = new List<string> { "@", "-" };

      for (int i = 0; i < args.Length; i++) {
        if(prefixCharacters.Contains(args[i].Substring(0,1))) {
          options.Add(args[i]);
        }
      }

      return options;
    }
  }
}