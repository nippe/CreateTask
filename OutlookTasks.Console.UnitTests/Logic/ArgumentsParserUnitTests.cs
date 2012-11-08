﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlookTasks.Console.Logic;
using Xunit;

namespace OutlookTasks.Console.UnitTests.Logic
{
  public class ArgumentsParserUnitTests
  {
    private string inputstringWithRandomArgs = "Go shopping for milk -td -p @pers @p";

    [Fact]
    public void ParseSubject_Should_Return_Everything_Not_Prefiexed()
    {
      ArgumentsParser argumentsParser = new ArgumentsParser();

      string subject = argumentsParser.GetSubject(inputstringWithRandomArgs.Split(' '));

      Assert.Equal("Go shopping for milk", subject);

    }

  }
}