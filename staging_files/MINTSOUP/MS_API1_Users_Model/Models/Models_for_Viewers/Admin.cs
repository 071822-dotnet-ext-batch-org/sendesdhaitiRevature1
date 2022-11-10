using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// this is the model for an admin - it needs (Guid? id, string? MSToken, string? email, string? username, AdminStatus? adminStatus, DateTime? dateCreated, DateTime? lastSignedIn)
    /// </summary>
    public class Admin
    {
        public Guid? ID {get;set;}
        public string? MSToken {get;set;}
        public string? Email {get;set;}
        public string? Username {get;set;}
        public AdminStatus? AdminStatus {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? LastSignedIn {get;set;}
        /// <summary>
        /// this is the model for an admin - it needs (Guid? id, string? MSToken, string? email, string? username, AdminStatus? adminStatus, DateTime? dateCreated, DateTime? lastSignedIn)
        /// </summary>
        public Admin(){}
        /// <summary>
        /// this is the model for an admin - it needs (Guid? id, string? MSToken, string? email, string? username, AdminStatus? adminStatus, DateTime? dateCreated, DateTime? lastSignedIn)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MSToken"></param>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="adminStatus"></param>
        /// <param name="dateCreated"></param>
        /// <param name="lastSignedIn"></param>
        public Admin(Guid? id, string? MSToken, string? email, string? username, AdminStatus? adminStatus, DateTime? dateCreated, DateTime? lastSignedIn)
        {
            this.ID = id;
            this.MSToken = MSToken;
            this.Email = email;
            this.Username = username;
            this.AdminStatus = adminStatus;
            this.DateCreated = dateCreated;
            this.LastSignedIn = lastSignedIn;

        }

        
    }
}