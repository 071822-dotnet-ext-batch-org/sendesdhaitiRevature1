using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    //--------separate
    public enum Status
    {
        Pending = 1,
        Approved = 2,
        Denied = 0
    }
    //--------separate
    public class Ticket
    {
        private Guid ticket_ID { get; set; }// = Guid.NewGuid();
        private decimal amount { get; set; }
        private string? description { get; set; }
        private string ticket_status;
        private DateTime submitDate { get; set; }
        private DateTime reviewDate { get; set; }
        private Guid? fk_employeeID { get; set; }// = Guid.NewGuid();




        public Guid Ticket_ID
        {
            get
            {
                return ticket_ID;
            }
            set
            {
                ticket_ID = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public string? Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string TicketStatus
        {
            get
            {
                return ticket_status;
            }
            set
            {
                ticket_status = Status.Pending.ToString();
            }
        }

        public DateTime SubmitDate
        {
            get
            {
                return submitDate;
            }
            set
            {
                submitDate = value;
            }
        }

        public DateTime ReviewDate
        {
            get
            {
                return reviewDate;
            }
            set
            {
                reviewDate = value;
            }
        }

        public Guid? FK_EmployeeID
        {
            get
            {
                return fk_employeeID;
            }
            set
            {
                fk_employeeID = value;
            }
        }


        //THe Constructors for Tickets

        public Ticket() { }
        public Ticket(TicketDTO ticket)
        {
            this.Ticket_ID = Guid.NewGuid();
            this.Amount = ticket.amount;
            this.Description = ticket.description;
            this.TicketStatus = ticket._status;
            this.SubmitDate = DateTime.Now;
            this.ReviewDate = DateTime.Now;
            this.FK_EmployeeID = Guid.NewGuid();


        }
    }
}