# 🏪 MiniMarketplace - Clean Architecture E-Commerce Solution

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
│   ├── DTOs/                       # Data transfer objects
│   └── Mappers/                    # Object mapping profiles
│
├── 📁 Domain/                       # Domain Layer
│   ├── Entities/                   # Aggregate roots
│   ├── ValueObjects/               # Domain value objects
│   └── Exceptions/                 # Domain-specific exceptions
│
├── 📁 Persistence/                  # Data Access Layer
│   ├── Data/                       # DbContext configuration
│   ├── Repositories/               # Repository implementations
│   ├── Migrations/                 # EF Core migrations
│   └── Mappers/                    # Persistence mapping logic
│
├── 📁 Infrastructure/               # Cross-cutting Concerns
│   └── Services/                   # External service adapters
│
└── 📄 MiniMarketplace.sln          # Solution file
```
