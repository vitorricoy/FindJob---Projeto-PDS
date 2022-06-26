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
    public class MessageServiceTests
    {
        [Fact]
        public void TestListJobsByUserWithValidUser()
        {
            var userId = Guid.NewGuid();
            
            var jobRepositoryMock = Substitute.For<IJobRepository>();
            jobRepositoryMock.ListJobsByUser(userId.ToString(), false)
                .Returns(new List<Job>());

            var userRepositoryMock = Substitute.For<IUserRepository>();
            userRepositoryMock.GetUserById(userId.ToString())
                .Returns(new User(userId.ToString(), "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>()));

            var skillRepositoryMock = Substitute.For<ISkillRepository>();

            var jobService = new JobService(jobRepositoryMock, userRepositoryMock, skillRepositoryMock);

            List<Job> response = jobService.ListJobsByUser(userId.ToString());

            Assert.Equal(new List<Job>(), response);
        }

        [Fact]
        public void TestListJobsByUserWithInvalidUser()
        {
            var userId = Guid.NewGuid();

            var jobRepositoryMock = Substitute.For<IJobRepository>();
            jobRepositoryMock.ListJobsByUser(userId.ToString(), false)
                .Returns(new List<Job>());

            var userRepositoryMock = Substitute.For<IUserRepository>();
            userRepositoryMock.GetUserById(userId.ToString())
                .Returns((User?) null);

            var skillRepositoryMock = Substitute.For<ISkillRepository>();

            var jobService = new JobService(jobRepositoryMock, userRepositoryMock, skillRepositoryMock);

            Assert.Throws<InvalidUserIdException>(() => jobService.ListJobsByUser(userId.ToString()));
        }
    }
}
