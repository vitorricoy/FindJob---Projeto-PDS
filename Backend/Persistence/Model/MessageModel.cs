using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entity
{
    public class MessageModel
    {
        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        [ForeignKey("SenderId")]
        public virtual UserModel Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual UserModel Receiver { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }

        public MessageModel(string id, string content, UserModel sender, UserModel receiver, DateTime sentTime, bool isRead)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receiver = receiver;
            SentTime = sentTime;
            IsRead = isRead;
        }

        public MessageModel()
        {

        }

        public static MessageModel FromDomainObject(Message message)
        {
            return new MessageModel(message.Id, message.Content, UserModel.FromDomainObject(message.Sender), UserModel.FromDomainObject(message.Receiver), 
                message.SentTime, message.IsRead);
        }
    }
}
