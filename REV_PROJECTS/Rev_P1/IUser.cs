using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev_P1
{
    public interface IUser
    {
        void SetUserName(string username);
        void SetUserPassword(string password);
        string GetUserName();
        string GetUserPassword();
    }
}