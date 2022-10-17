using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Show Donation - it needs (Guid? id, Guid? userID, Guid? showID, string? note, DateTime? donationDate)
    /// </summary>
    public class ShowDonation
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Donater {get;set;}
        public Guid? FK_ShowID_Donatie {get;set;}
        public decimal? Amount {get;set;}
        public string? Note {get;set;}
        public DateTime? DonationDate {get;set;}

        /// <summary>
        /// This is the model to create a new Show Donation that is empty - it needs (Guid? id, Guid? userID, Guid? showID, string? note, DateTime? donationDate)
        /// </summary>    
        public ShowDonation(){}

        /// <summary>
        /// This is the model to create a new Show Donation - it needs (Guid? id, Guid? userID, Guid? showID, string? note, DateTime? donationDate)
        /// </summary>
        public ShowDonation(Guid? id, Guid? userID, Guid? showID, decimal? amount, string? note, DateTime? donationDate)
        {
            this.ID = id;
            this.FK_ViewerID_Donater = userID;
            this.FK_ShowID_Donatie = showID;
            this.Amount = amount;
            this.Note = note;
            this.DonationDate = donationDate;
        }
    }
}