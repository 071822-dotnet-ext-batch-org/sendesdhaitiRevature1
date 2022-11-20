using Models;

namespace MS_API1_Users_Repo
{
    public interface IUPDATE_AccessLayer
    {
        Task<bool> UPDATE_Admin_by_MSToken(Guid MSToken, string email, string username, AdminStatus adminStatus, DateTime lastSignedIn);
        Task<bool> UPDATE_aFollow_to_Show_by_ViewerID_Follower(Guid MSToken, Guid ShowID_Followie, FollowerStatus FollowerStatus);
        Task<bool> UPDATE_aFollow_to_Viewer_by_FollowieID_Follower(Guid MSToken, Guid ViewerID_Followie, FollowerStatus FollowerStatus);
        Task<bool> UPDATE_Friend_by_FriendieID_Friender(Guid MSToken, Guid viewerID_Friendie, FriendShipStatus relationshipStatus);
        Task<bool> UPDATE_myShowSubscription_by_SubscriptionID(Guid MSToken, Guid id, SubscriberMembershipStatus membershipStatus);
        Task<bool> UPDATE_myShow_by_showID(Guid MSToken, Guid showID, string showName, string showImage, int subscribers, int views, int likes, int comments, double rating, int rank, PrivacyLevel privacyLevel, ShowStanding showstanding, DateTime lastLive);
        Task<bool> UPDATE_ShowComment_by_ShowCommentID(Guid MSToken, Guid showCommentID, string comment);
        Task<bool> UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID(Guid MSToken, Guid id);
        Task<bool> UPDATE_ShowSession_by_SessionID(Guid id, int views, int likes, int comments);
        Task<bool> UPDATE_ShowSession_to_END_SESSION_by_SessionID(Guid id, int views, int likes, int comments, DateTime sessionEndDate);
        Task<bool> UPDATE_Viewer_by_MSToken(Guid MSToken, string fn, string ln, string email, string image, string username, string aboutMe, string streetAddy, string city, string state, string country, int areaCode, Role role, ViewerStatus membershipStatus, DateTime lastSignedIn);
    }
}