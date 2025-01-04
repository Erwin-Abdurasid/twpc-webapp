using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/shopping-cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _repo;
        private readonly IProductRepository _productRepo;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            _repo = shoppingCartRepository;
            _productRepo = productRepository;
        }

        [HttpGet("{userId:int}/get-items")]
        public async Task<ActionResult<IEnumerable<CartItemDto>?>> GetItems(int userId)
        {
            try 
	        {
                var cartItems = await _repo.GetItems(userId);

                if (cartItems == null) return NoContent();

                var products = await _productRepo.GetItems();

                if (products == null) throw new Exception("No products exists in the system.");

                var cartItemDtos = cartItems.ConvertToCartItemDto(products);

                return Ok(cartItemDtos);
	        }
	        catch (Exception ex)
	        {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
	        }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto?>> GetItem(int id)
        {
            try
            {
                var cartItem = await _repo.GetItem(id);

                if (cartItem == null) return NotFound();

                var product = await _productRepo.GetItem(cartItem.ProductId);

                if (product == null) return NotFound();

                var cartItemDto = cartItem.ConvertToCartItemDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto?>> PostItem([FromBody] CartItemToAddDto itemToAddDto)
        {
            try
            {
                var newCartItem = await _repo.AddItem(itemToAddDto);

                if (newCartItem == null) return NoContent();

                var product = await _productRepo.GetItem(newCartItem.ProductId);

                if (product == null)
                    throw new Exception($"Someting went wrong when attemping to retrieve product (productId: {newCartItem.ProductId})");

                var cartItemDto = newCartItem.ConvertToCartItemDto(product);

                return CreatedAtAction(nameof(GetItem), new { cartItemDto.Id }, cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto?>> DeleteItem(int id)
        {
            try
            {
                var cartItem = await _repo.DeleteItem(id);

                if (cartItem == null) return NotFound();

                var product = await _productRepo.GetItem(cartItem.ProductId);

                var cartItemDto = cartItem.ConvertToCartItemDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CartItemDto?>> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            try
            {
                var cartItem = await _repo.UpdateQty(id, cartItemQtyUpdateDto);

                if (cartItem == null) return NotFound();

                var product = await _productRepo.GetItem(cartItem.ProductId);

                var cartItemDto = cartItem.ConvertToCartItemDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
