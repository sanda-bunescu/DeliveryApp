using FoodDelivery.Filters.ActionFilters.RestaurantFilters;
using FoodDelivery.Models;
using FoodDelivery.Repositories.RestaurantRepo;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantReporitory;
        public RestaurantsController(IRestaurantRepository restaurantReporitory)
        {
            _restaurantReporitory = restaurantReporitory;
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(_restaurantReporitory.GetRestaurants());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(VerifyRestaurantIdActionFilter))]
        public IActionResult GetRestaurantByID(int id)
        {
            return Ok(HttpContext.Items["Restaurant"]);
        }

        [HttpPost]
        [TypeFilter(typeof(VerifyAddRestaurantActionFilter))]
        public IActionResult AddRestaurant([FromBody] Restaurants restaurant)
        {
            var newRestaurant = new Restaurants
            {
                Name = restaurant.Name,
                PhoneNumber = restaurant.PhoneNumber,
                Address = restaurant.Address

            };
            _restaurantReporitory.AddRestaurant(newRestaurant);
            return Ok();
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(VerifyRestaurantIdActionFilter))]
        [VerifyUpdateRestaurantActionFilter]
        public IActionResult UpdateRestaurant(int id, [FromBody] Restaurants restaurant)
        {
            _restaurantReporitory.UpdateRestaurant(id, restaurant);
            return Ok();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(VerifyRestaurantIdActionFilter))]
        public IActionResult DeleteRestaurant(int id)
        {
            _restaurantReporitory.DeleteRestaurant(HttpContext.Items["Restaurant"] as Restaurants);
            return Ok(HttpContext.Items["Restaurant"]);
        }
    }
}
