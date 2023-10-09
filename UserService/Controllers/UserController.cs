using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/user")] // Base route for UserController
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(User user)
        {
            // Call the UserService to register a user
            var result = _userService.RegisterUser(user);
            if (result)
            {
                return Created("", user); // 201 Created
            }
            return Conflict(); // 409 Conflict
        }

        [HttpPost("login")]
        public IActionResult LoginUser(User user)
        {
            // Call the UserService to validate user login
            var isValid = _userService.ValidateUser(user.UserId, user.Password);
            if (isValid)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, User user)
        {
            // Call the UserService to update a user
            var result = _userService.UpdateUser(userId, user);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            // Call the UserService to delete a user
            var result = _userService.DeleteUser(userId);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            // Call the UserService to get user details by ID
            var user = _userService.GetUserById(userId);
            if (user != null)
            {
                return Ok(user); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }
    }
}
