using ProductStockAPI.Models;

namespace ProductStockAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product updatedProduct);
        Task<bool> DeleteAsync(int id);


    }
}
