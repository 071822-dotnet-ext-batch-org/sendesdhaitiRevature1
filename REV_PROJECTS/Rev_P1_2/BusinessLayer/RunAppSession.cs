using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;


namespace BusinessLayer
{
    public class RunAppSession
    {
        private Guid currentSessionID {get;set;}= new Guid();
        private AppSession newAppSession;
        
/// <summary>
/// This method starts/creates a new AppSession
/// </summary>
        public void NewAppSession(){
            this.newAppSession = new AppSession();
        }

        public void AddNewEmployee(){
            this.newAppSession.Employee = RegisterEmployee.RegisterNewEmployee();
            string welcome = $"Welcome to your ReImbursement Portal {this.newAppSession.Employee.Fname}";
            Messages.Regular(welcome);
        }

        
    }
}