using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/skill/[controller]")]
    public class SkillController : ControllerBase
    {
        
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet(Name = "")]
        public Skill Get()
        {
            return new Skill();
        }
    }
}