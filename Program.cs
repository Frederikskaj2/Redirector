var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RedirectOptions>(builder.Configuration.GetSection("Redirect"));

var app = builder.Build();
app.UseRedirector();
app.Run();