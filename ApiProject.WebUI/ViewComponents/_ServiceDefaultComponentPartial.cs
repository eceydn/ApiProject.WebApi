using ApiProject.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiProject.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ServiceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7178/api/Services");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var values = JsonSerializer.Deserialize<List<ResultServiceDto>>(jsonData, options);
                    return View(values);
                }
            }
            catch (Exception)
            {
                // API çalışmıyorsa boş sayfa göster
            }

            return View(new List<ResultServiceDto>());
        }
    }
}
