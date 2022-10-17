using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class GET_Admin_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public GET_Admin_with_auth0ID(){}
        public GET_Admin_with_auth0ID(string? auth0ID)
        {
            this.Auth0ID = auth0ID;
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer by auth0 ID - it needs (string? auth0ID)
    /// </summary>
    public class GET_with_anAuth0ID_DTO
    {
        public string? Auth0ID {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID that is empty - it needs (string? auth0ID)
        /// </summary>
        public GET_with_anAuth0ID_DTO(){}

        /// <summary>
        /// This is the model DTO for a viewer to get their own viewer by auth0 ID - it needs (string? auth0ID)
        /// </summary>
        public GET_with_anAuth0ID_DTO(string? auth0ID)
        {
            this.Auth0ID = auth0ID;
        }
    }

    public class GET_Friend_with_ViewerID_Friender
    {
        public string? Auth0ID {get;set;}
        public Guid? FriendID {get;set;}
        public Guid? FK_ViewerID_Friender {get;set;}
        public DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID that is empty - it needs (string? auth0ID, Guid? viewerID_Friender)
        /// </summary>
        public GET_Friend_with_ViewerID_Friender(){Console.WriteLine($"Friends list tried to be gotten at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID - it needs (string? auth0ID, Guid? viewerID_Friender)
        /// </summary>
        public GET_Friend_with_ViewerID_Friender( string? auth0ID, Guid? FriendID, Guid? viewerID_Friender)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_Friender = viewerID_Friender;
            Console.WriteLine($"Friends list gotten by Viewer ID number: '{FK_ViewerID_Friender}' at '{DateCreated}'");
        }

    }


    /// <summary>
    /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
    /// </summary>
    public class GET_aFollower_with_ViewerID_Follower
    {
        public string? Auth0ID {get;set;}
        public Guid? FollowerID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public DateTime? DateGotten = DateTime.Now;

        /// <summary>
        /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
        /// </summary>
        public GET_aFollower_with_ViewerID_Follower(){Console.WriteLine($"\n\tFriend is being friended at '{DateGotten}'\n");}

        /// <summary>
        /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
        /// </summary>
        public GET_aFollower_with_ViewerID_Follower(string? auth0ID, Guid? followerID,Guid? viewerID_Follower)
        {
            this.Auth0ID = auth0ID;
            this.FollowerID = followerID;
            this.ViewerID_Follower = viewerID_Follower;
            Console.WriteLine($"\n\tFriend is being friended at '{DateGotten}'\n");
        }

    }



    /// <summary>
    /// This is the model DTO to CREATE a viewer by auth0 ID - it needs (string? auth0ID, string? email)
    /// </summary>
    public class CREATE_Viewer_on_signUP_with_auth0ID_DTO
    {
        public string? Auth0ID {get;set;}
        public string? Email {get;set;}


        /// <summary>
        /// This is the model DTO to CREATE a viewer by auth0 ID that is empty - it needs (string? auth0ID, string? email)
        /// </summary>
        public CREATE_Viewer_on_signUP_with_auth0ID_DTO(){}

        /// <summary>
        /// This is the model DTO to CREATE a viewer by auth0 ID - it needs (string? auth0ID, string? email)
        /// </summary>
        public CREATE_Viewer_on_signUP_with_auth0ID_DTO(string? auth0ID, string? email)
        {
            this.Auth0ID = auth0ID;
            this.Email = email;
        }

        private bool checkEmail_if_it_is_a_newEmail_or_in_the_list_of_AdminEmails(string? email)
        {
            string[] list = {"sendes12@gmail.com".ToUpper()};
            if(list.Contains(email?.ToUpper())) return true;
            else return false;

        }
    }


    /// <summary>
    /// This is the model DTO to CREATE a viewer by auth0 ID - it needs (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? membershipStatus, DateTime? lastSignedIn)
    /// </summary>
    public class UPDATE_Viewer_with_anID_DTO
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
        public Role? Role {get;set;}
        public DateTime? LastSignedIn {get;set;}
        public ViewerStatus? MembershipStatus {get;set;}

        /// <summary>
        /// This is the model DTO to CREATE a viewer by auth0 ID that is empty - it needs (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? membershipStatus, DateTime? lastSignedIn)
        /// </summary>
        public UPDATE_Viewer_with_anID_DTO(){}

        /// <summary>
        /// This is the model DTO to CREATE a viewer by auth0 ID - it needs (Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? membershipStatus, DateTime? lastSignedIn)
        /// </summary>
        public UPDATE_Viewer_with_anID_DTO(Guid? ID, string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? membershipStatus, DateTime? lastSignedIn)
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
            this.MembershipStatus = membershipStatus;

            this.LastSignedIn = lastSignedIn;

        }
    }

    public class UPDATE_Admin_with_auth0ID
    {
        public Guid? ID {get;set;}
        public string? Auth0ID {get;set;}
        public string? Username {get;set;}
        public string? Email {get;set;}
        public AdminStatus? AdminStatus {get;set;}
        public DateTime? LastSignedIn {get;set;}
        public UPDATE_Admin_with_auth0ID(){}
        public UPDATE_Admin_with_auth0ID(Guid? id, string? auth0ID, string? username, string? email, AdminStatus? adminStatus, DateTime? lastSignedIn)
        {
            this.ID = id;
            this.Auth0ID = auth0ID;
            this.Username = username;
            this.Email = email;
            this.AdminStatus = adminStatus;
            this.LastSignedIn = lastSignedIn;
        }

    }
    public class MyFriends_with_ViewerID_Friender
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_Friender {get;set;}
        public DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID that is empty - it needs (string? auth0ID, Guid? viewerID_Friender)
        /// </summary>
        public MyFriends_with_ViewerID_Friender(){Console.WriteLine($"Friends list tried to be gotten at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID - it needs (string? auth0ID, Guid? viewerID_Friender)
        /// </summary>
        public MyFriends_with_ViewerID_Friender( string? auth0ID, Guid? viewerID_Friender)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_Friender = viewerID_Friender;
            Console.WriteLine($"Friends list gotten by Viewer ID number: '{FK_ViewerID_Friender}' at '{DateCreated}'");
        }

    }



    /// <summary>
    /// This is the model DTO for a viewer to unfriend someone - it needs (string? auth0ID, Guid? viewerID_Friender, Guid? viewerID_Friendie, ViewerStatus? relationshipStatus)
    /// </summary>
    public class CREATE_or_UPDATE_with_ViewerIDs_Friended_or_Unfriended
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_Friender {get;set;}
        public Guid? ViewerID_Friendie {get;set;}
        public ViewerStatus? RelationshipStatus {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID that is empty - it needs (string? auth0ID, Guid? viewerID_Friender, Guid? viewerID_Friendie, ViewerStatus? relationshipStatus)
        /// </summary>
        public CREATE_or_UPDATE_with_ViewerIDs_Friended_or_Unfriended(){Console.WriteLine($"Friend is being friended at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer by auth0 ID - it needs (string? auth0ID, Guid? viewerID_Friender, Guid? viewerID_Friendie, ViewerStatus? relationshipStatus)
        /// </summary>
        public CREATE_or_UPDATE_with_ViewerIDs_Friended_or_Unfriended(string? auth0ID, Guid? viewerID_Friender, Guid? viewerID_Friendie, ViewerStatus? relationshipStatus)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_Friender = viewerID_Friender;
            this.ViewerID_Friendie = viewerID_Friendie;
            this.RelationshipStatus = relationshipStatus;
            Console.WriteLine($"Friend_is_being_friended at '{DateCreated}'");
        }

    }

    /// <summary>
    /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
    /// </summary>
    public class MyFollowers_with_ViewerID_Follower
    {
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public DateTime? DateGotten = DateTime.Now;

        /// <summary>
        /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
        /// </summary>
        public MyFollowers_with_ViewerID_Follower(){Console.WriteLine($"\n\tFriend is being friended at '{DateGotten}'\n");}

        /// <summary>
        /// This model DTO is for a viewer to get thier list of followers - it needs (string? auth0ID, Guid? viewerID_Follower)
        /// </summary>
        public MyFollowers_with_ViewerID_Follower(string? auth0ID, Guid? viewerID_Follower)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_Follower = viewerID_Follower;
            Console.WriteLine($"\n\tFriend is being friended at '{DateGotten}'\n");
        }

    }




    /// <summary>
    /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
    /// </summary>
    public class CREATE_aFollow_to_Viewer_with_ViewerID
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public Guid? ViewerID_Followie {get;set;}
        public FollowerStatus? FollowerStatus {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_aFollow_to_Viewer_with_ViewerID(){Console.WriteLine($"Friend is being friended at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_aFollow_to_Viewer_with_ViewerID(string? auth0ID, Guid? viewerID_Follower, Guid? viewerID_Followie, FollowerStatus? followerStatus)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_Follower = viewerID_Follower;
            this.ViewerID_Followie = viewerID_Followie;
            this.FollowerStatus = followerStatus;
            Console.WriteLine($"Friend_is_being_friended at '{DateTime.Now}'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
    /// </summary>
    public class CREATE_aFollow_to_Show_with_ViewerID
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public Guid? ShowID_Followie {get;set;}
        public FollowerStatus? FollowerStatus {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_aFollow_to_Show_with_ViewerID(){Console.WriteLine($"Friend is being friended at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_aFollow_to_Show_with_ViewerID(string? auth0ID, Guid? viewerID_Follower, Guid? showID_Followie, FollowerStatus? followerStatus)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_Follower = viewerID_Follower;
            this.ShowID_Followie = showID_Followie;
            this.FollowerStatus = followerStatus;
            Console.WriteLine($"Friend_is_being_friended at '{DateTime.Now}'");
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
    /// </summary>
    public class UPDATE_aFollow_to_Viewer_with_ViewerID
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public Guid? ViewerID_Followie {get;set;}
        public FollowerStatus? FollowerStatus {get;set;}
        public DateTime? StatusUpdateDate = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public UPDATE_aFollow_to_Viewer_with_ViewerID(){Console.WriteLine($"Friend is being friended at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public UPDATE_aFollow_to_Viewer_with_ViewerID(string? auth0ID, Guid? id, Guid? viewerID_Follower, Guid? viewerID_Followie, FollowerStatus? followerStatus, DateTime? statusUpdateDate)
        {
            this.Auth0ID = auth0ID;
            this.ID = id;
            this.ViewerID_Follower = viewerID_Follower;
            this.ViewerID_Followie = viewerID_Followie;
            this.FollowerStatus = followerStatus;
            this.StatusUpdateDate = statusUpdateDate;
            Console.WriteLine($"Friend_is_being_friended at '{DateTime.Now}'");
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
    /// </summary>
    public class UPDATE_aFollow_to_Show_with_ViewerID
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ID {get;set;}
        public Guid? ViewerID_Follower {get;set;}
        public Guid? ShowID_Followie {get;set;}
        public FollowerStatus? FollowerStatus {get;set;}
        public DateTime? StatusUpdateDate = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public UPDATE_aFollow_to_Show_with_ViewerID(){Console.WriteLine($"Friend is being friended at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public UPDATE_aFollow_to_Show_with_ViewerID(string? auth0ID, Guid? id, Guid? viewerID_Follower, Guid? showID_Followie, FollowerStatus? followerStatus, DateTime? statusUpdateDate)
        {
            this.Auth0ID = auth0ID;
            this.ID = id;
            this.ViewerID_Follower = viewerID_Follower;
            this.ShowID_Followie = showID_Followie;
            this.FollowerStatus = followerStatus;
            this.StatusUpdateDate = statusUpdateDate;
            Console.WriteLine($"Friend_is_being_friended at '{DateTime.Now}'");
        }
    }

    public class GET_aShow_by_ShowID_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? ShowID {get;set;}
        public GET_aShow_by_ShowID_with_auth0ID(){}
        public GET_aShow_by_ShowID_with_auth0ID(string? auth0ID, Guid? showID)
        {
            this.Auth0ID = auth0ID;
            this.ShowID = showID;
        }
    }

    public class GET_aSubscriber_by_SubscriberID_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? SubscriberID {get;set;}
        public GET_aSubscriber_by_SubscriberID_with_auth0ID(){}
        public GET_aSubscriber_by_SubscriberID_with_auth0ID(string? auth0ID, Guid? subscriberID)
        {
            this.Auth0ID = auth0ID;
            this.SubscriberID = subscriberID;
        }
    }

    public class GET_aShowLike_by_ShowLikeID_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? ShowLikeID {get;set;}
        public GET_aShowLike_by_ShowLikeID_with_auth0ID(){}
        public GET_aShowLike_by_ShowLikeID_with_auth0ID(string? auth0ID, Guid? showLikeID)
        {
            this.Auth0ID = auth0ID;
            this.ShowLikeID = showLikeID;
        }
    }

    public class GET_anOBJ_by_1GUID_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? OBJID {get;set;}
        public GET_anOBJ_by_1GUID_with_auth0ID(){}
        public GET_anOBJ_by_1GUID_with_auth0ID(string? auth0ID, Guid? objID)
        {
            this.Auth0ID = auth0ID;
            this.OBJID = objID;
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
    /// </summary>
    public class CREATE_or_DEL_with_ViewerIDs_LikeShow_or_UnLikeShow
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_ShowLiker {get;set;}
        public Guid? ShowID_LikedShow {get;set;}
        public Guid? ShowSessionID_ShowLikie {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_or_DEL_with_ViewerIDs_LikeShow_or_UnLikeShow(){Console.WriteLine($"Friend is being friended at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs ( Auth0ID, ViewerID_Friender, ViewerID_Friendie)
        /// </summary>
        public CREATE_or_DEL_with_ViewerIDs_LikeShow_or_UnLikeShow(string? auth0ID, Guid? viewerID_ShowLiker, Guid? showID_LikedShow, Guid? showSessionID_ShowLikie)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_ShowLiker = viewerID_ShowLiker;
            this.ShowID_LikedShow = showID_LikedShow;
            this.ShowSessionID_ShowLikie = showSessionID_ShowLikie;
            Console.WriteLine($"Friend_is_being_friended at '{DateCreated}'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to create a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
    /// </summary>
    public class CREATE_with_ViewerIDs_CommentonShow
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_ShowCommenter {get;set;}
        public Guid? ShowID_ShowCommentie {get;set;}
        public Guid? ShowSessionID {get;set;}
        public string? Comment {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public CREATE_with_ViewerIDs_CommentonShow(){Console.WriteLine($"Comment is being written at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public CREATE_with_ViewerIDs_CommentonShow(string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID, string? comment)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_ShowCommenter = viewerID_ShowCommenter;
            this.ShowID_ShowCommentie = showID_CommentedShow;
            this.ShowSessionID = showSessionID;
            this.Comment = comment;
            Console.WriteLine($"Comment is being written at '{DateCreated}'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to update a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
    /// </summary>
    public class UPDATE_with_ViewerIDs_CommentonShow
    {
        
        public string? Auth0ID {get;set;}
        public Guid? CommentID_UpdatedComment {get;set;}
        public Guid? ViewerID_ShowCommenter {get;set;}
        public Guid? ShowSessionID_ShowCommentie {get;set;}
        public string? Comment {get;set;}
        public int? Likes {get;set;}
        public DateTime? CommentUpdateDate {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public UPDATE_with_ViewerIDs_CommentonShow(){Console.WriteLine($"Comment is being written at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public UPDATE_with_ViewerIDs_CommentonShow(string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showSessionID_ShowCommentie, Guid? commentID_UpdatedComment, string? comment, int? likes, DateTime? commentUpdateDate)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_ShowCommenter = viewerID_ShowCommenter;
            this.ShowSessionID_ShowCommentie = showSessionID_ShowCommentie;
            this.CommentID_UpdatedComment = commentID_UpdatedComment;
            this.Comment = comment;
            this.Likes = likes;
            this.CommentUpdateDate = commentUpdateDate;
            Console.WriteLine($"Comment is being updated at '{DateTime.Now}'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to delete a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie)
    /// </summary>
    public class DEL_with_ViewerIDs_RemoveCommentonShow
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_ShowCommenter {get;set;}
        public Guid? ShowSessionID_ShowCommentie {get;set;}
        public Guid? CommentID_UpdatedComment {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to delete a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie)
        /// </summary>
        public DEL_with_ViewerIDs_RemoveCommentonShow(){Console.WriteLine($"Comment is being written at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to delete a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie)
        /// </summary>
        public DEL_with_ViewerIDs_RemoveCommentonShow(string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showSessionID_ShowCommentie, Guid? commentID_UpdatedComment)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_ShowCommenter = viewerID_ShowCommenter;
            this.ShowSessionID_ShowCommentie = showSessionID_ShowCommentie;
            this.CommentID_UpdatedComment = commentID_UpdatedComment;
            Console.WriteLine($"Comment is being updated at '{DateCreated}'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to create/delete a like on a comment - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
    /// </summary>
    public class CREATE_or_DEL_with_ViewerIDs_LikeonComment_or_UnLikeonComment
    {
        
        public string? Auth0ID {get;set;}
        public Guid? ViewerID_ShowCommentLiker {get;set;}
        public Guid? ShowCommentID_ShowCommentLikie {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public CREATE_or_DEL_with_ViewerIDs_LikeonComment_or_UnLikeonComment(){Console.WriteLine($"Comment is being written at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to follow/unfollow someone - it needs (string? auth0ID, Guid? viewerID_ShowCommenter, Guid? showID_CommentedShow, Guid? showSessionID_ShowCommentie, string? comment)
        /// </summary>
        public CREATE_or_DEL_with_ViewerIDs_LikeonComment_or_UnLikeonComment(string? auth0ID, Guid? viewerID_ShowCommentLiker, Guid? showCommentID_ShowCommentLikie)
        {
            this.Auth0ID = auth0ID;
            this.ViewerID_ShowCommentLiker = viewerID_ShowCommentLiker;
            this.ShowCommentID_ShowCommentLikie = showCommentID_ShowCommentLikie;
            Console.WriteLine($"Comment is being written at '{DateCreated}'");
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
    /// </summary>
    public class CREATE_Show_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_Owner {get;set;}
        public string? ShowName {get;set;}
        public string? ShowImage {get;set;}
        public PrivacyLevel? PrivacyLevel {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
        /// </summary>
        public CREATE_Show_with_auth0ID(){Console.WriteLine($"Show is being created at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
        /// </summary>
        public CREATE_Show_with_auth0ID(string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_Owner = fk_viewerID_Owner;
            this.ShowName = showName;
            this.ShowImage = showImage;
            this.PrivacyLevel = privacyLevel;
            Console.WriteLine($"\n\tShow is being created at '{DateCreated}' by viewer with ID 'FK_ViewerID_Owner' as 'ShowName\n'");
        }
    }

    /// <summary>
    /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
    /// </summary>
    public class UPDATE_Show_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? ShowID {get;set;}
        public Guid? FK_ViewerID_Owner {get;set;}
        public string? ShowName {get;set;}
        public string? ShowImage {get;set;}
        public int? Views {get;set;}
        public int? Likes {get;set;}
        public int? Comments {get;set;}
        public double? Rating {get;set;}
        public int? Rank {get;set;}
        public PrivacyLevel? PrivacyLevel {get;set;}
        public ShowStanding? ShowStatus {get;set;}
        private DateTime DateCreated = DateTime.Now;
        public DateTime? LastLive {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
        /// </summary>
        public UPDATE_Show_with_auth0ID(){Console.WriteLine($"Show is being created at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Owner, string? showName, string? showImage, PrivacyLevel? privacyLevel)
        /// </summary>
        public UPDATE_Show_with_auth0ID(string? auth0ID, Guid? showID, Guid? fk_viewerID_Owner, string? showName, string? showImage, int? views, int? likes, int? comments, double? rating, int? rank, PrivacyLevel? privacyLevel, ShowStanding? showstanding, DateTime? lastLive)
        {
            this.Auth0ID = auth0ID;
            this.ShowID = showID;
            this.FK_ViewerID_Owner = fk_viewerID_Owner;
            this.ShowName = showName;
            this.ShowImage = showImage;
            this.Views = views;
            this.Likes = likes;
            this.Comments = comments;
            this.Rating = rating;
            this.Rank = rank;
            this.PrivacyLevel = privacyLevel;
            this.ShowStatus = showstanding;
            this.LastLive = lastLive;
            Console.WriteLine($"\n\tShow is being created at '{DateCreated}' by viewer with ID 'FK_ViewerID_Owner' as 'ShowName\n'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
    /// </summary>
    public class CREATE_or_UPDATE_ShowSubscriber_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_Subscriber {get;set;}
        public Guid? FK_ShowID_Subscribie {get;set;}
        public Guid? FK_ShowSessionID {get;set;}
        public ViewerStatus? MembershipStatus {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public CREATE_or_UPDATE_ShowSubscriber_with_auth0ID(){Console.WriteLine($"Show is being created at '{DateTime.Now}'");}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public CREATE_or_UPDATE_ShowSubscriber_with_auth0ID(string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_Subscriber = fk_viewerID_Subscriber;
            this.FK_ShowID_Subscribie = fk_showID_Subscribie;
            this.FK_ShowSessionID = fk_showSessionID;
            this.MembershipStatus = membershipStatus;
            Console.WriteLine($"\n\tShow is being created at '{DateTime.Now}' by viewer with ID 'FK_ViewerID_Owner' as 'ShowName\n'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
    /// </summary>
    public class UPDATE_ShowSubscriber_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? SubscriberID {get;set;}
        public Guid? FK_ViewerID_Subscriber {get;set;}
        public Guid? FK_ShowID_Subscribie {get;set;}
        
        public ViewerStatus? MembershipStatus {get;set;}
        private DateTime DateCreated = DateTime.Now;
        public DateTime? SubscriptionUpdateDate {get;set;}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public UPDATE_ShowSubscriber_with_auth0ID(){Console.WriteLine($"Show is being created at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public UPDATE_ShowSubscriber_with_auth0ID(Guid? subscriberID, string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, ViewerStatus? membershipStatus, DateTime? subscriptionUpdateDate)
        {
            this.Auth0ID = auth0ID;
            this.SubscriberID = subscriberID;
            this.FK_ViewerID_Subscriber = fk_viewerID_Subscriber;
            this.FK_ShowID_Subscribie = fk_showID_Subscribie;
            this.MembershipStatus = membershipStatus;
            this.SubscriptionUpdateDate = subscriptionUpdateDate;
            Console.WriteLine($"\n\tShow is being created at '{DateCreated}' by viewer with ID 'FK_ViewerID_Owner' as 'ShowName\n'");
        }
    }


    /// <summary>
    /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
    /// </summary>
    public class CREATE_ShowDonation_with_auth0ID
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ViewerID_Donater {get;set;}
        public Guid? FK_ShowID_Donatie {get;set;}
        public decimal? Amount {get;set;}
        public string? Note {get;set;}
        private DateTime DateCreated = DateTime.Now;

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public CREATE_ShowDonation_with_auth0ID(){Console.WriteLine($"Show is being created at '{DateCreated}'");}

        /// <summary>
        /// This is the model DTO for a viewer to create/update a show subscription by auth0 ID - it needs (string? auth0ID, Guid? fk_viewerID_Subscriber, Guid? fk_showID_Subscribie, Guid? fk_showSessionID, ViewerStatus? membershipStatus)
        /// </summary>
        public CREATE_ShowDonation_with_auth0ID(string? auth0ID, Guid? fk_viewerID_Donater, Guid? fk_showID_Donatie, decimal? amount, string? note)
        {
            this.Auth0ID = auth0ID;
            this.FK_ViewerID_Donater = fk_viewerID_Donater;
            this.FK_ShowID_Donatie = fk_showID_Donatie;
            this.Amount = amount;
            this.Note = note;
            Console.WriteLine($"\n\tShow is being created at '{DateCreated}' by viewer with ID 'FK_ViewerID_Owner' as 'ShowName\n'");
        }
    }

    public class CREATE_or_UPDATE_ShowSession_with_showID
    {
        public string? Auth0ID {get;set;}
        public Guid? ID {get;set;}
        public Guid? FK_ShowID {get;set;}
        public int? Views {get;set;}
        public int? Likes {get;set;}
        public int? Comments {get;set;}
        public DateTime? SessionEndDate {get;set;}
        public CREATE_or_UPDATE_ShowSession_with_showID(){}
        public CREATE_or_UPDATE_ShowSession_with_showID(string? auth0ID, Guid? fk_ShowID)
        {
            this.Auth0ID = auth0ID;
            this.FK_ShowID = fk_ShowID;
        }
        public CREATE_or_UPDATE_ShowSession_with_showID(string? auth0ID, Guid? id, Guid? fk_ShowID, int? views, int? likes, int? comments, DateTime? sessionEndDate)
        {
            this.Auth0ID = auth0ID;
            this.ID = id;
            this.FK_ShowID = fk_ShowID;
            this.Views = views;
            this.Likes = likes;
            this.Comments = comments;
            this.SessionEndDate = sessionEndDate;
        }
    }


    public class CREATE_ShowSessionJoin_with_showSessionID
    {
        public string? Auth0ID {get;set;}
        public Guid? FK_ShowSessionID {get;set;}
        public Guid? FK_ViewerID_ShowViewer {get;set;}
        public CREATE_ShowSessionJoin_with_showSessionID(){}
        public CREATE_ShowSessionJoin_with_showSessionID(string? auth0ID, Guid? fk_showSessionID, Guid? fk_viewerID)
        {
            this.Auth0ID = auth0ID;
            this.FK_ShowSessionID = fk_showSessionID;
            this.FK_ViewerID_ShowViewer = fk_viewerID;
        }
    }

    public class UPDATE_ShowSessionJoin_with_showSessionID
    {
        public string? Auth0ID {get;set;}
        public Guid? ID {get;set;}
        public Guid? FK_ShowSessionID {get;set;}
        public Guid? FK_ViewerID_ShowViewer {get;set;}
        public DateTime? SessionLeaveDate {get;set;}
        public UPDATE_ShowSessionJoin_with_showSessionID(){}
        public UPDATE_ShowSessionJoin_with_showSessionID(string? auth0ID, Guid? id, Guid? fk_showSessionID, Guid? fk_viewerID, DateTime? sessionLeaveDate)
        {
            this.Auth0ID = auth0ID;
            this.ID = id;
            this.FK_ShowSessionID = fk_showSessionID;
            this.FK_ViewerID_ShowViewer = fk_viewerID;
            this.SessionLeaveDate = sessionLeaveDate;
        }
    }


}