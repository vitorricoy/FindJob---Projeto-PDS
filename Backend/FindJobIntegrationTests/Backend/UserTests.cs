using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Backend.Persistence;
using Backend.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend.Tests
{
    public class UserTests
    {
        readonly UserController userController;
        readonly ApplicationDbContext context;

        public UserTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UserTests")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            UserRepository userRepository = new(context);

            UserService skillService = new(userRepository);

            userController = new UserController(skillService);
        }

        [Fact]
        public void TestClientLogin()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", HashingUtil.getHash("test"), "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            OkObjectResult? actionResult = userController.Login("client@test.com", "test") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;
            Assert.NotNull(responseObject);
            Assert.Equal(client, responseObject);
        }

        [Fact]
        public void TestFreelancerLogin()
        {
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", HashingUtil.getHash("test"), "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(freelancer, context);

            OkObjectResult? actionResult = userController.Login("freelancer@test.com", "test") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;
            Assert.NotNull(responseObject);
            Assert.Equal(freelancer, responseObject);
        }

        [Fact]
        public void TestCreateClient()
        {
            CreateClientInput input = new("Cliente Teste", "client@test.com", "testclient", "33333333");
            OkObjectResult? actionResult = userController.RegisterClient(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;

            Assert.Equal(input.Name, responseObject?.Name);
            Assert.Equal(input.Email, responseObject?.Email);
            Assert.Equal(HashingUtil.getHash(input.Password), responseObject?.Password);
            Assert.Equal(input.Phone, responseObject?.Phone);
            Assert.False(responseObject?.IsFreelancer);
        }

        [Fact]
        public void TestCreateFreelancer()
        {
            CreateFreelancerInput input = new("Freelancer Teste", "freelancer@test.com", "freelancer", "44444444", new List<string>() { "java", "c#", "c++", "html" }, new List<double>() { 2.0, 4.0, 5.0, 1.0});
            OkObjectResult? actionResult = userController.RegisterFreelancer(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            User? responseObject = actionResult?.Value as User;

            Dictionary<Skill, Tuple<double, int>> expectedDict = new Dictionary<Skill, Tuple<double, int>>()
            {
                {new Skill("java", "java"), Tuple.Create(2.0, 1) },
                {new Skill("c#", "c#"), Tuple.Create(4.0, 1) },
                {new Skill("c++", "c++"), Tuple.Create(5.0, 1) },
                {new Skill("html", "html"), Tuple.Create(1.0, 1) }
            };

            Assert.Equal(input.Name, responseObject?.Name);
            Assert.Equal(input.Email, responseObject?.Email);
            Assert.Equal(HashingUtil.getHash(input.Password), responseObject?.Password);
            Assert.Equal(input.Phone, responseObject?.Phone);
            Assert.True(responseObject?.IsFreelancer);
            Assert.Equal(expectedDict, responseObject?.Skills);
        }
    }
}
