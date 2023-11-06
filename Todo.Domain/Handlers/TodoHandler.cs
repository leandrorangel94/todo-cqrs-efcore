using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
  class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>
  {

    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
      _repository = repository;
    }
    public ICommandResult Handle(CreateTodoCommand command)
    {
      // Fail Fast Validation
      command.Validate();
      if (command.Invalid)
        return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

      //Save TODO on SQL

      //Notify user
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
      throw new NotImplementedException();
    }
  }
}