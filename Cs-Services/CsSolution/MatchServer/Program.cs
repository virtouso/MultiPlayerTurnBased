using MatchServer.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapHub<MatchHub>("/match");
app.MapHub<LobbyHub>("/lobby");


app.Run();
