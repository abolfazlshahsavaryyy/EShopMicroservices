# EShopMicroservices
description 

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












