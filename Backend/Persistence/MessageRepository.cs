﻿using Backend.Domain.Entity;
using Backend.Domain.Repository;

namespace Backend.Persistence
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public Message CreateMessage(Message message)
        {
            MessageEntity messageEntity = MessageEntity.FromDomainObject(message);
            return dbContext.Add(messageEntity).Entity.ToDomainObject();
        }

        public List<Message> GetHistory(int userId1, int userId2)
        {
            return dbContext.Messages
                .Where(m => m.Sender.Id.Equals(userId1) && m.Receiver.Id.Equals(userId2) || m.Sender.Id.Equals(userId2) && m.Receiver.Id.Equals(userId1))
                .OrderByDescending(m => m.SentTime)
                .ToList()
                .Select(m => m.ToDomainObject())
                .ToList();
        }

        public Message GetLastMessage(int userId1, int userId2)
        {
            return dbContext.Messages
                .Where(m => m.Sender.Id.Equals(userId1) && m.Receiver.Id.Equals(userId2) || m.Sender.Id.Equals(userId2) && m.Receiver.Id.Equals(userId1))
                .OrderByDescending(m => m.SentTime)
                .First()
                .ToDomainObject();
        }
    }
}
