using BookishNet.DataLayer.Models;

namespace BookishNet.RepositoryLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool CheckUserCredentials(string username, string password);

        User GetUserByUsername(string username);
    }
}