# Library App

## Description

Library App is a .NET 8.0 application built with a clean architecture approach, separating core business logic, infrastructure concerns, and presentation. The application is designed to manage library operations with a layered architecture pattern that promotes separation of concerns and maintainability.

## Project Structure

- **AccelerateDevGitHubCopilot.sln** - The main solution file
- **src/**
  - **Library.ApplicationCore/** - Core business logic and domain models
    - **Entities/** - Domain entities
    - **Enums/** - Enumeration types
    - **Interfaces/** - Interfaces for services and repositories
    - **Services/** - Business logic implementations
  - **Library.Infrastructure/** - Data access and external services
    - **Data/** - Database contexts and repositories
  - **Library.Console/** - Console application UI
    - **Json/** - JSON configuration and serialization
    - **appSettings.json** - Application configuration
    - **CommonActions.cs** - Shared functionality
    - **ConsoleApp.cs** - Main console application logic
    - **ConsoleState.cs** - State management for the console app
    - **Program.cs** - Entry point
- **tests/**
  - **UnitTests/** - Test classes for the application
    - **LoanFactory.cs** - Factory for loan objects in tests

## Key Classes and Interfaces

The application follows a clean architecture pattern with:

- **Domain Entities** in the ApplicationCore layer representing the core business objects
- **Service Interfaces** defining the contract for business operations
- **Service Implementations** that contain the business logic
- **Repository Interfaces** for data access abstraction
- **Repository Implementations** in the Infrastructure layer that handle data persistence
- **Console Application** that provides a user interface to interact with the system

## Usage

### Prerequisites

- .NET 8.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the solution directory
3. Build the solution:

```bash
dotnet build
```

4. Run the console application:

```bash
dotnet run --project src/Library.Console/Library.Console.csproj
```

### Running the Tests

Execute the following command to run the unit tests:

```bash
dotnet test
```

## Configuration

The application uses `appSettings.json` in the Library.Console project for configuration settings. Modify this file to change application behavior.

## Dependencies

- Microsoft.Extensions.Configuration (8.0.0)
- Microsoft.Extensions.Configuration.Json (8.0.0)
- Microsoft.Extensions.DependencyInjection (8.0.0)
- Microsoft.Extensions.DependencyInjection.Abstractions (8.0.1)

## License

This project is licensed under the MIT License - see the LICENSE
