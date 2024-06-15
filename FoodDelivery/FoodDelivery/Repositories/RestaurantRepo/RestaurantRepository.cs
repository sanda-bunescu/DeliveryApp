using FoodDelivery.Models;

namespace FoodDelivery.Repositories.RestaurantRepo
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ApplicationDbContext _context;
        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddRestaurant(Restaurants restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }
        public void DeleteRestaurant(Restaurants restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public List<Restaurants> GetRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public void UpdateRestaurant(int id, Restaurants restaurant)
        {
            Restaurants restaurantToUpdate = _context.Restaurants.FirstOrDefault(r => r.RestaurantsId == id);
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.PhoneNumber = restaurant.PhoneNumber;
            restaurantToUpdate.Address = restaurant.Address;
            _context.SaveChanges();
        }
    }
}
