# Product Management API

A modern ASP.NET Core web application that provides both a RESTful API and an MVC web interface for managing products. Built with .NET 10.0, this application demonstrates best practices for building scalable web APIs with comprehensive documentation using Swagger/OpenAPI.

## Features

- 🚀 RESTful API for product management (Create, Read, Delete operations)
- 🌐 MVC web interface for user-friendly product management
- 📝 Interactive API documentation with Swagger UI
- ✅ Data validation with comprehensive error handling
- 🔄 CORS support for frontend integration
- 💾 In-memory data storage for easy testing and development
- 📋 XML documentation for all API endpoints

## Technology Stack

- **Framework**: ASP.NET Core 10.0
- **Language**: C# with nullable reference types enabled
- **API Documentation**: Swashbuckle.AspNetCore (Swagger/OpenAPI)
- **Architecture**: MVC pattern with service layer
- **Data Validation**: Data Annotations

## Prerequisites

Before running this application, ensure you have the following installed:

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- A code editor (Visual Studio 2022, Visual Studio Code, or JetBrains Rider)
- (Optional) Postman, curl, or similar tool for API testing

## Getting Started

### Installation

1. Clone the repository:
```bash
git clone https://github.com/sandeepmvn/ProductManagementAPICopilot.git
cd ProductManagementAPICopilot
```

2. Navigate to the project directory:
```bash
cd ProductManagement
```

3. Restore dependencies:
```bash
dotnet restore
```

### Running the Application

1. Build the project:
```bash
dotnet build
```

2. Run the application:
```bash
dotnet run
```

3. The application will start and be available at:
   - HTTPS: `https://localhost:5001`
   - HTTP: `http://localhost:5000`

4. Access the different interfaces:
   - **Swagger UI**: Navigate to `https://localhost:5001/swagger` for interactive API documentation
   - **MVC Web Interface**: Navigate to `https://localhost:5001` for the web interface
   - **API Endpoints**: Available at `https://localhost:5001/api/products`

## API Documentation

The API provides the following endpoints for product management:

### Endpoints Overview

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Retrieve all products |
| POST | `/api/products` | Create a new product |
| DELETE | `/api/products/{id}` | Delete a product by ID |

For detailed API documentation, including request/response examples and testing instructions, please refer to [API_DOCUMENTATION.md](API_DOCUMENTATION.md).

### Quick API Examples

**Get all products:**
```bash
curl -X GET "https://localhost:5001/api/products" -H "accept: application/json"
```

**Create a new product:**
```bash
curl -X POST "https://localhost:5001/api/products" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d '{"name":"Laptop","price":999.99}'
```

**Delete a product:**
```bash
curl -X DELETE "https://localhost:5001/api/products/1" -H "accept: application/json"
```

## Project Structure

```
ProductManagement/
├── Controllers/
│   ├── HomeController.cs          # MVC controller for web interface
│   ├── ProductController.cs       # MVC controller for product views
│   └── ProductsController.cs      # API controller for RESTful endpoints
├── Models/
│   ├── Product.cs                 # Product data model with validation
│   └── ErrorViewModel.cs          # Error handling model
├── Services/
│   └── ProductService.cs          # Business logic for product management
├── Views/                         # Razor views for MVC interface
├── wwwroot/                       # Static files (CSS, JS, images)
├── Program.cs                     # Application entry point and configuration
└── appsettings.json              # Application configuration
```

## Data Model

The `Product` model includes the following properties:

| Property | Type | Validation Rules |
|----------|------|------------------|
| Id | int | Auto-generated |
| Name | string | Required, 1-100 characters |
| Price | decimal | Required, 0.01-999999.99 |

## Configuration

### CORS Configuration

The application includes CORS support configured for frontend integration on `http://localhost:5173`. To modify CORS settings, update the policy in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

### Swagger Configuration

Swagger is enabled for both development and production environments. Access the interactive documentation at `/swagger`.

## Development

### Building the Project

```bash
dotnet build
```

### Running in Development Mode

```bash
dotnet run --environment Development
```

### Testing

You can test the API using:
- **Swagger UI**: `https://localhost:5001/swagger` for interactive testing
- **Postman**: Import the OpenAPI specification from Swagger
- **curl**: Command-line testing (see examples above)
- **PowerShell**: See [API_DOCUMENTATION.md](API_DOCUMENTATION.md) for PowerShell examples

## Important Notes

- ⚠️ **In-Memory Storage**: This application uses in-memory storage. All data will be lost when the application restarts.
- 🔒 **Development Certificate**: You may need to trust the development certificate for HTTPS:
  ```bash
  dotnet dev-certs https --trust
  ```
- 🌐 **Production Deployment**: For production use, replace in-memory storage with a persistent database (SQL Server, PostgreSQL, etc.)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is open source and available for educational and demonstration purposes.

## Contact

For questions or feedback, please contact the Product Management Team.

---

**Built with ❤️ using ASP.NET Core**
