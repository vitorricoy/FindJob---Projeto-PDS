using Backend.Domain.Repository;

namespace Backend.Domain.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository jobRepository;
        public MessageService(IMessageRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }
    }
}
