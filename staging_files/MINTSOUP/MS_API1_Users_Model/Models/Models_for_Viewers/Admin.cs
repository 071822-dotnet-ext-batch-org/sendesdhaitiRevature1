using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Admin
    {
        //Not included in actual Admin Model
        private string? adminEmail_to_Verify = "sendes12@gmail.com";

        //Admin Model Properties
        public Guid? ID {get;set;}
        public string? Auth0ID {get;set;}
        public string? Email {get;set;}
        public string? Username {get;set;}
        public AdminStatus? AdminStatus {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? LastSignedIn {get;set;}

        public Admin(){}
        public Admin(Guid? id, string? auth0ID, string? email, string? username, AdminStatus? adminStatus, DateTime? dateCreated, DateTime? lastSignedIn)
        {
            this.ID = id;
            this.Auth0ID = auth0ID;
            this.Email = email;
            this.Username = username;
            this.AdminStatus = adminStatus;
            this.DateCreated = dateCreated;
            this.LastSignedIn = lastSignedIn;

        }

        
    }
}