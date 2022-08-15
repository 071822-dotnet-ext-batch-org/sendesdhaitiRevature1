using System;
using BusinessLayer;

namespace ReImbursementApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages.Welcome("Welcome to the Revature ReImbursement System.");
            RunAppSession myAppSession = new RunAppSession();

            //Run a session
            myAppSession.NewAppSession();
            myAppSession.AddNewEmployee();
            



        }
    }
}
