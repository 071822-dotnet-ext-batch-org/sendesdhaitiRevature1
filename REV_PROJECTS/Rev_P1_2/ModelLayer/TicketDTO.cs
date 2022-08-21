using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace ModelLayer
{
    public class TicketDTO
    {
        public Guid ticket_ID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="Your ticket 'MUST' have an amount to be valid!")]
        //[StringLength(maximumLength:8 , ErrorMessage ="Your amount must be within 8 characters (Includes '.')")]
        public decimal amount { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Your amount must be within 100 characters")]
        public string? description { get; set; }

        public readonly Status _status;
        public DateTime submitDate { get; set; }
        public DateTime reviewDate { get; set; }
        public decimal Tax { get; set; }

        public TicketDTO() { }

        public TicketDTO(string tstatus)
        {
            ticket_ID = Guid.NewGuid();
            this.amount = 0;
            description = "Empty";
            Status e;
            var result = Enum.TryParse<Status>(tstatus, out e);
            if (result == true)
            {
                _status = e;
            }
            else
            {
                _status = Status.Pending;
            }
            submitDate = DateTime.Now;
            reviewDate = DateTime.Now;
        }


        public TicketDTO(decimal amount, string description)
        {
            ticket_ID = Guid.NewGuid();
            this.amount = amount;
            this.description = description;
            _status = Status.Pending;
            submitDate = DateTime.Now;
            reviewDate = DateTime.Now;
        }


        public TicketDTO(Ticket t)
        {
            ticket_ID = t.Ticket_ID;
            this.amount = t.Amount;
            this.description = t.Description;
            _status = t.TicketStatus;
            submitDate = t.SubmitDate;
            reviewDate = t.ReviewDate;
        }



    }
}

