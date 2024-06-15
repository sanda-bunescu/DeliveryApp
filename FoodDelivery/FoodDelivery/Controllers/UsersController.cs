
using FoodDelivery.Filters.ActionFilters.UserFilters;
using FoodDelivery.Models;
using FoodDelivery.Repositories.UserRepo;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserReporitory _userReporitory;
        public UsersController(IUserReporitory userReporitory)
        {
            _userReporitory = userReporitory;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userReporitory.GetUsers());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(VerifyUserIdActionFilter))]
        public IActionResult GetUserByID(int id)
        {
            return Ok(HttpContext.Items["User"]);
        }

        [HttpPost]
        [TypeFilter(typeof(VerifyAddUserActionFilter))]
        public IActionResult AddUser([FromBody] Users user)
        {
            var newUser = new Users
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                DeliveryAddress = user.DeliveryAddress
            
            };
            _userReporitory.AddUser(newUser);
            return Ok();
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(VerifyUserIdActionFilter))]
        [VerifyUpdateUserActionFilter]
        public IActionResult UpdateUser(int id, [FromBody] Users user)
        {
            _userReporitory.UpdateUser(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(VerifyUserIdActionFilter))]
        public IActionResult DeleteUser(int id)
        {
            _userReporitory.DeleteUser(HttpContext.Items["User"] as Users);
            return Ok(HttpContext.Items["User"]);
        }
    }
}
