using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;
using NuGet.Protocol.Core.Types;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Pages
{
    public class IndexModel : PageModel
    { 
        public IList<Message> Message_ { get; set; } = default!;
         
        public async Task OnGetAsync([FromServices] IRepository repository)
        {
            Message_ = await repository.GetMessages();
        } 
    }
}
