namespace Minimal.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapToDoEndpoints(this IEndpointRouteBuilder builder)
        {           

            builder.MapGet("/v1/tasks", ([FromServices] ITaskRepositories _taskRepositories) => 
            {       
                return _taskRepositories.GetTasks();                
            });

          
            builder.MapGet("v1/tasks/{id}", async([FromRoute] Guid id,
                                                    ITaskRepositories _taskRepositories) =>
            {
                return await _taskRepositories.GetTasksById(id);
            });
               

            builder.MapPost("v1/tasks", async ([FromBody] TaskValidate model,
                                                [FromServices] ITaskRepositories _taskRepositories) => 
                {
                   var task = await _taskRepositories.PostTask(model);

                    return task is null ? Results.BadRequest(model.Notifications) : Results.Created($"v1/tasks", task);
                });


            builder.MapPut("v1/editTasks/{id}", async ([FromRoute] Guid id,
                                                        [FromBody] TaskValidate model,
                                                        [FromServices] ITaskRepositories _taskRepositories) => 
            {
                var task =  await _taskRepositories.PutTask(id, model); 

                return task is null ? Results.BadRequest(model.Notifications) : Results.Ok(task);
            });

            builder.MapDelete("/v1/DeleteTask/{id}", async ([FromRoute] Guid id,
                                                                 [FromServices] ApplicationDbContext _context) => 
            {
               
            });
        }
    }
}