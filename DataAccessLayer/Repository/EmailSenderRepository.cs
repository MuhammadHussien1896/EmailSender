using DataAccessLayer.Context;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly AppDbContext context;

        public EmailSenderRepository(AppDbContext Context)
        {
            context = Context;
        }

        public  void CreateNewMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.ToList();
        }

        public Message GetMessageById(int messageId)
        {
            return context.Messages.Where(m => m.Id == messageId).FirstOrDefault();
        }
    }
}
