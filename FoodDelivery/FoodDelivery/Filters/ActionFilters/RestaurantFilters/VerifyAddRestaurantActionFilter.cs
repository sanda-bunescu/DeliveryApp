using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.RestaurantFilters
{
    public class VerifyAddRestaurantActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddRestaurantActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var restaurant = context.ActionArguments["restaurant"] as Restaurants;

            if (restaurant == null)
            {
                context.ModelState.AddModelError("Restaurant", "Restaurant object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

            //verify if there is a restaurant with the same data
            var RestaurantDb = db.Restaurants.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(restaurant.Name) && !string.IsNullOrWhiteSpace(x.Name) &&
                restaurant.Name.ToLower() == x.Name.ToLower() &&
                !string.IsNullOrWhiteSpace(restaurant.Address) && !string.IsNullOrWhiteSpace(x.Address) &&
                restaurant.Address.ToLower() == x.Address.ToLower() &&
                !string.IsNullOrWhiteSpace(restaurant.PhoneNumber) && !string.IsNullOrWhiteSpace(x.PhoneNumber) &&
                restaurant.PhoneNumber.ToLower() == x.PhoneNumber.ToLower()
            );

            if (RestaurantDb != null)
            {
                context.ModelState.AddModelError("Restaurant", "Restaurant object already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
