# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Comprehensive documentation in Markdown format
  - README.md - Enhanced main documentation with quick reference
  - API.md - Detailed API endpoint documentation
  - ARCHITECTURE.md - Technical architecture guide
  - DEVELOPMENT.md - Development setup and workflow guide
  - CONTRIBUTING.md - Contribution guidelines
  - CHANGELOG.md - This changelog file

## [1.0.0] - Initial Release

### Added
- Backend Weather API built with ASP.NET Core 9.0 Minimal APIs
  - GET /weatherforecast endpoint for 5-day weather forecast
  - GET /sunset endpoint for sunset time calculation
  - GET /sunset/range endpoint for multiple days sunset times
- Frontend Blazor Server-Side application
  - Weather data display page
  - Integration with backend API
- OpenAPI/Swagger integration
- Scalar interactive API documentation
- GitHub Codespaces configuration
- Dev Container support
- VS Code launch configurations for debugging
- Hot reload support for rapid development

### Features
- .NET 9.0 framework
- Server-side Blazor UI
- RESTful API with OpenAPI specification
- Interactive API testing with Scalar
- Docker Dev Container support
- One-click GitHub Codespaces setup

[unreleased]: https://github.com/github/dotnet-codespaces/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/github/dotnet-codespaces/releases/tag/v1.0.0
