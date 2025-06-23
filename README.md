# 🏪 MiniMarketplace - E-Commerce Solution

## 📌 Overview

MiniMarketplace is a robust e-commerce platform following Clean Architecture principles with clear separation of concerns. This solution demonstrates modern .NET development practices including domain-driven design, repository pattern, and dependency inversion.

## Project Structure
```
MiniMarketplace
├── 📁 Api/                          # Presentation Layer
│   ├── Controllers/                # API Endpoints
│   ├── Middleware/                 # Custom middleware
│   └── Program.cs                  # Startup configuration
│
├── 📁 Application/                  # Application Layer
│   ├── Interfaces/                 # Repository & service contracts
│   ├── Services/                   # Use case implementations
│   └── Mappers/                    # Object mapping profiles
│
├── 📁 Domain/                       # Domain Layer
│   ├── ValueObjects/               # Domain value objects
│   ├── DTOs/                       # Data transfer objects
│   └── Exceptions/                 # Domain-specific exceptions
│
├── 📁 Persistence/                  # Data Access Layer
│   ├── Data/                       # DbContext configuration
│   ├── Entities/                   # Aggregate roots
│   ├── Mappers/                    # Persistence mapping logic
│   ├── Migrations/                 # EF Core migrations
│   └── Repositories/               # Repository implementations
│
├── 📁 Infrastructure/               # Cross-cutting Concerns
│   └── Services/                   # External service adapters
│
├── 📁 Tests/                       # Unit Tests, Integration Tests
│
└── 📄 MiniMarketplace.sln          # Solution file
```
## Prerequisites
* .NET 8.0 SDK
* Docker (for local PostgreSQL instance)
* PostgreSQL 15 (via Docker or native installation)
* Environment variables management (e.g., .env files or secret managers)

## Local Development Setup
### 1. Provision the PostgreSQL Database
Use Docker Compose for consistent local database environment:
```
version: '3.8'

services:
  postgres:
    image: postgres:15
    environment:
      POSTGRES_DB: MiniMarketplaceDb
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: ${POSTGRES_PASSWORD} # Use environment variables or secret management
    ports:
      - "5432:5432"
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
```
Launch the database container: ``` docker-compose up -d ```

## Setup

1. Copy `.env.example` to `.env` and update the following variables as needed:  
* `DB_CONNECTION_STRING`  
* `DB_PASSWORD`  
(Make sure the database credentials match your local or dev environment.)

2. Start PostgreSQL with Docker Compose:  ```docker-compose up -d```

Apply database migrations:
```dotnet ef database update --project MiniMarketplace.Persistence``` 

Build and run the API:
```dotnet run --project Api``` 
