using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class CheckoutBase : ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        public IEnumerable<CartItemDto> CartItems { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorage { get; set; }

        public int TotalQty { get; set; }

        public string PaymentDescription { get; set; } = "";

        public decimal PaymentAmount { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                CartItems = await ManageCartItemsLocalStorage.GetCollection();

                if (CartItems != null)
                {
                    Guid orderGuid = Guid.NewGuid();

                    PaymentAmount = CartItems.Sum(p => p.TotalPrice);
                    TotalQty = CartItems.Sum(p => p.Qty);
                    PaymentDescription = $"O_{HardCoded.UserId}_{orderGuid}";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPaypalButton");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
