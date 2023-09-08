using Microsoft.EntityFrameworkCore;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    public class Guest_BookContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public Guest_BookContext(DbContextOptions<Guest_BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}