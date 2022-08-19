using System;
namespace ModelLayer
{
    public class Manager : Employee
    {
        private Guid ManagerID { get; set; } = Guid.NewGuid();
        private string MFUsername { get; set; }
        private string MFPassword { get; set; }
        private string? MFname { get; set; }
        private string? MLname { get; set; }
        private Guid? FK_Ticket_ID { get; set; }

        private List<Ticket>? Tickets_for_Review { get; set; } 

        public Manager(){}

        /// <summary>
        /// WHen someone makes a new manager
        /// They will need a username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Manager(string username, string password)
        {
            this.ManagerID = Guid.NewGuid();
            this.MFUsername = username;
            this.MFPassword = password;
            this.MFname = null;
            this.MLname = null;
            this.FK_Ticket_ID = null;
            this.Tickets_for_Review = new List<Ticket>();

        }
    }
}

