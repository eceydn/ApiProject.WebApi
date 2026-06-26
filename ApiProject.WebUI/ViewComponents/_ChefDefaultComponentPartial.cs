using ApiProject.WebUI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiProject.WebUI.ViewComponents
{
    public class _ChefDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ChefDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7178/api/Chefs");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var values = JsonSerializer.Deserialize<List<ResultChefDto>>(jsonData, options);
                    return View(values);
                }
            }
            catch (Exception)
            {
                // API çalışmıyorsa boş sayfa göster
            }

            return View(new List<ResultChefDto>());
        }
    }
}
