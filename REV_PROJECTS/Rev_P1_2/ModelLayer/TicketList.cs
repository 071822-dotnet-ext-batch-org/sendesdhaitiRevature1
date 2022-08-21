using System;
namespace ModelLayer
{
    public class TicketList : Ticket
    {
        /// <summary>
        /// List for Employee Tickets
        /// </summary>
        public List<Ticket>? SubmittedTickets { get; set; } = new List<Ticket>();

        /// <summary>
        /// List for Manager pending Tickets up for review
        /// </summary>
        public List<Ticket>? TicketsForReview { get; set; } = new List<Ticket>();

        /// <summary>
        /// List of Completely Reviewed Tickets
        /// </summary>
        public List<Ticket>? ReviewedTickets { get; set; } = new List<Ticket>();


    }
}

