using BookishNet.DataLayer.Models;

namespace BookishNet.RepositoryLayer.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Author GetByPenName(string penName);

        bool CheckUserCredentials(string username, string password);

        Author GetUserByUsername(string username);
    }
}