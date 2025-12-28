using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;
    /// <summary>
    /// Initializes a new instance of the ProductsController class using the specified product service.
    /// </summary>
    /// <param name="productService">The service used to manage and retrieve product data. Cannot be null.</param>
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns>A list of products</returns>
    /// <response code="200">Returns the list of products</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
    public ActionResult<List<Product>> GetProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    /// <summary>
    /// Adds a new product
    /// </summary>
    /// <param name="product">The product to add</param>
    /// <returns>The created product</returns>
    /// <response code="201">Returns the newly created product</response>
    /// <response code="400">If the product is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    /// <returns>No content if successful</returns>
    /// <response code="204">Product successfully deleted</response>
    /// <response code="404">Product not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteProduct(int id)
    {
        var result = _productService.RemoveProduct(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

}
