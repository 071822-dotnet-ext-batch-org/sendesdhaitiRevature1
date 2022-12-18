using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Show - A Show must have (Guid? id, Guid? ownerID, string? showname, int? views, double? rating, int? rank,  DateTime? dateCreated, DateTime? lastLive, PrivacyLevel? privacyLevel, List<Follower?>? subscribers, List<ShowLikes?>? likes, List<ShowComment?>? comments, List<ShowDonation?>? donations)
    /// </summary>
    public class Show
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Owner {get;set;}
        public string? ShowName {get;set;}
        public string? ShowImage {get;set;}
        public int? SubscribersCount {get;set;}
        public int? Views {get;set;}
        public int? Likes {get;set;}
        public int? Comments {get;set;}
        public double? Rating {get;set;}
        public int? Rank {get;set;}
        
        public PrivacyLevel? PrivacyLevel {get;set;}
        public ShowStanding? ShowStatus {get;set;}
        public DateTime? DateCreated {get;set;}
        public DateTime? LastLive {get;set;}

        public List<ShowSession?> Sessions { get; set; } = new List<ShowSession?>();
        public List<ShowSessionJoins?> SessionJoins { get; set; } = new List<ShowSessionJoins?>();
        public List<ShowSubscriber?> Subscribers { get; set; } = new List<ShowSubscriber?>();
        public List<Follower?> Followers { get; set; } = new List<Follower?>();
        public List<ShowLikes?> ShowLikes { get; set; } = new List<ShowLikes?>();
        public List<ShowComment?> ShowComments { get; set; } = new List<ShowComment?>();
        public List<ShowDonation?> Donations { get; set; } = new List<ShowDonation?>();

        //Constructors
        /// <summary>
        /// This is the model to create a new Show that is empty - A Show must have (Guid? id, Guid? ownerID, string? showname, int? views, double? rating, int? rank,  DateTime? dateCreated, DateTime? lastLive, PrivacyLevel? privacyLevel, List<Follower?>? subscribers, List<ShowLikes?>? likes, List<ShowComment?>? comments, List<ShowDonation?>? donations)
        /// </summary>
        public Show(){}

        /// <summary>
        /// This is the model to create a new Show - A Show must have (Guid? id, Guid? ownerID, string? showname, int? views, double? rating, int? rank,  DateTime? dateCreated, DateTime? lastLive, PrivacyLevel? privacyLevel, List<Follower?>? subscribers, List<ShowLikes?>? likes, List<ShowComment?>? comments, List<ShowDonation?>? donations)
        /// </summary>
        public Show(Guid? id, Guid? ownerID, string? showname, string? showImage, int? subscribersCount, int? views, int? likes, int? comments, double? rating, int? rank, PrivacyLevel? privacyLevel, ShowStanding? showStatus, DateTime? dateCreated, DateTime? lastLive,
            List<ShowSession?> sessions, List<ShowSessionJoins?> sessionJoins, List<ShowSubscriber?> subscribers, List<Follower?> followers, List<ShowLikes?> showLikes, List<ShowComment?> showComments, List<ShowDonation?> donations)
        {
            //shows properties
            this.ID = id;
            this.FK_ViewerID_Owner = ownerID;
            this.ShowName = showname;
            this.ShowImage = showImage;
            this.SubscribersCount = subscribersCount;
            this.Views = views;
            this.Likes = likes;
            this.Comments = comments;
            this.Rating = rating;
            this.Rank = rank;
            this.PrivacyLevel = privacyLevel;
            this.ShowStatus = showStatus;
            this.DateCreated = dateCreated;
            this.LastLive = lastLive;

            //properties connected to viewers
            this.Sessions = sessions;
            this.SessionJoins = sessionJoins;
            this.Followers = followers;
            this.Subscribers = subscribers;
            this.ShowLikes = showLikes;
            this.ShowComments = showComments;
            this.Donations = donations;
        }


    }

    /// <summary>
    /// This enum is to describe the show standing status
    /// </summary>
    public enum ShowStanding
    {
        Pending,
        Great,
        Good,
        Moderate,
        Bad,
        Deactivated,
        Banned
    }
}