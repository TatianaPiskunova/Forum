using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml.Linq;

namespace Экзамен.Models
{
    public class Post
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
        [Display(Name = "Пост:")]
        public string? TextPost { get; set; }
        [Display(Name = "Дата создания:")]
        public DateTime DateTime { get; set; }      
        public int TopicId { get; set; }   
        public string? UserName { get; set; }

    }
}


