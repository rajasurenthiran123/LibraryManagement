# LBMS_V1


LBMS_V1 is a library management system backend API built with ASP.NET Core. It provides CRUD operations on books, members, and borrowing records, leveraging Entity Framework Core for data access and Serilog for logging.

## Features

- Manage Books including create, update, delete, and list all
- Manage Members and their borrowing records
- Clean separation of concerns using service interfaces and dependency injection
- Logging with Serilog including file and console sinks
- RESTful API endpoints with Swagger UI support for easy testing and documentation

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server instance accessible over network
- Visual Studio 2022 or VS Code (optional)

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Update `appsettings.json` connection string with your SQL Server details:
   ```json
   "ConnectionStrings": {
       "LibraryDb": "Server=your_server;Database=LibraryDb;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
   }
   ```

3. Apply EF Core migrations to create the database schema:
   ```bash
   dotnet ef database update
   ```

4. Build and run the project:
   ```bash
   dotnet run
   ```

5. Access Swagger UI at https://localhost:<port>/swagger to explore and test API endpoints.

## API Endpoints

- `POST /Library/Create` — Create a new book
- `PUT /Library/Update/{id}` — Update an existing book
- `DELETE /Library/Delete/{id}` — Delete a book
- `GET /Library/GetAll` — Retrieve all books

## Logging

Logs are written using Serilog to both console and rolling daily log files at:

`C:/Raja/log-.txt`

Ensure this folder exists and the application has write permissions.

## Technologies Used

- ASP.NET Core 8.0 Web API
- Entity Framework Core 8.0 with SQL Server
- Serilog for structured logging
- Swagger (Swashbuckle) for API documentation
- Dependency Injection and repository/service pattern


***
