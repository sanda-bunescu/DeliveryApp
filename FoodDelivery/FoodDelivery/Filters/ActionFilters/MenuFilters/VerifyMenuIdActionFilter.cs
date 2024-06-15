using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.MenuFilters
{
    public class VerifyMenuIdActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyMenuIdActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            var menu = db.Menus.Find(id.Value);

            if (id == null || id <= 0 || menu == null)
            {
                context.ModelState.AddModelError("id", "Invalid Menu ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                context.HttpContext.Items["Menu"] = menu;
            }
        }
    }
}
