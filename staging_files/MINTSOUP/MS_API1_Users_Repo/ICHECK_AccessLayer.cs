namespace MS_API1_Users_Repo
{
    public interface ICHECK_AccessLayer
    {
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Admin_by_Email(string Email);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Admin_by_MSToken(Guid? MSToken);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Follow_by_FollowID_Follower(Guid? MSToken, Guid? FollowieViewerID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Friend_by_FriendID_Freinder(Guid? MSToken, Guid? FriendieViewerID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_Show_EXISTS_by_ShowName(string showName);
        Task<int> CHECK_if_there_are_ANY_CommentsOnShowSession(Guid? ShowSession);
        Task<int> CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken(Guid? MSToken);
        Task<int> CHECK_if_there_are_ANY_LikesOnShowComment(Guid? ShowComment);
        Task<int> CHECK_if_there_are_ANY_LikesOnShowSession(Guid? ShowSession);
        Task<int> CHECK_if_there_are_ANY_Shows(Guid? MSToken);
        Task<int> CHECK_if_there_are_ANY_ShowSessions(Guid? MSToken);
        Task<int> CHECK_if_there_are_ANY_ShowSessions_on_aShow(Guid? ShowID);
        Task<int> CHECK_if_there_are_ANY_Subscribers();
        Task<int> CHECK_if_this_SHOW_has_ANY_Subscribers(Guid? ShowId);
        Task<int> CHECK_if_YOU_have_ANY_Shows(Guid? MSToken);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_ANY_LikesOnShowSession(Guid? MSToken, Guid? ShowSession);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions(Guid? MSToken);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions_To_This_Show(Guid? MSToken, Guid? ShowID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_A_LikeOnShowComment(Guid? MSToken, Guid? ShowCommentID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_THIS_CommentOnShowSession(Guid? MSToken, Guid? CommentID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_THIS_Donation_to_a_Show(Guid? MSToken, Guid? ShowDonationID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_Own_the_personalWallet(Guid? MSToken, Guid? ViewersWalletID);
        Task<int> CHECK_if_YOU_Own_the_showsWallet(Guid? MSToken, Guid? ShowWalletID);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_Email(string Email);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_MSToken(Guid? MSToken);
        Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_viewerID(Guid? ViewerID);
    }
}