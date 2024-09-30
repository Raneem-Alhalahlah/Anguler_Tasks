using AngularTask2.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTask2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ServicesController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAllServices()
        {
            var services = _db.Services.ToList();
            if (!services.Any()) 
            { return BadRequest(); }
            return Ok(services);
        }
    }
}
