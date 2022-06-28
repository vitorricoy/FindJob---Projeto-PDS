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
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            JobRepository jobRepository = new(context);
            SkillRepository skillRepository = new(context);
            UserRepository userRepository = new(context);

            JobService jobService = new(jobRepository, userRepository, skillRepository);

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


            Job jobToCreate = new Job(Guid.NewGuid().ToString(), "testJob", "Test Job", 10, 2.5, true, skills, client, null, new List<User>(), true, true);
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
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            User otherClient = new(Guid.NewGuid().ToString(), "client 2", "client2@test.com", "test", "333344443", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(otherClient, context);

            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            Skill html = new("HTML", "html");
            TestingHelper.CreateSkillsInDatabase(html, context);

            Job firstClientJob = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java}, client, null, new List<User>(), true, true);
            Job secondClientJob = new(Guid.NewGuid().ToString(), "testJob 2", "Test Job 2", 15, 300, false, new List<Skill>() { cpp, html }, client, null, new List<User>(), true, true);
            Job otherClientJob = new(Guid.NewGuid().ToString(), "testJob 3", "Test Job 3", 20, 350, false, new List<Skill>() { cpp, java }, otherClient, null, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(firstClientJob, context);
            TestingHelper.CreateJobInDatabase(secondClientJob, context);
            TestingHelper.CreateJobInDatabase(otherClientJob, context);

            OkObjectResult? actionResult = jobController.ListJobsByUser(client.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            List<Job>? responseObject = actionResult.Value as List<Job>;
            Assert.NotNull(responseObject);

            Assert.Equal(2, responseObject.Count);

            Assert.Equal(firstClientJob, responseObject[0]);
            Assert.Equal(secondClientJob, responseObject[1]);
        }

        [Fact]
        public void TestRetrieveJobsAsFreelancer()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            Skill html = new("HTML", "html");
            TestingHelper.CreateSkillsInDatabase(html, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(5.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            var otherFreelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { cSharp, Tuple.Create(5.0, 1) }, { html, Tuple.Create(5.0, 1) } };
            User otherFreelancer = new(Guid.NewGuid().ToString(), "otherFreelancer", "otherFreelancer@test.com", "test", "333344443", true, otherFreelancerSkills);
            TestingHelper.CreateUserInDatabase(otherFreelancer, context);

            Job firstClientJob = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, freelancer, new List<User>(), true, true);
            Job secondClientJob = new(Guid.NewGuid().ToString(), "testJob 2", "Test Job 2", 15, 300, false, new List<Skill>() { cpp, html }, client, freelancer, new List<User>(), true, true);
            Job otherClientJob = new(Guid.NewGuid().ToString(), "testJob 3", "Test Job 3", 20, 350, false, new List<Skill>() { cpp, java }, client, otherFreelancer, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(firstClientJob, context);
            TestingHelper.CreateJobInDatabase(secondClientJob, context);
            TestingHelper.CreateJobInDatabase(otherClientJob, context);

            OkObjectResult? actionResult = jobController.ListJobsByUser(freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            List<Job>? responseObject = actionResult.Value as List<Job>;
            Assert.NotNull(responseObject);

            Assert.Equal(2, responseObject.Count);

            Assert.Equal(firstClientJob, responseObject[0]);
            Assert.Equal(secondClientJob, responseObject[1]);
        }

        [Fact]
        public void TestSearchJobs()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            Skill html = new("HTML", "html");
            TestingHelper.CreateSkillsInDatabase(html, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(4.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            User otherClient = new(Guid.NewGuid().ToString(), "client 2", "client2@test.com", "test", "333344443", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(otherClient, context);

            Job firstClientJob = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, null, new List<User>(), true, true);
            Job secondClientJob = new(Guid.NewGuid().ToString(), "testJob 2", "Test Job 2", 15, 300, false, new List<Skill>() { cpp, html }, client, null, new List<User>(), true, true);
            Job otherClientJob = new(Guid.NewGuid().ToString(), "testJob 3", "Test Job 3", 20, 350, false, new List<Skill>() { cpp, java }, otherClient, null, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(firstClientJob, context);
            TestingHelper.CreateJobInDatabase(secondClientJob, context);
            TestingHelper.CreateJobInDatabase(otherClientJob, context);

            OkObjectResult? actionResult = jobController.SearchJobsForFreelancer(freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            List<Job>? responseObject = actionResult.Value as List<Job>;
            Assert.NotNull(responseObject);

            Assert.Equal(3, responseObject.Count);

            Assert.Equal(otherClientJob, responseObject[0]);
            Assert.Equal(firstClientJob, responseObject[1]);
            Assert.Equal(secondClientJob, responseObject[2]);
            
        }

        [Fact]
        public void TestApplyToJob()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(4.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            Job job = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, null, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(job, context);

            ApplyFreelancerInput input = new ApplyFreelancerInput(job.Id, freelancer.Id);

            OkObjectResult? actionResult = jobController.ApplyFreelancerToJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            Boolean resultValue = (Boolean)actionResult.Value;
            Assert.True(resultValue);

            List<JobCandidateModel> candidatesJob = context.JobCandidates.Where(j => j.JobId.Equals(job.Id)).ToList();
            Assert.Single(candidatesJob);
            Assert.Equal(freelancer.Id, candidatesJob[0].CandidateId);
        }

        [Fact]
        public void TestListJobCandidates()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            Skill html = new("HTML", "html");
            TestingHelper.CreateSkillsInDatabase(html, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(5.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            var otherFreelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { cSharp, Tuple.Create(4.0, 1) }, { html, Tuple.Create(5.0, 1) } };
            User otherFreelancer = new(Guid.NewGuid().ToString(), "otherFreelancer", "otherFreelancer@test.com", "test", "333344443", true, otherFreelancerSkills);
            TestingHelper.CreateUserInDatabase(otherFreelancer, context);

            Job job = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, null, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(job, context);

            context.JobCandidates.Add(new JobCandidateModel(job.Id, freelancer.Id));
            context.JobCandidates.Add(new JobCandidateModel(job.Id, otherFreelancer.Id));
            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            OkObjectResult? actionResult = jobController.GetJobCandidatesBySkill(job.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            List<User> resultValue = actionResult.Value as List<User>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count);
            Assert.Equal(freelancer, resultValue[0]);
            Assert.Equal(otherFreelancer, resultValue[1]);
        }

        [Fact]
        public void TestChooseJobCandidate()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            Skill html = new("HTML", "html");
            TestingHelper.CreateSkillsInDatabase(html, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(5.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            var otherFreelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { cSharp, Tuple.Create(4.0, 1) }, { html, Tuple.Create(5.0, 1) } };
            User otherFreelancer = new(Guid.NewGuid().ToString(), "otherFreelancer", "otherFreelancer@test.com", "test", "333344443", true, otherFreelancerSkills);
            TestingHelper.CreateUserInDatabase(otherFreelancer, context);

            Job job = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, null, new List<User>(), true, true);
            TestingHelper.CreateJobInDatabase(job, context);

            context.JobCandidates.Add(new JobCandidateModel(job.Id, freelancer.Id));
            context.JobCandidates.Add(new JobCandidateModel(job.Id, otherFreelancer.Id));
            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            ApplyFreelancerInput input = new ApplyFreelancerInput(job.Id, freelancer.Id);

            OkObjectResult? actionResult = jobController.ChooseFreelancerForJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            Boolean resultValue = (Boolean)actionResult.Value;
            Assert.True(resultValue);

            var jobModel = context.Jobs.Where(j => j.Id.Equals(job.Id)).First();
            Assert.Equal(freelancer.Id, jobModel.AssignedFreelancerId);
            Assert.False(jobModel.Available);
        }

        [Fact]
        public void TestRateJob()
        {
            Skill cSharp = new("C#", "c#");
            TestingHelper.CreateSkillsInDatabase(cSharp, context);

            Skill java = new("Java", "java");
            TestingHelper.CreateSkillsInDatabase(java, context);

            Skill cpp = new("C++", "c++");
            TestingHelper.CreateSkillsInDatabase(cpp, context);

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            var freelancerSkills = new Dictionary<Skill, Tuple<double, int>>() { { java, Tuple.Create(5.0, 1) }, { cpp, Tuple.Create(5.0, 1) } };
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, freelancerSkills);
            TestingHelper.CreateUserInDatabase(freelancer, context);

            Job job = new(Guid.NewGuid().ToString(), "testJob 1", "Test Job 1", 10, 2.5, true, new List<Skill>() { cSharp, java }, client, freelancer, new List<User>(), true, false);
            TestingHelper.CreateJobInDatabase(job, context);

            context.JobCandidates.Add(new JobCandidateModel(job.Id, freelancer.Id));
            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            RateJobInput input = new RateJobInput(job.Id, 5.0);

            OkObjectResult? actionResult = jobController.RateJob(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult.StatusCode);

            Boolean resultValue = (Boolean)actionResult.Value;
            Assert.True(resultValue);

            var jobModel = context.Jobs.Where(j => j.Id.Equals(job.Id)).First();
            Assert.False(jobModel.Active);

            var userSkill = context.UserSkills.Where(s => s.SkillId.Equals(java.NormalizedName) && s.UserId.Equals(freelancer.Id)).First();
            Assert.Equal(5.0, userSkill.Rating);
            Assert.Equal(2, userSkill.RatingsDone);
        }
    }
}
