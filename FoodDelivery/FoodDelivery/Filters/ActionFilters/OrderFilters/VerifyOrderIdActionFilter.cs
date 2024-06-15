using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Filters.ActionFilters.OrderFilters
{
    public class VerifyOrderIdActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyOrderIdActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            var order = db.Orders.Find(id.Value);

            if (id == null || id <= 0 || order == null)
            {
                context.ModelState.AddModelError("id", "Invalid ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}
