using GutoShopping.Web.Models;
using GutoShopping.Web.Services.IServices;
using GutoShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GutoShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
                try
                {
                    // Configurar o cabeçalho de autorização
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Enviar o objeto cart para a API
                    var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);

                    // Verificar se a requisição foi bem sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler e retornar o conteúdo da resposta
                        return await response.ReadContentAs<CartViewModel>();
                    }
                    else
                    {
                        // Lançar uma exceção se a requisição falhar
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Failed to add item to cart. Status code: {response.StatusCode}, Error: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    // Capturar e relançar qualquer exceção ocorrida durante a chamada da API
                    throw new Exception("An error occurred when calling the API", ex);
                }

            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var response = await _client.PostAsJson($"{BasePath}/add-cart", model);
            //if (response.IsSuccessStatusCode)
            //    return await response.ReadContentAs<CartViewModel>();
            //else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

    }
}
