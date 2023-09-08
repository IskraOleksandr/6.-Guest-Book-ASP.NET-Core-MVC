using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Controllers
{
    public class MessageController : Controller
    {
        private readonly Guest_BookContext _context;

        public MessageController(Guest_BookContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Login") != null )
            {
                IEnumerable<Message> messages = await Task.Run(() => _context.Messages.Include(u => u.User));
                ViewBag.Message = messages;
                return View();
            }
            else 
                return RedirectToAction("Login", "User");
        }

        public async Task<ActionResult> Guest()
        {
            IEnumerable<Message> messages = await Task.Run(() => _context.Messages.Include(u => u.User));
            ViewBag.Message = messages;
            return View("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addMessage(string mes_text)
        {
            var user_login = HttpContext.Session.GetString("Login");

            if (HttpContext.Session.GetString("Login") == null)
                return RedirectToAction("Login", "User");

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Login == user_login);

            var mes = new Message
            {
                User = user,
                MessageText = mes_text,
                MessageDate = DateTime.Now
            };

            _context.Messages.Add(mes);
            _context.SaveChanges();

            return RedirectToAction("Index", "Message");
        }
    }
}