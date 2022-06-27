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
        List<Message> mockRepo;
        
        IMessageRepository messageRepositoryMock;

        IUserRepository userRepositoryMock;

        IMessageService messageService;

        public MessageServiceTests()
        {
            userRepositoryMock = Substitute.For<IUserRepository>();

            userRepositoryMock.GetUserById(Arg.Is<string>(id => new[] { "id_teste1", "id_teste2", "id_teste3", "id_teste4" }.Contains(id))).
                Returns(args => new User((string)args[0], "teste", "teste", "teste", "teste", false, null));
            
            userRepositoryMock.GetUserById(Arg.Is<string>(id => !(new[] { "id_teste1", "id_teste2", "id_teste3", "id_teste4" }.Contains(id)))).
                Returns(args => null);


            mockRepo = new List<Message>();

            messageRepositoryMock = Substitute.For<IMessageRepository>();

            messageRepositoryMock.CreateMessage(Arg.Any<Message>()).
                Returns(args => { mockRepo.Add((Message)args[0]); return (Message)args[0]; });

            messageRepositoryMock.GetHistory(Arg.Any<string>(), Arg.Any<string>()).
                Returns(args =>
                {
                    return mockRepo
                    .Where(m => m.Sender.Id.Equals((string)args[0]) && m.Receiver.Id.Equals((string)args[1]) || m.Sender.Id.Equals((string)args[1]) && m.Receiver.Id.Equals((string)args[0]))
                    .OrderByDescending(m => m.SentTime)
                    .ToList();
                });

            messageRepositoryMock.GetLastMessage(Arg.Any<string>(), Arg.Any<string>()).
                Returns(args =>
                {
                    return mockRepo
                    .Where(m => m.Sender.Id.Equals((string)args[0]) && m.Receiver.Id.Equals((string)args[1]) || m.Sender.Id.Equals((string)args[1]) && m.Receiver.Id.Equals((string)args[0]))
                    .OrderByDescending(m => m.SentTime)
                    .FirstOrDefault();
                });

            messageRepositoryMock.GetUsersThatHaveChats(Arg.Any<string>()).
                Returns(args =>
                {
                    return mockRepo
                    .Where(m => m.Sender.Id.Equals((string)args[0]) || m.Receiver.Id.Equals((string)args[0]))
                    .ToList()
                    .Select(m => m.Sender.Id != (string)args[0] ? m.Sender.Id : m.Receiver.Id)
                    .Distinct()
                    .ToList();
                });

            messageService = new MessageService(messageRepositoryMock, userRepositoryMock);
        }

        [Fact]
        public void TestCreateMessageWithValidUsers()
        {
            var response = messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "id_teste2");

            Assert.Equal("teste", response.Content);
            Assert.Equal(new DateTime(0), response.SentTime);
            Assert.False(response.IsRead);
            Assert.Equal("id_teste1", response.Sender.Id);
            Assert.Equal("id_teste2", response.Receiver.Id);
            mockRepo.Clear();
        }

        [Fact]
        public void TestCreateMessageWithInvalidSender()
        {
            Assert.Throws<InvalidUserIdException>(() => messageService.CreateMessage("teste", new DateTime(0), "xxxx", "id_teste1"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestCreateMessageWithInvalidReceiver()
        {
            Assert.Throws<InvalidUserIdException>(() => messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "xxxx"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetHistoryIfUsersDidntChat()
        {
            Assert.Equal(new List<Message>(), messageService.GetHistory("id_teste1", "id_teste2"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetHistoryReturnsInTimeOrder()
        {
            var first = messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "id_teste2");

            var last = messageService.CreateMessage("teste", new DateTime(2), "id_teste1", "id_teste2");

            var second = messageService.CreateMessage("teste", new DateTime(1), "id_teste2", "id_teste1");

            var response = messageService.GetHistory("id_teste1", "id_teste2");

            Assert.Equal(new[] { last, second, first }, response);
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetLastMessageWithNoMessage()
        {
            Assert.Null(messageService.GetLastMessage("id_teste1", "id_teste2"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetLastMessageWithOneMessage()
        {
            var last_message = messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "id_teste2");

            var response = messageService.GetLastMessage("id_teste1", "id_teste2");

            Assert.Equal(last_message, response);
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetLastMessageWithManyMessages()
        {
            messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "id_teste2");

            var last_message = messageService.CreateMessage("teste", new DateTime(2), "id_teste1", "id_teste2");

            messageService.CreateMessage("teste", new DateTime(1), "id_teste2", "id_teste1");

            var response = messageService.GetLastMessage("id_teste1", "id_teste2");

            Assert.Equal(last_message, response);
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetUsersThatHaveChatsWithNoChats()
        {
            Assert.Equal(new List<User>(), messageService.GetUsersThatHaveChats("id_teste1"));
            mockRepo.Clear();
        }

        [Fact]
        public void TestGetUsersThatHaveChatsWithUnrelatedChats()
        {
            messageService.CreateMessage("teste", new DateTime(0), "id_teste1", "id_teste2");
            messageService.CreateMessage("teste", new DateTime(0), "id_teste3", "id_teste1");
            messageService.CreateMessage("teste", new DateTime(0), "id_teste2", "id_teste4");
            messageService.CreateMessage("teste", new DateTime(0), "id_teste4", "id_teste3");

            var response = messageService.GetUsersThatHaveChats("id_teste1");

            Assert.Contains(response, user => "id_teste2" == user.Id);
            Assert.Contains(response, user => "id_teste3" == user.Id);
            Assert.DoesNotContain(response, user => "id_teste4" == user.Id);
            
            mockRepo.Clear();
        }
    }
}
