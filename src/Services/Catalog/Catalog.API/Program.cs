using BuildingBlocks.Behaviors;
using Carter;
using Marten;
var builder = WebApplication.CreateBuilder(args);

//add services
var assembly = typeof(Program).Assembly;
builder.Services.AddLogging();
builder.Services.AddCarter();
builder.Services.AddMediatR(confg =>
{
    confg.RegisterServicesFromAssemblies(assembly);
    confg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
}).UseLightweightSessions();
var app = builder.Build();


//add application configuration pipline
app.MapCarter();

app.Run();
