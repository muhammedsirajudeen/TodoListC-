var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


List<Todo> TodoList = new List<Todo>();


app.MapGet("/todolist", () =>
{
    return TodoList;

})
.WithName("GetTodoList")
.WithOpenApi();

app.MapPost("/todolist", (Todo todo) =>
{
    TodoList.Add(todo);
    return new HttpResponse("success", 200);
})
.WithName("PostTodoList")
.WithOpenApi();

app.MapPut("/todolist", (int id, Todo todo) =>
{
    int i;
    for (i = 0; i < TodoList.Count; i++)
    {
        if (TodoList[i].Id == id)
        {
            TodoList[i].Task = todo.Task;
            TodoList[i].Status = todo.Status;

        }
    }

    return new HttpResponse("success", 201);
})
.WithName("PutTodoList")
.WithOpenApi();


app.MapDelete("/todolist", (int id) =>
{
    for (int j = 0; j < TodoList.Count; j++)
    {
        if (id == TodoList[j].Id)
        {
            TodoList.RemoveAt(j);
        }
    }
    System.Console.WriteLine(id);
    return new HttpResponse("successfully deleted", 201);
})
.WithName("DeleteTodoList")
.WithOpenApi();


app.Run();



