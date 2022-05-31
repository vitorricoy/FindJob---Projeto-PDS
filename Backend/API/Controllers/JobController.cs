using Backend.API.Controllers.Models;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Backend.Domain.Exceptions;
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
            catch (InvalidJobIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListJobsByUser([FromQuery(Name = "userId")] string userId)
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
        public IActionResult SearchJobsForFreelancer([FromQuery(Name = "userId")] string userId)
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
        public IActionResult Get([FromQuery(Name = "jobId")] string jobId)
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

        [HttpPost]
        public IActionResult CreateNewJob([FromBody] CreateJobInput input)
        {
            try
            {
                return Ok(jobService.CreateNewJob(input.Title, input.Description, input.Deadline, input.Payment, input.IsPaymentByHour, input.Skills, input.ClientId, input.AssignedFreelancerId));
            }
            catch (InvalidUserIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("apply")]
        public IActionResult ApplyFreelancerToJob([FromBody] ApplyFreelancerInput input)
        {
            try
            {
                return Ok(jobService.CandidateForJob(input.JobId, input.FreelancerId));
            }
            catch (InvalidJobIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (InvalidUserIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnavailableJobException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("choose")]
        public IActionResult ChooseFreelancerForJob([FromBody] ApplyFreelancerInput input)
        {
            try
            {
                return Ok(jobService.ChooseFreelancerForJob(input.JobId, input.FreelancerId));
            }
            catch (InvalidJobIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (InvalidUserIdException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (UnavailableJobException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("candidates")]
        public IActionResult GetJobCandidatesBySkill([FromQuery(Name = "jobId")] string jobId)
        {
            try
            {
                return Ok(jobService.GetJobCandidatesBySkill(jobId));
            }
            catch (InvalidJobIdException ex)
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