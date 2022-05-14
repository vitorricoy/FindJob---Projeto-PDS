using Backend.Domain.Entity;

namespace Backend.Domain.Service
{
    public interface IMessageService
    {
        public List<Message> GetHistory(string userId1, string userId2);

        public Message GetLastMessage(string userId1, string userId2);

        public Message CreateMessage(string text, DateTime sentTime, string senderId, string receiverId);
    }
}
