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
        private Guid ticket_ID { get; set; }
        private decimal amount { get; set; }
        private string? description { get; set; }
        private Status ticket_status;
        private DateTime submitDate { get; set; }
        private DateTime reviewDate { get; set; }




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

        public Status TicketStatus
        {
            get
            {
                return ticket_status;
            }
            set
            {
                ticket_status = Status.Pending;
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


        //THe Constructors for Tickets

        public Ticket() { }
        public Ticket(TicketDTO ticket)
        {
            Ticket_ID= ticket.ticket_ID;
            Amount = ticket.amount;
            Description = ticket.description;
            TicketStatus = ticket._status;
            SubmitDate = ticket.submitDate;
            ReviewDate = ticket.reviewDate;

        }
    }
}