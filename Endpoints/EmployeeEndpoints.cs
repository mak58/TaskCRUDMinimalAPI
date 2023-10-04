namespace Minimal.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this IEndpointRouteBuilder endpoint)
        {
            
            endpoint.MapPost("/employee", async ([FromBody] EmployeeRequest employeeRequest, 
                                                [FromServices] ApplicationDbContext context) =>
            {
                var person = new Employee
                {
                    FirstName = employeeRequest.FirstName,
                    LastName = employeeRequest.LastName,
                    Email = employeeRequest.Email,
                    Address = new EmployeeAddress
                    {
                        AddressNumber = employeeRequest.Address.AddressNumber,
                        Street = employeeRequest.Address.Street,
                        City = employeeRequest.Address.City
                    }
                };

                
                context.Employees.Add(person);

                await context.SaveChangesAsync();

                return Results.Created($"/employee{person}", person);
            });
            

            endpoint.MapGet("/employee", ([FromServices] ApplicationDbContext context) =>
            {
                var employee = context
                            .Employees
                            .AsNoTracking()
                            .Include(x => x.Address)                            
                            .ToList();
        
                return Results.Ok(employee);
            });

            endpoint.MapGet("/employee/{id}", async ([FromServices] ApplicationDbContext context,
                                                     [FromRoute] Guid id) =>
            {
                var employee = await context
                                .Employees
                                .AsNoTracking()
                                .Include(e => e.Address)
                                .FirstOrDefaultAsync(e => e.Id == id);
                            
                return employee != null ? Results.Ok(employee)
                                        : Results.NotFound();
                    
            });

            
        }
        
    }
}