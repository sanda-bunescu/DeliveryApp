using FoodDelivery.Models;

namespace FoodDelivery.Repositories.RestaurantRepo
{
    public interface IRestaurantRepository
    {
        List<Restaurants> GetRestaurants();
        void AddRestaurant(Restaurants restaurant);
        void UpdateRestaurant(int id, Restaurants restaurant);
        void DeleteRestaurant(Restaurants rstaurant);
    }
}
