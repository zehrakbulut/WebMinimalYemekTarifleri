using WebMinimalYemekTarifleri.Model;
using WebMinimalYemekTarifleri.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRecipeService, RecipeService>();

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

app.UseHttpsRedirection();

app.MapGet("api/recipe", (IRecipeService recipeService) =>
{
    return Results.Ok(recipeService.GetAll());
});

app.MapPost("api/recipe/", async (IRecipeService recipeService, Recipe recipeItem) =>
{
    var createdToDoItem = recipeService.Create(recipeItem);
    return Results.Created($"/api/todo{createdToDoItem.Id}", createdToDoItem);
});

app.MapGet("api/recipe/{id}", (IRecipeService recipeService, int id) =>
{
    var todoItem = recipeService.GetById(id);
    if (todoItem == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todoItem);
});

app.MapPut("api/recipe/{id}", async (IRecipeService recipeService, int id, Recipe updateTodoItem) =>
{
    recipeService.Update(id, updateTodoItem);
    return Results.NoContent();
});

app.MapDelete("api/recipe/{id}", async (IRecipeService recipeService, int id) =>
{
    recipeService.Delete(id);
    return Results.NoContent();
});

app.Run();


