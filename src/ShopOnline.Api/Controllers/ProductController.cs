using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository productRepository)
        {
            _repo = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>?>> GetItems()
        {
            try
            {
                var products = await _repo.GetItems();

                var productDtos = products.ConvertToProductDto();

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await _repo.GetItem(id);

                if (product == null) return BadRequest();

                ProductDto? productDto = product.ConvertToProductDto();

                return Ok(productDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database.");
            }
        }

        [HttpGet("product-categories")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var categories = await _repo.GetCategories();

                var categorieDtos = categories.ConvertToProductCategoryDto();

                return Ok(categorieDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database.");
            }
        }

        [HttpGet("product-categories/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategoryId(int categoryId)
        {
            try
            {
                var products = await _repo.GetItemsByCategory(categoryId);

                var productDtos = products.ConvertToProductDto();

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database.");
            }
        }
    }
}
