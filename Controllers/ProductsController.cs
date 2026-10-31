using Microsoft.AspNetCore.Mvc;
using ProductStockAPI.DTOs.Products;
using ProductStockAPI.Models;
using ProductStockAPI.Services.Interfaces;

namespace ProductStockAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _service.GetAllAsync();

            var productDtos = products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            }).ToList();

            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(
            CreateProductDto createDto)
        {
            var product = new Product
            {
                Name = createDto.Name,
                Price = createDto.Price,
                StockQuantity = createDto.StockQuantity
            };

            var addedProduct = await _service.AddAsync(product);

            var productDto = new ProductDto
            {
                Id = addedProduct.Id,
                Name = addedProduct.Name,
                Price = addedProduct.Price,
                StockQuantity = addedProduct.StockQuantity
            };

            return CreatedAtAction(
                nameof(GetProducts),
                new { id = addedProduct.Id },
                productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(
            int id, UpdateProductDto updateDto)
        {
            var updatedProduct = new Product
            {
                Name = updateDto.Name,
                Price = updateDto.Price,
                StockQuantity = updateDto.StockQuantity
            };

            var product = await _service.UpdateAsync(id, updatedProduct);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}