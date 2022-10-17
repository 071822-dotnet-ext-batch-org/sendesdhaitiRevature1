using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MS_API1_Users_Repo
{
    public class CREATE_AccessLayer
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public CREATE_AccessLayer(IConfiguration config)
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
//-----------------------CREATE VIEWER SECTION---------------------
    public async Task<bool> CREATE_Viewer_by_auth0ID(Models.CREATE_Viewer_on_signUP_with_auth0ID_DTO? createViewerDTO)
    {
        if(createViewerDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Viewers (Auth0ID, Email) VALUES(@Auth0ID, @Email)", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", createViewerDTO?.Auth0ID);
                command.Parameters.AddWithValue("@Email", createViewerDTO?.Email);
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
    }//End of CREATE_Viewer_by_auth0ID

//-----------------------CREATE ADMIN SECTION---------------------
    public async Task<bool> CREATE_Admin_by_auth0ID(Models.CREATE_Viewer_on_signUP_with_auth0ID_DTO? createAdminDTO)
    {
        if(createAdminDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Admins (Auth0ID, Email) VALUES(@Auth0ID, @Email)", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", createAdminDTO?.Auth0ID);
                command.Parameters.AddWithValue("@Email", createAdminDTO?.Email);
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
    }//End of CREATE_Viewer_by_auth0ID

//-----------------------CREATE FRIEND SECTION---------------------
    public async Task<bool> CREATE_Friend_by_ViewerID_Friender(Models.CREATE_or_UPDATE_with_ViewerIDs_Friended_or_Unfriended? create_update_FriendDTO)
    {
        if((create_update_FriendDTO?.ViewerID_Friender != null) && (create_update_FriendDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Friends (FK_ViewerID_Friender, FK_ViewerID_Friendie, FriendshipStatus) VALUES(@FK_ViewerID_Friender, @FK_ViewerID_Friendie, @FriendshipStatus) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Friender", create_update_FriendDTO?.ViewerID_Friender);
                command.Parameters.AddWithValue("@FK_ViewerID_Friendie", create_update_FriendDTO?.ViewerID_Friendie);
                command.Parameters.AddWithValue("@FriendshipStatus", create_update_FriendDTO?.RelationshipStatus);
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
    }//End of CREATE_Friend_by_ViewerID_Freinder

//-----------------------CREATE FOLLOWER SECTION---------------------
    public async Task<bool> CREATE_aFollow_to_Viewer_by_ViewerID_Follower(Models.CREATE_aFollow_to_Viewer_with_ViewerID? create_update_FollowDTO)
    {
        if((create_update_FollowDTO?.ViewerID_Follower != null) && (create_update_FollowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ViewerID_Followie) VALUES(@FK_ViewerID_Follower, @FK_ViewerID_Followie) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", create_update_FollowDTO?.ViewerID_Follower);
                command.Parameters.AddWithValue("@FK_ViewerID_Followie", create_update_FollowDTO?.ViewerID_Followie);
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
    }//End of CREATE_aFollow_to_Viewer_by_ViewerID_Follower


    public async Task<bool> CREATE_aFollow_to_Show_with_ViewerID_Follower(Models.CREATE_aFollow_to_Show_with_ViewerID? create_update_FollowDTO)
    {
        if((create_update_FollowDTO?.ViewerID_Follower != null) && (create_update_FollowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ShowID_Followie) VALUES(@FK_ViewerID_Follower, @FK_ShowID_Followie) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", create_update_FollowDTO?.ViewerID_Follower);
                command.Parameters.AddWithValue("@FK_ShowID_Followie", create_update_FollowDTO?.ShowID_Followie);
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
    }//End of CREATE_aFollow_to_Show_with_ViewerID_Follower


//-----------------------CREATE SHOW SECTION---------------------
    public async Task<bool> CREATE_myShow_by_ViewerID_Owner(Models.CREATE_Show_with_auth0ID? create_or_update_ShowDTO)
    {
        if((create_or_update_ShowDTO?.FK_ViewerID_Owner != null) && (create_or_update_ShowDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Shows (FK_ViewerID_Owner, ShowName, ShowImage, PrivacyLeve, ShowStatus) VALUES(@FK_ViewerID_Owner, @ShowName, @ShowImage, @PrivacyLevel) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Owner", create_or_update_ShowDTO?.FK_ViewerID_Owner);
                command.Parameters.AddWithValue("@ShowName", create_or_update_ShowDTO?.ShowName);
                command.Parameters.AddWithValue("@ShowImage", create_or_update_ShowDTO?.ShowImage);
                command.Parameters.AddWithValue("@PrivacyLevel", create_or_update_ShowDTO?.PrivacyLevel);
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
    }//End of CREATE_myShows_by_ViewerID_Owner

//-----------------------CREATE SHOW SUBSCRIPTION SECTION---------------------
    public async Task<bool> CREATE_myShowSubscription_by_ViewerID_Subscriber(Models.CREATE_or_UPDATE_ShowSubscriber_with_auth0ID? create_or_update_SubscriptionDTO)
    {
        if((create_or_update_SubscriptionDTO?.FK_ViewerID_Subscriber != null) && (create_or_update_SubscriptionDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Subscribers (FK_ViewerID_Subscriber, FK_ShowID_Subscribie, FK_ShowSessionID, MembershipStatus) VALUES(@FK_ViewerID_Subscriber, @FK_ShowID_Subscribie, @FK_ShowSessionID, @MembershipStatus) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Subscriber", create_or_update_SubscriptionDTO?.FK_ViewerID_Subscriber);
                command.Parameters.AddWithValue("@FK_ShowID_Subscribie", create_or_update_SubscriptionDTO?.FK_ShowID_Subscribie);
                command.Parameters.AddWithValue("@FK_ShowSessionID", create_or_update_SubscriptionDTO?.FK_ShowSessionID);
                command.Parameters.AddWithValue("@MembershipStatus", create_or_update_SubscriptionDTO?.MembershipStatus);
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
    }//End of CREATE_myShowSubscription_by_ViewerID_Subscriber

//-----------------------CREATE SHOW LIKE SECTION---------------------
    public async Task<bool> CREATE_ShowLike_by_ViewerID_Liker(Models.CREATE_or_DEL_with_ViewerIDs_LikeShow_or_UnLikeShow? createShowLikeDTO)
    {
        if((createShowLikeDTO?.ViewerID_ShowLiker != null) && (createShowLikeDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowLikes (FK_ViewerID_Liker, FK_ShowID_Likie, FK_ShowSessionID) VALUES(@FK_ViewerID_Liker, @FK_ShowID_Likie, @FK_ShowSessionID) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Liker", createShowLikeDTO?.ViewerID_ShowLiker);
                command.Parameters.AddWithValue("@FK_ShowID_Likie", createShowLikeDTO?.ShowID_LikedShow);
                command.Parameters.AddWithValue("@FK_ShowSessionID", createShowLikeDTO?.ShowSessionID_ShowLikie);
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
    }//End of CREATE_ShowLike_by_ViewerID_Liker

//-----------------------CREATE SHOW COMMENT SECTION---------------------
    public async Task<bool> CREATE_ShowComment_by_ViewerID_Commenter(Models.CREATE_with_ViewerIDs_CommentonShow? createShowCommentDTO)
    {
        if((createShowCommentDTO?.ViewerID_ShowCommenter != null) && (createShowCommentDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowComments (FK_ViewerID_Commenter, FK_ShowID_Commentie, FK_ShowSessionID, Comment, Likes) VALUES(@FK_ViewerID_Commenter, @FK_ShowID_Commentie, @FK_ShowSessionID, @Comment, @Likes) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Commenter", createShowCommentDTO?.ViewerID_ShowCommenter);
                command.Parameters.AddWithValue("@FK_ShowID_Commentie", createShowCommentDTO?.ShowID_ShowCommentie);
                command.Parameters.AddWithValue("@FK_ShowSessionID", createShowCommentDTO?.ShowSessionID);
                command.Parameters.AddWithValue("@Comment", createShowCommentDTO?.Comment);
                command.Parameters.AddWithValue("@Likes", 0);
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
    }//End of CREATE_ShowComment_by_ViewerID_Commenter

//-----------------------CREATE SHOW COMMENT SECTION---------------------
    public async Task<bool> CREATE_ShowCommentLike_by_ViewerID_CommentLiker(Models.CREATE_or_DEL_with_ViewerIDs_LikeonComment_or_UnLikeonComment? createShowCommentLikeDTO)
    {
        if((createShowCommentLikeDTO?.ViewerID_ShowCommentLiker != null) && (createShowCommentLikeDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowCommentLikes (FK_ViewerID_Liker, FK_ShowCommentID) VALUES(@FK_ViewerID_Liker, @FK_ShowCommentID) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Liker", createShowCommentLikeDTO?.ViewerID_ShowCommentLiker);
                command.Parameters.AddWithValue("@FK_ShowID_Commentie", createShowCommentLikeDTO?.ShowCommentID_ShowCommentLikie);
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
    }//End of CREATE_ShowCommentLike_by_ViewerID_CommentLiker

//-----------------------CREATE SHOW DONATION SECTION---------------------
    public async Task<bool> CREATE_ShowDonation_by_ViewerID_Donater(Models.CREATE_ShowDonation_with_auth0ID? create_showDonationDTO)
    {
        if((create_showDonationDTO?.FK_ViewerID_Donater != null) && (create_showDonationDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowDonations (FK_ViewerID_Donater, FK_ShowID_Donatie, Amount, Note) VALUES(@FK_ViewerID_Donater, @FK_ShowID_Donatie, @Amount, @Note) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Donater", create_showDonationDTO?.FK_ViewerID_Donater);
                command.Parameters.AddWithValue("@FK_ShowID_Donatie", create_showDonationDTO?.FK_ShowID_Donatie);
                command.Parameters.AddWithValue("@Amount", create_showDonationDTO?.Amount);
                command.Parameters.AddWithValue("@Note", create_showDonationDTO?.Note);
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
    }//End of CREATE_ShowDonation_by_ViewerID_Donater

//-----------------------CREATE SHOW SESSION SECTION---------------------
    public async Task<bool> CREATE_ShowSession_by_ShowID(Models.CREATE_or_UPDATE_ShowSession_with_showID? create_showSessionDTO)
    {
        if((create_showSessionDTO?.FK_ShowID != null) && (create_showSessionDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowSessions (FK_ShowID) VALUES(@FK_ShowID) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID", create_showSessionDTO?.FK_ShowID);
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
    }//End of CREATE_ShowSession_by_ShowID

//-----------------------CREATE SHOW SESSION JOIN SECTION---------------------
    public async Task<bool> CREATE_ShowSessionJoin_by_ShowID(Models.CREATE_ShowSessionJoin_with_showSessionID? create_showSessionJoinDTO)
    {
        if((create_showSessionJoinDTO?.FK_ShowSessionID != null) && (create_showSessionJoinDTO?.Auth0ID != null))
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO ShowSessionJoins (FK_ShowSessionsID, FK_ViewerID_ShowViewer) VALUES(@FK_ShowSessionsID, @FK_ViewerID_ShowViewer) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionsID", create_showSessionJoinDTO?.FK_ShowSessionID);
                command.Parameters.AddWithValue("@FK_ViewerID_ShowViewer", create_showSessionJoinDTO?.FK_ViewerID_ShowViewer);
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
    }//End of CREATE_ShowSession_by_ShowID




    }
}