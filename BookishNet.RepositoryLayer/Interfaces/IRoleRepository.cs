using BookishNet.DataLayer.Models;

namespace BookishNet.RepositoryLayer.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        string GetRoleOfUser(Author user);

        string GetRoleOfUser(User user);
    }
}