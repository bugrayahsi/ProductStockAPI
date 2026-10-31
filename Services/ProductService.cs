using ProductStockAPI.Models;
using ProductStockAPI.Repositories.Interfaces;
using ProductStockAPI.Services.Interfaces;

namespace ProductStockAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Product> AddAsync(Product product)
        {
            return _repository.AddAsync(product);
        }

        public Task<Product?> UpdateAsync(
            int id, Product updatedProduct)
        {
            return _repository.UpdateAsync(id, updatedProduct);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}