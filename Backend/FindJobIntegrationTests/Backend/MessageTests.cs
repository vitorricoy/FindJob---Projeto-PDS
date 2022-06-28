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
using Xunit;

namespace Backend.Tests 
{
    public class MessageTests
    {
        readonly MessageController messageController;
        readonly ApplicationDbContext context;

        public MessageTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("MessageTests")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            MessageRepository messageRepository = new(context);
            UserRepository userRepository = new(context);

            MessageService messageService = new(messageRepository, userRepository);

            messageController = new MessageController(messageService);
        }

        [Fact]
        public void TestCreateMessage()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(freelancer, context);

            CreateMessageInput input = new("mensagem teste", DateTime.Now, client.Id, freelancer.Id);
            OkObjectResult? actionResult = messageController.CreateMessage(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Message? responseObject = actionResult?.Value as Message;
            Assert.NotNull(responseObject);

            Assert.Equal(input.Text, responseObject?.Content);
            Assert.Equal(input.SentTime, responseObject?.SentTime);
            Assert.Equal(client, responseObject?.Sender);
            Assert.Equal(freelancer, responseObject?.Receiver);
        }

        [Fact]
        public void TestGetMessageHistory()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            User otherClient = new(Guid.NewGuid().ToString(), "otherClient", "otherClient@test.com", "test", "444444444", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(otherClient, context);

            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(freelancer, context);


            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);
            Message message2 = new(Guid.NewGuid().ToString(), "message 2", freelancer, client, DateTime.Now.AddMinutes(-4), false);
            Message message3 = new(Guid.NewGuid().ToString(), "message 3", client, freelancer, DateTime.Now.AddMinutes(-3), false);
            Message message4 = new(Guid.NewGuid().ToString(), "message 4", client, freelancer, DateTime.Now.AddMinutes(-2), false);
            Message message5 = new(Guid.NewGuid().ToString(), "message 5", freelancer, client, DateTime.Now, false);
            Message message6 = new(Guid.NewGuid().ToString(), "message 6", otherClient, freelancer, DateTime.Now, false);

            TestingHelper.CreateMessageInDatabase(message1, context);
            TestingHelper.CreateMessageInDatabase(message2, context);
            TestingHelper.CreateMessageInDatabase(message3, context);
            TestingHelper.CreateMessageInDatabase(message4, context);
            TestingHelper.CreateMessageInDatabase(message5, context);
            TestingHelper.CreateMessageInDatabase(message6, context);

            OkObjectResult? actionResult = messageController.GetHistory(client.Id, freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Message>? responseObject = actionResult?.Value as List<Message>;
            Assert.NotNull(responseObject);
            Assert.Equal(5, responseObject?.Count);
            Assert.Equal(message5, responseObject?[0]);
            Assert.Equal(message4, responseObject?[1]);
            Assert.Equal(message3, responseObject?[2]);
            Assert.Equal(message2, responseObject?[3]);
            Assert.Equal(message1, responseObject?[4]);
        }

        [Fact]
        public void TestGetUsersThatHaveChats()
        {
            User client1 = new(Guid.NewGuid().ToString(), "client1", "client1@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client1, context);

            User client2 = new(Guid.NewGuid().ToString(), "client2", "client2@test.com", "test", "444444444", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client2, context);

            User client3 = new(Guid.NewGuid().ToString(), "client3", "client3@test.com", "test", "444444444", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client3, context);

            User client4 = new(Guid.NewGuid().ToString(), "client4", "client4@test.com", "test", "444444444", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client4, context);

            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(freelancer, context);


            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client1, freelancer, DateTime.Now.AddMinutes(-5), false);
            Message message2 = new(Guid.NewGuid().ToString(), "message 2", freelancer, client1, DateTime.Now.AddMinutes(-4), false);
            Message message3 = new(Guid.NewGuid().ToString(), "message 3", client2, freelancer, DateTime.Now.AddMinutes(-3), false);
            Message message4 = new(Guid.NewGuid().ToString(), "message 4", client3, freelancer, DateTime.Now.AddMinutes(-2), false);
            Message message5 = new(Guid.NewGuid().ToString(), "message 5", client1, client4, DateTime.Now.AddMinutes(-1), false);


            TestingHelper.CreateMessageInDatabase(message1, context);
            TestingHelper.CreateMessageInDatabase(message2, context);
            TestingHelper.CreateMessageInDatabase(message3, context);
            TestingHelper.CreateMessageInDatabase(message4, context);
            TestingHelper.CreateMessageInDatabase(message5, context);

            OkObjectResult? actionResult = messageController.GetUsersThatHaveChats(freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<User>? responseObject = actionResult?.Value as List<User>;
            Assert.NotNull(responseObject);
            Assert.Equal(3, responseObject?.Count);
            Assert.Equal(client1, responseObject?[0]);
            Assert.Equal(client2, responseObject?[1]);
            Assert.Equal(client3, responseObject?[2]);
        }

        [Fact]
        public void TestGetLastMessage()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(client, context);

            User otherClient = new(Guid.NewGuid().ToString(), "otherClient", "otherClient@test.com", "test", "444444444", false, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(otherClient, context);

            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            TestingHelper.CreateUserInDatabase(freelancer, context);


            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);
            Message message2 = new(Guid.NewGuid().ToString(), "message 2", freelancer, client, DateTime.Now.AddMinutes(-4), false);
            Message message3 = new(Guid.NewGuid().ToString(), "message 3", client, freelancer, DateTime.Now.AddMinutes(-3), false);
            Message message4 = new(Guid.NewGuid().ToString(), "message 4", client, freelancer, DateTime.Now.AddMinutes(-2), false);
            Message message5 = new(Guid.NewGuid().ToString(), "message 5", freelancer, client, DateTime.Now, false);
            Message message6 = new(Guid.NewGuid().ToString(), "message 6", otherClient, freelancer, DateTime.Now, false);

            TestingHelper.CreateMessageInDatabase(message1, context);
            TestingHelper.CreateMessageInDatabase(message2, context);
            TestingHelper.CreateMessageInDatabase(message3, context);
            TestingHelper.CreateMessageInDatabase(message4, context);
            TestingHelper.CreateMessageInDatabase(message5, context);
            TestingHelper.CreateMessageInDatabase(message6, context);

            OkObjectResult? actionResult = messageController.GetLastMessage(client.Id, freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Message? responseObject = actionResult?.Value as Message;
            Assert.NotNull(responseObject);
            Assert.Equal(message5, responseObject);
        }
    }
}