using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.CourierFilters
{
    public class VerifyCourierIdActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyCourierIdActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            var courier = db.Couriers.Find(id.Value);

            if (id == null || id <= 0 || courier == null)
            {
                context.ModelState.AddModelError("id", "Invalid ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                context.HttpContext.Items["Courier"] = courier;
            }

        }
    }
}
