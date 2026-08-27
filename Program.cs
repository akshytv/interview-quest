using InterviewQuest.API.Data;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.AddQuestDb();

// Register MediatR handlers
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
app.UsePathBase("/api/v1/quest");

// Middleware
app.UseHttpsRedirection();

// Map controller endpoints
app.MapControllers();

app.Run();