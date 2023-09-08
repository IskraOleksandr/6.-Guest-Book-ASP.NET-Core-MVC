using Microsoft.EntityFrameworkCore;
using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Все сессии работают поверх объекта IDistributedCache, и 
// ASP.NET Core предоставляет встроенную реализацию IDistributedCache
builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache
builder.Services.AddSession();  // Добавляем сервисы сессии

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<Guest_BookContext>(options => options.UseSqlServer(connection));

// Добавляем сервисы MVC
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseSession();   // Добавляем middleware-компонент для работы с сессиями
app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Message}/{action=Index}/{id?}");

app.Run();
