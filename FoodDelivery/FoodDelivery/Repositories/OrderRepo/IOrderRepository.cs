using FoodDelivery.DTOs;
using FoodDelivery.Models;

namespace FoodDelivery.Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        void AddOrder(NewOrderDTO order);
        void AddItemToOrder(ModifyOrderDTO toModify);
        void DeleteItemToOrder(ModifyOrderDTO toModify);
        void DeleteOrder(int id);

        Orders GetOrderByID(int id);
    }
}
