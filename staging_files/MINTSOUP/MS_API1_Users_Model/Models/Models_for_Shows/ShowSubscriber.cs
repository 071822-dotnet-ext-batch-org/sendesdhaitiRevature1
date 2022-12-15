using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new show subscription - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? subscribeDate)
    /// </summary>
    public class ShowSubscriber
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Subscriber {get;set;}
        public Guid? FK_ShowID_Subscribie {get;set;}
        public SubscriberMembershipStatus? MembershipStatus {get;set;}
        public DateTime? SubscribeDate {get;set;}
        public DateTime? SubscriptionUpdateDate {get;set;}

        /// <summary>
        /// This is the model to create a new show subscription that is empty - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? subscribeDate)
        /// </summary>
        public ShowSubscriber(){}

        /// <summary>
        /// This is the model to create a new show subscription - it needs (Guid? id, Guid? userID, Guid? showID, DateTime? subscribeDate)
        /// </summary>
        public ShowSubscriber(Guid? id, Guid? userID, Guid? showID, SubscriberMembershipStatus? membershipStatus, DateTime? subscribeDate, DateTime? subscriptionUpdateDate)
        {
            this.ID = id;
            this.FK_ViewerID_Subscriber = userID;
            this.FK_ShowID_Subscribie = showID;
            this.MembershipStatus = membershipStatus;
            this.SubscribeDate = subscribeDate;
            this.SubscriptionUpdateDate = subscriptionUpdateDate;
        }

    }
}