using System.ComponentModel.DataAnnotations;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    // класс модели-представления (view-model)
    public class Register
    {
        [Required(ErrorMessage = "Поле логина является обязательным.")]
        [Display(Name = "Логин:")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Длина логина должна быть от 3 до 25 символов")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле пароля является обязательным.")]
        [Display(Name = "Пароль:")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть от 3 до 20 символов")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Поле подтверждения пароля является обязательным.")]
        [Display(Name = "Подтверждение пароль:")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждиния пароля не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}