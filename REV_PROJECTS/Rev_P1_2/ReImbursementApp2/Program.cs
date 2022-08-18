using System;

using BusinessLayer;

namespace ReImbursementApp2
{
    class Program
    {
        private RunAppSession myAppSession = new RunAppSession();
        /// <summary>
        /// This method either registers or logs in an employee
        /// </summary>
        private async Task<bool> EmployeeAuthentication(){
            bool startSystem = false;
            RestartSessionAsk:
            Messages.Welcome("Would you like to sign in or register an account?\n\t\t\t|1 to Login\n\t\t\t|2 to Signup\n\t\t\t|0 to End Session");
            int? as1 = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,1);
            if(as1 == 1){
                await Task.Delay(961);
                //They chose to Login
                var em = await this.myAppSession.LoginEmployee();
                if( em != null){
                    Messages.Regular1("You signed in successully");
                    startSystem = true;
                    return startSystem;
                }else{
                    Messages.Regular1("You did not sign in successully");
                    startSystem = false;
                    return startSystem;
                }
                
            }else if(as1 == 2){
                //They chose to Signup
                
                await this.myAppSession.AddNewEmployee();
                Messages.Regular1($"");
                //Add Employee to DB HERE
                startSystem = true;
                return startSystem;

            }else if(as1 == 0){
                //They chose to Leave
                Messages.Regular1($"You chose {as1}, so we'll see you next time!");
                //Messages.Welcome($"\n\t\t\tYou chose {as1}, so we'll see you next time!");
                startSystem = false;
                return startSystem;      
            }else{
                //That was the wrong response
                Messages.Welcome("Your response must be either 1, 2, or 0");
                Messages.Regular1($"Your response must be either 1, 2, or 0");
                goto RestartSessionAsk;
            }

        }
        static async Task Main(string[] args)
        {
            Program p = new Program();
            Messages.Welcome("Welcome to the Revature ReImbursement System.");

            RunAppSession myAppSession = new RunAppSession();
            //You can make an infinite loop between question and answer
            // myAppSession.example();
            // myAppSession.example2();

            //Run a session
            myAppSession.NewAppSession();
            bool _startSystem = await p.EmployeeAuthentication();

            // bool _startSystem = await p.EmployeeAuthentication();

            while(_startSystem == true){
                // myAppSession.EnterRISystem();
                //if manager
                if(myAppSession.GetifManager() == true){
                    Messages.Regular1($"Welcome to your manger portal{myAppSession.GetFname()}");

                }else{
                    Messages.Regular1($"Welcome to your employee portal{myAppSession.GetFname()}");
                    restartTickets:
                    Messages.Regular1($"What would you like to do {myAppSession.GetFname()}?\n\tYou can:\n"+
                        $"|1 for Create a ReImbursement Ticket\n"+
                        $"|2 for Review Past Ticket Requests");
                    int askIf = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,1);
                    if(askIf == 1){
                        //Create Ticket

                        Messages.Regular1($"Ticket was created");
                        myAppSession.CreateATicket();
                        //var ticket = myAppSession.GetTicket();
                        myAppSession.AddToTicketsList();

                        myAppSession.ViewListofTickets();

                        Console.Read();
                        goto restartTickets;

                    }else if(askIf == 2){
                        //View Past Tickets/List of Tickets statuses and details
                        Messages.Regular1($"You are now viewing your tickets by date");
                        myAppSession.ViewListofTickets();
                        Console.Read();
                        goto restartTickets;
                    }else if(askIf == 0){
                        //View Past Tickets/List of Tickets statuses and details
                        Messages.Regular1($"You chose {0}. Goodbye!");
                    }else{
                        //View Past Tickets/List of Tickets statuses and details
                        Messages.Regular1($"That was not one of the answers");
                        Console.Read();
                        goto restartTickets;
                    }
                    
                }
                //if employee
                Messages.Regular1($"You've now reached the end of the Portal");
                

                var _break = Console.Read();
                // break;
            }


            



        }
    }
}
