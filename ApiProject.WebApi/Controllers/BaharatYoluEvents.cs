using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaharatYoluEvents : ControllerBase
    {
        private readonly ApiContext _context;

        public BaharatYoluEvents(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BaharatYoluEventList()
        {
            var values = _context.BaharatYoluEvents.ToList();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateBaharatYoluEvent(BaharatYoluEvent BaharatYoluEvent)
        {
            _context.BaharatYoluEvents.Add(BaharatYoluEvent);
            _context.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteBaharatYoluEvent(int id)
        {
            var value = _context.BaharatYoluEvents.Find(id);
            _context.BaharatYoluEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik silme işlemi başarılı!");
        }

        [HttpGet("GetBaharatYoluEvent")]
        public IActionResult GetBaharatYoluEvent(int id)
        {
            var value = _context.BaharatYoluEvents.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateBaharatYoluEvent(BaharatYoluEvent BaharatYoluEvent)
        {
            _context.BaharatYoluEvents.Update(BaharatYoluEvent);
            _context.SaveChanges();
            return Ok("Etkinlik güncelleme işlemi başarılı!");
        }
    }
}
