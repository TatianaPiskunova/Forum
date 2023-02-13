using System.ComponentModel.DataAnnotations;

namespace Экзамен.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не задано имя пользователя")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        //public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
