# ClearerAuthenticationSystem



A simple authentication system built with .NET 9 using Onion Architecture and Repository Pattern.



Architecture



This project follows Onion Architecture with four distinct layers:



\- ClearerAPI - Presentation Layer (Controllers, Middleware)

\- Application - Application Layer (Services, DTOs)

\- Domain - Domain Layer (Entities, Interfaces)

\- Infrastructure - Infrastructure Layer (Repositories, Database)



Features



\- User Registration with secure password hashing (BCrypt)

\- User Login with JWT token generation

\- Token-based authentication and authorization

\- Protected endpoints with middleware validation

\- Swagger documentation

\- Entity Framework Core with SQL Server

\- Repository Pattern implementation



&nbsp;

\*\*Prerequisites\*\*



Visual Studio 2022

.NET 9 SDK

SQL Server





Testing: Using Swagger UI



Navigate to /swagger

Test registration and login endpoints

Copy JWT token from login response

Click "Authorize" and enter: Bearer {token}

Test protected endpoints





API Endpoints



&nbsp;Register User

\- POST `/api/auth/register`

\- Content-Type: `application/json`

\- Body:

```json

{

&nbsp; "username": "ayo",

&nbsp; "email": "ayo@gmail.com",

&nbsp; "password": "ayo123!"

}



