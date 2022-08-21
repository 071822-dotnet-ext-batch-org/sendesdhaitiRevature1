using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModelLayer
{
    public class ManagerDTO
    {
        public Guid Manager_ID { get; set; } //not null
        public string? fname { get; set; } //null
        public string? lname { get; set; } //null
        [Required(ErrorMessage = "You must have a valid!")]
        public string username { get; set; } //not null
        [Required(ErrorMessage = "A password is required!")]
        public string password { get; set; } //not null
        public DateTime dateRegistered { get; set; } //not null

        //Manager specific Porperties
        //private List<Ticket> tickets_for_review;
        //private List<Ticket> reviewed_tickets;


        //Manager Constructors when manager is created
        public ManagerDTO() { }

        /// <summary>
        /// For returning managers unly using their username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public ManagerDTO(string username, string password)
        {
            Manager_ID = Guid.NewGuid();
            fname = "First Name";
            lname = "Last Name";
            this.username = username;
            this.password = password;
            dateRegistered = DateTime.Now;
        }

        /// <summary>
        /// Mostly used for returning managers
        /// </summary>
        /// <param name="m"></param>
        public ManagerDTO(Manager m)
        {
            Manager_ID = m.Manager_ID;
            this.fname = m.MFname;
            this.lname = m.MLname;
            this.username = m.MUsername;
            this.password = m.MPassword;
            dateRegistered = m.MDateRegistered;
        }

        /// <summary>
        /// For newly registered managers
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        public ManagerDTO(string username, string password, string fname, string lname)
        {
            Manager_ID = Guid.NewGuid();
            this.fname = fname;
            this.lname = lname;
            this.username = username;
            this.password = password;
            dateRegistered = DateTime.Now;
        }
    }
}

