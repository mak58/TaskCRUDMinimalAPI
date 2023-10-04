namespace Minimal.Endpoints;

public static class TodoEndpoints 
{        
    public static void MapToDoEndpoints(this IEndpointRouteBuilder endpoint)
    {                 
        endpoint.MapGet("v1/tasks", ([FromServices] ITaskRepositories taskRepositories) => 
        {          
            return taskRepositories.GetTasks();                
        });
          
        endpoint.MapGet("v1/tasks{id}", async ([FromRoute] Guid id,
                                               [FromServices] ITaskRepositories taskRepositories) =>
        {
            return await taskRepositories.GetTasksById(id);
        });
               
        endpoint.MapPost("v1/tasks", async ([FromBody] TaskValidate model,
                                            [FromServices] ITaskRepositories taskRepositories) => 
        {
            var task = await taskRepositories.PostTask(model);

            return task is null ? Results.BadRequest(model.Notifications) 
                                : Results.Created($"v1/tasks/{task.Id}", task);
        });

        endpoint.MapPut("v1/tasks/{id}", async ([FromRoute] Guid id,
                                                [FromBody] TaskValidate model,
                                                [FromServices] ITaskRepositories taskRepositories) =>
        {
            var task = await taskRepositories.GetTasksById(id);

            if (task is null) return Results.BadRequest(model.Notifications);

            await taskRepositories.PutTask(id, model);

            return task is null ? Results.BadRequest() : Results.Ok(task);
        });

        endpoint.MapDelete("/v1/tasks/{id}", ([FromRoute] Guid id,
                                              [FromServices] ITaskRepositories taskRepositories) => 
        {
            taskRepositories.DeleteTask(id); 
        });
    }            
}

