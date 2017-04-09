using System;
using System.Collections.Generic;
using System.Text;
using BookishNet.DataLayer.Models;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IRoleService : IGenericService<Role>
    {
        string GetRoleOfUser(Author user);

        string GetRoleOfUser(User user);
    }
}
