using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Filters.ActionFilters.MenuFilters
{
    public class VerifyAddMenuActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddMenuActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var menu = context.ActionArguments["menu"] as Menus;

            if (menu == null)
            {
                context.ModelState.AddModelError("Menu", "Menu object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

            //verify if there is already a menu for the restaurant
            var MenuDb = db.Menus.FirstOrDefault(x =>
                menu.RestaurantsId == x.RestaurantsId
            );

            if (MenuDb != null)
            {
                context.ModelState.AddModelError("Menu", "Menu object already exists");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            //verify if there is a restaurant with the inserted Restaurantsid
            var restaurant = db.Restaurants.FirstOrDefault(r => r.RestaurantsId == menu.RestaurantsId);
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
        }
    }
}
