using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _context;

        public ShoppingCartRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await _context.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                        c.ProductId == productId);
        }

        public async Task<CartItem?> AddItem(CartItemToAddDto itemToAddDto)
        {
            if (!await CartItemExists(itemToAddDto.CartId, itemToAddDto.ProductId))
            {
                var item = await (from product in _context.Products
                                  where product.Id == itemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = itemToAddDto.CartId,
                                      ProductId = itemToAddDto.ProductId,
                                      Qty = itemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await _context.CartItems.AddAsync(item);
                    await _context.SaveChangesAsync();

                    return result.Entity;
                }
            }

            return null;
        }

        public async Task<CartItem?> DeleteItem(int id)
        {
            var item = await _context.CartItems.FindAsync(id);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem?> GetItem(int id)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              CartId = cartItem.CartId,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>?> GetItems(int userId)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              CartId = cartItem.CartId,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty
                          }).ToListAsync();
        }

        public async Task<CartItem?> UpdateQty(int id, CartItemQtyUpdateDto itemQtyUpdateDto)
        {
            var item = await _context.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = itemQtyUpdateDto.Qty;

                await _context.SaveChangesAsync();

                return item;
            }

            return null;
        }
    }
}
