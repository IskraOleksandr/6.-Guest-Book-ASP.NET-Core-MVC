using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Pages
{
    public class AddMessageModel : PageModel
    {
        private readonly IRepository repo;

        public AddMessageModel(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public string mes_text { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user_login = HttpContext.Session.GetString("Login");

                if (HttpContext.Session.GetString("Login") == null)
                    return RedirectToPage("Login");

                var user = await repo.GetUser(user_login);

                var mes = new Message
                {
                    User = user,
                    MessageText = mes_text,
                    MessageDate = DateTime.Now
                };
                await repo.AddMessage(mes);
                await repo.Save();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
