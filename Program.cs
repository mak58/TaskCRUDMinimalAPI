using Microsoft.AspNetCore.Mvc;
using Minimal.Data;
using Minimal.Models;
using Minimal.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/v1/tasks", (AppDbContext context) => {    
    var tasks = context.
        Tasks.
        ToList();
    
    return tasks is null ? Results.BadRequest() : Results.Ok(tasks);
});

app.MapPost("v1/tasks", (
    AppDbContext context,
    [FromBody]CreateTasksViewModels model) => 
    {
        var tasks = model.MapTo();
        if (!model.IsValid)
            return Results.BadRequest(model.Notifications);

        context.Tasks.Add(tasks);
        context.SaveChanges();

        return Results.Created($"v1/tasks", tasks);
    });

app.MapPut("v1/editTasks/{id}", (
    [FromRoute] Guid id,
    [FromBody] UpdateClassViewModels models,
    AppDbContext context) => 
    {
         var tasks = models.MapTo();
        if (!models.IsValid)
            return Results.BadRequest(models.Notifications);

        var editedTasks = context.Tasks
                            .Where(x => x.Id == id)
                            .FirstOrDefault();
        
        if (editedTasks == null)
            return Results.BadRequest();

        editedTasks.Title = models.Title;
        editedTasks.Done = models.Done; 

        context.Tasks.Update(editedTasks);
        context.SaveChanges();

        return Results.Ok(tasks);
    });

app.MapDelete("/v1/DeleteTask/{id:Guid}", (
    [FromRoute] Guid id,
    AppDbContext context ) => 
    {
        var editedTasks = context.Tasks
                .Where(x => x.Id == id)
                .FirstOrDefault();

        if (editedTasks == null)
            return Results.BadRequest();

        context.Tasks.Remove(editedTasks);
        context.SaveChanges();

        return Results.Ok();
    });  



app.Run();
 