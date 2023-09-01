using Haack.AIDemoWeb.Startup;
using Haack.AIDemoWeb.Startup.Config;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OpenAIDemo.Hubs;
using Serious.ChatFunctions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.RegisterOpenAI(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddMigrationServices();
builder.Services.AddSignalR();
builder.Services.AddMassTransitConfig();
builder.Services.AddTransient<WeatherFunction>();
builder.Services.Configure<WeatherOptions>(builder.Configuration.GetSection(WeatherOptions.Weather));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.MapGet("/logout", async ctx =>
{
    await ctx.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new AuthenticationProperties
        {
            RedirectUri = "/"
        });
});

app.MapHub<ChatHub>("/hub");

app.Run();
