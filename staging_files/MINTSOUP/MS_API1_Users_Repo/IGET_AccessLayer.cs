using Models;
// using MS_API1_Users_Model;
namespace MS_API1_Users_Repo;

public interface IGET_AccessLayer
{
    Task<Follower?> GET_aFollower_by_ViewerID_Follower(string? MSToken, Guid? FollowerID,Guid? ViewerID_Follower);
    Task<Friend?> GET_aFriend_by_ViewerID_Freinder(string? MSToken, Guid? FriendID, Guid? viewerID_Friender);
    Task<List<Follower?>> GET_allFollowers(string? MSToken);
    Task<List<Friend?>> GET_allFriends(string? MSToken);
    Task<List<ShowCommentLike?>> GET_allLikes_of_ShowComment_by_showCommentID(string? MSToken, Guid? OBJ_ID);
    Task<List<Wallet?>> GET_allPersonalWallets(string? MSToken);
    Task<List<ShowCommentLike?>> GET_allShowCommentLikes(string? MSToken);
    Task<List<ShowComment?>> GET_allShowComments(string? MSToken);
    Task<List<ShowDonation?>> GET_allShowDonations(string? MSToken);
    Task<List<ShowLikes?>> GET_allShowLikes(string? MSToken);
    Task<List<Show?>> GET_allShows(string? MSToken);
    Task<List<ShowSessionJoins?>> GET_allShowSessionJoins(string? MSToken);
    Task<List<ShowSession?>> GET_allShowSessions(string? MSToken);
    Task<List<ShowSubscriber?>> GET_allShowSubscriber(string? MSToken);
    Task<List<ShowWallet?>> GET_allShowWallets(string? MSToken);
    Task<List<Viewer?>> GET_allViewers(string? MSToken);
    Task<ShowCommentLike?> GET_aShowCommentLike_by_ShowCommentLikeID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<ShowComment?> GET_aShowComment_by_ShowCommentID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<ShowDonation?> GET_aShowDonation_by_ShowDonationID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<ShowLikes?> GET_aShowLike_by_ShowLikeID_with_MSToken(string? MSToken, Guid? showLikeID);
    Task<ShowSessionJoins?> GET_aShowSessionJoin_by_ShowSessionJoinID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<ShowSession?> GET_aShowSession_by_ShowSessionID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<Show?> GET_aShow_by_ShowID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<ShowSubscriber?> GET_aSubscriber_by_SubscriberID_with_MSToken(string? MSToken, Guid? OBJ_ID);
    Task<Viewer?> GET_aViewer_by_aViewerID(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowSessionJoins?>> GET_Joins_of_ShowSession_by_showSessionID(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowLikes?>> GET_LikesOfShowSession_by_ShowSessionID(string? MSToken, Guid? OBJ_ID);
    Task<Admin?> GET_myAdmin_by_MSToken(string? MSToken);
    Task<List<Follower?>> GET_myFollowers_by_ViewerID_Follower(string? MSToken);
    Task<List<Friend?>> GET_myFriends_by_ViewerID_Freinder(string? MSToken);
    Task<ShowCommentLike?> GET_myLike_of_ShowComment_by_showCommentID(string? MSToken, Guid? OBJ_ID);
    Task<Wallet> GET_myPersonalWallet_by_viewerID(string? MSToken );
    Task<List<ShowComment?>> GET_myShowComments_by_ViewerID_Commenter(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowDonation?>> GET_myShowDonations_by_ViewerID_Donater(string? MSToken);
    Task<List<ShowLikes?>> GET_myShowSessionsLikes_by_ShowSessionID(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowSession?>> GET_myShowSessions_by_showID(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowSubscriber?>> GET_myShowSubscribers_by_ShowID_Subscriber(string? MSToken, Guid? OBJ_ID);
    Task<List<ShowSubscriber?>> GET_myShowSubscriptions_by_ViewerID_Subscriber(string? MSToken);
    Task<List<Show?>> GET_myShows_by_ViewerID_Owner(string? MSToken);
    Task<ShowWallet> GET_myShowWallet_by_viewer_AND_showID(string? MSToken, Guid? id_Of_walletOwner);
    Task<Viewer?> GET_myViewer_by_MSToken(string? MSToken);
}