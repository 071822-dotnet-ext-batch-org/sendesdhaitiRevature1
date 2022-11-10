// using MS_API1_Users_Model;
namespace MS_API1_Users_Repo;

public interface ICHECK_AccessLayer
{
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Admin_by_MSToken(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Admin_by_Email(string? Email);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Follow_by_FollowID_Follower(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Friend_by_FriendID_Freinder(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_Show_EXISTS_by_ShowName(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_CommentsOnShowSession(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_LikesOnShowComment(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_LikesOnShowSession(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_Shows(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_ShowSessions(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_ShowSessions_on_aShow(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_there_are_ANY_Subscribers(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOURSHOW_has_ANY_Subscribers(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_have_ANY_Shows(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_ANY_LikesOnShowSession(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_A_LikeOnShowComment(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_THIS_CommentOnShowSession(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_made_THIS_Donation_to_a_Show(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_Own_the_personalWallet(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_if_YOU_Own_the_storesWallet(string? MSToken, Guid? OBJID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_MSToken(string? MSToken);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_viewerID(string? MSToken, Guid? ViewerID);
    Task<CHECK_AccessLayer.CHECKSTATUS> CHECK_Viewer_by_Email(string? Email);
}
