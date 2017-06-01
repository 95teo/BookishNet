using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByPenName(string penName);

        bool CheckUserCredentials(string username, string password);

        User GetUserByUsername(string username);
    }
}