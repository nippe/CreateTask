using System;
using System.Collections.Generic;

namespace CreateTask.Interfaces
{
  public interface IOptionsParser
  {
    DateTime DueDate { get; }
    IList<string> Tags { get; }
  }
}