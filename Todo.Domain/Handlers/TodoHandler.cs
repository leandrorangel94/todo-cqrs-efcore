using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
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

      //Gera o Todo Item
      var todo = new TodoItem(command.Title, command.User, command.Date);

      //Notify user
      _repository.Create(todo);

      //Retorna o resultado
      return new GenericCommandResult(true, "Tarefa salva!", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
      throw new NotImplementedException();
    }
  }
}