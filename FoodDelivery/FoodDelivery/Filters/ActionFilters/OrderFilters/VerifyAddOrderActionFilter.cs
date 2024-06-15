using FoodDelivery.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.OrderFilters
{
    public class VerifyAddOrderActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddOrderActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var order = context.ActionArguments["order"] as NewOrderDTO;

            if (order == null)
            {
                context.ModelState.AddModelError("Order", "Order object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

            var restaurant = db.Restaurants.FirstOrDefault(r => r.RestaurantsId == order.RestaurantsID);
            if (restaurant == null)
            {
                context.ModelState.AddModelError("RestaurantsId", "The provided RestaurantsId does not exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.UsersId == order.UsersID);
            if (user == null)
            {
                context.ModelState.AddModelError("UsersId", "The provided UsersId does not exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }
            Console.WriteLine($"Hrereeeeee:{order.CouriersID}");
            var courier = db.Couriers.FirstOrDefault(c => c.CouriersId == order.CouriersID);
            if (courier == null)
            {
                context.ModelState.AddModelError("CouriersId", "The provided CouriersId does not exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var item = db.Items.FirstOrDefault(c => c.ItemsId == order.ItemsID);
            if (item == null)
            {
                context.ModelState.AddModelError("ItemsID", "The provided Item ID does not exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }
        }
    }
}
