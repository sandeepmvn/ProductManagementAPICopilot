using ProductManagement.Models;

namespace ProductManagement.Services;

/// <summary>
/// Provides services for managing product data including creation and retrieval operations.
/// </summary>
public class ProductService
{
    private static readonly List<Product> _products = new();
    private static int _nextId = 1;

    /// <summary>
    /// Retrieves all products from the product collection.
    /// </summary>
    /// <returns>A list containing all products.</returns>
    public List<Product> GetAllProducts()
    {
        return _products.ToList();
    }

    /// <summary>
    /// Adds a new product to the product collection and assigns it a unique identifier.
    /// </summary>
    /// <param name="product">The product to add to the collection.</param>
    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        
        product.Id = _nextId++;
        _products.Add(product);
    }

    /// <summary>
    /// Removes a product from the collection by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to remove.</param>
    /// <returns>True if the product was successfully removed; otherwise, false.</returns>
    public bool RemoveProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return false;
        }

        _products.Remove(product);
        return true;
    }
}
