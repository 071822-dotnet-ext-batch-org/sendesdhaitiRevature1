using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Show Like - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? likeDate)
    /// </summary>
    public class ShowLikes
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Liker {get;set;}
        public Guid? FK_ShowID_Likie {get;set;}
        public Guid? FK_ShowSessionID {get;set;}
        public DateTime? LikeDate {get;set;}

        /// <summary>
        /// This is the model to create a new Show Like that is empty - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? likeDate)
        /// </summary>
        public ShowLikes(){}

        /// <summary>
        /// This is the model to create a new Show Like - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? likeDate)
        /// </summary>
        public ShowLikes(Guid? id, Guid? userID, Guid? showID, Guid? showSessionID, DateTime? likeDate)
        {
            this.ID = id;
            this.FK_ViewerID_Liker = userID;
            this.FK_ShowID_Likie = showID;
            this.FK_ShowSessionID = showSessionID;
            this.LikeDate = likeDate;
        }
    }
}