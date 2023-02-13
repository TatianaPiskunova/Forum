using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Экзамен.Models;

namespace Экзамен.Models
{
    public class TopicPost
    {
        //public int? IdForTopic { get; set; }
        public string? TitleTopic { get; set; }
        //public Topic Topic { get; set; }
        public List<Post>? Posts { get; set; }

        public int Id { get; set; }
        //public int TopicId { get; set; }
        //public Topic Topic { get; set; }
        //public int PostId { get; set; }
        //public Post Post { get; set; }
    }
    //public List<Post>? Posts { get; set; }
    //}
}


