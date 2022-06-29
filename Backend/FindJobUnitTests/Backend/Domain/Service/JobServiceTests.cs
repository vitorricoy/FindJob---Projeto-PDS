using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Domain.Service.Tests
{
    public class JobRepositoryTests
    {
        List<Job> mockRepo;

        ISkillRepository skillRepositoryMock;

        IUserRepository userRepositoryMock;

        IJobRepository jobRepositoryMock;

        IJobService jobService;

        User freela1;


        public JobRepositoryTests()
        {
            skillRepositoryMock = Substitute.For<ISkillRepository>();

            skillRepositoryMock.CreateNewSkill(Arg.Any<Skill>()).Returns(args => (Skill)args[0]);

            var skills_freela1 = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("java","java")] = new Tuple<double,int>(5,1),
                [new Skill("python", "python")] = new Tuple<double, int>(10, 1)
            };

            var skills_freela2 = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("c#", "c#")] = new Tuple<double, int>(3, 1),
                [new Skill("c++", "c++")] = new Tuple<double, int>(6, 1)
            };

            

            userRepositoryMock = Substitute.For<IUserRepository>();

            userRepositoryMock.GetUserById("id_cliente").Returns(new User("id_cliente", "teste", "teste", "teste", "teste", false, null));

            freela1 = new User("id_freela", "teste", "teste", "teste", "teste", true, skills_freela1);

            userRepositoryMock.GetUserById("id_freela").Returns(freela1);

            userRepositoryMock.GetUserById("id_freela2").Returns(new User("id_freela2", "teste", "teste", "teste", "teste", true, skills_freela2));

            userRepositoryMock.GetUserById(Arg.Is<string>(id => !(new[] { "id_cliente", "id_freela", "id_freela2" }.Contains(id)))).Returns(args => null);

            userRepositoryMock.When(mock => mock.UpdateUser(Arg.Any<User>())).Do(args => freela1 = (User)args[0]);

            mockRepo = new List<Job>();
            
            jobRepositoryMock = Substitute.For<IJobRepository>();

            jobRepositoryMock.CreateNewJob(Arg.Any<Job>()).Returns(args => { mockRepo.Add((Job)args[0]); return (Job)args[0]; });

            jobRepositoryMock.When(mock => mock.UpdateJob(Arg.Any<Job>())).Do(args =>
            {
                var newjob = (Job)args[0];
                var job = mockRepo.FirstOrDefault(j => j.Id == newjob.Id);

                if(job != null)
                {
                    job.Active = newjob.Active;
                    job.Available = newjob.Available;
                    job.AssignedFreelancer = newjob.AssignedFreelancer;
                    job.Candidates = newjob.Candidates;
                }
            });

            jobRepositoryMock.GetJobById(Arg.Any<string>()).Returns(args => { return mockRepo.Where(j => j.Id == (string)args[0]).FirstOrDefault(); });

            jobRepositoryMock.GetAllAvailableJobs().Returns(args => { return mockRepo.Where(j => j.Available).ToList(); });

            jobRepositoryMock.ListJobsByUser(Arg.Any<string>(),Arg.Any<bool>()).Returns(args => {
                if ((bool)args[1])
                {
                    return mockRepo.Where(j => j.AssignedFreelancer != null && j.AssignedFreelancer.Id == (string)args[0] && j.Active).ToList();
                }
                else
                {
                    return mockRepo.Where(j => j.Client != null && j.Client.Id == (string)args[0] && j.Active).ToList();
                }
            });

            jobService = new JobService(jobRepositoryMock, userRepositoryMock, skillRepositoryMock);
        }
        
        [Fact]
        public void TestListJobsByUserWithValidUser()
        {
            List<Job> response = jobService.ListJobsByUser("id_cliente");

            Assert.Equal(new List<Job>(), response);

            mockRepo.Clear();
        }

        [Fact]
        public void TestListJobsByUserWithInvalidUser()
        {
            Assert.Throws<InvalidUserIdException>(() => jobService.ListJobsByUser("xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestSearchJobsForFreelancerIfJobsAreOrdered()
        {
            var jobId1 = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>() { "python", "java" }, "id_cliente").Id;
            var jobId3 = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>() { "c++", "java" }, "id_cliente").Id;
            var jobId2 = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>() { "python", "c#" }, "id_cliente").Id;

            var response = jobService.SearchJobsForFreelancer("id_freela");

            Assert.Equal(new[] { jobId1, jobId2, jobId3 }, response.Select(job => job.Id));


            mockRepo.Clear();
        }

        [Fact]
        public void TestSearchJobsForFreelancerWithInvalidUserId()
        {
            Assert.Throws<InvalidUserIdException>(() => jobService.SearchJobsForFreelancer("xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestSearchJobsForFreelancerIfUserIsntFreelancer()
        {
            Assert.Throws<InvalidUserIdException>(() => jobService.SearchJobsForFreelancer("id_cliente"));
            mockRepo.Clear();
        }
        
        [Fact]
        public void TestRateJobWithValidJobId()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>() { "python", "c#"}, "id_cliente").Id;
            jobService.CandidateForJob(jobId, "id_freela");
            jobService.ChooseFreelancerForJob(jobId, "id_freela");

            jobService.RateJob(jobId, 2.2);

            Assert.Equal(6.1, freela1.Skills[new Skill("python", "python")].Item1);
            Assert.Equal(2, freela1.Skills[new Skill("python", "python")].Item2);

            Assert.Equal(5, freela1.Skills[new Skill("java", "java")].Item1);
            Assert.Equal(1, freela1.Skills[new Skill("java", "java")].Item2);

            var skills_freela1 = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("java", "java")] = new Tuple<double, int>(5, 1),
                [new Skill("python", "python")] = new Tuple<double, int>(10, 1)
            };

            freela1 = new User("id_freela", "teste", "teste", "teste", "teste", true, skills_freela1);

            mockRepo.Clear();
        }

        [Fact]
        public void TestRateJobWithInvalidJobId()
        {
            Assert.Throws<InvalidJobIdException>(() => jobService.RateJob("xxxx",0));
            mockRepo.Clear();
        }

        [Fact]
        public void TestRateJobWithNotAssignedJob()
        {
            var jobid = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;
            
            Assert.Throws<InvalidJobIdException>(() => jobService.RateJob(jobid,0));
            mockRepo.Clear();
        }
        

        [Fact]
        public void TestGetJobByIdWithValidId()
        {
            var jobid = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;

            var response = jobService.GetJobById(jobid);

            Assert.NotNull(response);
            Assert.Equal("teste", response.Title);
            Assert.Equal("teste", response.Description);
            Assert.Equal(0, response.Deadline);
            Assert.Equal(0, response.Payment);
            Assert.False(response.IsPaymentByHour);

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetJobByIdWithInvalidId()
        {
            Assert.Null(jobService.GetJobById("xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestCreateJobWithValidClient()
        {
            var response = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente");

            Assert.NotNull(response);
            Assert.Equal("teste", response.Title);
            Assert.Equal("teste", response.Description);
            Assert.Equal(0, response.Deadline);
            Assert.Equal(0, response.Payment);
            Assert.False(response.IsPaymentByHour);

            mockRepo.Clear();
        }

        [Fact]
        public void TestCreateJobWithInvalidClient()
        {
            Assert.Throws<InvalidUserIdException>(() => jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(),"xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestCandidateForJobWithValidConditions()
        {
            var job = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente");
            
            jobService.CandidateForJob(job.Id, "id_freela");

            Assert.Contains(job.Candidates, user => user.Id == "id_freela");

            mockRepo.Clear();
        }

        [Fact]
        public void TestCandidateForJobWithInvalidJobId()
        {
            Assert.Throws<InvalidJobIdException>(() => jobService.CandidateForJob("xxxx","id_freela"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestCandidateForJobWithInvalidUserId()
        {
            var jobId = jobService.CreateNewJob("teste","teste",0,0,false, new List<string>(), "id_cliente").Id;
            
            Assert.Throws<InvalidUserIdException>(() => jobService.CandidateForJob(jobId, "xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestCandidateForJobWithUnavailableJob()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;
            jobService.CandidateForJob(jobId, "id_freela");
            jobService.ChooseFreelancerForJob(jobId, "id_freela");
            Assert.Throws<UnavailableJobException>(() => jobService.CandidateForJob(jobId, "id_freela2"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestChooseFreelancerForJobWithValidConditions()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;
            jobService.CandidateForJob(jobId, "id_freela");
            jobService.ChooseFreelancerForJob(jobId, "id_freela");

            var response = jobService.GetJobById(jobId);

            Assert.False(response.Available);
            Assert.NotNull(response.AssignedFreelancer);
            Assert.Equal("id_freela", response.AssignedFreelancer.Id);

            mockRepo.Clear();
        }

        [Fact]
        public void TestChooseFreelancerForJobWithInvalidJobId()
        {
            Assert.Throws<InvalidJobIdException>(() => jobService.ChooseFreelancerForJob("xxxx", "id_freela"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestChooseFreelancerForJobWithInvalidUserId()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;

            Assert.Throws<InvalidUserIdException>(() => jobService.ChooseFreelancerForJob(jobId, "xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestChooseFreelancerForJobWithUnavailableJob()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>(), "id_cliente").Id;

            jobService.CandidateForJob(jobId, "id_freela");
            jobService.CandidateForJob(jobId, "id_freela2");
            jobService.ChooseFreelancerForJob(jobId, "id_freela");

            Assert.Throws<UnavailableJobException>(() => jobService.ChooseFreelancerForJob(jobId, "id_freela2"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetJobCandidatesBySkillAreOrdered()
        {
            var jobId = jobService.CreateNewJob("teste", "teste", 0, 0, false, new List<string>() { "java", "c++" }, "id_cliente").Id;
            jobService.CandidateForJob(jobId, "id_freela");
            jobService.CandidateForJob(jobId, "id_freela2");

            var response = jobService.GetJobCandidatesBySkill(jobId);

            Assert.Equal(new[] { "id_freela2", "id_freela" }, response.Select(user => user.Id));

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetJobCandidatesBySkillWithInvalidJobId()
        {
            Assert.Throws<InvalidJobIdException>(() => jobService.GetJobCandidatesBySkill("xxxx"));
            mockRepo.Clear();
        }
    }
}
