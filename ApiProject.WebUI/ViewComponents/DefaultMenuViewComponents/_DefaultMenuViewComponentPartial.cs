using ApiProject.WebUI.Dtos.CategoryDtos;
using ApiProject.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiProject.WebUI.ViewComponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMenuViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7178/api/Products/ProductListWithCategory");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    return View(values);
                }
                ViewBag.ErrorMessage = $"API Hatası: {responseMessage.StatusCode}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Bağlantı Hatası: {ex.Message}";
            }
            
            return View();
        }
    }
}
