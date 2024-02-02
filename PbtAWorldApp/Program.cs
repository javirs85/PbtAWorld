using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Security.Claims;
using Blazored.Toast;
using PbtAWorldApp;
using PbtAWorldConnectivity;
using DinoIsland;
using System.Dynamic;
using PbtALib;
using PbtADBConnector.DbAccess;
using PbtADBConnector.Data;
using PbtADBConnector;
using DungeonWorld;
using static PbtaWorldRazonCommonComponents.LastRollOverlay;
using UrbanShadows;
using PbtaWorldRazonCommonComponents;
using static PbtaWorldRazonCommonComponents.CharacterSelector;
using PbtALib.ifaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddRazorPages().AddApplicationPart(typeof(DungeonWorld.Pages.DWPlayerSheet).Assembly);

builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ISeasonsData, SeasonData>();
builder.Services.AddSingleton<ICharacterData, CharacterData>();
builder.Services.AddSingleton<IDataBaseController, DataBaseController>();
builder.Services.AddSingleton<DinoMovesService>();
builder.Services.AddSingleton<DWMovesService>();
builder.Services.AddSingleton<USMovesService>();
builder.Services.AddSingleton<PNJs>();
builder.Services.AddSingleton<DinoGameController>();
builder.Services.AddSingleton<DWGameController>();
builder.Services.AddSingleton<USGameController>();
builder.Services.AddSingleton<LastRollViewerService>();
builder.Services.AddScoped<DinoCharacter>();
builder.Services.AddSingleton<MoveSelector.MoveSelectorService>();
builder.Services.AddSingleton<CharacterSelectorService>();
builder.Services.AddSingleton<VTTService>();
builder.Services.AddScoped<VTTLocalManagerService>();
builder.Services.AddBlazorBootstrap();



builder.Services.AddAuthentication("Cookies")
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "TrySingOutGoogleAuth";
        opt.LoginPath = "/auth/google-login";
    })
    .AddGoogle(opt =>
    {
        opt.ClientId = builder.Configuration["Google:Id"] ?? "Not Found";
        opt.ClientSecret = builder.Configuration["Google:Secret"] ?? "Google secret not found";
        opt.Scope.Add("profile");
        opt.Events.OnCreatingTicket = context =>
        {
            string picuri = context.User.GetProperty("picture").GetString() ?? "No picuri found";
            context.Identity?.AddClaim(new Claim("picture", picuri));

            return Task.CompletedTask;
        };
    });

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

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.MapHub<DinoGameController>(DinoGameController.HubUrl);

app.Run();
