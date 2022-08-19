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
        private AppSession _newAppSession = new AppSession();
        private Employee _sessionEmployee = new Employee();
        private Manager? _sessionManager = new Manager();

        private Ticket? _sessionTicket = new Ticket();
        private readonly AdoDotnetAccessPoint _accessPoint = new AdoDotnetAccessPoint();
        private List<Ticket> sessionTickets { get; set; } = new List<Ticket>();
        
        /// <summary>
        /// This method starts/creates a new AppSession
        /// </summary>
        public void NewAppSession(){
            this._newAppSession = new AppSession();
        }

        /// <summary>
        /// This method in the currently ran session returns a true or false if the Employee's login credential match
        /// </summary>
        /// <param name="employeeInput"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExists_Employee(Employee employeeInput)
        {
            Employee em = new Employee();
            em = employeeInput;
            //Check if employee exists from the repo layer
            bool checkAP = await _accessPoint.Employee_LoginCheck(em);
            if(checkAP == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// This logs the user in based on the Employee obj
        /// </summary>
        /// <param name="employeeInput"></param>
        /// <returns></returns>
        public async Task<Employee?> Login_Employee(Employee employeeInput)
        {
            //Employee? em = new Employee();
            _sessionEmployee = await _accessPoint.Employee_Login(employeeInput);
            return _sessionEmployee;
        }

        public async Task<bool> CheckIfExists_Ticket(int employeeInput)
        {
            Ticket em = new Ticket();
            em.ticket_Status = employeeInput;
            //Check if employee exists from the repo layer
            bool checkAP = await _accessPoint.Employee_TicketCheck(em);
            if (checkAP == false)
            {
                return false;
            }
            else
            {
                //add ticket to list for every ticket that matches the id
                return true;
            }

        }//End of Ticket Check

        public async Task<Ticket?> Get_Ticket_Employee(int input_T)
        {
            Ticket em = new Ticket();
            em.ticket_Status = input_T;
            Ticket? checkT = await _accessPoint.Employee_TicketGet(em);
            if(checkT == null)
            {
                Console.WriteLine("The ticket could not be viewed");
                return null;
            }
            else
            {
                Console.WriteLine("The ticket was found");
                return checkT;
            }

        }

        //Submit ticket
        public async Task<bool> Submit_EmployeeTicket(Ticket emTicket)
        {
            _sessionTicket = emTicket;
            _sessionTicket.fk_Employee_ID = this._sessionEmployee.employeeID;
            bool checkIfSaved = await _accessPoint.Employee_TicketSubmit(_sessionTicket);
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