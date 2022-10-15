using Microsoft.AspNetCore.Mvc;
using PresentaionLayer.DTO_s;
using PresentaionLayer.Models;
using PresentaionLayer.Models.ViewModels;
using PresentaionLayer.Repository;
using System.Diagnostics;

namespace PresentaionLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSenderRepository context;

        public HomeController(IEmailSenderRepository context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await context.GetMessages();
            HomeViewModel model = new()
            {
                Messages = messages
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Message message)
        {
            if (ModelState.IsValid)
            {
                await context.SaveMessage(message.Subject, message.MessageContent);
                return RedirectToAction("Index");
            }
            var messages = await context.GetMessages();
            return View(new HomeViewModel() { Message = message,Messages = messages});
        }
        public async Task<IActionResult> Details(int Id)
        {
            var message = await context.GetMessage(Id);
            if(message != null)
            {
                DetailsViewModel model = new() 
                { 
                    Message = message
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Details(int Id,List<string> emails)
        {
            context.SendMail(Id, emails);
            return Json("done");
        }
    }
}