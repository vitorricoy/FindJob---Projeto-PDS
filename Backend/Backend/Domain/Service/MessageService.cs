﻿using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        public Message CreateMessage(string text, DateTime sentTime, string senderId, string receiverId)
        {
            User sender = userRepository.GetUserById(senderId);
            User receiver = userRepository.GetUserById(receiverId);

            if (sender == null || receiver == null)
            {
                throw new InvalidUserIdException();
            }

            Message newMessage = new Message(Guid.NewGuid().ToString(),text, sender, receiver, sentTime, false);

            return messageRepository.CreateMessage(newMessage);
        }

        public List<Message> GetHistory(string userId1, string userId2)
        {
            return messageRepository.GetHistory(userId1, userId2);
        }

        public Message GetLastMessage(string userId1, string userId2)
        {
            return messageRepository.GetLastMessage(userId1, userId2);
        }

        public List<User> GetUsersThatHaveChats(string userId)
        {
            List<string> userIds = messageRepository.GetUsersThatHaveChats(userId);
            return userIds.Select(u => userRepository.GetUserById(u)).ToList();
        }
    }
}
