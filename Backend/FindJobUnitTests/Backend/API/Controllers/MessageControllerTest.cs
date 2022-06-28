using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FindJobUnitTests.Backend.API.Controllers
{
    public class MessageControllerTest
    {
        public MessageControllerTest()
        {

        }

        [Fact]
        public void TestGetHistorySuccess()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);
            Message message2 = new(Guid.NewGuid().ToString(), "message 2", freelancer, client, DateTime.Now.AddMinutes(-4), false);
            Message message3 = new(Guid.NewGuid().ToString(), "message 3", client, freelancer, DateTime.Now.AddMinutes(-3), false);

            messageServiceMock.GetHistory(Arg.Any<string>(), Arg.Any<string>()).Returns(args => new List<Message>() { message1, message2, message3 });
            MessageController controller = new(messageServiceMock);
            OkObjectResult? actionResult = controller.GetHistory(client.Id, freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Message>? responseObject = actionResult?.Value as List<Message>;
            Assert.Equal(new List<Message>() { message1, message2, message3 }, responseObject);
        }

        [Fact]
        public void TestGetHistoryError()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();
            messageServiceMock.GetHistory(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            MessageController controller = new(messageServiceMock);
            ObjectResult? actionResult = controller.GetHistory("1", "2") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestGetUsersThatHaveChatsSuccess()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();

            User client1 = new(Guid.NewGuid().ToString(), "client1", "client1@test.com", "test1", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User client2 = new(Guid.NewGuid().ToString(), "client2", "client2@test.com", "test2", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User client3 = new(Guid.NewGuid().ToString(), "client3", "client3@test.com", "test3", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());

            messageServiceMock.GetUsersThatHaveChats(Arg.Any<string>()).Returns(args => new List<User>() { client1, client2, client3 });
            MessageController controller = new(messageServiceMock);
            OkObjectResult? actionResult = controller.GetUsersThatHaveChats("1") as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<User>? responseObject = actionResult?.Value as List<User>;
            Assert.Equal(new List<User>() { client1, client2, client3 }, responseObject);
        }

        [Fact]
        public void TestGetUsersThatHaveChatsError()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();
            messageServiceMock.GetUsersThatHaveChats(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            MessageController controller = new(messageServiceMock);
            ObjectResult? actionResult = controller.GetUsersThatHaveChats("1") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestGetLastMessageSuccess()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);

            messageServiceMock.GetLastMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(args => message1);
            MessageController controller = new(messageServiceMock);
            OkObjectResult? actionResult = controller.GetLastMessage(client.Id, freelancer.Id) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Message? responseObject = actionResult?.Value as Message;
            Assert.Equal(message1, responseObject);
        }

        [Fact]
        public void TestGetLastMessageError()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();
            messageServiceMock.GetLastMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            MessageController controller = new(messageServiceMock);
            ObjectResult? actionResult = controller.GetLastMessage("1", "2") as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestCreateMessageSuccess()
        {
            IMessageService messageServiceMock = Substitute.For<IMessageService>();

            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);

            messageServiceMock.CreateMessage(Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<string>(), Arg.Any<string>()).Returns(args => message1);
            MessageController controller = new(messageServiceMock);
            CreateMessageInput input = new(message1.Content, message1.SentTime, message1.Sender.Id, message1.Receiver.Id);
            OkObjectResult? actionResult = controller.CreateMessage(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Message? responseObject = actionResult?.Value as Message;
            Assert.Equal(message1, responseObject);
        }

        [Fact]
        public void TestCreateMessageError()
        {
            User client = new(Guid.NewGuid().ToString(), "client", "client@test.com", "test", "333333333", false, new Dictionary<Skill, Tuple<double, int>>());
            User freelancer = new(Guid.NewGuid().ToString(), "freelancer", "freelancer@test.com", "test", "333344443", true, new Dictionary<Skill, Tuple<double, int>>());
            Message message1 = new(Guid.NewGuid().ToString(), "message 1", client, freelancer, DateTime.Now.AddMinutes(-5), false);

            IMessageService messageServiceMock = Substitute.For<IMessageService>();
            messageServiceMock.CreateMessage(Arg.Any<string>(), Arg.Any<DateTime>(), Arg.Any<string>(), Arg.Any<string>()).Returns(args => { throw new Exception(); });
            CreateMessageInput input = new(message1.Content, message1.SentTime, message1.Sender.Id, message1.Receiver.Id);
            MessageController controller = new(messageServiceMock);
            ObjectResult? actionResult = controller.CreateMessage(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

    }
}
