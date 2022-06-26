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
    public class UserServiceTests
    {
        List<User> mockRepo;

        IUserRepository userRepositoryMock;

        IUserService userService;
        
        public UserServiceTests()
        {
            mockRepo = new List<User>();

            userRepositoryMock = Substitute.For<IUserRepository>();

            userRepositoryMock.CreateNewUser(Arg.Any<User>()).
                Returns(args =>
                {
                    mockRepo.Add((User)args[0]);
                    return (User)args[0];
                });

            userRepositoryMock.GetUserById(Arg.Any<string>()).
                Returns(args => mockRepo.Find(user => user.Id == (string)args[0]));

            userRepositoryMock.GetUserByEmail(Arg.Any<string>()).
                Returns(args => mockRepo.Find(user => user.Email == (string)args[0]));

            userService = new UserService(userRepositoryMock);
        }

        [Fact]
        public void TestRegisterClientWithNewUser()
        {
            var response = userService.RegisterClient("jhon", "a@b.com", "abcd", "1234");

            Assert.Equal("jhon", response.Name);
            Assert.Equal("a@b.com", response.Email);
            Assert.Equal("1234", response.Phone);
            Assert.False(response.IsFreelancer);
            Assert.Null(response.Skills);

            mockRepo.Clear();
        }

        [Fact]
        public void TestRegisterClientWithAlreadyRegisteredEmail()
        {
            userService.RegisterClient("jhon", "a@b.com", "abcd", "1234");

            Assert.Throws<InvalidSignUpCredentialsException>(() => userService.RegisterClient("jhon2", "a@b.com", "wxyz", "6789"));

            mockRepo.Clear();
        }

        [Fact]
        public void TestRegisterFreelancerWithNewUser()
        {
            var response = userService.RegisterFreelancer("jhon", "a@b.com", "abcd", "1234", new List<string>(){ "c++", "java"}, new List<double>(){ 4.5, 4.8});

            Assert.Equal("jhon", response.Name);
            Assert.Equal("a@b.com", response.Email);
            Assert.Equal("1234", response.Phone);
            Assert.True(response.IsFreelancer);
            Assert.NotNull(response.Skills);

            var skills = new Dictionary<Skill, Tuple<double, int>>()
            {
                [new Skill("c++", "c++")] = new Tuple<double, int>(4.5, 1),
                [new Skill("java", "java")] = new Tuple<double, int>(4.8, 1)
            }.ToList();

            Assert.True(response.Skills.ToList().All(pair => skills.Contains(pair)));

            mockRepo.Clear();
        }

        [Fact]
        public void TestRegisterFreelancerWithAlreadyExistingUser()
        {
            userService.RegisterFreelancer("jhon", "a@b.com", "abcd", "1234", new List<string>() { "c++", "java" }, new List<double>() { 4.5, 4.8 });

            Assert.Throws<InvalidSignUpCredentialsException>(() => userService.RegisterFreelancer("jhony", "a@b.com", "wxyz", "6789", new List<string>() { "c#", "python" }, new List<double>() { 1.2, 2.1 }));

            mockRepo.Clear();
        }

        [Fact]
        public void TestLoginWithValidCredentials()
        {
            userService.RegisterClient("jhon", "a@b.com", "abcd", "1234");

            var response = userService.Login("a@b.com", "abcd");

            Assert.Equal("jhon", response.Name);
            Assert.Equal("a@b.com", response.Email);
            Assert.Equal("1234", response.Phone);
            Assert.False(response.IsFreelancer);
            Assert.Null(response.Skills);

            mockRepo.Clear();
        }

        [Fact]
        public void TestLoginWithInvalidEmail()
        {
            userService.RegisterClient("jhon", "a@b.com", "abcd", "1234");

            Assert.Throws<InvalidLoginCredentialsException>(() => userService.Login("x@b.com", "abcd"));
      
            mockRepo.Clear();
        }

        [Fact]
        public void TestLoginWithValidEmailAndInvalidPassword()
        {
            userService.RegisterClient("jhon", "a@b.com", "abcd", "1234");

            Assert.Throws<InvalidLoginCredentialsException>(() => userService.Login("a@b.com", "wxyz"));

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetUserByIdWithValidId()
        {
            mockRepo.Add(new User("test_id", "jhon", "a@b.com", "abcd", "1234", false, null));

            var response = userService.GetUserById("test_id");

            Assert.Equal("jhon", response.Name);
            Assert.Equal("a@b.com", response.Email);
            Assert.Equal("1234", response.Phone);
            Assert.False(response.IsFreelancer);
            Assert.Null(response.Skills);

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetUserByIdWithInValidId()
        {
            mockRepo.Add(new User("test_id", "jhon", "a@b.com", "abcd", "1234", false, null));

            var response = userService.GetUserById("other_test_id");

            Assert.Null(response);

            mockRepo.Clear();
        }
    }
}
