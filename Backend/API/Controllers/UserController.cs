using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Name = "login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                return Ok(userService.Login(email, password));
            } 
            catch (InvalidLoginCredentialsException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}