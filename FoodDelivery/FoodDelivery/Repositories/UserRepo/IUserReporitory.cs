using FoodDelivery.Models;

namespace FoodDelivery.Repositories.UserRepo
{
    public interface IUserReporitory
    {
        List<Users> GetUsers();
        void AddUser(Users user);
        void UpdateUser(int id, Users user);
        void DeleteUser(Users user);
    }
}
