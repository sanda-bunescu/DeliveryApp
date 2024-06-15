using FoodDelivery.Models;

namespace FoodDelivery.Repositories.CourierRepo
{
    public class CourierRepository : ICourierReporitory
    {
        private ApplicationDbContext _context;
        public CourierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCourier(Couriers courier)
        {
            _context.Couriers.Add(courier);
            _context.SaveChanges();
        }
        public void DeleteCourier(Couriers courier)
        {
            courier.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Couriers> GetCouriers()
        {
            return _context.Couriers.ToList();
        }

        public void UpdateCourier(int id, Couriers courier)
        {
            Couriers courierToUpdate = _context.Couriers.FirstOrDefault(c => c.CouriersId == id);
            courierToUpdate.Name = courier.Name;
            courierToUpdate.PhoneNumber = courier.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
