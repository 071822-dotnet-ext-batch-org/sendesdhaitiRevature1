using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ShowSession
    {
        public Guid? ID {get;set;}
        public Guid? FK_ShowID {get;set;}
        public int? Views {get;set;}
        public int? Likes {get;set;}
        public int? Comments {get;set;}
        public DateTime? SessionStartDate {get;set;}
        public DateTime? SessionEndDate {get;set;}

        //Automatically generated for each Show session for front end
        // public int? Section {get;set;}
        // public int? MaxRows = 20;
        // public int? MaxSeatsPerRow = 20;
        public ShowSession(){}
        public ShowSession(Guid? id, Guid? fk_ShowID, Guid? fk_ViewerID_ShowViewer, int? views, int? likes, int? comments, DateTime? sessionDate, DateTime? sessionEndDate)
        {
            this.ID = id;
            this.FK_ShowID = fk_ShowID;
            this.Views = Views;
            this.Likes = likes;
            this.Comments = comments;

            this.SessionStartDate = sessionDate;
            this.SessionEndDate = sessionEndDate;
        }

    }
}