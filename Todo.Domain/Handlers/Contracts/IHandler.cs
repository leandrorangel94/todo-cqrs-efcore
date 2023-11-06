using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
  interface IHandler<T> where T : ICommand
  {
    void Handle(ICommand command);
  }
}