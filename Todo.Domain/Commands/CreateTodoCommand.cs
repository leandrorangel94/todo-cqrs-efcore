using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  class CreateTodoCommand : ICommand
  {
    public string Title { get; set; }

    public string User { get; set; }
    public DateTime Date { get; set; }
    public CreateTodoCommand(DateTime date, string user, string title)
    {
      Title = title;
      User = user;
      Date = date;
    }

    public CreateTodoCommand()
    {
    }

    public void Validate()
    {
      throw new NotImplementedException();
    }
  }
}