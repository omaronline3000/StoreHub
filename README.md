# StoreHub

A product management REST API built with **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**. The project focuses on RESTful API development, JWT authentication, and organizing backend logic using Repository and Unit of Work patterns.

## Features

- **Product Management:** Create, retrieve, update, and soft-delete products.
- **Category Management:** Manage product categories and retrieve category information with associated products.
- **Authentication:** User registration and login using ASP.NET Core Identity.
- **JWT Authentication:** Generate JSON Web Tokens for authenticated requests.
- **DTOs:** Separate API request/response models from database entities.
- **Layered Architecture:** Separate controllers, services, repositories, and data access.
- **Repository Pattern:** Encapsulate database access behind repository abstractions.
- **Unit of Work:** Organize repository access and persistence operations.
- **Entity Framework Core:** Manage relational data and interact with SQL Server.
- **Swagger:** Explore and test API endpoints during development.

## Tech Stack

| Technology | Purpose |
|---|---|
| C# | Programming language |
| ASP.NET Core Web API | REST API development |
| .NET 10 | Target framework |
| Entity Framework Core | ORM and database access |
| SQL Server | Relational database |
| ASP.NET Core Identity | User management |
| JWT Bearer Authentication | Token-based authentication |
| Swagger / OpenAPI | API documentation and testing |

## Architecture

The application separates HTTP handling, business logic, and data access into distinct layers.

```text
StoreHub
├── Controllers
│   ├── AccountController
│   ├── ProductController
│   └── CategoryController
├── Services
│   ├── ProductService
│   └── CategoryService
├── Repositories
│   ├── Generic Repository
│   ├── Product Repository
│   └── Category Repository
├── DTOs
├── Models
├── Data
└── Program.cs
```

*The directory tree is illustrative; adjust it to match the current repository structure.*

### Request Flow

```text
HTTP Request
     |
     v
Controller
     |
     v
Service Layer
     |
     v
Repository / Unit of Work
     |
     v
Entity Framework Core
     |
     v
SQL Server
```

Controllers handle HTTP requests and responses. Services organize application logic, while repositories encapsulate data access through EF Core.

## Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server
- A development environment such as Visual Studio or Visual Studio Code

### 1. Clone the repository

```bash
git clone https://github.com/omaronline3000/StoreHub.git
cd StoreHub
```

### 2. Configure the database

Configure the SQL Server connection string in your application's configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION_STRING"
  }
}
```

Use the connection-string key expected by the application's `Program.cs` or database configuration. The example above is a template, not a substitute for the project's actual configuration.

### 3. Configure JWT settings

Add the JWT settings required by the application, including the signing key, issuer, audience, and expiration configuration where applicable.

Keep signing keys and database credentials out of source control. Use User Secrets or environment variables for local development.

### 4. Restore dependencies

```bash
dotnet restore
```

### 5. Apply database migrations

From the directory containing the project file, run:

```bash
dotnet ef database update
```

If the project does not already contain the required migrations, create one first using the appropriate EF Core tooling.

### 6. Run the application

```bash
dotnet run
```

Open the Swagger URL printed in the application output, if Swagger is enabled for the current environment.

## API Capabilities

The API includes endpoints for:

- User registration and login.
- Retrieving product information.
- Creating, updating, and soft-deleting products.
- Retrieving categories and their associated products.

For exact routes, HTTP methods, request bodies, and authentication requirements, refer to the controller implementations and Swagger documentation.

## Engineering Concepts

StoreHub is a practical project for exploring:

- RESTful API design.
- Separation of concerns.
- Dependency Injection.
- DTO-based data transfer.
- Repository and Unit of Work patterns.
- Entity Framework Core and relational data access.
- JWT-based authentication.
- Soft deletion and database persistence.

## Project Status

**In Progress**

The project is being developed as a practical exercise in ASP.NET Core Web API development and backend software engineering.

## Author

**Omar Ibrahim Said Ahmed**

- GitHub: [omaronline3000](https://github.com/omaronline3000)

---

*StoreHub is a learning project intended to demonstrate backend development concepts. Review authentication, authorization, validation, and configuration before using it in a production environment.*
