using Microsoft.EntityFrameworkCore;
using Guest_Book_���������_������������_�_ASP.NET_Core_MVC.Models;
using Guest_Book_���������_������������_�_ASP.NET_Core_MVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// ��� ������ �������� ������ ������� IDistributedCache, � 
// ASP.NET Core ������������� ���������� ���������� IDistributedCache
builder.Services.AddDistributedMemoryCache();// ��������� IDistributedMemoryCache
builder.Services.AddSession();  // ��������� ������� ������

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<Guest_BookContext>(options => options.UseSqlServer(connection));

// ��������� ������� MVC
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRepository, Guest_Book_Repository>();

var app = builder.Build();
app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������
app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

app.MapRazorPages();

app.Run();
