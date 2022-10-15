using API.Utilities;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEmailSenderRepository dbcontext;
        //injecting repository to use the methodes that connects with database
        public HomeController(IEmailSenderRepository dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        //get all messages from db
        [HttpGet("GetMessages")]
        public IActionResult GetAllMessages()
        {
            IList<Message> messages = dbcontext.GetAllMessages().ToList();
            return Ok(messages);
        }
        //create a new message
        [HttpPost("SaveMessage")]
        public IActionResult SaveMessage(Message message)
        {
            try
            {
                dbcontext.CreateNewMessage(message);
                return Ok(message);
            }
            //if an error occured return a bad request
            catch (Exception)
            {
                return BadRequest("An error has occured !");
            }
            
        }
        //get message by id
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int Id)
        {
            var message = dbcontext.GetMessageById(Id);
            if (message != null)
            {
                return Ok(message);
            }
            return NotFound("No message found with this ID !");
        }
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(int Id, List<string> emails)
        {
            var message = dbcontext.GetMessageById(Id);
            MailSender.SendMail(message, emails);
            return Ok();
        }
    }
}
