using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.CourierFilters
{
    public class VerifyUpdateCourierActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var courier = context.ActionArguments["courier"] as Couriers;
            if (courier == null)
            {
                context.ModelState.AddModelError("Courier", "Courier is NULL");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }


        }

    }
}
