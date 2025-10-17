using Microsoft.AspNetCore.Mvc;
using AutoTreader.Models;

namespace AutoTreader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        [HttpGet]
        public ActionResult<Car> GetAllRecord()
        {
            using (var context = new CarDBContest())
            {
                var car = context.Cars.ToList();
                if (car != null)
                {
                    return Ok(car);
                }
                return BadRequest(new {message = "Sikertelen lekérdezés"});
            }
        }
    }
}
