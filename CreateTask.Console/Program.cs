using System;
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
      //ITaskManager taskManager = ObjectFactory.GetInstance<ITaskManager>();
      IArgumentParser argumentParser = ObjectFactory.GetInstance<IArgumentParser>();
      IOptionsParser optionParser = ObjectFactory.GetInstance<IOptionsParser>();

      ITaskBuilder taskBuilder = new TaskBuilder(args, argumentParser, optionParser);

      ITaskDTO taskDto = taskBuilder.CreateTask();

      var taskManagers = container.GetAllInstances<ITaskManager>();

      foreach (ITaskManager taskManager in taskManagers) {
        taskManager.CreateTask(taskDto);           
      }
    }
  }
}
