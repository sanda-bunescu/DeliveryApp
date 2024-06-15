using FoodDelivery.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.OrderFilters
{
    public class VerifyDeleteOrderIDActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyDeleteOrderIDActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            if (db.Orders.FirstOrDefault(x => x.OrdersId == id) == null)
            {
                context.ModelState.AddModelError("OrderID", "Invalid Order ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}
