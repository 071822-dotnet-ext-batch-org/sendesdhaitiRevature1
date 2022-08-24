using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace ModelLayer
{
    public class TicketDTO
    {
        //public Guid ticket_ID { get; set; }// = Guid.NewGuid();

        [Required(ErrorMessage ="Your ticket 'MUST' have an amount to be valid!")]
        //[StringLength(maximumLength:8 , ErrorMessage ="Your amount must be within 8 characters (Includes '.')")]
        public decimal amount { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Your amount must be within 100 characters")]
        public string? description { get; set; }

        public string _status { get; set; }
        //public DateTime submitDate { get; set; }
        //public DateTime reviewDate { get; set; }
        public decimal Tax { get; set; }
        //public Guid? fk_employeeID { get; set; }// = Guid.NewGuid();

        //public TicketDTO() { }
        public TicketDTO() { }

        /// <summary>
        /// A method to create a ticket
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        public TicketDTO(decimal amount, string description)
        {
            //this.ticket_ID = Guid.NewGuid();
            this.amount = amount;
            this.description = description;
            this._status = Status.Pending.ToString();
            //this.submitDate = DateTime.Now;
            //this.reviewDate = DateTime.Now;
            //this.fk_employeeID = null;//Guid.NewGuid();
        }

        /// <summary>
        /// A method to load a ticket
        /// </summary>
        /// <param name="t"></param>
        public TicketDTO(Ticket t)
        {
            //this.ticket_ID = Guid.NewGuid();
            this.amount = t.Amount;
            this.description = t.Description;
            this._status = t.TicketStatus;
            //this.submitDate = t.SubmitDate;
            //this.reviewDate = t.ReviewDate;
            //this.fk_employeeID = Guid.NewGuid();
        }



    }
}

