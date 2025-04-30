var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Map("/", () =>
{
    var x=new
    {
        IsWork=true
    };
    return x;
});
app.Run();