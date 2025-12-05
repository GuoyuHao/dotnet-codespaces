using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

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
