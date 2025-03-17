var builder = WebApplication.CreateBuilder(args);

//add services

var app = builder.Build();

//add application configuration pipline

app.Run();
