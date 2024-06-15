using FoodDelivery.Models;

namespace FoodDelivery.Repositories.UserRepo
{
    public class UserRepository : IUserReporitory
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void DeleteUser(Users user)
        {
            user.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(int id, Users user)
        {
            Users userToUpdate = _context.Users.FirstOrDefault(u => u.UsersId == id);
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            userToUpdate.DeliveryAddress = user.DeliveryAddress;
            _context.SaveChanges();
        }

    }
}
