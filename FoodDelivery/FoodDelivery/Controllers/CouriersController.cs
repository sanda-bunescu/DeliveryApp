using FoodDelivery.Filters.ActionFilters;
using FoodDelivery.Filters.ActionFilters.CourierFilters;
using FoodDelivery.Models;
using FoodDelivery.Repositories.CourierRepo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CouriersController : ControllerBase
    {
        private readonly ICourierReporitory _courierReporitory;
        public CouriersController(ICourierReporitory courierReporitory)
        {
            _courierReporitory = courierReporitory;
        }

        [HttpGet]
        public IActionResult GetCouriers() {
            return Ok(_courierReporitory.GetCouriers());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(VerifyCourierIdActionFilter))]
        public IActionResult GetCourierByID(int id)
        {
            return Ok(HttpContext.Items["Courier"]);
        }

        [HttpPost]
        [TypeFilter(typeof(VerifyAddCourierActionFilter))]
        public IActionResult AddCourier([FromBody]Couriers courier)
        {
            var newCourier = new Couriers{
                Name = courier.Name,
                PhoneNumber = courier.PhoneNumber
            };
            _courierReporitory.AddCourier(newCourier);
            return Ok();
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(VerifyCourierIdActionFilter))]
        [VerifyUpdateCourierActionFilter]
        public IActionResult UpdateCourier(int id, [FromBody] Couriers courier)
        {
            _courierReporitory.UpdateCourier(id, courier);
            return Ok();
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(VerifyCourierIdActionFilter))]
        public IActionResult DeleteCourier(int id)
        {
            _courierReporitory.DeleteCourier(HttpContext.Items["Courier"] as Couriers);
            return Ok(HttpContext.Items["Courier"]);
        }


    }
}
