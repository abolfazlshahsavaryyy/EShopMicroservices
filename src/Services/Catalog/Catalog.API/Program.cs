using Carter;

var builder = WebApplication.CreateBuilder(args);

//add services
builder.Services.AddCarter();

var app = builder.Build();


//add application configuration pipline
app.MapCarter();

app.Run();
