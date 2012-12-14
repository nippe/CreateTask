using System.Collections.Generic;

namespace CreateTask.Interfaces
{
  public interface IArgumentParser
  {
    string GetSubject(string[] inputstringWithRandomArgs);
    IList<string> GetOptions(string[] args);
  }
}