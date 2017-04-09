using System;
using System.Collections.Generic;
using System.Text;
using BookishNet.DataLayer.Models;

namespace BookishNet.ServiceLayer.Interfaces
{
    public interface IUserService :IGenericService<User>
    {
        bool CheckUserCredentials(string username, string password);

        User GetUserByUsername(string username);
    }
}
