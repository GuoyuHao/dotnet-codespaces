using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;
using BackEnd.Services;
using BackEnd.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // current workaround for port forwarding in codespaces
    // https://github.com/dotnet/aspnetcore/issues/57332
    options.AddDocumentTransformer((document, context, ct) =>
    {
        document.Servers = [];
        return Task.CompletedTask;
    });
});

// Register blast radius analysis service
builder.Services.AddSingleton<IBlastRadiusAnalysisService, BlastRadiusAnalysisService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/sunset", (DateOnly? date) =>
{
    var targetDate = date ?? DateOnly.FromDateTime(DateTime.Now);
    var sunsetTime = CalculateSunsetTime(targetDate);
    
    return new SunsetInfo(targetDate, sunsetTime);
})
.WithName("GetSunset");

app.MapGet("/sunset/range", (DateOnly? startDate, int days = 7) =>
{
    var start = startDate ?? DateOnly.FromDateTime(DateTime.Now);
    var sunsetTimes = Enumerable.Range(0, days).Select(index =>
    {
        var date = start.AddDays(index);
        return new SunsetInfo(date, CalculateSunsetTime(date));
    })
    .ToArray();
    
    return sunsetTimes;
})
.WithName("GetSunsetRange");

// Blast Radius Security Analysis Endpoints
app.MapGet("/security/blast-radius/alberto-polak", async (IBlastRadiusAnalysisService service) =>
{
    var result = await service.GetAlbertoPolakBlastRadiusAsync();
    return Results.Ok(result);
})
.WithName("GetAlbertoPolakBlastRadius")
.WithSummary("Get blast radius security analysis for Alberto Polak's account")
.WithDescription("Analyzes the exposure perimeter and blast radius for Alberto Polak's account, showing all resources and assets that could be impacted if the account is compromised.");

app.MapPost("/security/blast-radius", async (BlastRadiusAnalysisRequest request, IBlastRadiusAnalysisService service) =>
{
    if (string.IsNullOrWhiteSpace(request.TargetName))
    {
        return Results.BadRequest(new { error = "TargetName is required" });
    }

    var result = await service.AnalyzeBlastRadiusAsync(request);
    return Results.Ok(result);
})
.WithName("AnalyzeBlastRadius")
.WithSummary("Analyze blast radius for any target account")
.WithDescription("Performs a blast radius security analysis for a specified target account or resource, identifying the exposure perimeter and potential impact.");

app.Run();

static TimeOnly CalculateSunsetTime(DateOnly date)
{
    // Simplified sunset calculation based on day of year
    // In a real application, you would use astronomical calculations
    // based on latitude, longitude, and date
    var dayOfYear = date.DayOfYear;
    
    // Simulate seasonal variation (earlier in winter, later in summer)
    // Base time around 6 PM with +/- 2 hours variation
    var baseMinutes = 18 * 60; // 6:00 PM in minutes
    var variation = Math.Sin((dayOfYear - 80) * Math.PI / 182.5) * 120; // +/- 2 hours
    var totalMinutes = (int)(baseMinutes + variation);
    
    var hours = totalMinutes / 60;
    var minutes = totalMinutes % 60;
    
    return new TimeOnly(hours, minutes);
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal record SunsetInfo(DateOnly Date, TimeOnly SunsetTime)
{
    public string FormattedTime => SunsetTime.ToString("hh:mm tt");
}
