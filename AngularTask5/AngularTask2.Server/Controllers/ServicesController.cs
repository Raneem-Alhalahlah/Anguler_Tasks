using AngularTask2.Server.Dtos;
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

        [HttpPost("addservise")]
        public IActionResult addservise([FromForm] addServicesDTO addservise) {



            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Imagessss");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var ImageFile = Path.Combine(uploadFolder, addservise.ServiceImage.FileName);

            using (var stream = new FileStream(ImageFile, FileMode.Create))

            {
                addservise.ServiceImage.CopyToAsync(stream);
            }

            var addserves = new Service
            {

                ServiceName = addservise.ServiceName,
                ServiceDescription = addservise.ServiceDescription,
                ServiceImage = ImageFile,

            };


              _db.Services.Add(addserves);
            _db.SaveChanges();

            return Ok();
        }
    }  
}
