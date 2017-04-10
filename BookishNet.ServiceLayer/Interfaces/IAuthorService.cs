using BookishNet.DataLayer.Models;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IAuthorService : IGenericService<Author>
    {
        Author GetByPenName(string penName);

        bool CheckUserCredentials(string username, string password);

        Author GetUserByUsername(string username);
    }
}