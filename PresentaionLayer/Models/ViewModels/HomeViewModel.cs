using PresentaionLayer.DTO_s;

namespace PresentaionLayer.Models.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Messages = new List<Message>();
        }
        public Message Message { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
