using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using Backend.Persistence;
using NSubstitute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Domain.Repository.Tests
{
    public class JobRepositoryTests
    {
        ApplicationDbContext dbContextMock;

        IJobRepository jobRepository;
        
        public JobRepositoryTests()
        {

            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase("MessageRepositoryTests")
                 .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                 .Options;

            dbContextMock = new ApplicationDbContext(_contextOptions);

            dbContextMock.ChangeTracker.Clear();

            dbContextMock.Database.EnsureDeleted();
            dbContextMock.Database.EnsureCreated();

            jobRepository = new JobRepository(dbContextMock);

        }

        [Fact]
        public void TestCreateJobCreatesNewSkills()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            
            TestingHelper.CreateUserInDatabase(user1, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>() { new Skill("java","java")},user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            var skills = dbContextMock.Skills.ToList();

            Assert.Contains(skills, s => s.NormalizedName == "java");
        }

        [Fact]
        public void TestCreateJobAddsJobRequirement()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            
            TestingHelper.CreateUserInDatabase(user1, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>() { new Skill("java", "java") }, user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            var req = dbContextMock.JobSkills.ToList();

            Assert.Contains(req, r => r.JobId == "id_teste" && r.SkillId == "java");
        }

        [Fact]
        public void TestCreateJobAddsJobCandidates()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            
            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);
            
            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>() { user2}, true, false);

            jobRepository.CreateNewJob(job);

            var cands = dbContextMock.JobCandidates.ToList();

            Assert.Contains(cands, c => c.JobId == "id_teste" && c.CandidateId == "id_2");
        }

        [Fact]
        public void TestUpdateJobAddsNewSkills()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            job.Skills.Add(new Skill("java", "java"));

            jobRepository.UpdateJob(job);

            var skills = dbContextMock.Skills.ToList();

            Assert.Contains(skills, s => s.NormalizedName == "java");
        }

        [Fact]
        public void TestUpdateJobAddsNewCandidates()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            job.Candidates.Add(user2);

            jobRepository.UpdateJob(job);

            var cands = dbContextMock.JobCandidates.ToList();

            Assert.Contains(cands, c => c.JobId == "id_teste" && c.CandidateId == "id_2");
        }

        [Fact]
        public void TestGetJobByIdWithValidId()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            var response = jobRepository.GetJobById("id_teste");

            Assert.Equal(job, response);
        }

        [Fact]
        public void TestGetJobByIdWithInvalidId()
        {
            Assert.Null(jobRepository.GetJobById("xxxx"));
        }

        [Fact]
        public void TestGetAllAvailableJobsWithNoJob()
        {
            Assert.Empty(jobRepository.GetAllAvailableJobs());
        }

        [Fact]
        public void TestGetAllAvailableJobsWithManyJobs()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, true);
            var job2 = new Job("id_teste2", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, false);
            var job3 = new Job("id_teste3", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, true);

            jobRepository.CreateNewJob(job);
            jobRepository.CreateNewJob(job2);
            jobRepository.CreateNewJob(job3);

            var response = jobRepository.GetAllAvailableJobs();

            Assert.Contains(response, j => j.Id == "id_teste");
            Assert.Contains(response, j => j.Id == "id_teste3");
        }

        [Fact]
        public void TestListJobsByUserWithClient()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            
            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            
            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>(), true, false);

            jobRepository.CreateNewJob(job);

            var response = jobRepository.ListJobsByUser("id_1",false);

            Assert.Contains(response, j => j.Id == "id_teste");
        }

        [Fact]
        public void TestListJobsByUserWithFreelancer()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", true, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);

            var job = new Job("id_teste", "teste", "teste", 0, 0, false, new List<Skill>(), user1, null, new List<User>() { user2}, true, false);

            jobRepository.CreateNewJob(job);

            var response = jobRepository.ListJobsByUser("id_2", true);

            Assert.Contains(response, j => j.Id == "id_teste");
        }
    }
}
