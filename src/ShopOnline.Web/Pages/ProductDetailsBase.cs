using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorage { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorage { get; set; }

        public List<CartItemDto>? ShoppingCartItems { get; set; }

        [Inject]
        public NavigationManager NVManager { get; set; }

        public ProductDto? Product { get; set; }

        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorage.GetCollection();

                Product = await GetProductById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public async Task AddtoCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);

                if (cartItemDto != null)
                {
                    ShoppingCartItems.Add(cartItemDto);

                    await ManageCartItemsLocalStorage.SaveCollection(ShoppingCartItems);
                }

                NVManager.NavigateTo("/shopping-cart");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<ProductDto?> GetProductById(int id)
        {
            var productDtos = await ManageProductsLocalStorage.GetCollection();

            if (productDtos != null)
            {
                return productDtos.SingleOrDefault(p => p.Id == id);
            }

            return default;
        }
    }
}
