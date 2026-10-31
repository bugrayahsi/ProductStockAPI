using Microsoft.EntityFrameworkCore;
using ProductStockAPI.Data;
using ProductStockAPI.Models;
using ProductStockAPI.Repositories.Interfaces;

namespace ProductStockAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> UpdateAsync(
            int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}