namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models
{
    public class Message
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
