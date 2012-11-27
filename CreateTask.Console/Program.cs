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
      IOptionsParser optionParser = new OptionsParser(argumentParser.GetOptions(args));
      ITaskBuilder taskBuilder = new TaskBuilder(args, argumentParser, optionParser);

      ITaskDTO taskDto = taskBuilder.CreateTask();

      taskManager.CreateTask(taskDto);
    }
  }
}
