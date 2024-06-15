using FoodDelivery.Filters.ActionFilters.MenuFilters;
using FoodDelivery.Models;
using FoodDelivery.Repositories.MenuRepo;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenusController : ControllerBase
    {
        private readonly IMenuRepository _menuReporitory;
        public MenusController(IMenuRepository menuReporitory)
        {
            _menuReporitory = menuReporitory;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            return Ok(_menuReporitory.GetMenus());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(VerifyMenuIdActionFilter))]
        public IActionResult GetMenuByID(int id)
        {
            return Ok(HttpContext.Items["Menu"]);
        }

        [HttpPost]
        [TypeFilter(typeof(VerifyAddMenuActionFilter))]
        public IActionResult AddMenu([FromBody] Menus menu)
        {
            var newMenu = new Menus
            {
                RestaurantsId = menu.RestaurantsId,

            };
            _menuReporitory.AddMenu(newMenu);
            return Ok();
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(VerifyMenuIdActionFilter))]
        public IActionResult DeleteMenu(int id)
        {
            _menuReporitory.DeleteMenu(HttpContext.Items["Menu"] as Menus);
            return Ok(HttpContext.Items["Menu"]);
        }

    }
}
