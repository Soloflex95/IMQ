using IMQ.Web.Components;
using IMQ.Web.Services;
using IMQ.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables (required for Azure App Service container deployment)
// This ensures OpenAI__ApiKey from Azure App Settings is available as OpenAI:ApiKey
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddSingleton<IQualificationService, InMemoryQualificationService>();

// Document parsing service (OpenAI)
builder.Services.AddScoped<IComplianceCalculationService, ComplianceCalculationService>();
builder.Services.AddHttpClient<IDocumentParsingService, OpenAIDocumentParsingService>();

// Qualification matching service (AI-powered standardization)
builder.Services.AddSingleton<IQualificationMatchingService, OpenAIQualificationMatchingService>();
builder.Services.AddHttpClient<IQualificationMatchingService, OpenAIQualificationMatchingService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
