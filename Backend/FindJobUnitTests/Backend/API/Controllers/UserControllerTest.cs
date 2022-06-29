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
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.API.Controllers
{
    public class UserControllerTest
    {
        public UserControllerTest()
        {

        }

        [Fact]
        public void TestLoginSuccess()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            userServiceMock.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(args => client);
            UserController controller = new(userServiceMock);
            OkObjectResult? actionResult = controller.Login(client.Email, client.Password) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;
            Assert.Equal(client, responseObject);
        }

        [Fact]
        public void TestLoginInvalidLoginCredentialsError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidLoginCredentialsException(); });
            UserController controller = new(userServiceMock);
            ObjectResult? actionResult = controller.Login("teste", "teste") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestLoginGenericError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            UserController controller = new(userServiceMock);
            ObjectResult? actionResult = controller.Login("teste", "teste") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestRegisterClientSuccess()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            userServiceMock.RegisterClient(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(args => client);
            UserController controller = new(userServiceMock);
            CreateClientInput input = new(client.Name, client.Email, client.Password, client.Phone);
            OkObjectResult? actionResult = controller.RegisterClient(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;
            Assert.Equal(client, responseObject);
        }

        [Fact]
        public void TestRegisterClientInvalidSignUpCredentialsError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.RegisterClient(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new InvalidSignUpCredentialsException(); });
            UserController controller = new(userServiceMock);
            CreateClientInput input = new("teste", "teste@teste.com", "teste", "33333333");
            ObjectResult? actionResult = controller.RegisterClient(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestRegisterClientGenericError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.RegisterClient(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            UserController controller = new(userServiceMock);
            CreateClientInput input = new("teste", "teste@teste.com", "teste", "33333333");
            ObjectResult? actionResult = controller.RegisterClient(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestRegisterFreelancerSuccess()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            userServiceMock.RegisterFreelancer(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<List<string>>(), Arg.Any<List<double>>()).Returns(args => freelancer);
            UserController controller = new(userServiceMock);
            CreateFreelancerInput input = new("freelancer", "freelancer@test.com", "test", "333344443", new List<string>(), new List<double>());
            OkObjectResult? actionResult = controller.RegisterFreelancer(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;
            Assert.Equal(freelancer, responseObject);
        }

        [Fact]
        public void TestRegisterFreelancerInvalidSignUpCredentialsError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.RegisterFreelancer(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<List<string>>(), Arg.Any<List<double>>()).Returns(args => { throw new InvalidSignUpCredentialsException(); });
            UserController controller = new(userServiceMock);
            CreateFreelancerInput input = new("freelancer", "freelancer@test.com", "test", "333344443", new List<string>(), new List<double>());
            ObjectResult? actionResult = controller.RegisterFreelancer(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(403, actionResult?.StatusCode);
        }

        [Fact]
        public void TestRegisterFreelancerGenericError()
        {
            IUserService userServiceMock = Substitute.For<IUserService>();
            userServiceMock.RegisterFreelancer(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<List<string>>(), Arg.Any<List<double>>()).Returns(args => { throw new Exception(); });
            UserController controller = new(userServiceMock);
            CreateFreelancerInput input = new("freelancer", "freelancer@test.com", "test", "333344443", new List<string>(), new List<double>());
            ObjectResult? actionResult = controller.RegisterFreelancer(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

    }
}
