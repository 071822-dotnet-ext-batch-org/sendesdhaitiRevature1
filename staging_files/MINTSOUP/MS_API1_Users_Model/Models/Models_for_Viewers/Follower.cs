using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new follower - it needs (Guid? id, Guid? viewerID_follower, Guid? viewerID_followie, ViewerStatus? friendshipStatus, DateTime? followDate, DateTime? statusUpdateDate)
    /// </summary>
    public class Follower
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Follower {get;set;}
        public Guid? FK_ViewerID_Followie {get;set;}
        public Guid? FK_ShowID_Followie {get;set;}
        public FollowerStatus? FollowerStatus {get;set;}

        public DateTime? FollowDate {get;set;}
        public DateTime? StatusUpdateDate {get;set;}
        
        /// <summary>
        /// This is the model to create a new follower - it needs (Guid? id, Guid? viewerID_follower, Guid? viewerID_followie, ViewerStatus? friendshipStatus, DateTime? followDate, DateTime? statusUpdateDate)
        /// </summary>
        public Follower(){}

        /// <summary>
        /// This is the model to create a new follower - it needs (Guid? id, Guid? viewerID_follower, Guid? viewerID_followie, ViewerStatus? friendshipStatus, DateTime? followDate, DateTime? statusUpdateDate)
        /// </summary>
        public Follower(Guid? id, Guid? viewerID_follower, Guid? viewerID_followie, Guid? fk_showID_Followie, FollowerStatus? followerStatus, DateTime? followDate, DateTime? statusUpdateDate)
        {
            this.ID = id;
            this.FK_ViewerID_Follower = viewerID_follower;
            this.FK_ViewerID_Followie = viewerID_followie;
            this.FK_ShowID_Followie =fk_showID_Followie;
            this.FollowerStatus = followerStatus;
            this.FollowDate = followDate;
            this.StatusUpdateDate = statusUpdateDate;
        }
    }
}