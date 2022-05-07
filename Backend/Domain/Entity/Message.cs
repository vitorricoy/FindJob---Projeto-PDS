namespace Backend.Domain.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public DateTime SentTime { get; set; }
        public bool IsRead { get; set; }

        public Message(int id, string content, User sender, User receiver, DateTime sentTime, bool isRead)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receiver = receiver;
            SentTime = sentTime;
            IsRead = isRead;
        }

        public Message(string content, User sender, User receiver, DateTime sentTime, bool isRead)
        {
            Content = content;
            Sender = sender;
            Receiver = receiver;
            SentTime = sentTime;
            IsRead = isRead;
        }

    }
}
