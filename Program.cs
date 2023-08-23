var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();


app.MapToDoEndpoints();

app.Run();
 