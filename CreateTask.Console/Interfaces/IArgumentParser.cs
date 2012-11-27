using System.Collections.Generic;
using CreateTask.Entities;

namespace CreateTask.Interfaces
{
  public interface IArgumentParser
  {
    string GetSubject(string[] inputstringWithRandomArgs);
    IList<string> GetOptions(string[] args);
  }
}