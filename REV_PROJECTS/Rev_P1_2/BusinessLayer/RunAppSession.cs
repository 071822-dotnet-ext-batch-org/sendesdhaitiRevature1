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
        private readonly AdoDotnetAccessPoint _accessPoint = new AdoDotnetAccessPoint();
        
/// <summary>
/// This method starts/creates a new AppSession
/// </summary>
        public void NewAppSession(){
            this._newAppSession = new AppSession();
        }

        public async Task<Employee?> AddNewEmployee(){
            RestartRegistration:
            Messages.Regular("Let's get you signed up!");
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
            //Messages.Regular(check.ToString());
            if(check == true){
                //check found your data
                ReAskResponse:
                Messages.Regular("Sign Up Again? or Login?");
                Messages.Regular("|1 for Sign Up\n\t|2 for Login");
                int? response = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,1);
                if(response == 1){
                    Messages.Regular("Restarting.....");
                    await Task.Delay(2000);
                    goto RestartRegistration;
                }else if(response == 2){
                    var logEm = await LoginEmployee();
                    await Task.Delay(2000);
                    return logEm;
                }else{
                    Messages.Regular("Incorrect response");
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
                //Messages.Regular("check did not find your data");
                Messages.Regular($"Your new account is {em.Username} with id: {em.EmployeeID}");
                await Task.Delay(2000);
                return em;
                // goto RestartRegistration;
            }


            string welcome = $"Welcome to your ReImbursement Portal {userN}";
            Messages.Regular(welcome);
        }

        public async Task<Employee> LoginEmployee(){
            this._newAppSession.Employee = new Employee();
            
            Messages.Regular("\tLet's Sign In.");

            RestartLogin:
            this._newAppSession.Employee = EmployeeAuth.LoginNewEmployee();
            Guid userID = this._newAppSession.Employee.EmployeeID; 
            string userN = this._newAppSession.Employee.Username; 
            string userP = this._newAppSession.Employee.Password;
            string userF = this._newAppSession.Employee.Fname;
            string userL = this._newAppSession.Employee.Lname;
            bool userM = this._newAppSession.Employee.Manager;
            // Messages.Regular($"{userID}");
            // Messages.Regular($"{userN}");
            // Messages.Regular($"{userP}");
            // Messages.Regular($"{userF}");
            // Messages.Regular($"{userL}");
            
            bool? check = await _accessPoint.Check_If_Employee_Exists_Async(userN);
            if(check == true){
                //The check was successful, which means 
                Messages.Regular("Check was successful, you may contine to log in.");
                userN = this._newAppSession.Employee.Username; 
                userP = this._newAppSession.Employee.Password; 
                Employee connResultLogin = await _accessPoint.LOGIN_Employee_Async(userN,userP);
                this._newAppSession.Employee = connResultLogin;
                while(true){
                    if(this._newAppSession.Employee == null){
                        this._newAppSession.Employee = new Employee(userN, userP);
                        Messages.Regular("\tEmployee was does not exist in our records. A new Employee account has been made for you!.");
                        goto RestartLogin;
                    }else{

                        Messages.Regular($"Ok {this._newAppSession.Employee.Fname}, you are now signed in.");
                        Messages.Regular($"YOUR SIGNUP DATE {this._newAppSession.Employee.SIGNUPDATE}");
                        Messages.Regular("\tWould you like to view a ticket?");
                        this._newAppSession.Employee.LASTSIGNEDIN = DateTime.Now;
                        return this._newAppSession.Employee;
                    }
                }
            }else{
                reTryaskToLogin:
                Messages.Regular("Check was not successful, would like to try again?\n\t\t\t|1 for Yes\n\t\t\t|0 for No");
                int? askTryLogAgain = VerifyAnswers.Verify_SingleString_Answer_FOR_INT(1,2);
                if(askTryLogAgain == 1){
                    goto RestartLogin;
                }else if(askTryLogAgain == 0){
                    Messages.Regular("You chose not to log in again. Goodbye.");
                    return this._newAppSession.Employee;
                }else{
                    Messages.Regular($"Your answer {askTryLogAgain} must be either 1 or 0.");
                    goto reTryaskToLogin;
                }
            }
    
            
        }

        public void EnterRISystem(){
            Messages.Regular($"You've now entered your ReImbursement Portal {this._newAppSession.Employee.Fname}");


        }

        public void example(){
            Messages.Regular("1");
            example2();
        }

        public void example2(){
            Messages.Regular("2");
            example();
        }

        
    }
}