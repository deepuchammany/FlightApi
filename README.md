# ✈️ FlightApi (.NET 8 Web API)

A RESTful API built with **ASP.NET Core 8** for managing flight information. It supports full CRUD operations, search filters, CSV-based seeding, and includes unit tests using **xUnit**.

---

## 📁 Project Structure

```
FlightApi/
├── Controllers/            # API Controllers
├── Data/                   # EF Core DbContext & CSV Seeder
├── Models/                 # Domain models and enums
├── Repositories/           # Data access layer
├── Services/               # Business logic layer
├── Program.cs              # App entrypoint
├── FlightInformation.csv   # Flight seed data (CSV)
├── FlightApi.csproj
|
FlightApi.Tests/            # Unit test project (xUnit)
└── FlightApi.Tests.csproj
```

---

## ✅ Prerequisites

- **Visual Studio 2022** (v17.8+)
- **.NET 8 SDK**
- Installed NuGet packages:
  - `Microsoft.EntityFrameworkCore.InMemory`
  - `Swashbuckle.AspNetCore`
  - `CsvHelper`
  - `xunit`, `Moq`, `Microsoft.AspNetCore.Mvc.Testing` (for tests)

---

## 🚀 How to Run the API

### 1. Open the Solution

Open `FlightApi.sln` in Visual Studio 2022.

### 2. Set Startup Project

Right-click the `FlightApi` project → **Set as Startup Project**

### 3. Run the API

Press `F5` or `Ctrl + F5` to start the server.

### 4. Access Swagger UI

Navigate to: [https://localhost:5001/swagger](https://localhost:5001/swagger)

> Port may vary—check the launch browser URL.

---

## 📦 CSV Import for Initial Seeding

The file `FlightInformation.csv` in the **FlightApi** project root is automatically imported at startup if the database is empty.

### 🔄 How to Update It

1. Replace or edit the `FlightInformation.csv` file in the root of the `FlightApi` project.
2. In Visual Studio:
   - Right-click `FlightInformation.csv` → **Properties**
   - Ensure **Copy to Output Directory** is set to `Copy if newer`

> This file is read and parsed during application startup to populate initial flight data.

---

## 🔍 API Endpoints

| Method | Endpoint                     | Description                  |
|--------|------------------------------|------------------------------|
| GET    | `/api/flights`              | List all flights             |
| GET    | `/api/flights/{id}`         | Get flight by ID             |
| POST   | `/api/flights`              | Create a new flight          |
| PUT    | `/api/flights/{id}`         | Update a flight              |
| DELETE | `/api/flights/{id}`         | Delete a flight              |
| GET    | `/api/flights/search`       | Search by airline/airport    |

---

## ❗ Optional Search Parameters

For `/api/flights/search`, you can provide any combination of:

- `airline`  
- `departure`  
- `arrival`

Example:
```http
GET /api/flights/search?airline=Delta
```

---

## 🧪 Run Tests

### Using Visual Studio

1. Open **Test Explorer** (View → Test Explorer)
2. Click **Run All Tests**

### Using CLI

```bash
dotnet test FlightApi.Tests
```

---

## 🛠 Dependency Setup

Install NuGet packages if not already:

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Swashbuckle.AspNetCore
dotnet add package CsvHelper
dotnet add package xunit
dotnet add package Moq
dotnet add package Microsoft.AspNetCore.Mvc.Testing
```

---

## ✅ Design Principles

- ✅ Follows **SOLID** principles
- ✅ Uses **Repository + Service** architecture
- ✅ In-memory persistence using **EF Core**
- ✅ Integrated with **Swagger** for interactive API docs
- ✅ Automated testing with **xUnit** and **Moq**

---

## 📄 License

This project is licensed under the MIT License.