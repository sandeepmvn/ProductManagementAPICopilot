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

### 3. Update a Product
- **URL**: `/api/products/{id}`
- **Method**: `PUT`
- **Description**: Updates an existing product by ID
- **Request Body**: JSON object with updated product details
- **Response**: 204 No Content if successful

**Example Request Body:**
```json
{
  "name": "Updated Keyboard",
  "price": 89.99
}
```

**Example Request:**
```
PUT /api/products/3
```

### 4. Delete a Product
- **URL**: `/api/products/{id}`
- **Method**: `DELETE`
- **Description**: Deletes a product by ID
- **Response**: 204 No Content if successful

**Example Request:**
```
DELETE /api/products/1
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

4. **Test PUT Endpoint**:
   - Click on `PUT /api/products/{id}`
   - Click "Try it out"
   - Enter the product ID in the id field
   - Edit the request body JSON with updated values
   - Click "Execute"
   - View the 204 No Content response indicating success

5. **Test DELETE Endpoint**:
   - Click on `DELETE /api/products/{id}`
   - Click "Try it out"
   - Enter the product ID to delete
   - Click "Execute"
   - View the 204 No Content response indicating success

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

**Update a product:**
```bash
curl -X PUT "https://localhost:5001/api/products/1" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Updated Laptop\",\"price\":1099.99}"
```

**Delete a product:**
```bash
curl -X DELETE "https://localhost:5001/api/products/1" \
  -H "accept: application/json"
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

**Update a product:**
```powershell
$body = @{
    name = "Updated Tablet"
    price = 549.99
} | ConvertTo-Json

Invoke-RestMethod -Uri "https://localhost:5001/api/products/1" -Method Put -Body $body -ContentType "application/json"
```

**Delete a product:**
```powershell
Invoke-RestMethod -Uri "https://localhost:5001/api/products/1" -Method Delete
```

## Notes

- The API uses in-memory storage, so data will be lost when the application restarts
- All endpoints return JSON format
- The API is available alongside the MVC web interface
- Swagger UI provides interactive documentation and testing capabilities
