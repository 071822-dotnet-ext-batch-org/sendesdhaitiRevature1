using System;

namespace Rev_P1
{
    class RevatureReImbursementSystem
    {
        static void Main(string[] args)
        {
            User currentUser = new User();
            UserAuth userAuth = new UserAuth();
            Console.WriteLine("\n\n\tWelcome to the Revature Employee Reimbursement System!\n\n");
            userAuth.RegisterUser();

        }
    }
}
