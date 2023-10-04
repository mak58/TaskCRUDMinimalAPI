var builder = WebApplication.CreateBuilder(args);

/// DI and DbConnection extending IServiceCollection method
builder.Services.AddServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

/// Endpoints extending IEndpointRouteBuilder method                
app.MapToDoEndpoints();
app.MapEmployeeEndpoints();

app.Run();
 