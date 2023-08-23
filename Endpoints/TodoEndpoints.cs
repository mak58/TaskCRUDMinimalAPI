namespace Minimal.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapToDoEndpoints(this IEndpointRouteBuilder builder)
        {            
            builder.MapGet("/v1/tasks", async ([FromServices] ApplicationDbContext _context) => 
            {    
                var tasks = _context
                    .Tasks
                    .AsNoTracking()
                    .ToList();
                
                return tasks is null ? Results.BadRequest() : Results.Ok(tasks);
            });


            /// <summary>
            /// This way to create the Get end was copied by @"https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio-code"
            /// Is was user lamda expression and a ternary operator.
            /// </summary>            
            builder.MapGet("tasks/{id}", async ([FromServices] ApplicationDbContext _context, Guid id) =>
                await _context.Tasks.FindAsync(id) is Tasks tasks ? Results.Ok(tasks) : Results.NotFound());

            builder.MapPost("v1/tasks", async ( [FromBody] TaskValidate model,
                                                [FromServices] ApplicationDbContext _context) => 
                {
                    var tasks = model.MapTo();
                    if (!model.IsValid)
                        return Results.BadRequest(model.Notifications);

                    _context.Tasks.Add(tasks);
                    await _context.SaveChangesAsync();

                    return Results.Created($"v1/tasks", tasks);
                });

            builder.MapPut("v1/editTasks/{id}", async ([FromRoute] Guid id,
                                                        TaskValidate model,
                                                       [FromServices] ApplicationDbContext _context) => 
            {
                var tasks = model.MapTo();

                if (!model.IsValid) return Results.BadRequest(model.Notifications);

                var editedTasks = _context.Tasks
                                    .Where(x => x.Id == id)
                                    .FirstOrDefault();
                    
                if (editedTasks is null) return Results.BadRequest();

                editedTasks.Title = model.Title;

                _context.Tasks.Update(editedTasks);
                await _context.SaveChangesAsync();

                return Results.Ok(tasks);
            });

            builder.MapDelete("/v1/DeleteTask/{id}", async ([FromRoute] Guid id,
                                                                 [FromServices] ApplicationDbContext _context) => 
            {
                var editedTasks = _context.Tasks
                                    .Where(x => x.Id == id)
                                    .FirstOrDefault();

                if (editedTasks is null) return Results.BadRequest();

                _context.Tasks.Remove(editedTasks);
                await _context.SaveChangesAsync();

                return Results.Ok();
                });
        }
    }
}