using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev_P1
{
    public interface IEmployee
    {
        //void RegisterUser(string username, string password,  string fName, string lName, int DOBMonth, int DOBDay, int DOBYear);
        void RegisterEmployee();
        void LoginEmployee();
        void SetFName();
        void SetLName();
        string GetFName();
        string GetLName();
        //void GetUserName();
        //void LoginUser(string username, string password);
        
    }
}