# API Documentation

This document provides detailed information about the Weather API endpoints.

## Base URL

When running in Codespaces or locally:
- **Development**: `https://localhost:8080` or forwarded Codespaces URL

## API Endpoints

### 1. Get Weather Forecast

Retrieves a 5-day weather forecast.

**Endpoint**: `GET /weatherforecast`

**Parameters**: None

**Response**:
```json
[
  {
    "date": "2024-01-15",
    "temperatureC": 10,
    "temperatureF": 50,
    "summary": "Cool"
  },
  {
    "date": "2024-01-16",
    "temperatureC": 15,
    "temperatureF": 59,
    "summary": "Mild"
  }
]
```

**Response Fields**:
- `date` (string): Date in ISO 8601 format (DateOnly)
- `temperatureC` (integer): Temperature in Celsius
- `temperatureF` (integer): Temperature in Fahrenheit (calculated)
- `summary` (string): Weather description

**Example Request**:
```bash
curl https://localhost:8080/weatherforecast
```

**Possible Summaries**:
- Freezing
- Bracing
- Chilly
- Cool
- Mild
- Warm
- Balmy
- Hot
- Sweltering
- Scorching

---

### 2. Get Sunset Time

Retrieves the sunset time for a specific date.

**Endpoint**: `GET /sunset`

**Parameters**:
| Parameter | Type | Required | Default | Description |
|-----------|------|----------|---------|-------------|
| date | DateOnly | No | Today | Target date for sunset calculation |

**Response**:
```json
{
  "date": "2024-01-15",
  "sunsetTime": "18:30:00",
  "formattedTime": "06:30 PM"
}
```

**Response Fields**:
- `date` (string): Date in ISO 8601 format
- `sunsetTime` (string): Sunset time in 24-hour format
- `formattedTime` (string): Sunset time in 12-hour format with AM/PM

**Example Requests**:
```bash
# Get today's sunset
curl https://localhost:8080/sunset

# Get sunset for a specific date
curl "https://localhost:8080/sunset?date=2024-06-21"
```

**Notes**:
- The sunset calculation is simplified and based on day of year
- Real-world applications should use astronomical calculations based on latitude and longitude
- The calculation simulates seasonal variation with ±2 hours around 6:00 PM base time

---

### 3. Get Sunset Time Range

Retrieves sunset times for a range of consecutive days.

**Endpoint**: `GET /sunset/range`

**Parameters**:
| Parameter | Type | Required | Default | Description |
|-----------|------|----------|---------|-------------|
| startDate | DateOnly | No | Today | Starting date for the range |
| days | integer | No | 7 | Number of days to calculate |

**Response**:
```json
[
  {
    "date": "2024-01-15",
    "sunsetTime": "18:30:00",
    "formattedTime": "06:30 PM"
  },
  {
    "date": "2024-01-16",
    "sunsetTime": "18:31:00",
    "formattedTime": "06:31 PM"
  }
]
```

**Response Fields**:
- Array of `SunsetInfo` objects (same structure as single sunset endpoint)

**Example Requests**:
```bash
# Get next 7 days of sunsets (default)
curl https://localhost:8080/sunset/range

# Get next 14 days starting from today
curl "https://localhost:8080/sunset/range?days=14"

# Get 10 days starting from a specific date
curl "https://localhost:8080/sunset/range?startDate=2024-06-01&days=10"
```

---

## Interactive API Documentation

When running in development mode, you can access interactive API documentation:

### Scalar API Reference
Navigate to `/scalar` in your browser to access the Scalar interactive API documentation.

**Features**:
- **Interactive Testing**: Test API endpoints directly from the browser
- **Request/Response Examples**: See example requests and responses
- **Schema Documentation**: View detailed schema definitions
- **Try It Out**: Execute API calls with custom parameters

**Example**: `https://localhost:8080/scalar`

### OpenAPI Specification
The raw OpenAPI specification is available at `/openapi/v1.json`

---

## Error Handling

### HTTP Status Codes

| Status Code | Description |
|-------------|-------------|
| 200 OK | Request successful |
| 400 Bad Request | Invalid parameters provided |
| 500 Internal Server Error | Server error occurred |

### Error Response Format
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "status": 400,
  "detail": "Invalid date format"
}
```

---

## Date Formats

All date parameters accept ISO 8601 format:
- `YYYY-MM-DD` (e.g., `2024-01-15`)

---

## CORS Configuration

Currently, the API does not have CORS configured. If you need to call the API from a different origin in development, you'll need to add CORS middleware.

---

## Rate Limiting

This sample application does not implement rate limiting. For production use, consider implementing rate limiting to protect the API from abuse.

---

## Authentication

This sample application does not require authentication. For production use, consider implementing authentication using:
- JWT tokens
- OAuth 2.0
- API keys

---

## Versioning

The current API does not have versioning. For production applications, consider implementing API versioning using:
- URL path versioning (e.g., `/v1/weatherforecast`)
- Header versioning
- Query parameter versioning

---

## Client Examples

### JavaScript/TypeScript
```javascript
// Fetch weather forecast
const response = await fetch('https://localhost:8080/weatherforecast');
const weatherData = await response.json();
console.log(weatherData);

// Fetch sunset with parameters
const sunsetResponse = await fetch('https://localhost:8080/sunset?date=2024-06-21');
const sunsetData = await sunsetResponse.json();
console.log(sunsetData.formattedTime);
```

### C# (.NET)
```csharp
using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://localhost:8080");

// Fetch weather forecast
var weatherData = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");

// Fetch sunset with parameters
var sunsetData = await httpClient.GetFromJsonAsync<SunsetInfo>("/sunset?date=2024-06-21");
```

### Python
```python
import requests

# Fetch weather forecast
response = requests.get('https://localhost:8080/weatherforecast')
weather_data = response.json()

# Fetch sunset with parameters
sunset_response = requests.get('https://localhost:8080/sunset', params={'date': '2024-06-21'})
sunset_data = sunset_response.json()
```

---

## Additional Resources

- [ASP.NET Core OpenAPI Documentation](https://learn.microsoft.com/aspnet/core/fundamentals/openapi/)
- [Scalar API Documentation Tool](https://scalar.com/)
- [OpenAPI Specification](https://swagger.io/specification/)
