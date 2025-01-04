using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsByCategoryBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IManageProductsLocalStorageService ManageProductsLocalStorage { get; set; }

        [Parameter]
        public int CategoryId { get; set; }

        public IEnumerable<ProductDto>? Products { get; set; }

        public string CategoryName { get; set; } = "";

        public string? ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products = await GetProductCollectionByCategoryId(CategoryId);

                if (Products != null && Products.Count() > 0)
                {
                    var prod = Products.FirstOrDefault(p => p.CategoryId == CategoryId);

                    if (prod != null)
                    {
                        CategoryName = prod.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async Task<IEnumerable<ProductDto>?> GetProductCollectionByCategoryId(int catId)
        {
            var products = await ManageProductsLocalStorage.GetCollection();

            if (products != null)
            {
                return products.Where(p => p.CategoryId == catId);
            }
            else
            {
                return await ProductService.GetItemsByCategoryId(catId);
            }
        }
    }
}
