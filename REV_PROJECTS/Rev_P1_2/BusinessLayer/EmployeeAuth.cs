using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public class EmployeeAuth : Employee
    {
/// <summary>
/// This method registers and employee
/// </summary>
/// <returns></returns>
        public  static Employee RegisterNewEmployee(){
            // Messages.WhatIsYour_ConsoleMessage("username");
            string username = "username";
            string password = "password";
            string fname = "first name";
            string lname = "last name";

            username = VerifyAnswers.Verify_Short_StringOnly_Answer(username, 5, 30);
            password = VerifyAnswers.Verify_String_Answer_for_PASSWORD(8,50);
            fname = VerifyAnswers.Verify_Short_StringOnly_Answer(fname, 3,30);
            lname = VerifyAnswers.Verify_Short_StringOnly_Answer(lname, 3,30);
            Employee employee = new Employee(fname, lname, username, password);
            return employee;
        }


        public static Employee LoginNewEmployee(){
            // Messages.WhatIsYour_ConsoleMessage("username");
            string username = "username";
            string password = "password";

            username = VerifyAnswers.Verify_Short_StringOnly_Answer(username, 2, 30);
            password = VerifyAnswers.Verify_String_Answer_for_PASSWORD(2,50);
            Employee employee = new Employee(username, password);
            Messages.Regular($"\tThe Employee with username {employee.Username} and password {employee.Password} will now be validated.");
            return employee;
        }
        
    }
}