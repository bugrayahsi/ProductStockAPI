using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(
            IProductService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _service.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(
            CreateProductDto createDto)
        {
            var product = _mapper.Map<Product>(createDto);

            var addedProduct = await _service.AddAsync(product);

            var productDto = _mapper.Map<ProductDto>(addedProduct);

            return CreatedAtAction(
                nameof(GetProducts),
                new { id = addedProduct.Id },
                productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(
            int id, UpdateProductDto updateDto)
        {
            var updatedProduct = _mapper.Map<Product>(updateDto);

            var product = await _service.UpdateAsync(id, updatedProduct);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);

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