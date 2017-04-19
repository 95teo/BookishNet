using BookishNet.DataLayer.Models;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IRoleService : IGenericService<Role>
    {
        string GetRoleOfUser(User user);
    }
}