using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Employee
    {
        private Guid employeeID {get;set;} = Guid.NewGuid();
        private Ticket employeeTicket {get;set;}

        //[Required]
        private string fname {get;set;}
        private string lname {get; set;}
        private bool manager {get; set;} = false;
        private string username {get;set;}
        private string password {get;set;}
        private DateTime datecreated {get;set;}
        private DateTime lastsignedin {get;set;}
        private List<Ticket> listofallTickets {get;set;} = new List<Ticket>();
        private protected DateTime newDateToday = new DateTime();
        public Guid EmployeeID {
            get{
                return this.employeeID;
            }set{
                this.employeeID = value;
            }
        }
        public string Username {
            get{
                return this.username;
            }set{
                this.username = value;
            }
        }
        public string Password {
            get{
                return this.password;
            }set{
                this.password = value;
            }
        }

        public string Fname {
            get{
                return this.fname;
            }set{
                this.fname = value;
            }
        }

        public string Lname {
            get{
                return this.lname;
            }set{
                this.lname = value;
            }
        }

        public bool Manager{
            get{
                return this.manager;
            }set{
                this.manager = value;
            }
        }

        public DateTime SIGNUPDATE{
            get{
                return this.datecreated;
            }set{
                this.datecreated = value;
            }
        }
        public DateTime LASTSIGNEDIN{
            get{
                return this.lastsignedin;
            }set{
                this.lastsignedin = value;
            }
        }

        public Ticket EmployeeTicket{
            get{
                return this.employeeTicket;
            }
            set{
                this.employeeTicket = value;
            }
        }

        public List<Ticket> ListofAllTickets{
            get{
                return this.listofallTickets;
            }set{
                this.listofallTickets = value;
            }
        }
        public Employee(){
        }

        /// <summary>
        /// This is an employee that is signing up for the first time
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Employee(string fName, string lName, string username, string password){
            this.EmployeeID = Guid.NewGuid();
            //Console.WriteLine(this.EmployeeID);
            this.EmployeeTicket = new Ticket();
            this.Username = username;
            this.Password = password;
            this.Fname = fName;
            this.Lname = lName;
            this.Manager = false;
            
            this.SIGNUPDATE = newDateToday.ToLocalTime();
            this.LASTSIGNEDIN = newDateToday.ToLocalTime();
            this.ListofAllTickets = new List<Ticket>();
        }
        

        /// <summary>
        /// This is an employee that has signed back into the system
        /// 
        /// It generates a new employee in the session 
        /// with the parameters/data that employee previously had
        /// </summary>
        /// <param name="employeeid"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="signupdate"></param>
        /// <param name="manager"></param>
        public Employee(string username, string password){
            this.EmployeeID = new Guid();
            this.EmployeeTicket = new Ticket();
            this.Username = username;
            this.Password = password;
            this.Fname = "nullFname";
            this.Lname = "nullLname";
            this.Manager = false;
            this.SIGNUPDATE = new DateTime();
            this.LASTSIGNEDIN = new DateTime();
            this.ListofAllTickets = new List<Ticket>();
        }
    }
}