# Contributing to .NET Codespaces

Thank you for your interest in contributing to this project! This document provides guidelines and instructions for contributing.

## Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues to avoid duplicates. When creating a bug report, include as many details as possible:

- **Use a clear and descriptive title**
- **Describe the exact steps to reproduce the problem**
- **Provide specific examples** to demonstrate the steps
- **Describe the behavior you observed** and what you expected to see
- **Include screenshots** if relevant
- **Note your environment**: OS, .NET version, browser, etc.

**Bug Report Template:**
```markdown
**Description:**
A clear description of the bug.

**Steps to Reproduce:**
1. Go to '...'
2. Click on '...'
3. See error

**Expected Behavior:**
What you expected to happen.

**Actual Behavior:**
What actually happened.

**Environment:**
- OS: [e.g., Windows 11, macOS 14, Ubuntu 22.04]
- .NET Version: [e.g., 9.0]
- Browser: [e.g., Chrome 120]
- Codespaces: [Yes/No]

**Additional Context:**
Any other relevant information.
```

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion:

- **Use a clear and descriptive title**
- **Provide a detailed description** of the suggested enhancement
- **Explain why this enhancement would be useful**
- **List any alternatives** you've considered

**Enhancement Template:**
```markdown
**Is your feature request related to a problem?**
A clear description of the problem.

**Describe the solution you'd like:**
A clear description of what you want to happen.

**Describe alternatives you've considered:**
Any alternative solutions or features you've considered.

**Additional context:**
Any other context or screenshots.
```

### Pull Requests

We actively welcome your pull requests:

1. **Fork the repository** and create your branch from `main`
2. **Make your changes** following the coding standards
3. **Test your changes** thoroughly
4. **Update documentation** if needed
5. **Write clear commit messages**
6. **Submit a pull request**

## Development Process

### Setting Up Your Development Environment

1. **Fork and clone the repository:**
   ```bash
   git clone https://github.com/YOUR-USERNAME/dotnet-codespaces.git
   cd dotnet-codespaces
   ```

2. **Open in Codespaces or Dev Container** (recommended)
   - Or install .NET 9.0 SDK for local development

3. **Create a new branch:**
   ```bash
   git checkout -b feature/your-feature-name
   ```

### Making Changes

1. **Keep changes focused**: Each PR should address a single concern
2. **Follow existing code style**: Match the style of the surrounding code
3. **Write meaningful commit messages**:
   ```
   Add sunset API endpoint
   
   - Implement GET /sunset endpoint
   - Add sunset time calculation logic
   - Update API documentation
   ```

4. **Test your changes**:
   - Manually test the application
   - Ensure all existing functionality still works
   - Test in both Codespaces and local environments if possible

### Code Style Guidelines

#### C# Code Style

- Use **PascalCase** for class names, method names, and properties
- Use **camelCase** for local variables and parameters
- Use **descriptive names** that clearly indicate purpose
- Follow standard C# naming conventions
- Use **implicit typing** (`var`) when the type is obvious
- Keep methods **short and focused** (single responsibility)
- Add **XML documentation comments** for public APIs

**Example:**
```csharp
/// <summary>
/// Calculates the sunset time for a given date.
/// </summary>
/// <param name="date">The target date.</param>
/// <returns>The calculated sunset time.</returns>
public static TimeOnly CalculateSunsetTime(DateOnly date)
{
    // Implementation
}
```

#### Blazor/Razor Code Style

- Use **PascalCase** for component names
- Keep components **focused and reusable**
- Use **code-behind** files for complex logic
- Follow **Blazor best practices**

#### General Guidelines

- **Use meaningful variable names**: Avoid single-letter names except for loop counters
- **Comment complex logic**: Explain why, not what
- **Keep files focused**: Each file should have a single, clear purpose
- **Avoid magic numbers**: Use named constants
- **Handle errors gracefully**: Add appropriate error handling

### Commit Messages

Write clear, concise commit messages:

- **First line**: Short summary (50 chars or less)
- **Blank line**
- **Detailed description**: Explain what and why, not how
- **Reference issues**: Include issue numbers when applicable

**Good commit message example:**
```
Add sunset time calculation endpoint

Implement a new API endpoint that calculates sunset times
based on the day of year. This provides a simplified
calculation for demonstration purposes.

Fixes #123
```

**Poor commit message example:**
```
fix stuff
```

### Pull Request Process

1. **Update documentation**: Ensure README, API.md, or other docs are updated
2. **Self-review**: Review your own PR before requesting reviews
3. **Request review**: Tag relevant maintainers
4. **Address feedback**: Respond to review comments promptly
5. **Keep PR updated**: Merge main branch if needed to resolve conflicts

**Pull Request Template:**
```markdown
## Description
Brief description of changes.

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Code refactoring

## Testing
Describe how you tested your changes.

## Checklist
- [ ] My code follows the style guidelines
- [ ] I have performed a self-review
- [ ] I have commented complex code
- [ ] I have updated documentation
- [ ] My changes generate no new warnings
- [ ] I have tested my changes
```

## Contributor License Agreement (CLA)

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

## Testing Guidelines

### Manual Testing Checklist

Before submitting a PR, verify:

- [ ] Backend starts without errors
- [ ] Frontend starts without errors
- [ ] Frontend can connect to backend
- [ ] All API endpoints work correctly
- [ ] Scalar documentation is accessible
- [ ] No console errors in browser
- [ ] Application works in Codespaces
- [ ] Application works in Dev Container
- [ ] Application works in local development

### Adding Tests

While this sample project doesn't currently include automated tests, we welcome contributions that add:

- Unit tests using xUnit
- Integration tests
- End-to-end tests

## Documentation

Good documentation is essential:

- **Update README.md** for user-facing changes
- **Update API.md** for API changes
- **Update DEVELOPMENT.md** for development process changes
- **Update ARCHITECTURE.md** for architectural changes
- **Add code comments** for complex logic
- **Include examples** where helpful

## Review Process

1. **Automated checks**: CI/CD checks must pass
2. **Code review**: At least one maintainer review required
3. **Testing**: Changes must be tested
4. **Documentation**: Documentation must be updated
5. **CLA**: CLA must be signed

## Getting Help

- **Documentation**: Check existing documentation first
- **Issues**: Search existing issues for similar problems
- **Discussions**: Use GitHub Discussions for questions
- **Contact**: Reach out to maintainers if needed

## Recognition

Contributors will be recognized in:
- GitHub contributors list
- Release notes (for significant contributions)

Thank you for contributing! 🎉

## Additional Resources

- [How to Contribute to Open Source](https://opensource.guide/how-to-contribute/)
- [GitHub Flow](https://guides.github.com/introduction/flow/)
- [Writing Good Commit Messages](https://chris.beams.io/posts/git-commit/)
- [ASP.NET Core Contribution Guidelines](https://github.com/dotnet/aspnetcore/blob/main/CONTRIBUTING.md)
