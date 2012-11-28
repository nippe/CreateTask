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
        x =>
          {
            x.ForRequestedType<ITaskManager>().TheDefaultIsConcreteType<OutlookTaskManager>();
            x.For<IArgumentParser>().Use<ArgumentParser>();
            x.For<IOptionsParser>().Use<OptionsParser>().Ctor<string[]>("options").Is(args).Ctor<DateTime>("currentDate").Is(DateTime.Today);
          }
        );
      Debug.Write(ObjectFactory.WhatDoIHave());
    }
  }
}