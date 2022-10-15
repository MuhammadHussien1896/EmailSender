using PresentaionLayer.DTO_s;

namespace PresentaionLayer.Models.ViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            Emails = new List<string>();
        }
        public Message Message { get; set; }
        public List<string> Emails { get; set; }
    }
}
