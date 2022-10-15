using System.ComponentModel.DataAnnotations;

namespace PresentaionLayer.DTO_s
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string MessageContent { get; set; }
    }
}
