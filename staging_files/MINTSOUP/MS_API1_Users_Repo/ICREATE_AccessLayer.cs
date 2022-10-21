using Models;

namespace MS_API1_Users_Repo
{
    public interface ICREATE_AccessLayer
    {
        Task<bool> CREATE_Admin_by_auth0ID(string? auth0ID, string? email);
        Task<bool> CREATE_aFollow_to_Show_with_showID(string? Auth0ID, Guid? FollowieID);
        Task<bool> CREATE_aFollow_to_Viewer_by_viewerID(string? auth0ID, Guid? followieID);
        Task<bool> CREATE_Friend_by_FriendieID(string? auth0ID, Guid? viewerID_Friendie);
        Task<bool> CREATE_myDonation_to_Show_by_ShowID(string? auth0ID, Guid? fk_showID_Subscribie, decimal? Amount, string Note);
        Task<bool> CREATE_myJoin_to_ShowSession_by_ShowSessionID(string? Auth0ID, Guid? ShowSessionID);
        Task<bool> CREATE_myLike_to_ShowComment_by_CommetID(string? auth0ID, Guid? showCommentID);
        Task<bool> CREATE_myShowSession_by_ShowID(string? auth0ID, Guid? showID);
        Task<bool> CREATE_myShow_by_auth0ID(string? auth0ID, string? showName, string? showImage, PrivacyLevel? privacyLevel);
        Task<bool> CREATE_mySubscription_to_Show_by_auth0ID_showID(string? auth0ID, Guid? showID, SubscriberMembershipStatus? MembershipStatus);
        Task<bool> CREATE_ShowComment_by_showSessionID(string? auth0ID, Guid? showSessionID_ShowCommentie, string? comment);
        Task<bool> CREATE_ShowLike_by_ShowSessionID(string? Auth0ID, Guid? ShowSessionID);
        /// <summary>
        /// This method registers a user as a viewer or a viewer AND admin if their email is in the list of admin
        /// </summary>
        /// <param name="auth0ID"></param>
        /// <param name="email"></param>
        /// <returns>returns a check status</returns>
        Task<CHECK_AccessLayer.CHECKSTATUS> CREATE_myViewer_by_auth0ID(string? auth0ID, string? email);
    }
}