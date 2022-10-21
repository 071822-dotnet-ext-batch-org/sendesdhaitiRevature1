using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace MS_API1_Users_Repo
{
    public interface IUPDATE_AccessLayer
    {
        Task<bool> UPDATE_Admin_by_auth0ID(string? auth0ID, string? email, string? username, AdminStatus? adminStatus, DateTime? lastSignedIn);
        Task<bool> UPDATE_aFollow_to_Show_by_ViewerID_Follower(string? Auth0ID, Guid? ShowID_Followie, FollowerStatus? FollowerStatus);
        Task<bool> UPDATE_aFollow_to_Viewer_by_FollowieID_Follower(string? Auth0ID, Guid? ViewerID_Followie, FollowerStatus? FollowerStatus);
        Task<bool> UPDATE_Friend_by_FriendieID_Friender(string? auth0ID, Guid? viewerID_Friendie, FriendShipStatus? relationshipStatus);
        Task<bool> UPDATE_myShowSubscription_by_SubscriptionID(string? auth0ID, Guid? id, SubscriberMembershipStatus? membershipStatus);
        Task<bool> UPDATE_myShow_by_showID(string? auth0ID, Guid? showID, string? showName, string? showImage, int? subscribers, int? views, int? likes, int? comments, double? rating, int? rank, PrivacyLevel? privacyLevel, ShowStanding? showstanding, DateTime? lastLive);
        Task<bool> UPDATE_ShowComment_by_ShowCommentID(string? auth0ID, Guid? showCommentID, string? comment);
        Task<bool> UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID(string? auth0ID, Guid? id);
        Task<bool> UPDATE_ShowSession_by_SessionID(string? auth0ID, Guid? id, int? views, int? likes, int? comments);
        Task<bool> UPDATE_ShowSession_to_END_SESSION_by_SessionID(string? auth0ID, Guid? id, int? views, int? likes, int? comments, DateTime? sessionEndDate);
        Task<bool> UPDATE_Viewer_by_auth0ID(string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Role? role, ViewerStatus? membershipStatus, DateTime? lastSignedIn);
    }

    public class UPDATE_AccessLayer : IUPDATE_AccessLayer
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public UPDATE_AccessLayer(IConfiguration config)
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
        public async Task<bool> UPDATE_Viewer_by_auth0ID(string? auth0ID, string? fn, string? ln, string? email, string? image, string? username, string? aboutMe, string? streetAddy, string? city, string? state, string? country, int? areaCode, Models.Role? role, Models.ViewerStatus? membershipStatus, DateTime? lastSignedIn)
        {
            if (auth0ID != null)
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Viewers SET " +
                " Fn = @Fn, Ln = @Ln, Email = @Email, Image = @Image, Username = @Username, AboutMe = @AboutMe, StreetAddy = @StreetAddy, City = @City, State = @State, Country = @Country, AreaCode = @AreaCode, Role = @Role, MembershipStatus = @MembershipStatus, LastSignedIn = @LastSignedIn " +
                " Where Auth0ID = @Auth0ID ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@Fn", fn);
                    command.Parameters.AddWithValue("@Ln", ln);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Image", image);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@AboutMe", aboutMe);
                    command.Parameters.AddWithValue("@StreetAddy", streetAddy);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@State", state);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@AreaCode", areaCode);
                    command.Parameters.AddWithValue("@Role", role.ToString());
                    command.Parameters.AddWithValue("@MembershipStatus", membershipStatus.ToString());
                    command.Parameters.AddWithValue("@LastSignedIn", lastSignedIn);
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
        public async Task<bool> UPDATE_Admin_by_auth0ID(string? auth0ID, string? email, string? username, Models.AdminStatus? adminStatus, DateTime? lastSignedIn)
        {
            if (auth0ID != null)
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Admins SET Email = @Email, Username = @Username, AdminStatus = @AdminStatus, LastSignedIn = @LastSignedIn) WHERE Auth0ID = @Auth0ID", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@AdminStatus", adminStatus);
                    command.Parameters.AddWithValue("@LastSignedIn", lastSignedIn);
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
        public async Task<bool> UPDATE_Friend_by_FriendieID_Friender(string? auth0ID, Guid? viewerID_Friendie, Models.FriendShipStatus? relationshipStatus)
        {
            if (auth0ID != null)
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Friends SET FriendshipStatus = @FriendshipStatus, FriendUpdateDate = getdate() WHERE FK_ViewerID_Friender = (select ID from Viewers where Auth0ID = @Auth0ID) AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ViewerID_Friendie", viewerID_Friendie);
                    command.Parameters.AddWithValue("@FriendshipStatus", relationshipStatus);
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
        public async Task<bool> UPDATE_aFollow_to_Viewer_by_FollowieID_Follower(string? Auth0ID, Guid? ViewerID_Followie, Models.FollowerStatus? FollowerStatus)
        {
            if ((ViewerID_Followie != null) && (Auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where Auth0ID = @Auth0ID) AND FK_ViewerID_Followie = @FK_ViewerID_Followie ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", Auth0ID);
                    command.Parameters.AddWithValue("@FK_ViewerID_Followie", ViewerID_Followie);
                    command.Parameters.AddWithValue("@FollowerStatus", FollowerStatus.ToString());
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
        }//End of UPDATE_aFollow_to_Viewer_by_FollowieID_Follower

        public async Task<bool> UPDATE_aFollow_to_Show_by_ViewerID_Follower(string? Auth0ID, Guid? ShowID_Followie, Models.FollowerStatus? FollowerStatus)
        {
            if ((ShowID_Followie != null) && (Auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where Auth0ID = @Auth0ID) AND FK_ShowID_Followie = @FK_ShowID_Followie", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", Auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID_Followie", ShowID_Followie);
                    command.Parameters.AddWithValue("@FollowerStatus", FollowerStatus.ToString());
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
        public async Task<bool> UPDATE_myShow_by_showID(string? auth0ID, Guid? showID, string? showName, string? showImage, int? subscribers, int? views, int? likes, int? comments, double? rating, int? rank, Models.PrivacyLevel? privacyLevel, Models.ShowStanding? showstanding, DateTime? lastLive)
        {
            if ((showID != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Shows SET " +
                " ShowName = @ShowName, ShowImage = @ShowImage, Subscribers = @Subscribers, Views = @Views, Likes = @Likes, Comments = @Comments, Rating = @Rating, Rank = @Rank,  PrivacyLevel = @PrivacyLevel, ShowStatus = @ShowStatus, LastLive = @LastLive " +
                " WHERE ID = @ID AND FK_ViewerID_Owner = (select ID from Viewers where Auth0ID = @Auth0ID) ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@ID", showID);
                    command.Parameters.AddWithValue("@ShowName", showName);
                    command.Parameters.AddWithValue("@ShowImage", showImage);
                    command.Parameters.AddWithValue("@Subscribers", subscribers);
                    command.Parameters.AddWithValue("@Views", views);
                    command.Parameters.AddWithValue("@Likes", likes);
                    command.Parameters.AddWithValue("@Comments", comments);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Rank", rank);

                    command.Parameters.AddWithValue("@PrivacyLevel", privacyLevel.ToString());
                    command.Parameters.AddWithValue("@ShowStatus", showstanding.ToString());
                    command.Parameters.AddWithValue("@LastLive", lastLive);
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
        public async Task<bool> UPDATE_myShowSubscription_by_SubscriptionID(string? auth0ID, Guid? id, Models.SubscriberMembershipStatus? membershipStatus)
        {
            if ((id != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Subscribers SET MembershipStatus = @MembershipStatus, SubscriptionUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Subscriber = (select ID from Viewers where Auth0ID = @Auth0ID) ", _conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@MembershipStatus", membershipStatus);
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
        }//End of UPDATE_myShowSubscription_by_SubscriptionID

        //-----------------------UPDATE SHOW COMMENT SECTION---------------------
        public async Task<bool> UPDATE_ShowComment_by_ShowCommentID(string? auth0ID, Guid? showCommentID, string? comment)
        {
            if ((showCommentID != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE ShowComments SET Comment = @Comment, CommentUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Commenter = (select ID from Viewers where Auth0ID = @Auth0ID) ", _conn))
                {
                    command.Parameters.AddWithValue("@ID", showCommentID);
                    command.Parameters.AddWithValue("@FK_ViewerID_Commenter", auth0ID);
                    command.Parameters.AddWithValue("@Comment", comment);
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
        public async Task<bool> UPDATE_ShowSession_by_SessionID(string? auth0ID, Guid? id, int? views, int? likes, int? comments)
        {
            if ((id != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments " +
                "  WHERE ID = @ID ", _conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Views", views);
                    command.Parameters.AddWithValue("@Likes", likes);
                    command.Parameters.AddWithValue("@Comments", comments);
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
        }//End of UPDATE_ShowSession_by_SessionID

        public async Task<bool> UPDATE_ShowSession_to_END_SESSION_by_SessionID(string? auth0ID, Guid? id, int? views, int? likes, int? comments, DateTime? sessionEndDate)
        {
            if ((id != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments, SessionEndDate = getdate() WHERE  FK_ShowID = @FK_ShowID AND ID = @ID ", _conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Views", views);
                    command.Parameters.AddWithValue("@Likes", likes);
                    command.Parameters.AddWithValue("@Comments", comments);
                    command.Parameters.AddWithValue("@SessionEndDate", sessionEndDate);
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
        }//End of UPDATE_ShowSession_to_END_SESSION_by_SessionID


        //-----------------------UPDATE SHOW SESSION JOIN SECTION---------------------
        public async Task<bool> UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID(string? auth0ID, Guid? id)
        {
            if ((id != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE ShowSessionJoins SET SessionLeaveDate = getdate() WHERE ID = @ID AND FK_ViewerID_ShowViewer = (select ID from Viewers where Auth0ID = @Auth0ID) ", _conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
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
        }//End of UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID

    }
}