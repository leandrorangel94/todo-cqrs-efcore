using Todo.Domain.Handlers;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.HandlerTests
{
  [TestClass]
  public class CreateTodoHandlerTests
  {
    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
      var command = new CreateTodoCommand("", "", DateTime.Now);
      var handler = new TodoHandler(null);
      Assert.Fail();
    }

    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_tarefa()
    {
      Assert.Fail();
    }
  }
}