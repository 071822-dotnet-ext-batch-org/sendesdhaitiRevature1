using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Friend - it needs (Guid? id, Guid? viewerID_friender, Guid? viewerID_friendie, ViewerStatus? relationStatus, DateTime? befriendDate, DateTime? friendshipUpdateDate)
    /// </summary>
    public class Friend
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Friender {get;set;}
        public Guid? FK_ViewerID_Friendie {get;set;}
        public FriendShipStatus? FriendshipStatus {get;set;} 
        public DateTime? FriendDate {get;set;}
        public DateTime? FriendshipUpdateDate {get;set;}

        /// <summary>
        /// This is the model to create a new Friend - it needs (Guid? id, Guid? viewerID_friender, Guid? viewerID_friendie, ViewerStatus? relationStatus, DateTime? befriendDate, DateTime? friendshipUpdateDate)
        /// </summary>
        public Friend(){}

        /// <summary>
        /// This is the model to create a new Friend - it needs (Guid? id, Guid? viewerID_friender, Guid? viewerID_friendie, ViewerStatus? relationStatus, DateTime? befriendDate, DateTime? friendshipUpdateDate)
        /// </summary>
        public Friend(Guid? id, Guid? viewerID_friender, Guid? viewerID_friendie, FriendShipStatus? friendshipStatus, DateTime? befriendDate, DateTime? friendshipUpdateDate)
        {
            this.ID = id;
            this.FK_ViewerID_Friender = viewerID_friender;
            this.FK_ViewerID_Friendie = viewerID_friendie;
            this.FriendshipStatus = friendshipStatus;
            this.FriendDate = befriendDate;
            this.FriendshipUpdateDate = friendshipUpdateDate;
        }
    }
}