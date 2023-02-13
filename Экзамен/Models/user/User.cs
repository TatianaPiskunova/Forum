using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Экзамен.Models
{
 
    public class User : IdentityUser
    {
        public string Lastname { get; set; }
    }
}
