using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MS_API1_Users_Repo
{
    public class Users_Viewer_UPDATE_AccessLayer
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public Users_Viewer_UPDATE_AccessLayer(IConfiguration config)
        {
            _config = config;

            
            if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
            {
                _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
            }
            else
            {
                _conn = new SqlConnection(_config["ConnectionStrings:ProductionString"]);
            }    

        }

//-----------------------UPDATE VIEWER SECTION---------------------
    public async Task<bool> UPDATE_Viewer_by_auth0ID(Models.UPDATE_Viewer_with_anID_DTO? updateViewerDTO)
    {
        if(updateViewerDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Viewers SET Fn = @Fn, Ln = @Ln, Email = @Email, Image = @Image, Username = @Username, AboutMe = @AboutMe, StreetAddy = @StreetAddy, City = @City, State = @State, Country = @Country, AreaCode = @AreaCode, Role = @Role, MembershipStatus = @MembershipStatus, LastSignedIn = @LastSignedIn Where ID = @ID AND Auth0ID = @Auth0ID ", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", updateViewerDTO?.Auth0ID);
                command.Parameters.AddWithValue("@ID", updateViewerDTO?.ID);
                command.Parameters.AddWithValue("@Fn", updateViewerDTO?.Fn);
                command.Parameters.AddWithValue("@Ln", updateViewerDTO?.Ln);
                command.Parameters.AddWithValue("@Email", updateViewerDTO?.Email);
                command.Parameters.AddWithValue("@Image", updateViewerDTO?.Image);
                command.Parameters.AddWithValue("@Username", updateViewerDTO?.Username);
                command.Parameters.AddWithValue("@AboutMe", updateViewerDTO?.AboutMe);
                command.Parameters.AddWithValue("@StreetAddy", updateViewerDTO?.StreetAddy);
                command.Parameters.AddWithValue("@City", updateViewerDTO?.City);
                command.Parameters.AddWithValue("@State", updateViewerDTO?.State);
                command.Parameters.AddWithValue("@Country", updateViewerDTO?.Country);
                command.Parameters.AddWithValue("@AreaCode", updateViewerDTO?.AreaCode);
                command.Parameters.AddWithValue("@Role", updateViewerDTO?.Role.ToString());
                command.Parameters.AddWithValue("@MembershipStatus", updateViewerDTO?.MembershipStatus.ToString());
                command.Parameters.AddWithValue("@LastSignedIn", updateViewerDTO?.LastSignedIn);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_Viewer_by_auth0ID

//-----------------------UPDATE ADMIN SECTION---------------------
    public async Task<bool> UPDATE_Admin_by_auth0ID(Models.UPDATE_Admin_with_auth0ID? createAdminDTO)
    {
        if(createAdminDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Admins SET Email = @Email, Username = @Username, AdminStatus = @AdminStatus, LastSignedIn = @LastSignedIn) WHERE ID = @ID AND Auth0ID = @Auth0ID", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", createAdminDTO?.Auth0ID);
                command.Parameters.AddWithValue("@ID", createAdminDTO?.ID);
                command.Parameters.AddWithValue("@Email", createAdminDTO?.Email);
                command.Parameters.AddWithValue("@Username", createAdminDTO?.Username);
                command.Parameters.AddWithValue("@AdminStatus", createAdminDTO?.AdminStatus);
                command.Parameters.AddWithValue("@LastSignedIn", createAdminDTO?.LastSignedIn);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_Admin_by_auth0ID

//-----------------------UPDATE FRIEND SECTION---------------------
    public async Task<bool> UPDATE_Friend_by_ViewerID_Friender(Models.CREATE_or_UPDATE_with_ViewerIDs_Friended_or_Unfriended? create_update_FriendDTO)
    {
        if((create_update_FriendDTO?.ViewerID_Friender != null) && (create_update_FriendDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Friends SET FriendshipStatus = @FriendshipStatus, FriendUpdateDate = @FriendUpdateDate WHERE FK_ViewerID_Friender = @FK_ViewerID_Friender AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Friender", create_update_FriendDTO?.ViewerID_Friender);
                command.Parameters.AddWithValue("@FK_ViewerID_Friendie", create_update_FriendDTO?.ViewerID_Friendie);
                command.Parameters.AddWithValue("@FriendshipStatus", create_update_FriendDTO?.RelationshipStatus);
                command.Parameters.AddWithValue("@FriendUpdateDate", DateTime.Now);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_Friend_by_ViewerID_Friender

//-----------------------UPDATE FOLLOWER SECTION---------------------
    public async Task<bool> UPDATE_aFollow_to_Viewer_by_ViewerID_Follower(Models.UPDATE_aFollow_to_Viewer_with_ViewerID? create_update_FollowDTO)
    {
        if((create_update_FollowDTO?.ViewerID_Follower != null) && (create_update_FollowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = @StatusUpdateDate WHERE FK_ViewerID_Follower = @FK_ViewerID_Follower AND FK_ViewerID_Followie = @FK_ViewerID_Followie AND ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", create_update_FollowDTO?.ID);
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", create_update_FollowDTO?.ViewerID_Follower);
                command.Parameters.AddWithValue("@FK_ViewerID_Followie", create_update_FollowDTO?.ViewerID_Followie);
                command.Parameters.AddWithValue("@FollowerStatus", create_update_FollowDTO?.FollowerStatus.ToString());
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_aFollow_to_Viewer_by_ViewerID_Follower

    public async Task<bool> UPDATE_aFollow_to_Show_by_ViewerID_Follower(Models.UPDATE_aFollow_to_Show_with_ViewerID? create_update_FollowDTO)
    {
        if((create_update_FollowDTO?.ViewerID_Follower != null) && (create_update_FollowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = @StatusUpdateDate WHERE FK_ViewerID_Follower = @FK_ViewerID_Follower AND ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", create_update_FollowDTO?.ID);
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", create_update_FollowDTO?.ViewerID_Follower);
                command.Parameters.AddWithValue("@FK_ViewerID_Followie", create_update_FollowDTO?.ShowID_Followie);
                command.Parameters.AddWithValue("@FollowerStatus", create_update_FollowDTO?.FollowerStatus.ToString());
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of CREATE_Follower_by_ViewerID_Follower



//-----------------------UPDATE SHOW SECTION---------------------
    public async Task<bool> UPDATE_myShow_by_ViewerID_Owner(Models.UPDATE_Show_with_auth0ID? create_or_update_ShowDTO)
    {
        if((create_or_update_ShowDTO?.FK_ViewerID_Owner != null) && (create_or_update_ShowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Shows SET ShowName = @ShowName, ShowImage = @ShowImage, Views = @Views, Likes = @Likes, Comments = @Comments, Rating = @Rating, Rank = @Rank,  PrivacyLevel = @PrivacyLevel, ShowStatus = @ShowStatus, LastLive = @LastLive WHERE ID = @ID AND FK_ViewerID_Owner = @FK_ViewerID_Owner ", _conn))
            {
                command.Parameters.AddWithValue("@ID", create_or_update_ShowDTO?.ShowID);
                command.Parameters.AddWithValue("@FK_ViewerID_Owner", create_or_update_ShowDTO?.FK_ViewerID_Owner);
                command.Parameters.AddWithValue("@ShowName", create_or_update_ShowDTO?.ShowName);
                command.Parameters.AddWithValue("@ShowImage", create_or_update_ShowDTO?.ShowImage);
                command.Parameters.AddWithValue("@Views", create_or_update_ShowDTO?.Views);
                command.Parameters.AddWithValue("@Likes", create_or_update_ShowDTO?.Likes);
                command.Parameters.AddWithValue("@Comments", create_or_update_ShowDTO?.Comments);
                command.Parameters.AddWithValue("@Rating", create_or_update_ShowDTO?.Rating);
                command.Parameters.AddWithValue("@Rank", create_or_update_ShowDTO?.Rank);

                command.Parameters.AddWithValue("@PrivacyLevel", create_or_update_ShowDTO?.PrivacyLevel.ToString());
                command.Parameters.AddWithValue("@ShowStatus", create_or_update_ShowDTO?.ShowStatus.ToString());
                command.Parameters.AddWithValue("@LastLive", create_or_update_ShowDTO?.LastLive);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_myShow_by_ViewerID_Owner

//-----------------------UPDATE SHOW SUBSCRIPTION SECTION---------------------
    public async Task<bool> UPDATE_myShowSubscription_by_ViewerID_Subscriber(Models.UPDATE_ShowSubscriber_with_auth0ID? update_SubscriptionDTO)
    {
        if((update_SubscriptionDTO?.FK_ViewerID_Subscriber != null) && (update_SubscriptionDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Subscribers SET MembershipStatus = @MembershipStatus, SubscriptionUpdateDate = @SubscriptionUpdateDate WHERE ID = @ID AND FK_ViewerID_Subscriber = @FK_ViewerID_Subscriber ", _conn))
            {
                command.Parameters.AddWithValue("@ID", update_SubscriptionDTO?.SubscriberID);
                command.Parameters.AddWithValue("@FK_ViewerID_Subscriber", update_SubscriptionDTO?.FK_ViewerID_Subscriber);
                command.Parameters.AddWithValue("@FK_ShowID_Subscribie", update_SubscriptionDTO?.FK_ShowID_Subscribie);
                command.Parameters.AddWithValue("@MembershipStatus", update_SubscriptionDTO?.MembershipStatus);
                command.Parameters.AddWithValue("@SubscriptionUpdateDate", update_SubscriptionDTO?.SubscriptionUpdateDate);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_myShowSubscription_by_ViewerID_Subscriber

//-----------------------UPDATE SHOW COMMENT SECTION---------------------
    public async Task<bool> UPDATE_ShowComment_by_ViewerID_Commenter(Models.UPDATE_with_ViewerIDs_CommentonShow? createShowCommentDTO)
    {
        if((createShowCommentDTO?.ViewerID_ShowCommenter != null) && (createShowCommentDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE ShowComments SET Comment = @Comment, Likes = @Likes, CommentUpdateDate = @CommentUpdateDate WHERE ID = @ID AND FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Commenter = @FK_ViewerID_Commenter ", _conn))
            {
                command.Parameters.AddWithValue("@ID", createShowCommentDTO?.CommentID_UpdatedComment);
                command.Parameters.AddWithValue("@FK_ViewerID_Commenter", createShowCommentDTO?.ViewerID_ShowCommenter);
                command.Parameters.AddWithValue("@FK_ShowSessionID", createShowCommentDTO?.ShowSessionID_ShowCommentie);
                command.Parameters.AddWithValue("@Comment", createShowCommentDTO?.Comment);
                command.Parameters.AddWithValue("@Likes", createShowCommentDTO?.Likes);

                command.Parameters.AddWithValue("@CommentUpdateDate", createShowCommentDTO?.CommentUpdateDate);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_ShowComment_by_ViewerID_Commenter

//-----------------------UPDATE SHOW SESSION SECTION---------------------
    public async Task<bool> UPDATE_ShowSession_by_ShowID(Models.CREATE_or_UPDATE_ShowSession_with_showID? create_showSessionDTO)
    {
        if((create_showSessionDTO?.FK_ShowID != null) && (create_showSessionDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments, SessionEndDate = @SessionEndDate WHERE  FK_ShowID = @FK_ShowID AND ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", create_showSessionDTO?.ID);
                command.Parameters.AddWithValue("@FK_ShowID", create_showSessionDTO?.FK_ShowID);
                command.Parameters.AddWithValue("@Views", create_showSessionDTO?.Views);
                command.Parameters.AddWithValue("@Likes", create_showSessionDTO?.Likes);
                command.Parameters.AddWithValue("@Comments", create_showSessionDTO?.Comments);
                command.Parameters.AddWithValue("@SessionEndDate", create_showSessionDTO?.SessionEndDate);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_ShowSession_by_ShowID

//-----------------------UPDATE SHOW SESSION JOIN SECTION---------------------
    public async Task<bool> UPDATE_ShowSessionJoin_by_ShowID(Models.UPDATE_ShowSessionJoin_with_showSessionID? create_showSessionJoinDTO)
    {
        if((create_showSessionJoinDTO?.FK_ShowSessionID != null) && (create_showSessionJoinDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"UPDATE ShowSessionJoins SET SessionLeaveDate = @SessionLeaveDate WHERE ID = @ID AND FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_ShowViewer = @FK_ViewerID_ShowViewer ", _conn))
            {
                command.Parameters.AddWithValue("@ID", create_showSessionJoinDTO?.ID);
                command.Parameters.AddWithValue("@FK_ShowSessionsID", create_showSessionJoinDTO?.FK_ShowSessionID);
                command.Parameters.AddWithValue("@FK_ViewerID_ShowViewer", create_showSessionJoinDTO?.FK_ViewerID_ShowViewer);
                command.Parameters.AddWithValue("@SessionLeaveDate", create_showSessionJoinDTO?.SessionLeaveDate);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }//End of UPDATE_ShowSessionJoin_by_ShowID

    }
}