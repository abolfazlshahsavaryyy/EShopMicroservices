using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extension;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
var app = builder.Build();


app.UseApiServices();
//Configure the request pipline 
if (app.Environment.IsDevelopment())
{
    await app.InitialiesDatabaseAsync();
}

app.Run();
