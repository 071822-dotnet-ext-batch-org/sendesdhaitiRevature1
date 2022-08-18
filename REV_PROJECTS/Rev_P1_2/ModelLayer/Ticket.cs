using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Ticket
    {
        private Guid ticketID {get;set;} = new Guid();
        private enum Status{
            Pending = 1,
            Approved = 2,
            Denied = 0

        }
        private Enum status {get;set;} = Status.Pending;
        private DateTime datesubmitted {get;set;}
        private DateTime? datereviewed {get;set;}
        private double amount {get;set;} = 0;
        private string? description {get;set;} = "Description is currently empty";
        public Employee? FK_EmployeeID {get;set;} = new Employee();

        public Guid TicketID {
            get{
                return this.ticketID;
            }set{
                this.ticketID = value;
            }
        }

        public Enum Ticket_Status {
            get{
                return this.status;
            }set{
                this.status = value;
            }
        }

        public DateTime DateSubmitted {
            get{
                return this.datesubmitted;
            }set{
                this.datesubmitted = value;
            }
        }
        public DateTime? DateReviewed {
            get{
                return this.datereviewed;
            }set{
                this.datereviewed = value;
            }
        }

        public double Amount {
            get{
                return this.amount;
            }set{
                this.amount = value;
            }
        }

        public string? Description {
            get{
                return this.description;
            }set{
                this.description = value;
            }
        }

        public Ticket(){

        }

        public Ticket(double amount){
            this.TicketID = new Guid();
            this.FK_EmployeeID = new Employee();
            this.Amount = amount;
            this.Description = "This description is empty";
            this.DateSubmitted = new DateTime().Date;
            this.DateReviewed = null;
            this.Ticket_Status = Status.Pending;
        }

        //New ticket
        public Ticket(double amount, string description){
            this.TicketID = new Guid();
            this.FK_EmployeeID = new Employee();
            this.Amount = amount;
            this.Description = description;
            this.DateSubmitted = new DateTime().Date;
            this.DateReviewed = null;
            this.Ticket_Status = Status.Pending;

        }

        //Previous Tickets
        public Ticket(Guid ticketID){
            this.TicketID = ticketID;
            this.FK_EmployeeID = new Employee();
            this.Amount = amount;
            this.Description = description;
            this.DateSubmitted = datesubmitted;
            this.DateReviewed = datereviewed;
            this.Ticket_Status = Status.Pending;
        }
    }
}