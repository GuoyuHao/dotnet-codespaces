# Development Guide

This guide helps you set up and develop the .NET Codespaces sample application.

## Prerequisites

### For GitHub Codespaces
- A GitHub account
- Access to GitHub Codespaces

### For Local Development
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- [Visual Studio Code](https://code.visualstudio.com/)
- [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Docker](https://www.docker.com/products/docker-desktop) (for Dev Container support)

## Getting Started

### Option 1: GitHub Codespaces (Recommended)

1. Click the "Open in GitHub Codespaces" badge in the README
2. Wait for the codespace to initialize (this may take a few minutes)
3. Once ready, the dependencies will be automatically restored

[![Open in GitHub Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=lightgrey&logo=github)](https://codespaces.new/github/dotnet-codespaces)

### Option 2: Dev Container (Local)

1. Clone the repository:
   ```bash
   git clone https://github.com/github/dotnet-codespaces.git
   cd dotnet-codespaces
   ```

2. Open in VS Code:
   ```bash
   code .
   ```

3. When prompted, click "Reopen in Container"
   - Alternatively, press `F1` and select "Dev Containers: Reopen in Container"

4. Wait for the container to build and initialize

### Option 3: Local Development (Without Container)

1. Clone the repository:
   ```bash
   git clone https://github.com/github/dotnet-codespaces.git
   cd dotnet-codespaces
   ```

2. Restore dependencies:
   ```bash
   cd SampleApp
   dotnet restore
   ```

3. Set the environment variable for the frontend to communicate with the backend:
   - **Windows (PowerShell)**:
     ```powershell
     $env:WEATHER_URL="https://localhost:8080"
     ```
   - **macOS/Linux (Bash)**:
     ```bash
     export WEATHER_URL="https://localhost:8080"
     ```

## Running the Application

### Using VS Code Debug Configuration (Recommended)

1. Open the Run and Debug view (`Ctrl+Shift+D` or `Cmd+Shift+D`)
2. Select "Run All" from the dropdown
3. Press `F5` or click the green play button
4. Both backend and frontend will start automatically
5. Your browser will open automatically to the frontend and backend Scalar documentation

### Running Manually

#### Start Backend
```bash
cd SampleApp/BackEnd
dotnet run
```

The backend will start on `https://localhost:8080`
- API: `https://localhost:8080/weatherforecast`
- Scalar docs: `https://localhost:8080/scalar`

#### Start Frontend
In a new terminal:
```bash
cd SampleApp/FrontEnd
export WEATHER_URL="https://localhost:8080"  # or $env:WEATHER_URL on Windows
dotnet run
```

The frontend will start on `https://localhost:8081`

## Building the Application

### Build All Projects
```bash
cd SampleApp
dotnet build
```

### Build Specific Project
```bash
# Backend
dotnet build SampleApp/BackEnd/BackEnd.csproj

# Frontend
dotnet build SampleApp/FrontEnd/FrontEnd.csproj
```

## Testing the Application

### Manual Testing

1. **Test the Backend API**:
   - Navigate to `https://localhost:8080/scalar`
   - Use the interactive API documentation to test endpoints
   - Try the "Test Request" button for each endpoint

2. **Test the Frontend**:
   - Navigate to `https://localhost:8081`
   - Verify that weather data loads correctly
   - Check browser console for any errors

3. **Test Backend API Directly**:
   ```bash
   # Weather forecast
   curl https://localhost:8080/weatherforecast
   
   # Sunset time
   curl "https://localhost:8080/sunset?date=2024-06-21"
   
   # Sunset range
   curl "https://localhost:8080/sunset/range?days=7"
   ```

### Unit Testing
Currently, this sample application does not include unit tests. To add tests:

1. Create test projects:
   ```bash
   dotnet new xunit -n BackEnd.Tests
   dotnet new xunit -n FrontEnd.Tests
   ```

2. Add test project references:
   ```bash
   cd BackEnd.Tests
   dotnet add reference ../BackEnd/BackEnd.csproj
   ```

3. Run tests:
   ```bash
   dotnet test
   ```

## Development Workflow

### Hot Reload

The application supports hot reload for rapid development:

```bash
# Backend with hot reload
cd SampleApp/BackEnd
dotnet watch run

# Frontend with hot reload
cd SampleApp/FrontEnd
dotnet watch run
```

Any code changes will automatically trigger a rebuild and restart.

### Debugging

1. Set breakpoints in your code
2. Use the "Run All" or individual launch configurations
3. Step through code using VS Code debugger
4. Inspect variables and call stack

### Code Formatting

Format code using:
```bash
dotnet format
```

## Project Structure

```
dotnet-codespaces/
├── .devcontainer/          # Dev container configuration
│   └── devcontainer.json
├── .vscode/                # VS Code settings and launch configs
│   ├── launch.json
│   ├── settings.json
│   └── tasks.json
├── SampleApp/              # Main application
│   ├── BackEnd/            # Weather API
│   │   ├── Program.cs      # API endpoints and configuration
│   │   └── BackEnd.csproj
│   ├── FrontEnd/           # Blazor web application
│   │   ├── Data/           # Data models and services
│   │   ├── Pages/          # Blazor pages
│   │   ├── Shared/         # Shared components
│   │   ├── wwwroot/        # Static files
│   │   ├── Program.cs      # App configuration
│   │   └── FrontEnd.csproj
│   └── SampleApp.sln       # Solution file
├── images/                 # Documentation images
├── ARCHITECTURE.md         # Architecture documentation
├── API.md                  # API documentation
├── DEVELOPMENT.md          # This file
└── readme.md              # Main README
```

## Common Development Tasks

### Adding a New API Endpoint

1. Open `SampleApp/BackEnd/Program.cs`
2. Add a new `MapGet`, `MapPost`, etc. before `app.Run()`:
   ```csharp
   app.MapGet("/myendpoint", () => 
   {
       return new { message = "Hello World" };
   })
   .WithName("MyEndpoint");
   ```
3. The endpoint will automatically appear in the OpenAPI/Scalar documentation

### Adding a New Blazor Page

1. Create a new `.razor` file in `SampleApp/FrontEnd/Pages/`
2. Add the `@page` directive at the top:
   ```razor
   @page "/mypage"
   
   <h1>My Page</h1>
   ```
3. Add navigation link in `Shared/NavMenu.razor`

### Adding a New NuGet Package

```bash
cd SampleApp/BackEnd  # or FrontEnd
dotnet add package PackageName
```

### Updating .NET Version

1. Update `TargetFramework` in `.csproj` files
2. Update base image in `.devcontainer/devcontainer.json`
3. Rebuild the dev container

## Environment Variables

### Backend
- `ASPNETCORE_ENVIRONMENT`: Set to `Development` or `Production`
- `ASPNETCORE_URLS`: Override default URLs (e.g., `https://localhost:8080`)

### Frontend
- `ASPNETCORE_ENVIRONMENT`: Set to `Development` or `Production`
- `WEATHER_URL`: Backend API base URL (required)
- `ASPNETCORE_URLS`: Override default URLs (e.g., `https://localhost:8081`)

## Troubleshooting

### Port Already in Use
If ports 8080 or 8081 are already in use:
1. Stop the existing processes
2. Or change ports in `launch.json` and `devcontainer.json`

### Frontend Can't Connect to Backend
1. Verify `WEATHER_URL` environment variable is set correctly
2. Check that backend is running on the expected port
3. Check for HTTPS certificate issues in development

### Dev Container Won't Build
1. Ensure Docker is running
2. Try rebuilding: `F1` → "Dev Containers: Rebuild Container"
3. Check Docker logs for error messages

### Hot Reload Not Working
1. Ensure you're using `dotnet watch run`
2. Check that files are being saved
3. Some changes require a full rebuild (e.g., project file changes)

### HTTPS Certificate Issues
In development, you may need to trust the .NET development certificate:
```bash
dotnet dev-certs https --trust
```

## Additional Resources

- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [.NET CLI Reference](https://learn.microsoft.com/dotnet/core/tools/)
- [Visual Studio Code Documentation](https://code.visualstudio.com/docs)
- [Dev Containers Documentation](https://code.visualstudio.com/docs/devcontainers/containers)

## Getting Help

- Check the [GitHub Issues](https://github.com/github/dotnet-codespaces/issues)
- Review [ASP.NET Core documentation](https://learn.microsoft.com/aspnet/core/)
- Ask questions in [GitHub Discussions](https://github.com/github/dotnet-codespaces/discussions)
