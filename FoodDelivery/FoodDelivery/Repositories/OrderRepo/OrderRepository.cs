using FoodDelivery.DTOs;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repositories.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddItemToOrder(ModifyOrderDTO toModify)
        {
            var item = _context.Items.Find(toModify.ItemId);
            var order = _context.Orders.Find(toModify.OrderID);
            
            order.Items.Add(item);
            _context.SaveChanges();

            Console.WriteLine("Items in the order after addition:");
            foreach (var orderItem in order.Items)
            {
                Console.WriteLine($"Item ID: {orderItem.ItemsId}, Item Name: {orderItem.Name}");
            }
        }

        public void AddOrder(NewOrderDTO order)
        {
            Orders newOrder = new Orders()
            {
                Restaurant = _context.Restaurants.Find(order.RestaurantsID),
                User = _context.Users.Find(order.UsersID),
                Courier = _context.Couriers.Find(order.CouriersID),
                DateTime = DateTime.Now
            };
            newOrder.Items.Add(_context.Items.Find(order.ItemsID));

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            
        }

        public void DeleteItemToOrder(ModifyOrderDTO toModify)
        {
            var order = _context.Orders.Include(o => o.Items).FirstOrDefault(o => o.OrdersId == toModify.OrderID);

            var itemToRemove = order.Items.FirstOrDefault(i => i.ItemsId == toModify.ItemId);

            order.Items.Remove(itemToRemove);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var tmp = _context.Orders.Include(o => o.Items).FirstOrDefault(o => o.OrdersId == id);

            Console.WriteLine($"{tmp}hererere");
            tmp.Items.Clear();
            _context.Orders.Remove(tmp);
            _context.SaveChanges();
        }
    
        public Orders GetOrderByID(int id)
        {
            Orders order = _context.Orders
                .Include(o => o.Restaurant)
                .Include(o => o.User)
                .Include(o => o.Courier)
                .FirstOrDefault(o => o.OrdersId == id);

            return order;
        }
    }
}
