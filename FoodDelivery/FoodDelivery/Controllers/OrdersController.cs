using FoodDelivery.DTOs;
using FoodDelivery.Filters.ActionFilters.CourierFilters;
using FoodDelivery.Filters.ActionFilters.OrderFilters;
using FoodDelivery.Models;
using FoodDelivery.Repositories.OrderRepo;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderReporitory;
        public OrdersController(IOrderRepository orderReporitory)
        {
            _orderReporitory = orderReporitory;
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(VerifyOrderIdActionFilter))]
        public IActionResult GetOrderByID(int id)
        {
            Orders order = _orderReporitory.GetOrderByID(id);

            return Ok(new
            {
                order.OrdersId,
                order.Restaurant.Name,
                order.DateTime
            });
        }

        [HttpPost]
        [TypeFilter(typeof (VerifyAddOrderActionFilter))]
        public IActionResult AddOrder([FromBody] NewOrderDTO order)
        {
            _orderReporitory.AddOrder(order);

            return Ok();            
        }
        //addItem and deleteItem will modify data from OrderItems(many to many relationship)
        [HttpPut("addItem")]
        [TypeFilter(typeof (VerifyAddItemToOrderActionFilter))]
        public IActionResult AddItemToOrder([FromBody] ModifyOrderDTO toModify)
        {
            _orderReporitory.AddItemToOrder(toModify);
            return Ok();
        }

        [HttpPut("deleteItem")]
        [TypeFilter(typeof(VerifyRemoveItemActionFilter))]
        public IActionResult DeleteItemFromOrder([FromBody] ModifyOrderDTO toModify)
        {
            _orderReporitory.DeleteItemToOrder(toModify);
            return Ok();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(VerifyDeleteOrderIDActionFilter))]
        public IActionResult DeleteOrder(int id)
        {
            _orderReporitory.DeleteOrder(id);

            return Ok();
        }

    }
}
