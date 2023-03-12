## Movie Ticket Reservation System

### Technologies Used
-   C#
-   .NET 6
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server
-   AutoMapper

### Architecture Overview

The project follows a clean architecture pattern with separation of concerns between different layers. The architecture consists of four layers:
>  Domain layer: contains the domain entities, value objects, domain services, and domain exceptions.
>  Application layer: contains the use cases and application services that implement the business logic.
>  Infrastructure layer: contains the implementation details, such as repositories and database access code.
>   Web API layer: contains the API controllers and input/output models.

 The diagram below shows a high-level overview of the architecture:
 

### Design Patterns

 - Factory pattern: This pattern is used to create objects of different
   types based on a common interface. In your case, you can use a
   factory to create different types of reservations based on their
   state.

 - Builder pattern: This pattern is used to create complex objects by
   separating the construction logic from the object itself. In your
   case, you can use a builder to create reservations with various
   options.

 - Repository pattern: This pattern is used to abstract data access from
   the rest of the application. In your case, you can use a repository
   to perform CRUD (Create, Read, Update, Delete) operations on the
   reservations.
   
 - Unit of Work pattern: This pattern is used to group a set of related
   database operations into a single transaction. In your case, you can
   use a unit of work to ensure that all changes to the reservations are
   committed to the database atomically.


### Project Structure

The project structure follows a modular approach with separate projects for each layer:

-   CleanArchitecture.Domain
-   CleanArchitecture.Application
-   CleanArchitecture.Infrastructure
-   CleanArchitecture.WebApi

Each project contains the necessary folders and files for the layer's implementation.

### Domain Layer
The domain layer contains the domain entities and services, including:
>   Movie
>  Screen
>   ScreenShow
>  Reservation
>  ReservationStateEnum
>  IReservationRepository
>  IReservationService

The domain entities have relationships with each other, such as a ScreenShow belongs to a Screen, and a Reservation has a reference to a ScreenShow.

### Application Layer

The application layer contains the use cases and corresponding application services, including:

-   CreateReservationUseCase
-   ICreateReservationService
-   GetReservationByIdUseCase
-   IGetReservationService
-   CancelReservationUseCase
-   ICancelReservationService

The use cases encapsulate the business logic and call the corresponding application service to perform the required operations.

### Infrastructure Layer

The infrastructure layer contains the implementation details, such as repositories and database access code. It includes:

-   ReservationRepository
-   UnitOfWork
-   ApplicationDbContext

The repository implements the interface defined in the domain layer and provides the concrete implementation of the data access code. The unit of work groups related database operations and ensures transactional consistency. The ApplicationDbContext class provides the database context and configuration for Entity Framework Core.


### Web API Layer


The web API layer provides the RESTful API endpoints and input/output models. It includes the following controllers:

-   MovieController
-   ScreenController
-   ScreenShowController
-   ReservationController

Each controller maps to a use case in the application layer and calls the corresponding application service to perform the required operations. The input/output models provide a standardized representation of the data exchanged between the client and the server.

### Conclusion

The project is a clean architecture implementation that separates concerns between different layers and follows design patterns to ensure maintainability and extensibility. The project structure and organization provide a modular and scalable approach to development.