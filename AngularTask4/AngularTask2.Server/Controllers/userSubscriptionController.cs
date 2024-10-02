using AngularTask2.Server.Dtos;
using AngularTask2.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularTask2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userSubscriptionController : ControllerBase
    {
        private readonly MyDbContext _db;
        public userSubscriptionController(MyDbContext db)
        {
            _db = db;

        }



        [HttpPost]
        public IActionResult AddUserSubsicribtion([FromBody] userRequestDto userSubscriptionD)
        {
            var subSecription = _db.Subscriptions.Where(x=> x.SubscriptionId == userSubscriptionD.SubscriptionId).FirstOrDefault();
            var amount = subSecription.SubscriptionAmount;
                var startDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endDate = DateOnly.FromDateTime(DateTime.Now);
            switch(amount)
            {
                case "7":
                    endDate = startDate.AddDays(7);break ;
                case "90":
                    endDate = startDate.AddMonths(3); break;
                case "365":
                    endDate = startDate.AddYears(1); break;
            }
            var userSubscription = new UserSubscription
            {
                UserId = userSubscriptionD.UserId,
                SubscriptionId = userSubscriptionD.SubscriptionId,
                SubServiceId = userSubscriptionD.SubServiceId,
                EndDate = endDate,
                StartDate = startDate
            };
            _db.UserSubscriptions.Add(userSubscription);
            _db.SaveChanges();

            return Ok(userSubscription);
        }
    }
}
