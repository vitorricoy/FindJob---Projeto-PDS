namespace Backend.API.Controllers.Models
{
    public class CreateMessageInput
    {
        public string Text { get; set; }
        public DateTime SentTime { get; set; } 
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public CreateMessageInput(string text, DateTime sentTime, string senderId, string receiverId)
        {
            Text = text;
            SentTime = sentTime;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}
