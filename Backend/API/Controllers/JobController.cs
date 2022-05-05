using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/job/[controller]")]
    public class JobController : ControllerBase
    {
        
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet(Name = "")]
        public Job Get()
        {
            return new Job();
        }
    }
}