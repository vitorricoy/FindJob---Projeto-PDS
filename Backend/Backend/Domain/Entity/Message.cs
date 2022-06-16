namespace Backend.Domain.Entity
{
    public class Message
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }

        public Message(string id, string content, User sender, User receiver, DateTime sentTime, bool isRead)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receiver = receiver;
            SentTime = sentTime;
            IsRead = isRead;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Equals((Message)obj);
        }

        public bool Equals(Message obj)
        {
            return obj != null && obj.Id.Equals(Id) && obj.Content.Equals(Content) && obj.Sender.Equals(Sender) && obj.Receiver.Equals(Receiver) && obj.SentTime.Equals(SentTime) && obj.IsRead.Equals(IsRead);
        }
    }
}
