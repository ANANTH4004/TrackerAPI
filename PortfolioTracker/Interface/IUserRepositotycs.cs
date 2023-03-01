using PortfolioTracker.Models;

namespace PortfolioTracker.Interface
{
    public interface IUserRepositotycs
    {
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);
    }
}
