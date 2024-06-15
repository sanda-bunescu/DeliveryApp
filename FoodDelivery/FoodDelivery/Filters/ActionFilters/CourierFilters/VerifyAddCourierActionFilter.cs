using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.CourierFilters
{
    public class VerifyAddCourierActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddCourierActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var courier = context.ActionArguments["courier"] as Couriers;

            if (courier == null)
            {
                context.ModelState.AddModelError("Courier", "Couriers object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            //verify if there is a courier with the passed Name and phoneNumber
            var CourierDb = db.Couriers.FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(courier.Name) && !string.IsNullOrWhiteSpace(x.Name) && courier.Name.ToLower() == x.Name.ToLower() &&
                    !string.IsNullOrWhiteSpace(courier.PhoneNumber) && !string.IsNullOrWhiteSpace(x.PhoneNumber) && courier.PhoneNumber.ToLower() == x.PhoneNumber.ToLower()

                );
            if (CourierDb != null)
            {
                context.ModelState.AddModelError("Courier", "Courier object already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }


    }
}
