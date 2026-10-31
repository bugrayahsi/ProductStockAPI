using ProductStockAPI.Models;

namespace ProductStockAPI.Services.Interfaces
    
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product updatedProduct);
        Task<bool> DeleteAsync(int id);

    }
}
