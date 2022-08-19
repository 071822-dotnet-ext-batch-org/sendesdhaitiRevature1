using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Employee
    {
        private Guid EmployeeID {get;set;} = Guid.NewGuid();
        private Guid? FK_TicketID {get;set;} = Guid.NewGuid();

        //[Required]
        private string? Fname {get;set;}
        private string? Lname {get; set;}
        //private bool manager {get; set;} = false;
        private string Username {get;set;}
        private string Password {get;set;}
        private DateTime SignUpDate { get;set;}
        private DateTime? LastSignedIn { get;set;}
        private List<Ticket>? ListofallTickets {get;set;}

        /// <summary>
        /// Employee ID
        /// </summary>
        public Guid employeeID
        {
            get
            {
                return this.EmployeeID;
            }
            set
            {
                this.EmployeeID = value;
            }
        }


        /// <summary>
        /// Employee Ticket Foreign Key ID
        /// </summary>
        public Guid? fk_TicketID
        {
            get
            {
                return this.FK_TicketID;
            }
            set
            {
                this.FK_TicketID = value;
            }
        }

        /// <summary>
        /// The Employee's Username
        /// </summary>
        public string username
        {
            get
            {
                return this.Username;
            }
            set
            {
                this.Username = value;
            }
        }

        /// <summary>
        /// The Employee's Passowrd
        /// </summary>
        public string password
        {
            get
            {
                return this.Password;
            }
            set
            {
                this.Password = value;
            }
        }


        /// <summary>
        /// The Employee's First name
        /// </summary>
        public string? fname
        {
            get
            {
                return this.Fname;
            }
            set
            {
                this.Fname = value;
            }
        }

        /// <summary>
        /// The Employee's Last name
        /// </summary>
        public string? lname
        {
            get
            {
                return this.Lname;
            }
            set
            {
                this.Lname = value;
            }
        }

        /// <summary>
        /// Date the Employee signed up
        /// </summary>
        public DateTime signUpDate
        {
            get
            {
                return this.SignUpDate;
            }
            set
            {
                this.SignUpDate = value;
            }
        }

        /// <summary>
        /// Last known date Employee signed in
        /// </summary>
        public DateTime? lastSignedIn
        {
            get
            {
                return this.LastSignedIn;
            }
            set
            {
                this.LastSignedIn = value;
            }
        }

        /// <summary>
        /// Employee's List of tickets
        /// </summary>
        public List<Ticket>? listofallTickets
        {
            get
            {
                return this.ListofallTickets;
            }
            set
            {
                this.ListofallTickets = value;
            }
        }
        public Employee(){}

        /// <summary>
        /// This is an employee that is signing up for the first time
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Employee(string fName, string lName, string username, string password){
            this.EmployeeID = Guid.NewGuid();
            this.FK_TicketID = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.Fname = fName;
            this.Lname = lName;
            this.SignUpDate = new DateTime();
            this.LastSignedIn = null;
            this.ListofallTickets = new List<Ticket>();
        }
        

        /// <summary>
        /// This is an employee that has signed back into the system
        /// 
        /// It generates a new employee in the session 
        /// with the parameters/data that employee previously had
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Employee(string username, string password){
            this.EmployeeID = Guid.NewGuid();
            this.FK_TicketID = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.Fname = "nullFname";
            this.Lname = "nullLname";
            this.SignUpDate = new DateTime();
            this.LastSignedIn = new DateTime();
            this.ListofallTickets = new List<Ticket>();
        }
    }
}