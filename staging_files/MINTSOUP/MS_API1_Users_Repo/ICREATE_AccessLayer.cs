using Models;

namespace MS_API1_Users_Repo
{
    public interface ICREATE_AccessLayer
    {
        Task<bool> CREATE_Admin_by_MSToken(string? MSToken, string? email);
        Task<bool> CREATE_aFollow_to_Show_with_showID(string? MSToken, Guid? FollowieID);
        Task<bool> CREATE_aFollow_to_Viewer_by_viewerID(string? MSToken, Guid? followieID);
        Task<bool> CREATE_Friend_by_FriendieID(string? MSToken, Guid? viewerID_Friendie);
        Task<bool> CREATE_myDonation_to_Show_by_ShowID(string? MSToken, Guid? fk_showID_Subscribie, decimal? Amount, string Note);
        Task<bool> CREATE_myJoin_to_ShowSession_by_ShowSessionID(string? MSToken, Guid? ShowSessionID);
        Task<bool> CREATE_myLike_to_ShowComment_by_CommetID(string? MSToken, Guid? showCommentID);
        Task<bool> CREATE_myShowSession_by_ShowID(string? MSToken, Guid? showID);
        Task<bool> CREATE_myShow_by_MSToken(string? MSToken, string? showName, string? showImage, PrivacyLevel? privacyLevel);
        Task<bool> CREATE_mySubscription_to_Show_by_MSToken_showID(string? MSToken, Guid? showID, SubscriberMembershipStatus? MembershipStatus);
        Task<bool> CREATE_ShowComment_by_showSessionID(string? MSToken, Guid? showSessionID_ShowCommentie, string? comment);
        Task<bool> CREATE_ShowLike_by_ShowSessionID(string? MSToken, Guid? ShowSessionID);
        /// <summary>
        /// This method registers a user as a viewer or a viewer AND admin if their email is in the list of admin
        /// </summary>
        /// <param name="MSToken"></param>
        /// <param name="email"></param>
        /// <returns>returns a check status</returns>
        Task<CHECK_AccessLayer.CHECKSTATUS> CREATE_myViewer_by_MSToken(string? MSToken, string? email);
    }
}