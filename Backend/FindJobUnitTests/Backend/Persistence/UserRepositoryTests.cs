using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using Backend.Persistence;
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
    public class UserRepositoryTests
    {

        ApplicationDbContext dbContextMock;

        IUserRepository userRepository;
        public UserRepositoryTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                  .UseInMemoryDatabase("SkillRepositoryTests")
                  .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                  .Options;

            dbContextMock = new ApplicationDbContext(_contextOptions);

            dbContextMock.ChangeTracker.Clear();

            dbContextMock.Database.EnsureDeleted();
            dbContextMock.Database.EnsureCreated();

            userRepository = new UserRepository(dbContextMock);
        }

        [Fact]
        public void TestCreateUserCreatesNewSkills()
        {
            var skills = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("java", "java")] = new Tuple<double, int>(5, 1),
                [new Skill("python", "python")] = new Tuple<double, int>(10, 1)
            };

            var response = userRepository.CreateNewUser(new User("id_teste", "teste", "teste", "teste", "teste", true, skills));

            Assert.Equal("id_teste", response.Id);
            Assert.Equal("teste", response.Name);
            Assert.Equal("teste", response.Email);
            Assert.Equal("teste", response.Password);
            Assert.Equal("teste", response.Phone);
            Assert.True(response.IsFreelancer);

            var createdSkills = dbContextMock.Skills.ToList();

            Assert.Contains(createdSkills, s => s.NormalizedName == "java");
            Assert.Contains(createdSkills, s => s.NormalizedName == "python");

        }

        [Fact]
        public void TestCreateUserAddsUserProficiencies()
        {
            var skills = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("java", "java")] = new Tuple<double, int>(5, 1),
                [new Skill("python", "python")] = new Tuple<double, int>(10, 1)
            };

            userRepository.CreateNewUser(new User("id_teste", "teste", "teste", "teste", "teste", true, skills));

            var createdProfs = dbContextMock.UserSkills.ToList();

            Assert.Contains(createdProfs, p => p.SkillId == "java" && p.UserId == "id_teste");
            Assert.Contains(createdProfs, p => p.SkillId == "python" && p.UserId == "id_teste");

        }

        [Fact]
        public void TestUpdateUserUpdatesValues()
        {
            userRepository.CreateNewUser(new User("id_teste", "teste", "teste", "teste", "teste", true, new Dictionary<Skill, Tuple<double, int>>()));
            var response = userRepository.UpdateUser(new User("id_teste", "teste2", "teste2", "teste2", "teste2", true, new Dictionary<Skill, Tuple<double, int>>()));
            
            Assert.Equal("id_teste", response.Id);
            Assert.Equal("teste2", response.Name);
            Assert.Equal("teste2", response.Email);
            Assert.Equal("teste2", response.Password);
            Assert.Equal("teste2", response.Phone);
            Assert.True(response.IsFreelancer);

        }

        [Fact]
        public void TestUpdateUserAddsNewProficiencies()
        {
            var skills = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("java", "java")] = new Tuple<double, int>(5, 1),
                [new Skill("python", "python")] = new Tuple<double, int>(10, 1)
            };

            userRepository.CreateNewUser(new User("id_teste", "teste", "teste", "teste", "teste", true, new Dictionary<Skill, Tuple<double, int>>()));
            userRepository.UpdateUser(new User("id_teste", "teste", "teste", "teste", "teste", true, skills));

            var createdProfs = dbContextMock.UserSkills.ToList();

            Assert.Contains(createdProfs, p => p.SkillId == "java" && p.UserId == "id_teste");
            Assert.Contains(createdProfs, p => p.SkillId == "python" && p.UserId == "id_teste");

        }

        [Fact]
        public void TestGetUserByIdWithValidId()
        {
            userRepository.CreateNewUser(new User("id_teste", "teste", "teste", "teste", "teste", true, new Dictionary<Skill, Tuple<double, int>>()));

            var response = userRepository.GetUserById("id_teste");

            Assert.Equal("id_teste", response.Id);
            Assert.Equal("teste", response.Name);
            Assert.Equal("teste", response.Email);
            Assert.Equal("teste", response.Password);
            Assert.Equal("teste", response.Phone);
            Assert.True(response.IsFreelancer);

        }

        [Fact]
        public void TestGetUserByIdWithInvalidId()
        {
            Assert.Null(userRepository.GetUserById("xxxx"));
        }

        [Fact]
        public void TestGetUserByEmailWithValidEmail()
        {
            userRepository.CreateNewUser(new User("id_teste", "teste", "email_teste", "teste", "teste", true, new Dictionary<Skill, Tuple<double, int>>()));

            var response = userRepository.GetUserByEmail("email_teste");

            Assert.Equal("id_teste", response.Id);
            Assert.Equal("teste", response.Name);
            Assert.Equal("email_teste", response.Email);
            Assert.Equal("teste", response.Password);
            Assert.Equal("teste", response.Phone);
            Assert.True(response.IsFreelancer);

        }

        [Fact]
        public void TestGetUserByEmailWithInvalidEmail()
        {
            Assert.Null(userRepository.GetUserById("xxxx"));
        }
    }
}
