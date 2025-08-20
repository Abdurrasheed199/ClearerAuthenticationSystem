# ClearerAuthenticationSystem



Authentication System



A simple authentication system built with .NET 9 using Onion Architecture and Repository Pattern.



Architecture



This project follows Onion Architecture with four distinct layers:



\- AuthSystem.API - Presentation Layer (Controllers, Middleware)

\- AuthSystem.Application - Application Layer (Services, DTOs)

\- AuthSystem.Domain - Domain Layer (Entities, Interfaces)

\- AuthSystem.Infrastructure - Infrastructure Layer (Repositories, Database)



Features



\- User Registration with secure password hashing (BCrypt)

\- User Login with JWT token generation

\- Token-based authentication and authorization

\- Protected endpoints with middleware validation

\- Swagger/OpenAPI documentation

\- Entity Framework Core with SQL Server

\- Repository Pattern implementation



API Endpoints



&nbsp;Register User

\- POST `/api/auth/register`

\- Content-Type: `application/json`

\- Body:

```json

{

&nbsp; "username": "testuser",

&nbsp; "email": "test@example.com",

&nbsp; "password": "SecurePass123!"

}



