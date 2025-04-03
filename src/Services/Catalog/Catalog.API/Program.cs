using Carter;

var builder = WebApplication.CreateBuilder(args);

//add services
builder.Services.AddCarter();
builder.Services.AddMediatR(confg =>
{
    confg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();


//add application configuration pipline
app.MapCarter();

app.Run();
