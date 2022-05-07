using Backend.Domain.Entity;

namespace Backend.Domain.Repository
{
    public interface IMessageRepository
    {
        public List<Message> GetHistory(int userId1, int userId2);

        public Message GetLastMessage(int userId1, int userId2);

        public Message CreateMessage(Message message);
    }
}
