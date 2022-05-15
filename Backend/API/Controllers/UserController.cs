using Backend.API.Controllers.Models;
using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromQuery(Name = "email")] string email, [FromQuery(Name = "password")] string password)
        {
            try
            {
                return Ok(userService.Login(email, password));
            } 
            catch (InvalidLoginCredentialsException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("register/client")]
        public IActionResult RegisterClient([FromBody] CreateClientInput input)
        {
            try
            {
                return Ok(userService.RegisterClient(input.Name, input.Email, input.Password, input.Phone));
            }
            catch (AlreadyRegisteredUserException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("register/freelancer")]
        public IActionResult RegisterFreelancer([FromBody] CreateFreelancerInput input)
        {
            try
            {
                return Ok(userService.RegisterFreelancer(input.Name, input.Email, input.Password, input.Phone, input.SkillRates));
            }
            catch (AlreadyRegisteredUserException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}