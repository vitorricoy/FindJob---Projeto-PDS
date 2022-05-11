using Backend.API.Controllers.Models;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/skill")]
    public class SkillController : ControllerBase
    {
        
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllSkills()
        {
            try
            {
                return Ok(skillService.GetAllSkills());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateNewSkill([FromBody] CreateSkillInput input)
        {
            try
            {
                return Ok(skillService.CreateNewSkill(input.Name));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}