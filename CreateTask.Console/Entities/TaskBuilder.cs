using CreateTask.Interfaces;

namespace CreateTask.Entities
{
  public class TaskBuilder : ITaskBuilder
  {
    private readonly string[] _args;
    private readonly IArgumentParser _argumentsParser;
    private readonly IOptionsParser _optionsParser;

    public TaskBuilder(string[] inputArguments, IArgumentParser argumentParser, IOptionsParser optionsParser) {
      _args = inputArguments;
      _argumentsParser = argumentParser;
      _optionsParser = optionsParser;
    }

    #region ITaskBuilder Members

    public ITaskDTO CreateTask() {
      return new TaskDTO
               {
                 DueDate = _optionsParser.DueDate,
                 Subject = _argumentsParser.GetSubject(_args),
                 Tags = _optionsParser.Tags
               };
    }

    #endregion
  }
}