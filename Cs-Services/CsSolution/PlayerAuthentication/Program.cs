using PlayerAuthentication.Mediator;
using SharedRepository;
using Microsoft.Extensions.Configuration;
using SharedUtility.Jwt;
using SharedRepository.Repository.SqlRepository.EntityFrameworkdRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddScoped<IPlayerAuthenticationMediator, PlayerAuthenticationMediator>();
builder.Services.AddScoped<IJwtHelper,JwtHelper>();
builder.Services.AddHealthChecks();

string mongoUserName = builder.Configuration.GetValue<string>("Mongo:UserName");
string mongoPassword = builder.Configuration.GetValue<string>("Mongo:Password");
string mongoServer = builder.Configuration.GetValue<string>("Mongo:Server");
string mongoDatabase = builder.Configuration.GetValue<string>("Mongo:DatabaseName");

builder.Services.AddSingleton(typeof(IMongoRepository), new MongoRepository(mongoUserName, mongoPassword, mongoServer, mongoDatabase));


//string PostgreSqlConnectionString = builder.Configuration.GetConnectionString("PostgreSql");
builder.Services.AddDbContext<MultiPlayerTurnBasedContext>(o=>
    o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));

var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHealthChecks("/healthCheck");


app.Run();


public partial class Program { }