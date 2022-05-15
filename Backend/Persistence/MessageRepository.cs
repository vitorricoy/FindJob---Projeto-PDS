using Backend.Domain.Entity;
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
            MessageModel messageEntity = MessageModel.FromDomainObject(message);

            Message returnValue = ToDomainObject(dbContext.Add(messageEntity).Entity);
            dbContext.SaveChanges();
            return returnValue;
        }

        public List<Message> GetHistory(string userId1, string userId2)
        {
            return dbContext.Messages
                .Where(m => m.Sender.Id.Equals(userId1) && m.Receiver.Id.Equals(userId2) || m.Sender.Id.Equals(userId2) && m.Receiver.Id.Equals(userId1))
                .OrderByDescending(m => m.SentTime)
                .ToList()
                .Select(m => ToDomainObject(m))
                .ToList();
        }

        public Message GetLastMessage(string userId1, string userId2)
        {
            MessageModel messMod = dbContext.Messages
                .Where(m => m.Sender.Id.Equals(userId1) && m.Receiver.Id.Equals(userId2) || m.Sender.Id.Equals(userId2) && m.Receiver.Id.Equals(userId1))
                .OrderByDescending(m => m.SentTime)
                .First();
            return ToDomainObject(messMod);
        }

        
    }
}
