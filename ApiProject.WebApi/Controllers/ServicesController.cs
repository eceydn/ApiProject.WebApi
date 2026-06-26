using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Servis ekleme işlemi başarılı!");
        }

        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            return NotFound("Servis bulunamadı!");
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Servis silme işlemi başarılı!");
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            return NotFound("Servis bulunamadı!");
            return Ok(value);
        }

        [HttpPut("UpdateService")]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis güncelleme işlemi başarılı!");
        }
    }
}
