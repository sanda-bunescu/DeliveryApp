using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Metrics;

namespace FoodDelivery.Filters.ActionFilters.UserFilters
{
    public class VerifyAddUserActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddUserActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var user = context.ActionArguments["user"] as Users;

            if (user == null)
            {
                context.ModelState.AddModelError("User", "User object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

            //verify if there is a user with the same data
            var UserDb = db.Users.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(x.Name) && 
                user.Name.ToLower() == x.Name.ToLower() &&
                !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(x.Password) &&
                user.Password.ToLower() == x.Password.ToLower() &&
                !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(x.Email) &&
                user.Email.ToLower() == x.Email.ToLower() &&
                !string.IsNullOrWhiteSpace(user.DeliveryAddress) && !string.IsNullOrWhiteSpace(x.DeliveryAddress) &&
                user.DeliveryAddress.ToLower() == x.DeliveryAddress.ToLower() &&
                !string.IsNullOrWhiteSpace(user.PhoneNumber) && !string.IsNullOrWhiteSpace(x.PhoneNumber) && 
                user.PhoneNumber.ToLower() == x.PhoneNumber.ToLower()
            );

            if (UserDb != null)
            {
                context.ModelState.AddModelError("User", "User object already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
