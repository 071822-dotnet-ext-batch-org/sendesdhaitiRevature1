using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Ticket
    {
        private Guid TicketID {get;set;} = Guid.NewGuid();
        private decimal Amount {get;set;} = 0;
        private string? Description {get;set;}
        private int Ticket_Status {get;set;}
        private DateTime DateSubmitted { get; set; }
        private DateTime? DateReviewed {get;set;}
        private Guid? FK_Employee_ID { get; set; }
        private Guid? FK_ManagerReviewer_ID { get; set; }


        //Enum for ticket status
        private enum Status{
            Pending = 1,
            Approved = 2,
            Denied = 0

        }


        /// <summary>
        /// The Ticket ID
        /// </summary>
        public Guid ticketID
        {
            get
            {
                return this.TicketID;
            }
            set
            {
                this.TicketID = value;
            }
        }


        /// <summary>
        /// Ticket status
        /// | 1 is Pending |
        /// | 2 is Aprroved |
        /// | 0 id Denied |
        /// </summary>
        public int ticket_Status
        {
            get
            {
                return (int)Status.Pending;
            }
            set
            {
                value = (int)Status.Pending;
            }
        }

        public DateTime dateSubmitted
        {
            get
            {
                return this.DateSubmitted;
            }
            set
            {
                this.DateSubmitted = value;
            }
        }
        public DateTime? dateReviewed
        {
            get
            {
                return this.DateReviewed;
            }
            set
            {
                this.DateReviewed = value;
            }
        }

        public decimal amount
        {
            get
            {
                return this.Amount;
            }
            set
            {
                this.Amount = value;
            }
        }

        public string? description
        {
            get
            {
                return this.Description;
            }
            set
            {
                this.Description = value;
            }
        }
        public Guid? fk_Employee_ID
        {
            get
            {
                return this.FK_Employee_ID;
            }
            set
            {
                this.FK_Employee_ID = value;
            }
        }

        public Guid? fk_Manager_ID
        {
            get
            {
                return this.FK_ManagerReviewer_ID;
            }
            set
            {
                this.FK_ManagerReviewer_ID = value;
            }
        }

        public Ticket(){

        }


        //New ticket with only amount and no description
        /// <summary>
        /// New ticket with only amount and no description
        /// </summary>
        /// <param name="amount"></param>
        public Ticket(decimal amount){
            this.TicketID = Guid.NewGuid();
            this.Amount = amount;
            this.Description = "Empty";
            this.DateSubmitted = DateTime.Now;
            this.DateReviewed = DateTime.Now;
            this.Ticket_Status = (int)Status.Pending;
            this.FK_Employee_ID = Guid.NewGuid();
            this.FK_ManagerReviewer_ID = null;
        }

        //New ticket with description
        /// <summary>
        /// New Ticket with descrition
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public Ticket(decimal amount, string description){
            this.TicketID = Guid.NewGuid();
            this.Amount = amount;
            this.Description = description;
            this.DateSubmitted = DateTime.Now;
            this.DateReviewed = DateTime.Now;
            this.Ticket_Status = (int)Status.Pending;
            this.FK_Employee_ID = Guid.NewGuid();
            this.FK_ManagerReviewer_ID = null;

        }

        //Previous Tickets

        /// <summary>
        /// Previously made tickets
        /// </summary>
        /// <param name="ticketID"></param>
        public Ticket(Guid ticketID)
        {
            this.TicketID = ticketID;
            this.Amount = 0;
            this.Description = "Empty";
            this.DateSubmitted = DateTime.Now;
            this.DateReviewed = DateTime.Now;
            this.Ticket_Status = Ticket_Status;
            this.FK_Employee_ID = Guid.NewGuid();
            this.FK_ManagerReviewer_ID = null;
        }
    }
}