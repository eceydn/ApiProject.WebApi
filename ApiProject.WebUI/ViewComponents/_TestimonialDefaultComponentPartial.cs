using ApiProject.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProject.WebUI.ViewComponents
{
    public class _TestimonialDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7178/api/Testimonials/");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<Dtos.TestimonialDtos.ResultTestimonialDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception)
            {
                // API çalışmıyorsa hata fırlatmasını engelle
            }
            return View(new List<Dtos.TestimonialDtos.ResultTestimonialDto>());
        }
    }
}
