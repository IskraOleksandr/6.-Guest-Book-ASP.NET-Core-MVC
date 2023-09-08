using Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Models;

namespace Guest_Book_Внедрение_зависимостей_в_ASP.NET_Core_MVC.Repository
{
    public interface IRepository
    {
        Task<List<Message>> GetMessages();

        Task<User> GetUser(string login);

        Task AddMessage(Message message);

        Task Save();

        Task<List<User>> GetUsers();

        Task AddUser(User user);
    }
}
