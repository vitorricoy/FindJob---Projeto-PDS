using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FindJobUnitTests.Backend.API.Controllers
{
    public class JobControllerTest
    {

        public JobControllerTest()
        {
            
        }

        [Fact]
        public void TestRateJobSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.RateJob(Arg.Any<string>(), Arg.Any<double>()).Returns(args => true);
            JobController controller = new(jobServiceMock);
            RateJobInput input = new("1", 1.0);
            OkObjectResult? actionResult = controller.RateJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            bool? responseObject = actionResult?.Value as bool?;
            Assert.True(responseObject);
        }

        [Fact]
        public void TestRateJobInvalidJobError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.RateJob(Arg.Any<string>(), Arg.Any<double>()).Returns(args => { throw new InvalidJobIdException(); });
            JobController controller = new(jobServiceMock);
            RateJobInput input = new("1", 1.0);
            ObjectResult? actionResult = controller.RateJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestRateJobUnknownError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.RateJob(Arg.Any<string>(), Arg.Any<double>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            RateJobInput input = new("1", 1.0);
            ObjectResult? actionResult = controller.RateJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestListJobsByUserSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job1 = new(Guid.NewGuid().ToString(), "testJob1", "Test Job 1", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            Job job2 = new(Guid.NewGuid().ToString(), "testJob2", "Test Job 2", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.ListJobsByUser(Arg.Any<string>()).Returns(args => new List<Job>() { job1, job2});
            JobController controller = new(jobServiceMock);
            OkObjectResult? actionResult = controller.ListJobsByUser("123") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Job>? responseObject = actionResult?.Value as List<Job>;
            Assert.Equal(new List<Job>() { job1, job2 }, responseObject);
        }

        [Fact]
        public void TestListJobsByUserError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ListJobsByUser(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ObjectResult? actionResult = controller.ListJobsByUser("123") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestSearchJobsForFreelancerSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job1 = new(Guid.NewGuid().ToString(), "testJob1", "Test Job 1", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            Job job2 = new(Guid.NewGuid().ToString(), "testJob2", "Test Job 2", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.SearchJobsForFreelancer(Arg.Any<string>()).Returns(args => new List<Job>() { job1, job2 });
            JobController controller = new(jobServiceMock);
            OkObjectResult? actionResult = controller.SearchJobsForFreelancer("123") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Job>? responseObject = actionResult?.Value as List<Job>;
            Assert.Equal(new List<Job>() { job1, job2 }, responseObject);
        }

        [Fact]
        public void TestSearchJobsForFreelancerError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.SearchJobsForFreelancer(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ObjectResult? actionResult = controller.SearchJobsForFreelancer("123") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestGetJobSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job = new(Guid.NewGuid().ToString(), "testJob", "Test Job ", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.GetJobById(Arg.Any<string>()).Returns(args =>job);
            JobController controller = new(jobServiceMock);
            OkObjectResult? actionResult = controller.Get("123") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Job? responseObject = actionResult?.Value as Job;
            Assert.Equal(job, responseObject);
        }

        [Fact]
        public void TestGetJobError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.GetJobById(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ObjectResult? actionResult = controller.Get("123") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestCreateJobSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job = new Job(Guid.NewGuid().ToString(), "testJob", "Test Job ", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.CreateNewJob(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<double>(), Arg.Any<bool>(), Arg.Any<List<string>>(), Arg.Any<string>()).Returns(args => job);
            JobController controller = new(jobServiceMock);
            CreateJobInput input = new(job.Title, job.Description, job.Deadline, job.Payment, job.IsPaymentByHour, job.Skills.Select(s => s.Name).ToList(), job.Client.Id);
            OkObjectResult? actionResult = controller.CreateNewJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Job? responseObject = actionResult?.Value as Job;
            Assert.Equal(job, responseObject);
        }

        [Fact]
        public void TestCreateJobInvalidUserIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job = new(Guid.NewGuid().ToString(), "testJob", "Test Job ", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.CreateNewJob(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<double>(), Arg.Any<bool>(), Arg.Any<List<string>>(), Arg.Any<string>()).Returns(args => { throw new InvalidUserIdException(); });
            JobController controller = new(jobServiceMock);
            CreateJobInput input = new(job.Title, job.Description, job.Deadline, job.Payment, job.IsPaymentByHour, job.Skills.Select(s => s.Name).ToList(), job.Client.Id);
            ObjectResult? actionResult = controller.CreateNewJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestCreateJobGenericError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            Job job = new Job(Guid.NewGuid().ToString(), "testJob", "Test Job ", 10, 2.5, true, new List<Skill>(), client, null, new List<User>(), true, true);
            jobServiceMock.CreateNewJob(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<int>(), Arg.Any<double>(), Arg.Any<bool>(), Arg.Any<List<string>>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            CreateJobInput input = new(job.Title, job.Description, job.Deadline, job.Payment, job.IsPaymentByHour, job.Skills.Select(s => s.Name).ToList(), job.Client.Id);
            ObjectResult? actionResult = controller.CreateNewJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestApplyFreelancerToJobSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.CandidateForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => true);
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            OkObjectResult? actionResult = controller.ApplyFreelancerToJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            bool? responseObject = actionResult?.Value as bool?;
            Assert.True(responseObject);
        }

        [Fact]
        public void TestApplyFreelancerToJobInvalidJobIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.CandidateForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidJobIdException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ApplyFreelancerToJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestApplyFreelancerToJobInvalidUserIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.CandidateForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidUserIdException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ApplyFreelancerToJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestApplyFreelancerToJobUnavaibleJobError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.CandidateForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new UnavailableJobException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ApplyFreelancerToJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestApplyFreelancerToJobGenericError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.CandidateForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ApplyFreelancerToJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestChooseFreelancerToJobSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ChooseFreelancerForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => true);
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            OkObjectResult? actionResult = controller.ChooseFreelancerForJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            bool? responseObject = actionResult?.Value as bool?;
            Assert.True(responseObject);
        }

        [Fact]
        public void TestChooseFreelancerToJobInvalidJobIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ChooseFreelancerForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidJobIdException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ChooseFreelancerForJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestChooseFreelancerToJobInvalidUserIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ChooseFreelancerForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidUserIdException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ChooseFreelancerForJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestChooseFreelancerToJobUnavaibleJobError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ChooseFreelancerForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new UnavailableJobException(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ChooseFreelancerForJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestChooseFreelancerToJobGenericError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.ChooseFreelancerForJob(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ApplyFreelancerInput input = new("1", "2");
            ObjectResult? actionResult = controller.ChooseFreelancerForJob(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestGetJobCandidatesBySkillSuccess()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            User freelancer1 = new(Guid.NewGuid().ToString(), "frreelancer1", "frreelancer1@test.com", "test1", "333333333", true, new Dictionary<Skill, Tuple<double, int>>());
            User freelancer2 = new(Guid.NewGuid().ToString(), "frreelancer2", "frreelancer2@test.com", "test2", "444444444", true, new Dictionary<Skill, Tuple<double, int>>());

            jobServiceMock.GetJobCandidatesBySkill(Arg.Any<string>()).Returns(args => new List<User>() { freelancer1, freelancer2 });
            JobController controller = new(jobServiceMock);
            OkObjectResult? actionResult = controller.GetJobCandidatesBySkill("1") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<User>? responseObject = actionResult?.Value as List<User>;
            Assert.Equal(new List<User>() { freelancer1, freelancer2 }, responseObject);
        }

        [Fact]
        public void TestGetJobCandidatesBySkillInvalidJobIdError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.GetJobCandidatesBySkill(Arg.Any<string>()).Returns(args => { throw new InvalidJobIdException(); });
            JobController controller = new(jobServiceMock);
            ObjectResult? actionResult = controller.GetJobCandidatesBySkill("1") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestGetJobCandidatesBySkillGenericError()
        {
            IJobService jobServiceMock = Substitute.For<IJobService>();
            jobServiceMock.GetJobCandidatesBySkill(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            JobController controller = new(jobServiceMock);
            ObjectResult? actionResult = controller.GetJobCandidatesBySkill("1") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

    }
}
