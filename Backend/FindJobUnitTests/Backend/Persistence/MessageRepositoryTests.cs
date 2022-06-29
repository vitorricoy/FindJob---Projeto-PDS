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
    public class MessageRepositoryTests
    {
        ApplicationDbContext dbContextMock;

        IMessageRepository messageRepository;
        
        public MessageRepositoryTests()
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

            messageRepository = new MessageRepository(dbContextMock);
        }

        [Fact]
        public void TestCreateMessageWithNewMessage()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);
            var response = messageRepository.CreateMessage(new Message("id_teste", "teste", user1, user2, new DateTime(0), false));

        }

        [Fact]
        public void TestGetHistoryWithValidUserIds()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);

            var mes1 = messageRepository.CreateMessage(new Message("id_teste", "teste", user1, user2, new DateTime(0), false));
            var mes2 = messageRepository.CreateMessage(new Message("id_teste2", "teste", user2, user1, new DateTime(1), false));
            var mes3 = messageRepository.CreateMessage(new Message("id_teste3", "teste", user1, user2, new DateTime(2), false));

            var createdMess = dbContextMock.Messages.ToList();

            Assert.Contains(createdMess, mes => mes.Id =="id_teste");
            Assert.Contains(createdMess, mes => mes.Id == "id_teste2");
            Assert.Contains(createdMess, mes => mes.Id == "id_teste3");
        }

        [Fact]
        public void TestGetHistoryWithInValidUserIds()
        {
            Assert.Empty(messageRepository.GetHistory("xxx","xxxx"));
        }

        [Fact]
        public void TestGetLastMessageWithValidUserIds()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);

            messageRepository.CreateMessage(new Message("id_teste", "teste", user1, user2, new DateTime(0), false));
            messageRepository.CreateMessage(new Message("id_teste2", "teste", user2, user1, new DateTime(1), false));
            messageRepository.CreateMessage(new Message("id_teste3", "teste", user1, user2, new DateTime(2), false));

            var response = messageRepository.GetLastMessage("id_1", "id_2");

            Assert.NotNull(response);
            Assert.Equal("id_teste3",response.Id);
        }

        [Fact]
        public void TestGetLastMessageWithInValidUserIds()
        {
            Assert.Null(messageRepository.GetLastMessage("xxx", "xxxx"));
        }

        [Fact]
        public void TestGetUsersThatHaveChatsWithNoChats()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            Assert.Empty(messageRepository.GetUsersThatHaveChats("id_1"));
        }

        [Fact]
        public void TestGetUsersThatHaveChatsWithManyChats()
        {
            var user1 = new User("id_1", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user2 = new User("id_2", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());
            var user3 = new User("id_3", "teste", "teste", "teste", "teste", false, new Dictionary<Skill, Tuple<double, int>>());

            TestingHelper.CreateUserInDatabase(user1, dbContextMock);
            TestingHelper.CreateUserInDatabase(user2, dbContextMock);
            TestingHelper.CreateUserInDatabase(user3, dbContextMock);

            var mes1 = messageRepository.CreateMessage(new Message("id_teste", "teste", user1, user2, new DateTime(0), false));
            var mes2 = messageRepository.CreateMessage(new Message("id_teste2", "teste", user1, user3, new DateTime(1), false));

            var response = messageRepository.GetUsersThatHaveChats("id_1");

            Assert.Contains(response, id => id == "id_2");
            Assert.Contains(response, id => id == "id_3");
        }

    }
}
