using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IRepository _repository;
        [BindProperty]
        public Register reg { get; set; } = default!;
        public RegisterModel(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Login = reg.Login;

                byte[] saltbuf = new byte[16];

                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(saltbuf);

                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();
                 
                byte[] password = Encoding.Unicode.GetBytes(salt + reg.Password);//переводим пароль в байт-массив   
                var md5 = MD5.Create();//создаем объект для получения средств шифрования   
                byte[] byteHash = md5.ComputeHash(password);//вычисляем хеш-представление в байтах

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                user.Password = hash.ToString();
                user.Salt = salt;

                await _repository.AddUser(user);
                await _repository.Save(); 

                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
