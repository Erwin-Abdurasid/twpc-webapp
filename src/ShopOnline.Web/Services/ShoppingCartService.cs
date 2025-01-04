using Newtonsoft.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;
using System.Text;

namespace ShopOnline.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _http;
        public event Action<int>? OnShoppingCartChanged;

        public ShoppingCartService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<CartItemDto?> AddItem(CartItemToAddDto itemToAddDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/shopping-cart", itemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();

                    throw new Exception($"HTTP Status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CartItemDto?> DeleteItem(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/shopping-cart/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }

                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemDto>?> GetItems(int userId)
        {
            try
            {
                var response = await _http.GetAsync($"api/shopping-cart/{userId}/get-items");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();

                    throw new Exception($"HTTP Status: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RaiseEventOnShoppingCartChanged(int totalQty)
        {
            if (OnShoppingCartChanged != null)
            {
                OnShoppingCartChanged.Invoke(totalQty);
            }
        }

        public async Task<CartItemDto?> UpdateItemQty(CartItemQtyUpdateDto itemQtyUpdateDto)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(itemQtyUpdateDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _http.PatchAsync($"api/shopping-cart/{itemQtyUpdateDto.CartItemId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
