# ECommerceProductCatalogBackend

This repository contains the **ASP.NET Core Web API backend** for the **E-Commerce Product Catalog** system.

The project follows **Clean Architecture principles**, separating concerns into different layers for better maintainability and scalability.

---

# Technologies Used

* ASP.NET Core Web API
* .NET 8
* Entity Framework Core
* SQL Server
* Dependency Injection
* Swagger (API Documentation)
* Clean Architecture

---

# Project Architecture

The solution is organized into the following layers:

```
src/
 ├── ECommerceProductCatalog.API
 │   ├── Controllers
 │   ├── Middleware
 │   ├── Program.cs
 │   └── appsettings.json
 │
 ├── ECommerceProductCatalog.Application
 │   ├── Dtos
 │   ├── Services
 │   ├── Interface
 │   ├── Mapper
 │   └── Extensions
 │
 ├── ECommerceProductCatalog.Domain
 │   ├── Entities
 │   └── Enums
 │
 ├── ECommerceProductCatalog.Infrastructure
 │   ├── Persistence
 │   └── Repositories
 │
 └── ECommerceProductCatalog.Tests
```

---

# Prerequisites

Before running the project, install the following:

* .NET SDK 8.0+
* SQL Server / SQL Server Express
* Visual Studio / VS Code
* Git

Download .NET SDK:
https://dotnet.microsoft.com/download

---

# Setup Instructions

## 1 Clone Repository

```
git clone https://github.com/kashyapvaibhav123/ECommerceProductCatalogBackend.git
cd ECommerceProductCatalogBackend
```

---

# 2 Configure Database

Open:

```
src/ECommerceProductCatalog.API/appsettings.json
```

Update the connection string:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ECommerceProductCatalogDB;Trusted_Connection=True;"
}
```

---

# 3 Create Database

Run the provided SQL script:

```
database.sql
```

This will create the required tables and insert sample data.

---

# 4 Restore Dependencies

Run the following command:

```
dotnet restore
```

---

# 5 Run the API

Run the application:

```
dotnet run --project src/ECommerceProductCatalog.API
```

The API will start at:

```
http://localhost:5218/
```

---

# Swagger API Documentation

Once the API is running, open:

```
http://localhost:5218/swagger
```

Swagger provides interactive API documentation to test endpoints.

---

# Features

* Product catalog management
* Pagination, filtering, and sorting
* Clean architecture implementation
* Repository pattern
* DTO mapping
* Middleware support
* API documentation with Swagger

---

# Testing

Unit tests are located in:

```
tests/ECommerceProductCatalog.Tests
```

Run tests using:

```
dotnet test
```

---

# Frontend Repository

Angular frontend repository:

```
https://github.com/YOUR_USERNAME/ECommerceProductCatalogFrontend
```

---

# Author

Vaibhav Kashyap
