using PresentaionLayer.DTO_s;

namespace PresentaionLayer.Repository
{
    public interface IEmailSenderRepository
    {
        public Task<Message> GetMessage(int Id);
        public Task<IEnumerable<Message>> GetMessages();
        public Task<Message> SaveMessage(string subject, string content);
        public Task SendMail(int id, List<string> emails);
    }
}
