# Vladiola Store Backend API Solution (Not completed yet)

## Technologies

* [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 7](https://docs.microsoft.com/en-us/ef/core/)
* [Angular 14](https://angular.io/) (Doesn't configured in this solution)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)

## Getting Started

1. Install the latest [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
2. Install the latest [Node.js LTS](https://nodejs.org/en/)
3. Navigate to `src/WebUI` and launch the project using `dotnet run` or run `dotnet run --project src/WebUI` from root
   directory.

Check out Jason Taylor's [blog post](https://jasontaylor.dev/clean-architecture-getting-started/) for more information
about this solution template.

### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the
solution without needing to set up additional infrastructure (e.g. PostgreSQL).

If you would like to use PostgreSQL, you will need to update **WebUI/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DatabaseConnection** connection string within **appsettings.json** points to a valid PostgreSQL
instance, for example:

```json
  "ConnectionStrings": {
    "DatabaseConnection": "Server=127.0.0.1;Port=5432;Database=myowndb;User Id=postgres;Password=Password123;"
},
```

When you run the application the database will be automatically created (if necessary) and the latest migrations will be
applied.

### Database Migrations

To use `dotnet-ef` for your migrations first ensure that "UseInMemoryDatabase" is disabled, as described within previous
section.
Then, add the following flags to your command (values assume you are executing from repository root)

* `--project src\\Infrastructure` (optional if in this folder)
* `--startup-project src\\WebUI`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

```bash
dotnet ef migrations add "Initial" --project src\\Infrastructure --startup-project src\\WebGUI --output-dir Persistence/Migrations
```

To update database after migrating, you can you this command:

```bash
dotnet ef database update --project src\\Infrastructure --startup-project src\\WebGUI
```

## Folder structure overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other
layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application
need to access a notification service, a new interface would be added to application and an implementation would be
created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These
classes should be based on interfaces defined within the application layer.

### WebGUI

This layer is a single page application based on Angular 14 and ASP.NET Core 7. This layer depends on both the
Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency
injection. Therefore only *`Program.cs`* should reference Infrastructure.

## License

This project is licensed with the [MIT license](LICENSE.md).