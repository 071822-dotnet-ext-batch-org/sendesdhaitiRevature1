using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;
using RepoLayer;


namespace BusinessLayer
{
    public class RunAppSession
    {
        private Guid currentSessionID {get;set;}= Guid.NewGuid();
        private AppSession _newAppSession = new AppSession();
        private Ticket _ticket = new Ticket();
        private readonly AdoDotnetAccessPoint _accessPoint = new AdoDotnetAccessPoint();
        
/// <summary>
/// This method starts/creates a new AppSession
/// </summary>
        public void NewAppSession(){
            this._newAppSession = new AppSession();
        }

        public async Task<Employee?> AddNewEmployee(){
            RestartRegistration:
            Messages.Regular1("Let's get you signed up!");
            await Task.Delay(961);
            this._newAppSession.Employee = EmployeeAuth.RegisterNewEmployee();



            Guid userID = this._newAppSession.Employee.EmployeeID; 
            string userN = this._newAppSession.Employee.Username; 
            string userP = this._newAppSession.Employee.Password;
            string userF = this._newAppSession.Employee.Fname;
            string userL = this._newAppSession.Employee.Lname;
            bool userM = this._newAppSession.Employee.Manager;
            DateTime userSignup = this._newAppSession.Employee.SIGNUPDATE;
            DateTime userLastMod = this._newAppSession.Employee.LASTSIGNEDIN;

            //We nee to check if the credentials entered are not present already before they enter the portal
            var check = await _accessPoint.Check_If_Employee_Exists_Async(userN);
            //Messages.Regular1(check.ToString());
            if(check == true){
                //check found your data
                ReAskResponse:
                Messages.Regular1("Sign Up Again? or Login?");
                Messages.Regular1("|1 for Sign Up\n\t|2 for Login");
                int? response = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,1);
                if(response == 1){
                    Messages.Regular1("Restarting.....");
                    await Task.Delay(2000);
                    goto RestartRegistration;
                }else if(response == 2){
                    var logEm = await LoginEmployee();
                    await Task.Delay(2000);
                    return logEm;
                }else{
                    Messages.Regular1("Incorrect response");
                    await Task.Delay(2000);
                    goto ReAskResponse;
                }
                
            }else{
                //check did not find your data
                Employee em = new Employee(){
                    EmployeeID = userID,
                    Username = userN,
                    Fname =userF,
                    Lname = userL,
                    Manager = userM,
                    SIGNUPDATE = userSignup,
                    LASTSIGNEDIN = userLastMod,
                    Password = userP
                        
                };
                Messages.Regular1(em.EmployeeID.ToString());
                Messages.Regular1(em.Username);
                Messages.Regular1(em.Fname);
                Messages.Regular1(em.Lname);
                Messages.Regular1(em.Password);
                Messages.Regular1(em.Manager.ToString());
                Messages.Regular1(em.SIGNUPDATE.ToString());
                Messages.Regular1(em.LASTSIGNEDIN.ToString());
                //Messages.Regular1("check did not find your data");
                //var AddTODB = await _accessPoint.REGISTER_Employee_Async();
                Messages.Regular1($"Your new account is {em.Username} with id: {em.EmployeeID}");

                await Task.Delay(2000);
                return em;
                // goto RestartRegistration;
            }


            string welcome = $"Welcome to your ReImbursement Portal {userN}";
            Messages.Regular1(welcome);
        }

