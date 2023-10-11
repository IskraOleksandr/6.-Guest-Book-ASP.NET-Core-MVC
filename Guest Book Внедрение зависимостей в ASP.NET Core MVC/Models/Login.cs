using System.ComponentModel.DataAnnotations;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Поле логина является обязательным.")]
        [Display(Name = "Логин:")]
        public string? Login_ { get; set; }

        [Required(ErrorMessage = "Поле пароля является обязательным.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль:")]
        public string? Password { get; set; }
    }
}
