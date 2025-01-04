using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; } = null!;

        [Inject]
        public IJSRuntime Js { get; set; } = null!;

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorage { get; set; } = null!;

        public List<CartItemDto>? CartItems { get; set; }

        public decimal TotalPrice { get; set; }

        public int TotalQuantity { get; set; }

        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CartItems = await ManageCartItemsLocalStorage.GetCollection();

                CartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public async Task UpdateQty_input(int id)
        {
            await Js.InvokeVoidAsync("makeUpdateQtyButtonVisible", id, true);
        }

        public async Task UpdateItemQty_Click(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    var updateItemDto = new CartItemQtyUpdateDto
                    {
                        CartItemId = id,
                        Qty = qty
                    };

                    var returnedItemDto = await ShoppingCartService.UpdateItemQty(updateItemDto);

                    await UpdateItemTotalPrice(returnedItemDto);
                }
                else
                {
                    CartItemDto? item = default;

                    if (CartItems != null)
                    {
                        item = CartItems.FirstOrDefault(c => c.Id == id);
                    }

                    if (item != null)
                    {
                        item.Qty = 1;
                        item.TotalPrice = item.ProductPrice;
                    }

                    await UpdateItemTotalPrice(item);
                }

                CartChanged();

                await Js.InvokeVoidAsync("makeUpdateQtyButtonVisible", id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task UpdateItemTotalPrice(CartItemDto? itemDto)
        {
            CartItemDto? cartItem = default;

            if (itemDto != null)
            {
                cartItem = GetCartItem(itemDto.Id);
            }
            
            if (cartItem != null)
            {
                cartItem.TotalPrice = cartItem.ProductPrice * cartItem.Qty;
            }

            await ManageCartItemsLocalStorage.SaveCollection(CartItems);
        }

        public async Task DeleteItem_Click(int id)
        {
            _ = await ShoppingCartService.DeleteItem(id);

            await RemoveCartItem(id);

            CartChanged();
        }

        private CartItemDto? GetCartItem(int id)
        {
            if (CartItems != null)
            {
                return CartItems.FirstOrDefault(c => c.Id == id);
            }

            return default;
        }

        private async Task RemoveCartItem(int id)
        {
            CartItemDto? cartItemDto = default;

            if (CartItems != null)
            {
                cartItemDto = GetCartItem(id);

                if (cartItemDto != null)
                {
                    CartItems.Remove(cartItemDto);
                }
            }

            await ManageCartItemsLocalStorage.SaveCollection(CartItems);
        }

        private void CalculateCartSummaryTotal()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }

        private void SetTotalPrice()
        {
            if (CartItems != null)
            {
                TotalPrice = CartItems.Sum(c => c.TotalPrice);
            }
        }

        private void SetTotalQuantity()
        {
            if (CartItems != null)
            {
                TotalQuantity = CartItems.Sum(c => c.Qty);
            }
        }

        private void CartChanged()
        {
            CalculateCartSummaryTotal();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }
    }
}
