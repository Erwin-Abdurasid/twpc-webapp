using Blazored.LocalStorage;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ManageProductsLocalStorageService : IManageProductsLocalStorageService
    {
        private readonly ILocalStorageService _storageRepo;
        private readonly IProductService _productRepo;

        private const string Key = "ProductCollection";

        public ManageProductsLocalStorageService(ILocalStorageService localStorage,
            IProductService productService)
        {
            _storageRepo = localStorage;
            _productRepo = productService;
        }

        public async Task<IEnumerable<ProductDto>?> GetCollection()
        {
            return await _storageRepo.GetItemAsync<IEnumerable<ProductDto>>(Key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _storageRepo.RemoveItemAsync(Key);
        }

        private async Task<IEnumerable<ProductDto>?> AddCollection()
        {
            var products = await _productRepo.GetItems();

            if (products != null)
            {
                await _storageRepo.SetItemAsync(Key, products);
            }

            return products;
        }
    }
}
