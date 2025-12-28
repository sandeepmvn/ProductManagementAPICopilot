# GitHub Copilot Instructions
## .NET 10 Web API & MVC Project

These instructions guide GitHub Copilot to generate consistent, secure, maintainable, and production-ready code for this repository.

---

## 1. Technology Stack

- **Framework**: .NET 10
- **Languages**: C#
- **Architectures**:
  - ASP.NET Core Web API
  - ASP.NET Core MVC
- **ORM**: Entity Framework Core (latest compatible with .NET 10)
- **Authentication**: JWT / Cookie-based auth (as applicable)
- **Logging**: Microsoft.Extensions.Logging
- **Testing**: xUnit / NUnit (as used in project)
- **Dependency Injection**: Built-in ASP.NET Core DI

---

## 2. General Coding Standards

- Follow **Microsoft C# Coding Conventions**
- Prefer **readability over cleverness**
- Use **explicit typing** for public APIs
- Use `var` only when the type is obvious
- Avoid magic numbers and strings – use constants or enums
- Write **null-safe** code (`nullable enable` assumed)

---

## 3. Project Structure Conventions

### Web API
/Controllers
/Application
/Domain
/Infrastructure
/DTOs
/Mappings
/Middlewares

shell
Copy code

### MVC
/Controllers
/Models
/ViewModels
/Views
/wwwroot

markdown
Copy code

- Keep **controllers thin**
- Business logic must live in **Application/Service** layers
- Data access must live in **Infrastructure/Repositories**

---

## 4. Controller Guidelines

### Web API Controllers
- Use `[ApiController]`
- Use attribute routing (`[HttpGet]`, `[HttpPost]`, etc.)
- Always return `ActionResult<T>`
- Use proper HTTP status codes:
  - `200 OK`
  - `201 Created`
  - `400 BadRequest`
  - `401 Unauthorized`
  - `403 Forbidden`
  - `404 NotFound`
  - `500 InternalServerError`

Example:
```csharp
[HttpGet("{id:guid}")]
public async Task<ActionResult<UserDto>> GetById(Guid id)
MVC Controllers
Keep logic minimal

Use ViewModels, never expose domain entities directly

Prefer IActionResult

5. Dependency Injection
Constructor injection only

Do not use service locators

Register services using extension methods

Example:

csharp
Copy code
builder.Services.AddScoped<IUserService, UserService>();
6. Entity Framework Core Rules
Use async/await for all DB calls

No business logic inside DbContext

Prefer Fluent API over Data Annotations

Use AsNoTracking() for read-only queries

Avoid N+1 queries

7. DTOs & Mapping
Never expose EF entities directly to API responses

Use DTOs for requests and responses

Use AutoMapper or manual mapping (follow project standard)

DTOs should be immutable where possible

8. Error Handling & Validation
Centralized exception handling via middleware

Do not use try-catch in controllers unless necessary

Use ProblemDetails for API errors

Validate inputs using:

DataAnnotations

FluentValidation (if configured)

9. Security Best Practices
Never log secrets, tokens, or PII

Validate all user input

Use [Authorize] and [AllowAnonymous] explicitly

Protect against over-posting in MVC

Use HTTPS-only assumptions

10. Logging
Use ILogger<T>

Log at appropriate levels:

Information → business flow

Warning → recoverable issues

Error → failures/exceptions

Do not use Console.WriteLine

11. Async & Performance
Prefer async all the way

Do not block async calls (.Result, .Wait())

Avoid long-running tasks in controllers

Use background services where applicable

12. Testing Expectations
Write unit tests for:

Services

Business logic

Controllers should be tested with mocks

Avoid testing framework internals

13. Code Generation Expectations for Copilot
When generating code, Copilot should:

Match existing project structure

Reuse existing patterns and abstractions

Avoid introducing new libraries without justification

Include XML comments for public APIs

Generate production-ready, not demo-level code

14. What NOT to Do
❌ No inline SQL queries

❌ No business logic in controllers

❌ No hard-coded configuration values

❌ No synchronous database calls

❌ No exposing internal models to UI/API

15. Assumptions
Nullable reference types are enabled

Latest C# language features supported by .NET 10 are allowed

Clean Architecture principles are preferred

End of instructions.

