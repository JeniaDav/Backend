using System.ComponentModel.DataAnnotations;
namespace Backend.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}

