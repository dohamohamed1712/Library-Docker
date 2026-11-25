# Library Management API — Dockerized

ASP.NET Core Web API for a **Library Management System**, fully containerized with **Docker** and **Docker Compose**.

The API is built with **.NET 10**, **EF Core 10 (SQL Server)**, **AutoMapper**, and a **Generic Repository + Service** layer, following the architecture used in the DEPI sessions.

---

## Docker concepts applied

| Concept | Where |
|---|---|
| **Docker Image** | `Dockerfile` (multi-stage: `sdk:10.0` → `aspnet:10.0`) |
| **Container** | `library-api` service in `docker-compose.yml` |
| **Container for the database** | `sqlserver` service (`mcr.microsoft.com/mssql/server:2022-latest`) |
| **Dockerfile** | Multi-stage build: restore → publish → runtime |
| **Docker Compose** | Orchestrates API + SQL Server + network + volume |
| **Registry** | `docker pull mcr.microsoft.com/dotnet/aspnet:10.0` / `docker push <your-docker-id>/library-api` |

### Dockerfile stages

1. **build** — uses the full SDK image, restores NuGet packages, publishes the app in `Release` mode.
2. **final** — uses the lightweight ASP.NET runtime image only (no SDK), copies the published files and runs `dotnet Library.API.dll`.

This keeps the final image small and secure.

---

## Project structure

```
Library-Docker/
├── Dockerfile
├── docker-compose.yml
├── .dockerignore
├── LibraryManagement.sln
└── src/
    └── Library.API/
        ├── Controllers/        # REST endpoints
        ├── Data/               # DbContext, Configurations, Seeding
        ├── Dtos/               # Request / Response DTOs
        ├── Entities/           # Domain models
        ├── Extensions/         # Dependency injection extension
        ├── Helper/             # AutoMapper profiles
        ├── Migrations/         # EF Core migrations
        ├── Repositories/       # Generic Repository pattern
        ├── Results/            # GenericResult / PaginatedList
        └── Services/           # Generic + Book services
```

### Domain model

`Floor`, `Employee`, `User`, `UserPhone`, `Category`, `Publisher`, `Author`, `Shelf`, `Book`, `BookAuthor`, `Borrow`

---

## Run with Docker (recommended)

```bash
docker compose up --build
```

Then open:

- API root → http://localhost:8080
- Swagger UI → http://localhost:8080/swagger
- Health check → http://localhost:8080/health

Stop everything:

```bash
docker compose down
```

Stop and remove the database volume too:

```bash
docker compose down -v
```

### Build and run the image manually

```bash
docker build -t library-api:1.0 .
docker run -d -p 8080:8080 --name library-api library-api:1.0
```

---

## Run locally (without Docker)

```bash
cd src/Library.API
dotnet ef database update
dotnet run
```

Default local connection string (`appsettings.json`):

```
Server=localhost;Database=LibraryApiDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true
```

---

## API endpoints

| Resource | Endpoints |
|---|---|
| Books | `GET /api/books`, `GET /api/books/{id}`, `POST /api/books`, `PUT /api/books/{id}`, `DELETE /api/books/{id}` |
| Categories | `GET /api/categories`, `GET /api/categories/{id}`, `POST`, `PUT`, `DELETE` |
| Publishers | `GET /api/publishers`, ... |
| Authors | `GET /api/authors`, ... |
| Employees | `GET /api/employees`, ... |
| Users | `GET /api/users`, ... |
| Floors | `GET /api/floors`, ... |
| Shelves | `GET /api/shelves`, `GET /api/shelves/{code}`, ... |

All responses use a unified envelope:

```json
{
  "success": true,
  "message": "Retrieved successfully",
  "data": { }
}
```

---

## Seed data

On the first start the API applies migrations and seeds sample data (floors, employees, users, categories, publishers, authors, shelves, books, borrows), so the endpoints return data immediately.

---

## Tech stack

- .NET 10 / ASP.NET Core Web API
- Entity Framework Core 10 + SQL Server 2022
- AutoMapper
- Swashbuckle (Swagger UI)
- Generic Repository & Generic Service patterns
- Docker / Docker Compose
