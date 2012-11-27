using System.Collections.Generic;
using CreateTask.Entities;
using CreateTask.Interfaces;
using CreateTask.Logic;
using Xunit;

namespace CreateTask.Console.UnitTests.Logic
{
  public class ArgumentsParserUnitTests
  {
    private string inputstringWithRandomArgs = "Go shopping for milk -td -p @pers @p";

    [Fact]
    public void ParseSubject_Should_Return_Everything_Not_Prefiexed()
    {
      ArgumentParser argumentParser = new ArgumentParser();

      string subject = argumentParser.GetSubject(inputstringWithRandomArgs.Split(' '));
      
      Assert.Equal("Go shopping for milk", subject);
    }


    [Fact]
    public void ParseArguments_Sould_Return_EverythingPrefixed() {
      ArgumentParser argument = new ArgumentParser();
      IList<string> expectedOptions = new List<string>{"-td", "-p", "@pers", "@p"};

      IList<string> options = argument.GetOptions(inputstringWithRandomArgs.Split(' '));

      Assert.Equal(expectedOptions, options);
    }

   
  }
}
