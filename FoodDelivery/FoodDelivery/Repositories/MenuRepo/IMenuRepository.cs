using FoodDelivery.Models;

namespace FoodDelivery.Repositories.MenuRepo
{
    public interface IMenuRepository
    {
        List<Menus> GetMenus();
        void AddMenu(Menus menu);
        void DeleteMenu(Menus menu);
    }
}
