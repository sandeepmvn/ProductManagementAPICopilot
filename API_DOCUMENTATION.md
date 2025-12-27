# Product Management API Documentation

## API Endpoint

### Base URL
```
/api/products
```

## Available Endpoints

### 1. Get All Products
- **URL**: `/api/products`
- **Method**: `GET`
- **Description**: Retrieves a list of all products
- **Response**: 200 OK with JSON array of products

**Example Response:**
```json
[
  {
    "id": 1,
    "name": "Laptop",
    "price": 999.99
  },
  {
    "id": 2,
    "name": "Mouse",
    "price": 29.99
  }
]
```

### 2. Add a New Product
- **URL**: `/api/products`
- **Method**: `POST`
- **Description**: Adds a new product to the list
- **Request Body**: JSON object with product details
- **Response**: 201 Created with the created product

**Example Request Body:**
```json
{
  "name": "Keyboard",
  "price": 79.99
}
```

**Example Response:**
```json
{
  "id": 3,
  "name": "Keyboard",
  "price": 79.99
}
```

## Using Swagger UI

1. **Access Swagger**: Navigate to `/swagger` in your browser (e.g., `https://localhost:5001/swagger`)

2. **Test GET Endpoint**:
   - Click on `GET /api/products`
   - Click "Try it out"
   - Click "Execute"
   - View the response below

3. **Test POST Endpoint**:
   - Click on `POST /api/products`
   - Click "Try it out"
   - Edit the request body JSON
   - Click "Execute"
   - View the created product in the response

## Validation Rules

- **Name**: Required, 1-100 characters
- **Price**: Required, between 0.01 and 999999.99

## Testing with cURL

**Get all products:**
```bash
curl -X GET "https://localhost:5001/api/products" -H "accept: application/json"
```

**Add a new product:**
```bash
curl -X POST "https://localhost:5001/api/products" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Tablet\",\"price\":499.99}"
```

## Testing with PowerShell

**Get all products:**
```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/products" -Method Get
```

**Add a new product:**
```powershell
$body = @{
    name = "Tablet"
    price = 499.99
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:5001/api/products" -Method Post -Body $body -ContentType "application/json"
```

## Notes

- The API uses in-memory storage, so data will be lost when the application restarts
- All endpoints return JSON format
- The API is available alongside the MVC web interface
- Swagger UI provides interactive documentation and testing capabilities
