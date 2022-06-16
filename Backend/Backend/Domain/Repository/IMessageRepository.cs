using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IMessageRepository
    {
        public List<Message> GetHistory(string userId1, string userId2);

        public List<string> GetUsersThatHaveChats(string userId);

        public Message GetLastMessage(string userId1, string userId2);

        public Message CreateMessage(Message message);
    }
}
