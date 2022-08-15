using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Ticket
    {
        private Guid ticketID {get;set;} = new Guid();
        private bool pending {get;set;} = false;
        private bool? approved {get;set;} = false;
        private bool? denied {get;set;} = false;
        private DateTime datesubmitted {get;set;}
        private DateTime? datereviewed {get;set;}
        private double amount {get;set;} = 0;
        private string? description {get;set;} = "Description is currently empty";
        public Employee? EmployeeID {get;set;} = null;

        public Guid TicketID {
            get{
                return this.ticketID;
            }set{
                this.ticketID = value;
            }
        }

        public bool Pending {
            get{
                return this.pending;
            }set{
                this.pending = value;
            }
        }
        public bool? Approved {
            get{
                return this.approved;
            }set{
                this.approved = value;
            }
        }
        public bool? Denied {
            get{
                return this.denied;
            }set{
                this.denied = value;
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
            this.Amount = amount;
            this.Description = "This description is empty";
            this.DateSubmitted = new DateTime().Date;
            this.DateReviewed = null;
            this.Approved = null;
            this.Denied = null;
            this.Pending = true;
        }

        //New ticket
        public Ticket(double amount, string description){
            this.TicketID = new Guid();
            this.Amount = amount;
            this.Description = description;
            this.DateSubmitted = new DateTime().Date;
            this.DateReviewed = null;
            this.Approved = null;
            this.Denied = null;
            this.Pending = true;
        }

        //Previous Tickets
        public Ticket(Guid ticketID, double amount, string? description, DateTime datesubmitted, DateTime? datereviewed, bool? approved, bool? denied, bool pending){
            this.TicketID = ticketID;
            this.Amount = amount;
            this.Description = description;
            this.DateSubmitted = datesubmitted;
            this.DateReviewed = datereviewed;
            this.Approved = approved;
            this.Denied = denied;
            this.Pending = pending;
        }



    }
}