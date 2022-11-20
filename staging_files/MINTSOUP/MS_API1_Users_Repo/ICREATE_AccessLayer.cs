using Models;

namespace MS_API1_Users_Repo
{
    public interface ICREATE_AccessLayer
    {
        Task<bool> CREATE_Admin_by_MSToken(Guid MSToken, string email, string username);
        Task<bool> CREATE_aFollow_to_Show_with_showID(Guid MSToken, Guid FollowieID);
        Task<bool> CREATE_aFollow_to_Viewer_by_viewerID(Guid MSToken, Guid followieID);
        Task<bool> CREATE_Friend_by_FriendieID(Guid MSToken, Guid viewerID_Friendie);
        Task<bool> CREATE_myDonation_to_Show_by_ShowID(Guid MSToken, Guid fk_showID_Subscribie, decimal Amount, string Note);
        Task<bool> CREATE_myJoin_to_ShowSession_by_ShowSessionID(Guid MSToken, Guid ShowSessionID);
        Task<bool> CREATE_myLike_to_ShowComment_by_CommetID(Guid MSToken, Guid showCommentID);
        Task<bool> CREATE_myShowSession_by_ShowID(Guid MSToken, Guid showID);
        Task<bool> CREATE_myShow_by_MSToken(Guid MSToken, string showName, string showImage, PrivacyLevel privacyLevel);
        Task<bool> CREATE_mySubscription_to_Show_by_MSToken_showID(Guid MSToken, Guid showID, SubscriberMembershipStatus MembershipStatus);
        Task<bool> CREATE_ShowComment_by_showSessionID(Guid MSToken, Guid showSessionID_ShowCommentie, string comment);
        Task<bool> CREATE_ShowLike_by_ShowSessionID(Guid MSToken, Guid ShowSessionID);
    }
}