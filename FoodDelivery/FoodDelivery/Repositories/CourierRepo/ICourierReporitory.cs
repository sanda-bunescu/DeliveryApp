using FoodDelivery.Models;

namespace FoodDelivery.Repositories.CourierRepo
{
    public interface ICourierReporitory
    {
        List<Couriers> GetCouriers();
        void AddCourier(Couriers courier);
        void UpdateCourier(int id, Couriers courier);
        void DeleteCourier(Couriers courier);
    }
}
