using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Экзамен.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [Display(Name = "Тема:")]
        public string? TitleTopic { get; set; }
        public List<Post>? Posts { get; set; }
        public string? UserName { get; set; }

    }
}
