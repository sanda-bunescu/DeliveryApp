using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.RestaurantFilters
{
    public class VerifyRestaurantIdActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyRestaurantIdActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            var restaurant = db.Restaurants.Find(id.Value);

            if (id == null || id <= 0 || restaurant == null)
            {
                context.ModelState.AddModelError("id", "Invalid Restaurant ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                context.HttpContext.Items["Restaurant"] = restaurant;
            }
        }
    }
}
