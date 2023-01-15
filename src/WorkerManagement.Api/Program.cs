using WorkerManagement.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDomain();

var app = builder.Build();

app.MapControllers();

app.Run();

