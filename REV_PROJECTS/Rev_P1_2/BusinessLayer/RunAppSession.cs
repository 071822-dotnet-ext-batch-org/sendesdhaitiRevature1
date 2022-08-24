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
        private readonly AdoDotnetAccessPoint _accessPoint = new AdoDotnetAccessPoint();
        private AppSession _newAppSession;// = new AppSession();
        private List<Ticket>? _sessionTickets = new List<Ticket>();
        private Ticket? _mostRecentTicket = new Ticket();
        private Employee _sessionEmployee = new Employee();
        private Manager? _sessionManager = new Manager();

        //Our Model Layer - All Data saved for the session
        ////Gonna need a List model to hold all tickets - makee it a derived class
        //private List<Ticket> _sessionTickets { get; set; } = new List<Ticket>();

        ////Our Repo Layer - All Data dsaved and retrieved from Database


        ////------------------------------------------------Run Session Section
        ///// <summary>
        ///// This method starts/creates a new AppSession
        ///// </summary>
        public RunAppSession()
        {
            this._accessPoint = new AdoDotnetAccessPoint();
            this._newAppSession = new AppSession();
            //this._sessionEmployee = new Employee();
            //this._sessionManager = new Manager();
            //this._
        }



        ////------------------------------------------------Employee Checks and Pages Section

        /// <summary>
        /// This method in the currently ran session returns a true or false if the Employee's login credential match
        /// </summary>
        /// <param name="employeeInput"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExists_Employee(EmployeeDTO emCheckDTO)
        {
            //Check if username has any symbols or special characters
            Employee checkEm = new Employee(emCheckDTO);
            //em = employeeInput;
            //Check if employee exists from the repo layer
            bool checkAP = await this._accessPoint.Employee_LoginCheck(checkEm);
            if (checkAP == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// This logs the user in based on the EmployeeDTO obj
        /// </summary>
        /// <param name="emCheckDTO"></param>
        /// <returns></returns>
        public async Task<EmployeeDTO?> Login_Employee(EmployeeDTO emCheckDTO)
        {
            Employee _sessionEmployee = new Employee(emCheckDTO);
            _sessionEmployee = await this._accessPoint.Employee_Login(_sessionEmployee);
            this._sessionEmployee = _sessionEmployee;
            EmployeeDTO em = new EmployeeDTO(_sessionEmployee);
            return em;
        }


        public async Task<bool> Register_Employee(EmployeeDTO emDTO)
        {
            Employee _sessionEmployee = new Employee(emDTO);
            this._sessionEmployee = _sessionEmployee;
            var emSaveResponse = await this._accessPoint.Employee_Register(_sessionEmployee);
            return emSaveResponse;
        }



        ////------------------------------------------------Manager Checks and Pages Section


        public async Task<bool> CheckIfExists_Manager(ManagerDTO managerInput)
        {
            //Check if employee exists from the repo layer
            Manager checkMang = new Manager(managerInput);
            bool checkAP = await this._accessPoint.Manager_LoginCheck(checkMang);
            if (checkAP == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<ManagerDTO?> Login_Manager(ManagerDTO managerInput)
        {
            Manager _sessionManager = new Manager(managerInput);
            _sessionManager = await this._accessPoint.Manager_Login(_sessionManager);
            if(_sessionManager != null)
            {
                this._sessionManager = _sessionManager;
                Console.WriteLine($"The manager '{this._sessionManager.Username}' is now logged in");
                ManagerDTO? mangDTO = new ManagerDTO(_sessionManager);
                return mangDTO;
            }
            else
            {
                Console.WriteLine($"The manager '{managerInput.username}' could not be found!");
                return null;
            }
        }

        public async Task<bool> Register_Manager(ManagerDTO mangDTO)
        {
            Manager _sessionManager = new Manager(mangDTO);
            this._sessionManager = _sessionManager;
            var mangSaveResponse = await this._accessPoint.Manager_Register(_sessionManager);
            return mangSaveResponse;
        }



        ////------------------------------------------------Tickets Getting, Saving, and Updating Section
        public async Task<List<TicketDTO>?> Get_AllTickets()
        {
            //Ticket em = new Ticket();
            //em.Ticket_Status = input_T;
            List<Ticket>? _sessionTickets = await _accessPoint.Get_All_Tickets();

            List<TicketDTO>? tickDTO = new List<TicketDTO>();
            if (_sessionTickets != null)
            {
                foreach(Ticket t in _sessionTickets)
                {
                    TicketDTO retirevedDTO_Ticket = new TicketDTO(t);
                    tickDTO.Add(retirevedDTO_Ticket);
                }

                Console.WriteLine("the list of tickets were found");
                return tickDTO;
            }
            else
            {
                Console.WriteLine("The list of tickets is empty");
                return tickDTO;
            }

        }

        /// <summary>
        /// This method creates a new ticket by a specific employee
        /// </summary>
        /// <param name="emTicketDTO"></param>
        /// <returns></returns>
        public async Task<bool> Create_Ticket(TicketDTO emTicketDTO)
        {
            //Check if ticket DTO values are good before converting to Ticket OBJ
            bool descCheck = VerifyAnswers.Verify_StringAnswer_For_Descrition(emTicketDTO.description, 0, 200);
            if(emTicketDTO.amount <= 0)
            {
                //If amount is zero
                Console.WriteLine($"The amount of {emTicketDTO.amount} cannot be zero");
                return false;
            }
            
            else
            {
                //If description is a valid descrition
                if(descCheck == true)
                {
                    //Convert Ticket DTO obj to Ticket obj
                    //Ticket newTicket = new Ticket();
                    Ticket _mostRecentTicket = new Ticket()
                    {
                        Ticket_ID = Guid.NewGuid(),
                        Amount = (decimal)emTicketDTO.amount,
                        Description = emTicketDTO.description,
                        TicketStatus = emTicketDTO._status,
                        SubmitDate = DateTime.Now,
                        ReviewDate = DateTime.Now,
                        FK_EmployeeID = this._sessionEmployee.Employee_ID
                    };
                    Console.WriteLine($"\n\n\t\tTicket ID : {_mostRecentTicket.Ticket_ID}");
                    Console.WriteLine($"\t\tSession Employee: {this._sessionEmployee.Employee_ID}");
                    Console.WriteLine($"\t\tSession Employee: {_mostRecentTicket.FK_EmployeeID}");


                    bool checkIfSaved = await this._accessPoint.Employee_TicketSubmit(_mostRecentTicket);
                    if (checkIfSaved == true)
                    {
                        Console.WriteLine("Ticket Recorded");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Ticket could not be saved");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine($"The description of '{emTicketDTO.description}' was invalid");
                    return false;
                }
               
            }
        }

        //public async Task<bool> CheckIfExists_Ticket(int employeeInput)
        //{
        //    Ticket em = new Ticket();
        //    em.ticket_Status = employeeInput;
        //    //Check if employee exists from the repo layer
        //    bool checkAP = await _accessPoint.Employee_TicketCheck(em);
        //    if (checkAP == false)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        //add ticket to list for every ticket that matches the id
        //        return true;
        //    }

        //}//End of Ticket Check




        ////Submit ticket




        //public async Task<Employee?> AddNewEmployee(){
        //    RestartRegistration:
        //    Messages.Regular1("Let's get you signed up!");
        //    await Task.Delay(961);
        //    this._newAppSession.Employee = EmployeeAuth.RegisterNewEmployee();



        //    Guid userID = this._newAppSession.Employee.EmployeeID; 
        //    string userN = this._newAppSession.Employee.Username; 
        //    string userP = this._newAppSession.Employee.Password;
        //    string userF = this._newAppSession.Employee.Fname;
        //    string userL = this._newAppSession.Employee.Lname;
        //    bool userM = this._newAppSession.Employee.Manager;
        //    DateTime userSignup = this._newAppSession.Employee.SIGNUPDATE;
        //    DateTime userLastMod = this._newAppSession.Employee.LASTSIGNEDIN;

        //    //We nee to check if the credentials entered are not present already before they enter the portal
        //    var check = await _accessPoint.Check_If_Employee_Exists_Async(userN);
        //    //Messages.Regular1(check.ToString());
        //    if(check == true){
        //        //check found your data
        //        ReAskResponse:
        //        Messages.Regular1("Sign Up Again? or Login?");
        //        Messages.Regular1("|1 for Sign Up\n\t|2 for Login");
        //        int? response = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,1);
        //        if(response == 1){
        //            Messages.Regular1("Restarting.....");
        //            await Task.Delay(2000);
        //            goto RestartRegistration;
        //        }else if(response == 2){
        //            //var logEm = await LoginEmployee();
        //            await Task.Delay(2000);
        //            return null;
        //        }else{
        //            Messages.Regular1("Incorrect response");
        //            await Task.Delay(2000);
        //            goto ReAskResponse;
        //        }

        //    }else{
        //        //check did not find your data
        //        Employee em = new Employee(){
        //            EmployeeID = userID,
        //            Username = userN,
        //            Fname =userF,
        //            Lname = userL,
        //            Manager = userM,
        //            SIGNUPDATE = userSignup,
        //            LASTSIGNEDIN = userLastMod,
        //            Password = userP

        //        };
        //        Messages.Regular1(em.EmployeeID.ToString());
        //        Messages.Regular1(em.Username);
        //        Messages.Regular1(em.Fname);
        //        Messages.Regular1(em.Lname);
        //        Messages.Regular1(em.Password);
        //        Messages.Regular1(em.Manager.ToString());
        //        Messages.Regular1(em.SIGNUPDATE.ToString());
        //        Messages.Regular1(em.LASTSIGNEDIN.ToString());
        //        //Messages.Regular1("check did not find your data");
        //        //var AddTODB = await _accessPoint.REGISTER_Employee_Async();
        //        Messages.Regular1($"Your new account is {em.Username} with id: {em.EmployeeID}");

        //        await Task.Delay(2000);
        //        return em;
        //        // goto RestartRegistration;
        //    }


        //    string welcome = $"Welcome to your ReImbursement Portal {userN}";
        //    Messages.Regular1(welcome);
        //}

        //public async Task<Employee> LoginEmployee(string userN, string userP)
        //{


        //    this._newAppSession.Employee = new Employee();

        //    Messages.Regular1("\tLet's Sign In.");

        //    //RestartLogin:
        //    ////this._newAppSession.Employee = EmployeeAuth.LoginNewEmployee();
        //    ////Guid userID = this._newAppSession.Employee.EmployeeID; 
        //    ////string userN = this._newAppSession.Employee.Username; 
        //    ////string userP = this._newAppSession.Employee.Password;
        //    ////string userF = this._newAppSession.Employee.Fname;
        //    ////string userL = this._newAppSession.Employee.Lname;
        //    ////bool userM = this._newAppSession.Employee.Manager;
        //    //// Messages.Regular1($"{userID}");
        //    //// Messages.Regular1($"{userN}");
        //    //// Messages.Regular1($"{userP}");
        //    //// Messages.Regular1($"{userF}");
        //    //// Messages.Regular1($"{userL}");

        //    bool? check = await _accessPoint.Check_If_Employee_Exists_UN_and_PW_Async(userN, userP);
        //    if (check == null)
        //    {
        //        //If employee with Username is not in DB
        //        Console.WriteLine($"Employee '{userN}' is not found");
        //        return null;
        //    }
        //    else
        //    {
        //        //THe employee was found and must now check the password

        //    }
        //    //if(check == true){
        //    //    //The check was successful, which means 
        //    //    Messages.Regular1("Check was successful, you may contine to log in.");
        //    //    //userN = this._newAppSession.Employee.Username; 
        //    //    //userP = this._newAppSession.Employee.Password; 
        //    //    Employee connResultLogin = await _accessPoint.LOGIN_Employee_Async(userN,userP);
        //    //    this._newAppSession.Employee = connResultLogin;
        //    //    while(true){
        //    //        if(this._newAppSession.Employee == null){
        //    //            //this._newAppSession.Employee = new Employee(userN, userP);
        //    //            Messages.Regular1("\tEmployee was does not exist in our records. \n\t\tTry Again!.");
        //    //            goto RestartLogin;
        //    //        }else{

        //    //            Messages.Regular1($"Ok {this._newAppSession.Employee.Fname}, you are now signed in.");
        //    //            Messages.Regular1($"YOUR SIGNUP DATE {this._newAppSession.Employee.SIGNUPDATE}");
        //    //            Messages.Regular1("\tWould you like to view a ticket?");
        //    //            this._newAppSession.Employee.LASTSIGNEDIN = DateTime.Now;
        //    //            return this._newAppSession.Employee;
        //    //        }
        //    //    }
        //    //}else{
        //    //    reTryaskToLogin:
        //    //    Messages.Regular1("Check was not successful, would like to try again?\n\t\t\t|1 for Yes\n\t\t\t|0 for No");
        //    //    int? askTryLogAgain = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,2);
        //    //    if(askTryLogAgain == 1){
        //    //        goto RestartLogin;
        //    //    }else if(askTryLogAgain == 0){
        //    //        Messages.Regular1("You chose not to log in again. Goodbye.");
        //    //        return this._newAppSession.Employee;
        //    //    }else{
        //    //        Messages.Regular1($"Your answer {askTryLogAgain} must be either 1 or 0.");
        //    //        goto reTryaskToLogin;
        //    //    }
        //    //}


        //}

        //public string GetFname(){
        //    string a = _newAppSession.Employee.Fname;
        //    return a;
        //}

        //public string GetLname(){
        //    string a = _newAppSession.Employee.Lname;
        //    return a;
        //}

        //public string GetUname(){
        //    string a = _newAppSession.Employee.Username;
        //    return a;
        //}

        //public bool GetifManager(){
        //    bool a = _newAppSession.Employee.Manager;
        //    return a;
        //}

        //public DateTime GetSignUpDate(){
        //    DateTime namefirst = _newAppSession.Employee.SIGNUPDATE;
        //    return namefirst;
        //}

        //public void EnterRISystem(){
        //    Messages.Regular1($"You've now entered your ReImbursement Portal {this._newAppSession.Employee.Fname}");


        //}

        //public void example(){
        //    Messages.Regular1("1");
        //    example2();
        //}

        //public void example2(){
        //    Messages.Regular1("2");
        //    example();
        //}

        //public bool CreateATicket(){
        //    var emTicket = TicketCreate.CreateTicket();
        //    if(emTicket == null){
        //        Console.WriteLine("This ticket could not be saved");
        //        return false;
        //    }else{
        //        this._newAppSession.Employee.EmployeeTicket = emTicket;
        //        return true;
        //    }

        //}

        //public Ticket GetTicket(){
        //    return this._newAppSession.Employee.EmployeeTicket;
        //}

        //public Ticket NewTicket(){
        //    return _ticket = new Ticket();
        //}
        //public List<Ticket> GetListTickets(){
        //    return this._newAppSession.Employee.ListofAllTickets;
        //}
        //public List<Ticket> AddToTicketsList(){
        //    List<Ticket>? _List_of_tickets = new List<Ticket>();
        //    Ticket? emTicket = GetTicket();
        //    if(emTicket != null){
        //        this._newAppSession.Employee.ListofAllTickets.Add(emTicket);
        //        _List_of_tickets = this._newAppSession.Employee.ListofAllTickets;

        //        return _List_of_tickets;
        //    }else{
        //        Console.WriteLine("Your list of tickets is empty...");
        //        return this._newAppSession.Employee.ListofAllTickets;
        //    }
        //}

        //public  void ViewListofTickets(){
        //    List<Ticket> tList = this.GetListTickets();
        //    int count = 0;
        //    foreach( Ticket i in tList){
        //        Messages.Regular1($"List {count++ +1}"+
        //            $"\tTicket Amount: {i.Amount}\n"+
        //        $"\tTicket Description: {i.Description}\n"+
        //        $"\tIs Ticket Pending: {i.Ticket_Status.ToString()}");

        //    }
        //}

        //public Employee GetEmployee(){
        //    return this._newAppSession.Employee;
        //}


    }
}