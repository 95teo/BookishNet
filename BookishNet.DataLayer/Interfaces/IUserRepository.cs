using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool CheckUserCredentials(string username, string password);

        User GetUserByUsername(string username);
    }
}