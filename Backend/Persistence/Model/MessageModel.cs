using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class MessageModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public UserModel Sender { get; set; }
        public UserModel Receiver { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }

        private MessageModel(int id, string content, UserModel sender, UserModel receiver, DateTime sentTime, bool isRead)
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

        public static MessageModel FromDomainObject(Message message)
        {
            return new MessageModel(message.Id, message.Content, UserModel.FromDomainObject(message.Sender), UserModel.FromDomainObject(message.Receiver), 
                message.SentTime, message.IsRead);
        }
    }
}
