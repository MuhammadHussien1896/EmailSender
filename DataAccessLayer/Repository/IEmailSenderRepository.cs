using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IEmailSenderRepository
    {
        public void CreateNewMessage(Message message);
        public IEnumerable<Message> GetAllMessages();
        public Message GetMessageById(int messageId);
    }
}
