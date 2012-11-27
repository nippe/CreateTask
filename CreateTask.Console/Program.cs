using System;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;

namespace CreateTask
{
  class Program
  {
    static void Main(string[] args)
    {
      ITaskManager taskManager = new OutlookTaskManager();
      IArgumentParser argumentParser = new ArgumentParser();

      string subject = argumentParser.GetSubject(args);
      var options = argumentParser.GetOptions(args);
      var optionParser = new OptionsParser(options);



      TaskDTO taskDto;

      //taskManager.CreateTask(taskDto);
    }
  }
}
