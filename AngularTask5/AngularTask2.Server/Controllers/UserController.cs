using AngularTask2.Server.Dtos;
using AngularTask2.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTask2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UserController(MyDbContext db)
        {
            _db = db;

        }

        [HttpPost("addUser")]

        public IActionResult addUser([FromForm] RegesterRequestDto regesterRequestDto)
        {
           
            var chechuser = _db.Users.Where(x=> x.Email ==regesterRequestDto.Email).FirstOrDefault();

            if (chechuser != null)
                return BadRequest( "Invalid data!" );
            var user = new User
            {
                UserName = regesterRequestDto.UserName,
                Email = regesterRequestDto.Email,
              

            };

            _db.Users.Add(user);
            _db.SaveChanges();



            return Ok(user);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromForm] RegesterRequestDto userInfo)
        {
            var checkUser = _db.Users.Where(u => u.Email == userInfo.Email && u.UserName == userInfo.UserName).FirstOrDefault();

            if (checkUser == null)
            {
                return BadRequest("Email or Password wrong!");
            }

            return Ok(checkUser);
        }

    }
}
