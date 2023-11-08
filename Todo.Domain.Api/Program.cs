using Microsoft.EntityFrameworkCore;
using Todo.Domain.Infra.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
// builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
