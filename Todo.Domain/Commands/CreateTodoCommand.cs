using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  class CreateTodoCommand : Notifiable, ICommand
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
      AddNotifications(
          new Contract()
              .Requires()
              .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
              .HasMinLen(User, 6, "User", "Usuário inválido!")
      );
    }
  }
}