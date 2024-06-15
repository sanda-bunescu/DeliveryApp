using FoodDelivery.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.Filters.ActionFilters.OrderFilters
{
    public class VerifyAddItemToOrderActionFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;
        public VerifyAddItemToOrderActionFilter(ApplicationDbContext db)
        {
            this.db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var input = context.ActionArguments["toModify"] as ModifyOrderDTO;

            var orderDB = db.Orders.FirstOrDefault(x => x.OrdersId == input.OrderID);
            
            if (orderDB == null)
            {
                context.ModelState.AddModelError("OrderID", "OrderID dones't exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }
            db.Entry(orderDB).Collection(o => o.Items).Load();

            var itemIdInDB = db.Items.FirstOrDefault(x => x.ItemsId == input.ItemId);
            if (itemIdInDB == null)
            {
                context.ModelState.AddModelError("ItemID", "ItemID dones't exist");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
                return;
            }

            var isThere = orderDB.Items.FirstOrDefault(x => x.ItemsId == input.ItemId);

            if (db.Orders.FirstOrDefault(x => x.OrdersId == input.OrderID).Items.FirstOrDefault(y => y.ItemsId == input.ItemId) != null)
            {
                context.ModelState.AddModelError("ItemID", "Item already in the basket");
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
