using Bl;
using Bl.BlApi;
using Bl.BlImplemntion;
using Bl.BlObject;
using Dal;
using DataAccessLayer;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
DBActions actions = new DBActions(builder.Configuration);
var connection = actions.GetConnectionString("DB");
builder.Services.AddScoped<BlManger>(b => new BlManger(connection));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();







