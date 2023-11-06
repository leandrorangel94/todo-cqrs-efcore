using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
  interface ITodoRepository
  {
    void Create(TodoItem todo);
    void Update(TodoItem todo);
  }
}