using IMQ.Web.Components;
using IMQ.Web.Services;
using IMQ.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


var builder = WebApplication.CreateBuilder(args);

// Configure culture settings (fix for Azure deployment)
var supportedCultures = new[] { new CultureInfo("en-US") };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

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

// Master Requirements Service (in-memory for PoC)
builder.Services.AddSingleton<IMQ.Core.Services.Read.IMasterRequirementsReadService, IMQ.Core.Services.Read.InMemoryMasterRequirementsReadService>();

// Document parsing service (OpenAI)
builder.Services.AddScoped<IComplianceCalculationService, ComplianceCalculationService>();
builder.Services.AddHttpClient<IDocumentParsingService, OpenAIDocumentParsingService>();

// Qualification matching service (AI-powered standardization)
builder.Services.AddHttpClient<IQualificationMatchingService, OpenAIQualificationMatchingService>();
builder.Services.AddScoped<ICvQualificationAnalysisService, IMQ.Core.Services.CvQualificationAnalysisService>();

// IMQ API client (single, correct registration) - kept for other potential API calls
builder.Services.AddHttpClient("IMQApi", client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5091";
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// Apply culture settings
app.UseRequestLocalization();

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
