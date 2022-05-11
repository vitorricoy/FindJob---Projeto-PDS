using Backend.API.Controllers.Models;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {

        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpPost]
        [Route("rate")]
        public IActionResult RateJob([FromBody] RateJobInput input)
        {
            try
            {
                return Ok(jobService.RateJob(input.JobId, input.Rating));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListJobsByUser([FromQuery(Name = "userId")] int userId)
        {
            try
            {
                return Ok(jobService.ListJobsByUser(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchJobsForFreelancer([FromQuery(Name = "userId")] int userId)
        {
            try
            {
                return Ok(jobService.SearchJobsForFreelancer(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery(Name = "jobId")] int jobId)
        {
            try
            {
                return Ok(jobService.GetJobById(jobId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}