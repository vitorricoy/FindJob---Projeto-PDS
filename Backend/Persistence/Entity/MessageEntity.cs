using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class MessageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public UserEntity Sender { get; set; }
        public UserEntity Receiver { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }

        private MessageEntity(int id, string content, UserEntity sender, UserEntity receiver, DateTime sentTime, bool isRead)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receiver = receiver;
            SentTime = sentTime;
            IsRead = isRead;
        }

        public Message ToDomainObject()
        {
            return new Message(Id, Content, Sender.ToDomainObject(), Receiver.ToDomainObject(), SentTime, IsRead);
        }

        public static MessageEntity FromDomainObject(Message message)
        {
            return new MessageEntity(message.Id, message.Content, UserEntity.FromDomainObject(message.Sender), UserEntity.FromDomainObject(message.Receiver), 
                message.SentTime, message.IsRead);
        }
    }
}
