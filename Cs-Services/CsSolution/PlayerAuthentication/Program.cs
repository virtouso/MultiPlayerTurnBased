

using PlayerAuthentication.Mediator;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder. Services.Configure<TurnBasedMultiPlayerDataBaseSettings>(builder. Configuration.GetSection("TurnBasedMultiPlayer"));


builder.Services.AddSingleton<IPlayerAuthenticationMediator, PlayerAuthenticationMediator>();



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


