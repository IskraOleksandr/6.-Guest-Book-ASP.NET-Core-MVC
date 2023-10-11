using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Plugins;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;
using System.Security.Cryptography;
using System.Text;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRepository _repository;
        [BindProperty]
        public Login logon { get; set; } = default!;
        public LoginModel(IRepository repository)
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
                var users = await _repository.GetUsers();
                if (users.Count == 0)
                {
                    ModelState.AddModelError("", "Не коректный логин или пароль!");
                    return Page();
                }
                var users_t = users.Where(a => a.Login == logon.Login_);
                if (users_t.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Не коректный логин или пароль!");
                    return Page();//logon
                }
                var user = users_t.First();
                string? salt = user.Salt;
                 
                byte[] password = Encoding.Unicode.GetBytes(salt + logon.Password);//переводим пароль в байт-массив  
                var md5 = MD5.Create();//создаем объект для получения средств шифрования   
                byte[] byteHash = md5.ComputeHash(password);//вычисляем хеш-представление в байтах  

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("", "Не коректный логин или пароль!");
                    return Page();//logon
                }
                HttpContext.Session.SetString("Login", user.Login);

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
