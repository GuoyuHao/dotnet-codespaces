namespace FrontEnd.Data;

public class SunsetInfo
{
    public DateOnly Date { get; set; }
    
    public TimeOnly SunsetTime { get; set; }
    
    public string? FormattedTime { get; set; }
}
