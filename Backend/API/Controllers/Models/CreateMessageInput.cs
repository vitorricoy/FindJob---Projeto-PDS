namespace Backend.API.Controllers.Models
{
    public class CreateMessageInput
    {
        public string Text { get; set; }
        public DateTime SentTime { get; set; } 
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public CreateMessageInput(string text, DateTime sentTime, int senderId, int receiverId)
        {
            Text = text;
            SentTime = sentTime;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}
