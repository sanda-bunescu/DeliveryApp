using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.UserFilters
{
    public class VerifyUserIdActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyUserIdActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;

            var user = db.Users.Find(id.Value);

            if (id == null || id <= 0 || user == null)
            {
                context.ModelState.AddModelError("id", "Invalid User ID");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                context.HttpContext.Items["User"] = user;
            }
        }
    }
}
