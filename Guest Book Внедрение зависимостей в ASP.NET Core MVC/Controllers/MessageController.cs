using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Controllers
{
    public class MessageController : Controller
    {
        IRepository _repository; 

        public MessageController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetString("Login") != null)
            {
                var model = await _repository.GetMessages(); 
                return View(model);
            }
            else
                return RedirectToAction("Login", "User");
        }

        public async Task<ActionResult> Guest()
        {
            var model = await _repository.GetMessages(); 
            return View("Index", model);
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

            var user = await _repository.GetUser(user_login);

            var mes = new Message
            {
                User = user,
                MessageText = mes_text,
                MessageDate = DateTime.Now
            };

            await _repository.AddMessage(mes);
            await _repository.Save(); 

            return RedirectToAction("Index", "Message");
        }
    }
}