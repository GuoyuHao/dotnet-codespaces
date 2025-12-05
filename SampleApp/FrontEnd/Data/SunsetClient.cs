namespace FrontEnd.Data;

public class SunsetClient
{
    private HttpClient _httpClient;
    private ILogger<SunsetClient> _logger;

    public SunsetClient(HttpClient httpClient, ILogger<SunsetClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<SunsetInfo?> GetSunsetAsync(DateOnly? date = null)
    {
        var dateParam = date.HasValue ? $"?date={date.Value:yyyy-MM-dd}" : "";
        return await _httpClient.GetFromJsonAsync<SunsetInfo>($"sunset{dateParam}");
    }

    public async Task<SunsetInfo[]> GetSunsetRangeAsync(DateOnly? startDate = null, int days = 7)
    {
        var startDateParam = startDate.HasValue ? $"?startDate={startDate.Value:yyyy-MM-dd}&days={days}" : $"?days={days}";
        return await _httpClient.GetFromJsonAsync<SunsetInfo[]>($"sunset/range{startDateParam}") ?? [];
    }
}
