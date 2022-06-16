using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests
{
    public class JobTests
    {
        readonly JobController jobController;
        readonly ApplicationDbContext context;

        public JobTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("JobTests")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            JobRepository jobRepository = new JobRepository(context);
            SkillRepository skillRepository = new SkillRepository(context);
            UserRepository userRepository = new UserRepository(context);

            JobService jobService = new JobService(jobRepository, userRepository, skillRepository);

            jobController = new JobController(jobService);
        }

        [Fact]
        public void TestCreateJob()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());

            context.Users.Add(UserModel.FromDomainObject(client));

            Skill cSharp = new("C#", "c#");
            Skill java = new("Java", "java");
            List<Skill> skills = new(){ cSharp, java };


            Job jobToCreate = new Job(Guid.NewGuid().ToString(), "testJob", "Test Job", 10, 2.5, true, skills, client, null, new List<User>(), true, true); ;
            CreateJobInput input = new CreateJobInput(jobToCreate.Title, jobToCreate.Description, jobToCreate.Deadline, jobToCreate.Payment, jobToCreate.IsPaymentByHour, jobToCreate.Skills.Select(s => s.NormalizedName).ToList(), jobToCreate.Client.Id);
            OkObjectResult? actionResult = jobController.CreateNewJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            Job? responseObject = actionResult.Value as Job;
            Assert.NotNull(responseObject);

            Assert.Equal(jobToCreate.Title, responseObject.Title);
            Assert.Equal(jobToCreate.Description, responseObject.Description);
            Assert.Equal(jobToCreate.Deadline, responseObject.Deadline);
            Assert.Equal(jobToCreate.Payment, responseObject.Payment);
            Assert.Equal(jobToCreate.IsPaymentByHour, responseObject.IsPaymentByHour);
            Assert.Equal(jobToCreate.Skills.Reverse<Skill>(), responseObject.Skills);
            Assert.Equal(jobToCreate.Client, responseObject.Client);
            Assert.Equal(jobToCreate.AssignedFreelancer, responseObject.AssignedFreelancer);
            Assert.Equal(jobToCreate.Candidates, responseObject.Candidates);
            Assert.Equal(jobToCreate.Active, responseObject.Active);
            Assert.Equal(jobToCreate.Available, responseObject.Available);
        }

        [Fact]
        public void TestRetrieveJobsAsClient()
        {

        }

        [Fact]
        public void TestRetrieveJobsAsFreelancer()
        {

        }

        [Fact]
        public void TestCandidateJob()
        {

        }

        [Fact]
        public void TestRateJob()
        {

        }
    }
}
