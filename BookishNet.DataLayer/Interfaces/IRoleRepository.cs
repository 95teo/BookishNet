using BookishNet.DataLayer.Models;

namespace BookishNet.DataLayer.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        string GetRoleOfUser(User user);
    }
}