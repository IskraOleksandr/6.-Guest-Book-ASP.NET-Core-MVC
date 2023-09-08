namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    public class User
    {
        public int Id { get; set; }

        ICollection<Message> Messages { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }
    }
}