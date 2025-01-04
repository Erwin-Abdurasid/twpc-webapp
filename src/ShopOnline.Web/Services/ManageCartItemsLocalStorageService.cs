using Blazored.LocalStorage;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService _storageRepo;
        private readonly IShoppingCartService _cartRepo;

        private const string Key = "CartItemCollection";

        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService,
            IShoppingCartService shoppingCartService)
        {
            _storageRepo = localStorageService;
            _cartRepo = shoppingCartService;
        }

        public async Task<List<CartItemDto>?> GetCollection()
        {
            return await _storageRepo.GetItemAsync<List<CartItemDto>>(Key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _storageRepo.RemoveItemAsync(Key);
        }

        public async Task SaveCollection(List<CartItemDto>? cartItems)
        {
            await _storageRepo.SetItemAsync(Key, cartItems);
        }

        private async Task<List<CartItemDto>?> AddCollection()
        {
            var cartItems = await _cartRepo.GetItems(HardCoded.UserId);

            if (cartItems != null)
            {
                await _storageRepo.SetItemAsync(Key, cartItems);
            }

            return cartItems;
        }
    }
}
