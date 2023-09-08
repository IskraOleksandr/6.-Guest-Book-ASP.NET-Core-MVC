using System.ComponentModel.DataAnnotations;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    // класс модели-представления (view-model)
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин:")]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль:")]
        public string? Password { get; set; }
    }
}
