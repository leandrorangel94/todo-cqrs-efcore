using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
  [ApiController]
  [Route("v1/todos")]
  public class TodoController : ControllerBase
  {
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
      [FromServices] ITodoRepository repository
    )
    {
      return repository.GetAll("leandrorangel");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetAllDone(user);
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetByPeriod("leandrorangel", true, DateTime.Now.Date);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetByPeriod("leandrorangel", true, DateTime.Now.Date.AddDays(1));
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetAllUndone(user);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetByPeriod("leandrorangel", false, DateTime.Now.Date);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
      [FromServices] ITodoRepository repository
    )
    {
      var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return repository.GetByPeriod("leandrorangel", false, DateTime.Now.Date.AddDays(1));
    }


    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
      [FromBody] CreateTodoCommand command,
      [FromServices] TodoHandler handler
    )
    {
      command.User = "leandrorangel";
      return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone(
           [FromBody] MarkTodoAsDoneCommand command,
           [FromServices] TodoHandler handler
       )
    {
      command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone(
           [FromBody] MarkTodoAsDoneCommand command,
           [FromServices] TodoHandler handler
       )
    {
      command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
      return (GenericCommandResult)handler.Handle(command);
    }
  }
}