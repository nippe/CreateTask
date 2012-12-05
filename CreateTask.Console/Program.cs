using System;
using System.Diagnostics;
using CreateTask.Config;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;
using StructureMap;

namespace CreateTask
{
  class Program
  {
    static void Main(string[] args)
    {
      ContainerBootstrapper.BootstrapStructureMap(args);

      IContainer container = ObjectFactory.Container;
      IArgumentParser argumentParser = ObjectFactory.GetInstance<IArgumentParser>();
      IOptionsParser optionParser = ObjectFactory.GetInstance<IOptionsParser>();

      ITaskBuilder taskBuilder = new TaskBuilder(args, argumentParser, optionParser);
      ITaskDTO taskDto = taskBuilder.CreateTask();

      var taskManagers = container.GetAllInstances<ITaskManager>();

      foreach (ITaskManager taskManager in taskManagers) {
        if(taskManager.GetType().ToString().Contains("Trello")) {
          if( argumentParser.GetOptions(args).Contains("-trello")) {
            taskManager.CreateTask(taskDto);                       
          }
        }
        else {
          if (!argumentParser.GetOptions(args).Contains("-trello")) {
            taskManager.CreateTask(taskDto);
          }
        }
      }
    }
  }
}
