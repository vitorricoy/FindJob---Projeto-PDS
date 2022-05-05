namespace Backend.Domain.Entity
{
    public class Message
    {
        public int id { get; set; }
        public string content { get; set; }
        public User sender { get; set; }
        public User receiver { get; set; }
        public DateTime sentTime { get; set; }
        public bool isRead { get; set; }

    }
}