        public async Task<Employee> LoginEmployee(){
            this._newAppSession.Employee = new Employee();
            
            Messages.Regular1("\tLet's Sign In.");

            RestartLogin:
            this._newAppSession.Employee = EmployeeAuth.LoginNewEmployee();
            Guid userID = this._newAppSession.Employee.EmployeeID; 
            string userN = this._newAppSession.Employee.Username; 
            string userP = this._newAppSession.Employee.Password;
            string userF = this._newAppSession.Employee.Fname;
            string userL = this._newAppSession.Employee.Lname;
            bool userM = this._newAppSession.Employee.Manager;
            // Messages.Regular1($"{userID}");
            // Messages.Regular1($"{userN}");
            // Messages.Regular1($"{userP}");
            // Messages.Regular1($"{userF}");
            // Messages.Regular1($"{userL}");
            
            bool? check = await _accessPoint.Check_If_Employee_Exists_Async(userN);
            if(check == true){
                //The check was successful, which means 
                Messages.Regular1("Check was successful, you may contine to log in.");
                userN = this._newAppSession.Employee.Username; 
                userP = this._newAppSession.Employee.Password; 
                Employee connResultLogin = await _accessPoint.LOGIN_Employee_Async(userN,userP);
                this._newAppSession.Employee = connResultLogin;
                while(true){
                    if(this._newAppSession.Employee == null){
                        this._newAppSession.Employee = new Employee(userN, userP);
                        Messages.Regular1("\tEmployee was does not exist in our records. A new Employee account has been made for you!.");
                        goto RestartLogin;
                    }else{

                        Messages.Regular1($"Ok {this._newAppSession.Employee.Fname}, you are now signed in.");
                        Messages.Regular1($"YOUR SIGNUP DATE {this._newAppSession.Employee.SIGNUPDATE}");
                        Messages.Regular1("\tWould you like to view a ticket?");
                        this._newAppSession.Employee.LASTSIGNEDIN = DateTime.Now;
                        return this._newAppSession.Employee;
                    }
                }
            }else{
                reTryaskToLogin:
                Messages.Regular1("Check was not successful, would like to try again?\n\t\t\t|1 for Yes\n\t\t\t|0 for No");
                int? askTryLogAgain = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,2);
                if(askTryLogAgain == 1){
                    goto RestartLogin;
                }else if(askTryLogAgain == 0){
                    Messages.Regular1("You chose not to log in again. Goodbye.");
                    return this._newAppSession.Employee;
                }else{
                    Messages.Regular1($"Your answer {askTryLogAgain} must be either 1 or 0.");
                    goto reTryaskToLogin;
                }
            }
    
            
        }

        public string GetFname(){
            string a = _newAppSession.Employee.Fname;
            return a;
        }

        public string GetLname(){
            string a = _newAppSession.Employee.Lname;
            return a;
        }

        public string GetUname(){
            string a = _newAppSession.Employee.Username;
            return a;
        }

        public bool GetifManager(){
            bool a = _newAppSession.Employee.Manager;
            return a;
        }

        public DateTime GetSignUpDate(){
            DateTime namefirst = _newAppSession.Employee.SIGNUPDATE;
            return namefirst;
        }

        public void EnterRISystem(){
            Messages.Regular1($"You've now entered your ReImbursement Portal {this._newAppSession.Employee.Fname}");


        }

        public void example(){
            Messages.Regular1("1");
            example2();
        }

        public void example2(){
            Messages.Regular1("2");
            example();
        }

        public bool CreateATicket(){
            var emTicket = TicketCreate.CreateTicket();
            if(emTicket == null){
                Console.WriteLine("This ticket could not be saved");
                return false;
            }else{
                this._newAppSession.Employee.EmployeeTicket = emTicket;
                return true;
            }

        }

        public Ticket GetTicket(){
            return this._newAppSession.Employee.EmployeeTicket;
        }

        public Ticket NewTicket(){
            return _ticket = new Ticket();
        }
        public List<Ticket> GetListTickets(){
            return this._newAppSession.Employee.ListofAllTickets;
        }
        public List<Ticket> AddToTicketsList(){
            List<Ticket>? _List_of_tickets = new List<Ticket>();
            Ticket? emTicket = GetTicket();
            if(emTicket != null){
                this._newAppSession.Employee.ListofAllTickets.Add(emTicket);
                _List_of_tickets = this._newAppSession.Employee.ListofAllTickets;
                
                return _List_of_tickets;
            }else{
                Console.WriteLine("Your list of tickets is empty...");
                return this._newAppSession.Employee.ListofAllTickets;
            }
        }

        public  void ViewListofTickets(){
            List<Ticket> tList = this.GetListTickets();
            int count = 0;
            foreach( Ticket i in tList){
                Messages.Regular1($"List {count++ +1}"+
                    $"\tTicket Amount: {i.Amount}\n"+
                $"\tTicket Description: {i.Description}\n"+
                $"\tIs Ticket Pending: {i.Ticket_Status.ToString()}");

            }
        }

        public Employee GetEmployee(){
            return this._newAppSession.Employee;
        }

        
    }
}