# EShopMicroservices
This project is a microservices-based e-commerce system built with ASP.NET Core using Clean Architecture, DDD, CQRS, and Vertical Slice Architecture. It consists of four services: Catalog (PostgreSQL + Marten), Basket (PostgreSQL + Redis + gRPC), Discount (gRPC + SQLite), and Ordering (EF Core + SQL Server). The solution leverages MediatR with validation and logging behaviors, Carter for minimal APIs, and centralized exception handling. It also includes health checks, automated migrations, and domain events, delivering a scalable, cloud-ready backend architecture.
## 📚 Table of Contents

- [📦 EShopMicroservices](#eshopmicroservices)
- [🛠️ Services](#services)
  - [📁 Catalog Service](#catalog-service)
    - [Key Features & Architecture](#key-features--architecture)
    - [Vertical Slice Architecture](#vertical-slice-architecture)
    - [CQRS Pattern](#cqrs-pattern)
    - [Marten with PostgreSQL](#marten-with-postgresql)
    - [Carter Minimal APIs](#carter-minimal-apis)
    - [MediatR Pipeline Behaviors](#mediatr-pipeline-behaviors)
    - [Custom Exception Handling](#custom-exception-handling)
    - [Health Checks](#health-checks)
  - [🧺 Basket Service](#basket-service)
    - [Key Features & Architecture](#key-features--architecture-1)
    - [PostgreSQL + Marten](#postgresql--marten)
    - [Redis Caching Layer](#redis-caching-layer)
    - [gRPC Integration](#grpc-integration)
    - [Carter Minimal APIs](#carter-minimal-apis-1)
    - [MediatR Behaviors](#mediatr-behaviors)
  - [💸 Discount Service](#discount-service)
    - [Key Features & Architecture](#key-features--architecture-2)
    - [gRPC Communication](#grpc-communication)
    - [SQLite Database](#sqlite-database)
    - [Automated Database Migrations](#automated-database-migrations)
    - [Simple and Focused Design](#simple-and-focused-design)
  - [📦 Ordering Service](#ordering-service)
    - [Clean Architecture & Domain-Driven Design (DDD)](#clean-architecture--domain-driven-design-ddd)
    - [Clean Architecture Principles](#clean-architecture-principles)
    - [Domain-Driven Design (DDD)](#domain-driven-design-ddd)
    - [Key Features & Architecture](#key-features--architecture-3)
    - [Application Layer](#application-layer)
    - [Infrastructure Layer](#infrastructure-layer)
    - [API Layer](#api-layer)
    - [Database Initialization](#database-initialization)



# services
## Catalog Service

The Catalog Service is one of the core microservices in this ASP.NET Core solution. It is responsible for managing and exposing product catalog data to other services or clients.
### Key Features & Architecture
### Vertical Slice Architecture:
The service is structured around feature slices, promoting high cohesion and low coupling.

### CQRS Pattern

Command Query Responsibility Segregation is implemented to separate read and write operations, improving scalability and maintainability.



### Marten with PostgreSQL:

Uses PostgreSQL as the primary relational database.

Leverages Marten as a document database interface, simulating a NoSQL experience while benefiting from PostgreSQL's reliability.

### Carter Minimal APIs

Utilizes Carter for clean, minimal API endpoint definitions.

### MediatR Pipeline Behaviors

ValidationBehavior – Validates requests before execution.

LoggingBehavior – Logs request/response activities for better observability.

### Custom Exception Handling:

Centralized exception handling via CustomExceptionHandler for consistent error responses.

### Health Checks
Built-in health check endpoint (/health) to monitor database connectivity and service health.


## Basket Service

The Basket Service manages user shopping carts, offering high-performance data access and caching to ensure a seamless user experience.


### Key Features & Architecture

### PostgreSQL + Marten:
Stores shopping cart data using PostgreSQL.

Uses Marten as a document database layer to simplify persistence and querying.

### Redis Caching Layer:

Integrates Redis for distributed caching to improve read performance and reduce database load.

Uses a repository decorator pattern (CachBasketRepository) to transparently add caching to the IBasketRepository.

### gRPC Integration:

Communicates with the Discount Service over gRPC to apply dynamic discounts to basket items.

### Carter Minimal APIs:

Provides a clean, modular API surface.

### MediatR Behaviors:

ValidationBehavior – Ensures all incoming commands and queries are validated.

LoggingBehavior – Logs requests for better traceability and debugging.

## Discount Service

The Discount Service is a lightweight and high-performance microservice built with gRPC to provide discount calculation and retrieval capabilities to other services (such as the Basket Service). It centralizes all discount-related logic, ensuring consistent pricing rules across the system.

### Key Features & Architecture

### gRPC Communication:

Implements a gRPC-based API for fast, type-safe, and high-performance communication between services.

Ensures efficient integration with services like Basket, which query discount information during checkout.

### SQLite Database:

Uses Entity Framework Core with SQLite as the database engine.

Ideal for lightweight data storage and rapid access to discount records.

### Automated Database Migrations:

Integrates automatic database migration via app.UseMigration() during startup, ensuring schema consistency without manual steps.

### Simple and Focused Design:

Designed as a focused, single-responsibility service, handling only discount-related data and logic.

Follows a clear separation of concerns with dedicated data and service layers.


## Ordering Service

The Ordering Service is the most complex and feature-rich microservice in the system. It is responsible for managing the full order lifecycle — from creation and processing to persistence — and is designed with enterprise-grade architectural patterns for scalability, maintainability, and domain fidelity.

## Clean Architecture & Domain-Driven Design (DDD)

### Clean Architecture Principles:

Strict separation of concerns across Application, Infrastructure, and API layers.

Promotes maintainability, testability, and clear dependency boundaries.

### Domain-Driven Design (DDD):

Focuses on the core domain logic, encapsulating business rules within the Domain Layer.

Uses rich domain models and aggregates to ensure consistency and integrity of order-related operations.


### Key Features & Architecture

### Application Layer:

Contains business use cases and orchestrates domain logic.

Uses MediatR for implementing CQRS-style request/response handling.

Incorporates cross-cutting concerns like:

ValidationBehavior – Ensures all requests are validated before execution.

LoggingBehavior – Provides detailed logging for traceability.

### Infrastructure Layer:

Manages data access using Entity Framework Core with SQL Server as the primary database.

Adds SaveChanges Interceptors such as:

AuditableEntityInterceptor – Automatically populates audit fields like created/updated timestamps.

DispatchDomainEventInterceptor – Publishes domain events after transactions are committed, enabling event-driven workflows.

### API Layer:

Exposes RESTful endpoints for order operations.

Configured with middleware for dependency injection, exception handling, and routing.

### Database Initialization:

Includes an automatic database initialization process (app.InitialiesDatabaseAsync()) in development environments for easier setup and testing.







