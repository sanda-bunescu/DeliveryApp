using FoodDelivery.Models;

namespace FoodDelivery.Repositories.MenuRepo
{
    public class MenuRepository : IMenuRepository
    {
        private ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddMenu(Menus menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }

        public void DeleteMenu(Menus menu)
        {
            _context.Menus.Remove(menu);
            _context.SaveChanges();
        }

        public List<Menus> GetMenus()
        {
            return _context.Menus.ToList();
        }

    }
}
