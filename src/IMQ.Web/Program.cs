using IMQ.Web.Components;
using IMQ.Web.Services;
using IMQ.Core.Interfaces;
using Microsoft.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);
// Razor Components (required for Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Antiforgery (required because we call app.UseAntiforgery)
builder.Services.AddAntiforgery();

builder.Services.AddScoped(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(navigationManager.BaseUri)
    };
});


// Load environment variables (required for Azure App Service container deployment)
// This ensures OpenAI__ApiKey from Azure App Settings is available as OpenAI:ApiKey
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddSingleton<IQualificationService, InMemoryQualificationService>();

// Document parsing service (OpenAI)
builder.Services.AddScoped<IComplianceCalculationService, ComplianceCalculationService>();
builder.Services.AddHttpClient<IDocumentParsingService, OpenAIDocumentParsingService>();

// Qualification matching service (AI-powered standardization)
builder.Services.AddHttpClient<IQualificationMatchingService, OpenAIQualificationMatchingService>();

// IMQ API client (single, correct registration)
builder.Services.AddHttpClient("IMQApi", client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5091";
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
