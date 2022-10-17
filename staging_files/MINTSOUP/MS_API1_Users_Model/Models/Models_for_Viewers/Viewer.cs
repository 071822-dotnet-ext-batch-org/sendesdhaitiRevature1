using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Viewer - A viewer must have (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image,  string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? status, List<Friend?>? listOfFriends, List<Follower?>? listOfFollowers, List<Show?>? listOfCreatedShows, List<ShowSubscriber?>? listOfSubsrcibedShows, List<ShowLikes?>? listOfShowLikes, List<ShowComment?>? listOfShowComments, List<ShowDonation?>? listOfShowDonations)
    /// </summary>
    public class Viewer
    {
        //What the User Needs
        public Guid? ID {get;set;}
        public string? Auth0ID {get;set;}
        public string? Fn {get;set;}
        public string? Ln {get;set;}
        public string? Email {get;set;}
        public string? Image {get;set;}
        public string? Username {get;set;}
        public string? AboutMe {get;set;}
        public string? StreetAddy {get;set;}
        public string? City {get;set;}
        public string? State {get;set;}
        public string? Country {get;set;}
        public int? AreaCode {get;set;}
        
        public Role Role {get;set;}
        public ViewerStatus MembershipStatus {get;set;}
        
        public DateTime? DateSignedUp {get;set;}
        public DateTime? LastSignedIn {get;set;}

        List<Friend?> ListOfFriends {get;set;}
        List<Follower?> ListOfFollowers {get;set;}
        List<Show?> ListOfCreatedShows {get;set;}
        List<ShowSubscriber?> ListOfSubsrcibedShows {get;set;}
        List<ShowLikes?> ListOfShowLikes {get;set;}
        List<ShowComment?> ListOfShowComments {get;set;}
        List<ShowDonation?> ListOfShowDonations {get;set;}

        //Constructors
        /// <summary>
        /// This is the model to create a new Viewer that is empty - A viewer must have (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image,  string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? status, List<Friend?>? listOfFriends, List<Follower?>? listOfFollowers, List<Show?>? listOfCreatedShows, List<ShowSubscriber?>? listOfSubsrcibedShows, List<ShowLikes?>? listOfShowLikes, List<ShowComment?>? listOfShowComments, List<ShowDonation?>? listOfShowDonations)
        /// </summary>
        public Viewer()
        {
            Role = Role.Viewer;
            MembershipStatus = ViewerStatus.Guest;
            ListOfFriends = new List<Friend?>();
            ListOfFollowers = new List<Follower?>();
            ListOfCreatedShows = new List<Show?>();
            ListOfSubsrcibedShows = new List<ShowSubscriber?>();
            ListOfShowLikes = new List<ShowLikes?>();
            ListOfShowComments = new List<ShowComment?>();
            ListOfShowDonations = new List<ShowDonation?>();
        }

        public Viewer(Guid? id) :this()
        {
            this.ID = id;
        }

        public Viewer(string? auth0id) :this()
        {
            this.Auth0ID = auth0id;
        }

        /// <summary>
        /// This is the model to create a new Viewer - A viewer must have (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image,  string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? status, List<Friend?>? listOfFriends, List<Follower?>? listOfFollowers, List<Show?>? listOfCreatedShows, List<ShowSubscriber?>? listOfSubsrcibedShows, List<ShowLikes?>? listOfShowLikes, List<ShowComment?>? listOfShowComments, List<ShowDonation?>? listOfShowDonations)
        /// </summary>
        public Viewer(Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image,  string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role role, ViewerStatus status, List<Friend?> listOfFriends, List<Follower?> listOfFollowers, List<Show?> listOfCreatedShows, List<ShowSubscriber?> listOfSubsrcibedShows, List<ShowLikes?> listOfShowLikes, List<ShowComment?> listOfShowComments, List<ShowDonation?> listOfShowDonations)
        {
            this.ID = ID;
            this.Auth0ID = auth0ID;
            this.Fn = fn;
            this.Ln = ln;
            this.Email = email;
            this.Image = image;
            this.Username = username;
            this.AboutMe = aboutMe;
            this.StreetAddy = streetAddy;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.AreaCode = areaCode;
            this.Role = role;
            this.MembershipStatus = status;
            this.ListOfFriends = listOfFriends;
            this.ListOfFollowers = listOfFollowers;
            this.ListOfCreatedShows = listOfCreatedShows;
            this.ListOfSubsrcibedShows = listOfSubsrcibedShows;
            this.ListOfShowLikes = listOfShowLikes;
            this.ListOfShowComments = listOfShowComments;
            this.ListOfShowDonations = listOfShowDonations;
        }


        /// <summary>
        /// To check if the object passed into the method is a Viewer Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public new bool Equals(object? obj)
        {
            return obj is Viewer viewer &&
                   EqualityComparer<Guid?>.Default.Equals(ID, viewer.ID) &&
                   Auth0ID == viewer.Auth0ID &&
                   Fn == viewer.Fn &&
                   Ln == viewer.Ln &&
                   Email == viewer.Email &&
                   Image == viewer.Image &&
                   Username == viewer.Username &&
                   AboutMe == viewer.AboutMe &&
                   StreetAddy == viewer.StreetAddy &&
                   City == viewer.City &&
                   State == viewer.State &&
                   Country == viewer.Country &&
                   AreaCode == viewer.AreaCode &&
                   Role == viewer.Role &&
                   MembershipStatus == viewer.MembershipStatus &&
                   DateSignedUp == viewer.DateSignedUp &&
                   LastSignedIn == viewer.LastSignedIn &&
                   EqualityComparer<List<Friend?>>.Default.Equals(ListOfFriends, viewer.ListOfFriends) &&
                   EqualityComparer<List<Follower?>>.Default.Equals(ListOfFollowers, viewer.ListOfFollowers) &&
                   EqualityComparer<List<Show?>>.Default.Equals(ListOfCreatedShows, viewer.ListOfCreatedShows) &&
                   EqualityComparer<List<ShowSubscriber?>>.Default.Equals(ListOfSubsrcibedShows, viewer.ListOfSubsrcibedShows) &&
                   EqualityComparer<List<ShowLikes?>>.Default.Equals(ListOfShowLikes, viewer.ListOfShowLikes) &&
                   EqualityComparer<List<ShowComment?>>.Default.Equals(ListOfShowComments, viewer.ListOfShowComments) &&
                   EqualityComparer<List<ShowDonation?>>.Default.Equals(ListOfShowDonations, viewer.ListOfShowDonations);
        }
    }

    /// <summary>
    /// This is the role that determines the user's privledges 
    /// </summary>
    public enum Role
    {
        Viewer, //Viewer
        Host, //Viewer and Show Owner
        Admin, //Admin

    }
    /// <summary>
    /// This is the relationship/membership status of a viewer
    /// </summary>
    public enum ViewerStatus {
        Guest, // A viewer without an account
        Viewer, // ALL VIEWERS THAT ARENT EXCLUSIVEMEMBERS viewer to show
    }

    public enum AdminStatus {
        NonAdmin,
        Admin
    }

    public enum FollowerStatus {
        UnFollowed, // a viewer that is an unfollowed follower - un followed
        NonFollower, // a viewer that has never been your follower
        Follower, // a viewer that is your follower - following
    }

    public enum FriendShipStatus {
        UnFriended, // viewer that is no longer your friend
        PendingFriend, // viewer is waiting to have friend request responded to
        Friend, // viewer that is your friend - 
    }

    public enum SubscriberMembershipStatus {
        UnSubscribed, // viewer that has unsubscribed to your show - become unsubscribed if you subscribe again
        Subscriber, // viewer that is your subscriber - become subsriber after subscribing to a show
        PremiumMember, // viewer that is your Premium Member - become a premium member by buying show premium membership
        ExclusiveMember // HAVE ACCESS TO viewer that is an exclusive Tier member - by paying for MINT SOUP Membership
    }

    /// <summary>
    /// This is the role that determines the user's privledges 
    /// </summary>
    public enum PrivacyLevel
    {
        Private, //only viewable you you
        Exclusive, //only viewable by you and friends and followers
        Public, //viewable by anyone
    }

}