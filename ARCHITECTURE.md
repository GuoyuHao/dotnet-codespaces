# Architecture

This document describes the technical architecture of the .NET Codespaces sample application.

## Overview

The application consists of two main components:

```
┌─────────────────┐         ┌─────────────────┐
│                 │         │                 │
│  Frontend       │────────▶│  Backend        │
│  (Blazor)       │  HTTP   │  (Web API)      │
│  Port: 8081     │         │  Port: 8080     │
│                 │         │                 │
└─────────────────┘         └─────────────────┘
```

## Frontend Application

### Technology Stack
- **Framework**: ASP.NET Core 9.0
- **UI Framework**: Blazor Server-Side
- **Programming Language**: C#
- **Target Framework**: .NET 9.0

### Components

#### Pages
- **FetchData.razor**: Main page that displays weather forecast data
- **Error.cshtml**: Error handling page
- **_Host.cshtml**: Blazor host page

#### Data Services
- **WeatherForecastClient**: HTTP client service that fetches weather data from the backend API
- **WeatherForecast**: Data model for weather information

### Configuration
- The frontend connects to the backend API using the `WEATHER_URL` environment variable
- Configured in `appsettings.json` and `appsettings.Development.json`

## Backend Application

### Technology Stack
- **Framework**: ASP.NET Core 9.0 Minimal APIs
- **API Documentation**: OpenAPI with Scalar UI
- **Programming Language**: C#
- **Target Framework**: .NET 9.0

### API Endpoints

#### Weather Forecast Endpoints
1. **GET /weatherforecast**
   - Returns 5-day weather forecast
   - Response: Array of `WeatherForecast` objects

2. **GET /sunset**
   - Returns sunset time for a specific date
   - Query Parameters:
     - `date` (optional): Target date (defaults to today)
   - Response: `SunsetInfo` object

3. **GET /sunset/range**
   - Returns sunset times for a range of days
   - Query Parameters:
     - `startDate` (optional): Starting date (defaults to today)
     - `days` (optional): Number of days (default: 7)
   - Response: Array of `SunsetInfo` objects

### Data Models

#### WeatherForecast
```csharp
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
```

#### SunsetInfo
```csharp
record SunsetInfo(DateOnly Date, TimeOnly SunsetTime)
{
    public string FormattedTime => SunsetTime.ToString("hh:mm tt");
}
```

### Features
- **OpenAPI Integration**: Automatically generated API documentation
- **Scalar UI**: Interactive API documentation and testing interface (available at `/scalar`)
- **Codespaces Port Forwarding**: Custom OpenAPI document transformer to handle GitHub Codespaces port forwarding

## Development Container

### Base Image
- `mcr.microsoft.com/dotnet/sdk:9.0`

### Features
- Docker-in-Docker
- GitHub CLI
- PowerShell
- Azure Developer CLI (azd)
- .NET Runtime 8.0 and ASP.NET Core 8.0

### VS Code Extensions
- Azure Pack
- GitHub Copilot
- GitHub Actions
- C# Dev Kit

### Port Configuration
- **8080**: Backend API (Weather API)
- **8081**: Frontend Application (Blazor UI)

## Build and Runtime

### Build Process
The project uses standard .NET build tools:
- `dotnet build`: Compiles the application
- `dotnet publish`: Creates deployment artifacts
- `dotnet watch`: Enables hot reload during development

### Launch Configuration
The VS Code launch configuration supports:
- Running frontend and backend independently
- **Run All**: Compound configuration to start both services simultaneously

## Environment Variables

### Frontend
- `WEATHER_URL`: Base URL for the backend API (required)
- `ASPNETCORE_ENVIRONMENT`: Environment setting (Development/Production)

### Backend
- `ASPNETCORE_ENVIRONMENT`: Environment setting (Development/Production)

## Dependencies

### Backend Dependencies
- `Microsoft.AspNetCore.OpenApi` (v9.0.*)
- `Scalar.AspNetCore` (v2.0.*)

### Frontend Dependencies
- Standard ASP.NET Core 9.0 libraries (no additional packages)

## Security Considerations

1. **HTTPS Redirection**: Both frontend and backend enforce HTTPS redirection
2. **Development Mode**: OpenAPI/Scalar endpoints are only available in Development environment
3. **Exception Handling**: Production environment uses exception handler middleware

## Scalability Notes

This is a sample application designed for learning and demonstration purposes. For production use, consider:
- Adding authentication and authorization
- Implementing caching strategies
- Adding database persistence
- Implementing proper logging and monitoring
- Using a reverse proxy (e.g., nginx, YARP)
- Containerizing the applications with Docker
