using LeaderBoard.Mediator;
using SharedRepository;
using SharedRepository.Repository.RedisRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();

string redisIp = builder.Configuration.GetValue<string>("Redis:Server");
int redisPort= builder.Configuration.GetValue<int>("Redis:Port");

builder.Services.AddSingleton(typeof(IRedisRepository), new RedisRepository(redisIp,redisPort));



string mongoUserName = builder.Configuration.GetValue<string>("Mongo:UserName");
string mongoPassword = builder.Configuration.GetValue<string>("Mongo:Password");
string mongoServer = builder.Configuration.GetValue<string>("Mongo:Server");
string mongoDatabase = builder.Configuration.GetValue<string>("Mongo:DatabaseName");

builder.Services.AddSingleton(typeof(IMongoRepository), new MongoRepository(mongoUserName, mongoPassword, mongoServer, mongoDatabase));



builder.Services.AddSingleton<ILeaderBoardMediator,LeaderBoardMediator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
