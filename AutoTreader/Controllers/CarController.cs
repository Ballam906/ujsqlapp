using Microsoft.AspNetCore.Mvc;
using AutoTreader.Models;
using System.Diagnostics.Eventing.Reader;
using AutoTreader.Models.Dto;

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
                return BadRequest(new { message = "Sikertelen lekérdezés" });
            }
        }

        [HttpPost]
        public ActionResult<Car> AddNewRecord(Car car)
        {
            using (var context = new CarDBContest())
            {
                var newCar = new Car()
                {
                    Brand = car.Brand,
                    Type = car.Type,
                    Color = car.Color,
                    Year = car.Year,
                };
                if (newCar != null)
                {
                    context.Cars.Add(newCar);
                    context.SaveChanges();
                    return StatusCode(201, newCar);
                }
                return BadRequest(new { message = "Sikertelen hozzáadás" });
            }
        }

        [HttpDelete]
        public ActionResult<Car> DeleteRecord(int id)
        {
            using (var context = new CarDBContest())
            {
                var car = context.Cars.ToList();
                foreach (var item in car)
                {
                    if (item.Id == id)
                    {
                        context.Cars.Remove(item);
                        context.SaveChanges();
                        return Ok();
                    }

                }
                return BadRequest(new { message = "Sikertelen törlés" });

            }
        }

        [HttpGet("GetById")]
        public ActionResult<Car> GetRecordById(int id)
        {
            using (var context = new CarDBContest())
            {
                var car = context.Cars.FirstOrDefault(car => car.Id == id);
                if (car != null)
                {
                    return Ok(new { message = "Sikeres lekérdezés", result = car });
                }

                return NotFound(new { message = "Nincs ilyen id!" });
            }
        }

        [HttpPut]
        public ActionResult Putrecord(int id, UpdateCar updatecar)
        {
            using var context = new CarDBContest();
            {
                var existincar = context.Cars.FirstOrDefault(Car => Car.Id == id);
                if (existincar != null)
                {
                    existincar.Year = updatecar.Year;
                    existincar.Color = updatecar.Color;
                    existincar.Brand = updatecar.Brand;
                    existincar.Type = updatecar.Model;

                    context.Cars.Update(existincar);
                    context.SaveChanges();

                    return Ok(new { message = "Sikeres frissítés" });
                }

                return NotFound(new { message = "Nincs mit frissíteni" });
            }
        }
    }
}

