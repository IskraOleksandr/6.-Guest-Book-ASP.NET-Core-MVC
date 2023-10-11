using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear(); // очищается сессия
            return RedirectToPage("Login");
        }
    }
}
