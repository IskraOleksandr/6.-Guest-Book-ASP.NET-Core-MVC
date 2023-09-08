using System.ComponentModel.DataAnnotations;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    // класс модели-представления (view-model)
    public class RegisterModel
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}