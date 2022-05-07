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

        [HttpPost(Name = "rate")]
        public IActionResult RateJob(int jobId, double rating)
        {
            try
            {
                return Ok(jobService.RateJob(jobId, rating));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet(Name = "list")]
        public IActionResult ListJobsByFreelancer(int userId)
        {
            try
            {
                return Ok(jobService.ListJobsByFreelancer(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet(Name = "search")]
        public IActionResult SearchJobsForFreelancer(int userId)
        {
            try
            {
                return Ok(jobService.SearchJobsForFreelancer(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet(Name = "")]
        public Job Get()
        {
            return new Job();
        }
    }
}