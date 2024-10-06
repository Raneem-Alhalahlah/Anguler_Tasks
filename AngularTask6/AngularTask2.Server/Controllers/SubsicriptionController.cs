using AngularTask2.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTask2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsicriptionController : ControllerBase
    {
        private readonly MyDbContext _db;
        public SubsicriptionController(MyDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        public IActionResult getSubscriptions()
        {
            var subscriptions =_db.Subscriptions.ToList();
            return Ok(subscriptions);
        }
    }
}
