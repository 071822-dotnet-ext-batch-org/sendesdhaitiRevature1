using Models;

namespace MS_API1_Users_Repo
{
    public interface IGET_AccessLayer
    {
        Task<Follower?> GET_aFollower_by_ViewerID_Followie(Guid? MSToken, Guid? FollowerID);
        Task<Friend?> GET_aFriend_by_ViewerID_Freinder(Guid? MSToken, Guid? FriendID);
        Task<List<Follower?>> GET_allFollowers(Guid? MSToken);
        Task<List<Friend?>> GET_allFriends(Guid? MSToken);
        Task<List<ShowCommentLike?>> GET_allLikes_of_ShowComment_by_showCommentID(Guid? MSToken, Guid? CommentID);
        Task<List<Wallet?>> GET_allPersonalWallets(Guid? MSToken);
        Task<List<ShowCommentLike?>> GET_allShowCommentLikes(Guid? MSToken);
        Task<List<ShowComment?>> GET_allShowComments(Guid? MSToken);
        Task<List<ShowDonation?>> GET_allShowDonations(Guid? MSToken);
        Task<List<ShowLikes?>> GET_allShowLikes(Guid? MSToken);
        Task<List<Show?>> GET_allShows(Guid? MSToken);
        Task<List<ShowSessionJoins?>> GET_allShowSessionJoins(Guid? MSToken);
        Task<List<ShowSession?>> GET_allShowSessions(Guid? MSToken);
        Task<List<ShowSubscriber?>> GET_allShowSubscriber(Guid? MSToken);
        Task<List<ShowWallet?>> GET_allShowWallets(Guid? MSToken);
        Task<List<Viewer?>> GET_allViewers(Guid? MSToken);
        Task<List<ShowSessionJoins?>> GET_all_of_my_Joins_of_ShowSession_by_showSessionID(Guid? MSToken, Guid? ShowSessionID);
        Task<ShowCommentLike?> GET_aShowCommentLike_by_ShowCommentID_with_MSToken(Guid? MSToken, Guid? CommentID);
        Task<ShowComment?> GET_aShowComment_by_ShowCommentID_with_MSToken(Guid? MSToken, Guid? commentID);
        Task<ShowDonation?> GET_aShowDonation_by_ShowDonationID_with_MSToken(Guid? MSToken, Guid? donationid);
        Task<ShowLikes?> GET_aShowLike_by_ShowSessionID_with_MSToken(Guid? MSToken, Guid? FK_ShowSessionID);
        Task<ShowSessionJoins?> GET_aShowSessionJoin_by_ShowSessionJoinID_with_MSToken(Guid? MSToken, Guid? SessionJoinID);
        Task<ShowSession?> GET_aShowSession_by_ShowSessionID_with_MSToken(Guid? MSToken, Guid? ShowSessionID);
        Task<Show?> GET_aShow_by_ShowID_with_MSToken(Guid? MSToken, Guid? showID);
        Task<ShowSubscriber?> GET_aSubscriber_by_SubscriberID_with_MSToken(Guid? MSToken, Guid? subscriberID);
        Task<Viewer?> GET_aViewer_by_aViewerID(Guid? ViewerID);
        Task<List<ShowLikes?>> GET_LikesOfShowSession_by_ShowSessionID(Guid? MSToken, Guid? ShowSessionID);
        Task<Admin?> GET_myAdmin_by_MSToken(Guid? MSToken);
        Task<List<Follower?>> GET_myFollowers_by_ViewerID_Follower(Guid? MSToken);
        Task<List<Friend?>> GET_myFriends_by_ViewerID_Freinder(Guid? MSToken);
        Task<ShowCommentLike?> GET_myLike_of_ShowComment_by_showCommentID(Guid? MSToken, Guid? CommentID);
        Task<Wallet?> GET_myPersonalWallet_by_viewerID(Guid? MSToken);
        Task<List<ShowComment?>> GET_myShowComments_by_ViewerID_Commenter(Guid? MSToken, Guid? ShowSessionID);
        Task<List<ShowDonation?>> GET_myShowDonations_by_ViewerID_Donater(Guid? MSToken);
        Task<List<ShowLikes?>> GET_myShowSessionsLikes_by_ShowSessionID(Guid? MSToken, Guid? showsessionID);
        Task<List<ShowSession?>> GET_myShowSessions_by_showID(Guid? MSToken, Guid? ShowID);
        Task<List<ShowSubscriber?>> GET_myShowSubscribers_by_ShowID_Subscriber(Guid? MSToken, Guid? ShowID);
        Task<List<ShowSubscriber?>> GET_myShowSubscriptions_by_ViewerID_Subscriber(Guid? MSToken);
        Task<List<ShowSubscriber?>> GET_aShowsSubscriptions_by_ShowID_Subscriber(Guid? showid);
        Task<List<Show?>> GET_myShows_by_ViewerID_Owner(Guid? MSToken);
        Task<ShowWallet?> GET_myShowWallet_by_viewer_AND_showID(Guid? MSToken, Guid? ShowID);
        Task<Viewer?> GET_myViewer_by_MSToken(Guid? MSToken);
    }
}