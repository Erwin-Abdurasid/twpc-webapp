using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorage { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorage { get; set; }

        public IEnumerable<ProductDto>? Products { get; set; }

        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ClearLocalStorage();

                Products = await ManageProductsLocalStorage.GetCollection();

                var shoppingCartItems = await ManageCartItemsLocalStorage.GetCollection();
                var totalQty = shoppingCartItems.Sum(i => i.Qty);

                ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public int GetProductsCount()
        {
            return Products?.Count() ?? 0;
        }

        public IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        public string GetCategoryName(IGrouping<int, ProductDto> prodGroup)
        {
            return prodGroup.FirstOrDefault(p => p.CategoryId == prodGroup.Key).CategoryName;
        }

        private async Task ClearLocalStorage()
        {
            await ManageCartItemsLocalStorage.RemoveCollection();
            await ManageProductsLocalStorage.RemoveCollection();
        }
    }
}
