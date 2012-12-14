using System;
using System.Diagnostics;
using CreateTask.Interfaces;
using CreateTask.Logic;
using StructureMap;

namespace CreateTask.Config
{
  public static class ContainerBootstrapper
  {
    public static void BootstrapStructureMap(string[] args) {
      ObjectFactory.Initialize(
        init =>
          {
            init.Scan(scan =>
                        {
                          scan.AssembliesFromApplicationBaseDirectory();
                          scan.AddAllTypesOf<ITaskManager>();
                        });


            //x.ForRequestedType<ITaskManager>().TheDefaultIsConcreteType<OutlookTaskManager>();
            //init.For<ITaskManager>().Use(a => a.GetAllInstances<ITaskManager>().First());
            init.For<IArgumentParser>().Use<ArgumentParser>();
            init.For<IOptionsParser>().Use<OptionsParser>().Ctor<string[]>("options").Is(args).Ctor<DateTime>(
              "currentDate").Is(DateTime.Today);
          }
        );
      Debug.Write(ObjectFactory.WhatDoIHave());
    }
  }
}