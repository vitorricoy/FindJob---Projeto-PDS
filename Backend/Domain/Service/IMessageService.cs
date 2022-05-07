using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IMessageService
    {
        public List<Message> GetHistory(int userId1, int userId2);

        public Message GetLastMessage(int userId1, int userId2);

        public Message CreateMessage(string text, DateTime sentTime, int senderId, int receiverId);
    }
}
