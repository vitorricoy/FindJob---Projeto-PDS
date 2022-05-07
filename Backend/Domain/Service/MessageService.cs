using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserService userService;

        public MessageService(IMessageRepository messageRepository, IUserService userService)
        {
            this.messageRepository = messageRepository;
            this.userService = userService;
        }

        public Message CreateMessage(string text, DateTime sentTime, int senderId, int receiverId)
        {
            User sender = userService.GetUserById(senderId);
            User receiver = userService.GetUserById(receiverId);

            if (sender == null || receiver == null)
            {
                throw new InvalidUserIdException();
            }

            Message newMessage = new Message(text, sender, receiver, sentTime, false);

            return messageRepository.CreateMessage(newMessage);
        }

        public List<Message> GetHistory(int userId1, int userId2)
        {
            return messageRepository.GetHistory(userId1, userId2);
        }

        public Message GetLastMessage(int userId1, int userId2)
        {
            return messageRepository.GetLastMessage(userId1, userId2);
        }
    }
}
