using ProductManagement.Models;

namespace ProductManagement.Services;

public class ProductService
{
    private static readonly List<Product> _products = new();
    private static int _nextId = 1;

    public List<Product> GetAllProducts()
    {
        return _products.ToList();
    }

    public void AddProduct(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
    }
}
