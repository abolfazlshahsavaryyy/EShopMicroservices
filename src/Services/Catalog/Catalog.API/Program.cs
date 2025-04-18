using Carter;
using Marten;
var builder = WebApplication.CreateBuilder(args);

//add services
builder.Services.AddLogging();
builder.Services.AddCarter();
builder.Services.AddMediatR(confg =>
{
    confg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
}).UseLightweightSessions();
var app = builder.Build();


//add application configuration pipline
app.MapCarter();

app.Run();
