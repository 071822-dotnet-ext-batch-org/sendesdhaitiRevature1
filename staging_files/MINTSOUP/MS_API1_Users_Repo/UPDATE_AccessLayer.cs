using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using Npgsql;

namespace MS_API1_Users_Repo
{


    public class UPDATE_AccessLayer : IUPDATE_AccessLayer
    {
        private readonly IDBCONNECTION _conn;
        public UPDATE_AccessLayer(IDBCONNECTION c)
        {
            this._conn = c;
        }
        //private readonly IConfiguration _config;
        //private readonly SqlConnection _conn;

        //public UPDATE_AccessLayer(IConfiguration config)
        //{
        //    _config = config;


        //    if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
        //    }
        //    else
        //    {
        //        _conn = new SqlConnection(_config["ConnectionStrings:ProductionString"]);
        //    }

        //}

        //-----------------------UPDATE VIEWER SECTION---------------------
        public async Task<bool> UPDATE_Viewer_by_MSToken(Guid MSToken, string fn, string ln, string email, string image, string username, string aboutMe, string streetAddy, string city, string state, string country, int areaCode, Models.Role role, Models.ViewerStatus membershipStatus, DateTime lastSignedIn)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Viewers SET " +
            //" Fn = @Fn, Ln = @Ln, Email = @Email, Image = @Image, Username = @Username, AboutMe = @AboutMe, StreetAddy = @StreetAddy, City = @City, State = @State, Country = @Country, AreaCode = @AreaCode, Role = @Role, MembershipStatus = @MembershipStatus, LastSignedIn = @LastSignedIn " +
            //" Where FK_MSToken = @MSToken ", _conn))
            {
                string command = $"UPDATE Viewers SET " +
                " Fn = @Fn, Ln = @Ln, Email = @Email, Image = @Image, Username = @Username, AboutMe = @AboutMe, StreetAddy = @StreetAddy, City = @City, State = @State, Country = @Country, AreaCode = @AreaCode, Role = @Role, MembershipStatus = @MembershipStatus, LastSignedIn = @LastSignedIn " +
                " Where FK_MSToken = @MSToken ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@Fn", fn);
                cmd.Parameters.AddWithValue("@Ln", ln);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@AboutMe", aboutMe);
                cmd.Parameters.AddWithValue("@StreetAddy", streetAddy);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@AreaCode", areaCode);
                cmd.Parameters.AddWithValue("@Role", role.ToString());
                cmd.Parameters.AddWithValue("@MembershipStatus", membershipStatus.ToString());
                cmd.Parameters.AddWithValue("@LastSignedIn", lastSignedIn);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_Viewer_by_MSToken

        //-----------------------UPDATE ADMIN SECTION---------------------
        public async Task<bool> UPDATE_Admin_by_MSToken(Guid MSToken, string email, string username, Models.AdminStatus adminStatus, DateTime lastSignedIn)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Admins SET Email = @Email, Username = @Username, AdminStatus = @AdminStatus, LastSignedIn = @LastSignedIn) WHERE FK_MSToken = @MSToken", _conn))
            {
                string command = $"UPDATE Admins SET Email = @Email, Username = @Username, AdminStatus = @AdminStatus, LastSignedIn = @LastSignedIn) WHERE FK_MSToken = @MSToken";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@AdminStatus", adminStatus);
                cmd.Parameters.AddWithValue("@LastSignedIn", lastSignedIn);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_Admin_by_MSToken

        //-----------------------UPDATE FRIEND SECTION---------------------
        public async Task<bool> UPDATE_Friend_by_FriendieID_Friender(Guid MSToken, Guid viewerID_Friendie, Models.FriendShipStatus relationshipStatus)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Friends SET FriendshipStatus = @FriendshipStatus, FriendUpdateDate = getdate() WHERE FK_ViewerID_Friender = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ", _conn))
            {
                string command = $"UPDATE Friends SET FriendshipStatus = @FriendshipStatus, FriendUpdateDate = getdate() WHERE FK_ViewerID_Friender = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ViewerID_Friendie", viewerID_Friendie);
                cmd.Parameters.AddWithValue("@FriendshipStatus", relationshipStatus);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_Friend_by_ViewerID_Friender

        //-----------------------UPDATE FOLLOWER SECTION---------------------
        public async Task<bool> UPDATE_aFollow_to_Viewer_by_FollowieID_Follower(Guid MSToken, Guid ViewerID_Followie, Models.FollowerStatus FollowerStatus)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Followie = @FK_ViewerID_Followie ", _conn))
            {
                string command = $"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Followie = @FK_ViewerID_Followie ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ViewerID_Followie", ViewerID_Followie);
                cmd.Parameters.AddWithValue("@FollowerStatus", FollowerStatus.ToString());
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_aFollow_to_Viewer_by_FollowieID_Follower

        public async Task<bool> UPDATE_aFollow_to_Show_by_ViewerID_Follower(Guid MSToken, Guid ShowID_Followie, Models.FollowerStatus FollowerStatus)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ShowID_Followie = @FK_ShowID_Followie", _conn))
            {
                string command = $"UPDATE Followers SET FollowerStatus = @FollowerStatus, StatusUpdateDate = getdate() WHERE FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ShowID_Followie = @FK_ShowID_Followie";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Followie", ShowID_Followie);
                cmd.Parameters.AddWithValue("@FollowerStatus", FollowerStatus.ToString());
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of CREATE_Follower_by_ViewerID_Follower



        //-----------------------UPDATE SHOW SECTION---------------------
        public async Task<bool> UPDATE_myShow_by_showID(Guid MSToken, Guid showID, string showName, string showImage, int subscribers, int views, int likes, int comments, double rating, int rank, Models.PrivacyLevel privacyLevel, Models.ShowStanding showstanding, DateTime lastLive)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Shows SET " +
            //" ShowName = @ShowName, ShowImage = @ShowImage, Subscribers = @Subscribers, Views = @Views, Likes = @Likes, Comments = @Comments, Rating = @Rating, Rank = @Rank,  PrivacyLevel = @PrivacyLevel, ShowStatus = @ShowStatus, LastLive = @LastLive " +
            //" WHERE ID = @ID AND FK_ViewerID_Owner = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
            {
                string command = $"UPDATE Shows SET " +
                " ShowName = @ShowName, ShowImage = @ShowImage, Subscribers = @Subscribers, Views = @Views, Likes = @Likes, Comments = @Comments, Rating = @Rating, Rank = @Rank,  PrivacyLevel = @PrivacyLevel, ShowStatus = @ShowStatus, LastLive = @LastLive " +
                " WHERE ID = @ID AND FK_ViewerID_Owner = (select ID from Viewers where FK_MSToken = @MSToken) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@ID", showID);
                cmd.Parameters.AddWithValue("@ShowName", showName);
                cmd.Parameters.AddWithValue("@ShowImage", showImage);
                cmd.Parameters.AddWithValue("@Subscribers", subscribers);
                cmd.Parameters.AddWithValue("@Views", views);
                cmd.Parameters.AddWithValue("@Likes", likes);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Rank", rank);

                cmd.Parameters.AddWithValue("@PrivacyLevel", privacyLevel.ToString());
                cmd.Parameters.AddWithValue("@ShowStatus", showstanding.ToString());
                cmd.Parameters.AddWithValue("@LastLive", lastLive);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_myShow_by_ViewerID_Owner

        //-----------------------UPDATE SHOW SUBSCRIPTION SECTION---------------------
        public async Task<bool> UPDATE_myShowSubscription_by_SubscriptionID(Guid MSToken, Guid id, Models.SubscriberMembershipStatus membershipStatus)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE Subscribers SET MembershipStatus = @MembershipStatus, SubscriptionUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
            {
                string command = $"UPDATE Subscribers SET MembershipStatus = @MembershipStatus, SubscriptionUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@MembershipStatus", membershipStatus);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_myShowSubscription_by_SubscriptionID

        //-----------------------UPDATE SHOW COMMENT SECTION---------------------
        public async Task<bool> UPDATE_ShowComment_by_ShowCommentID(Guid MSToken, Guid showCommentID, string comment)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE ShowComments SET Comment = @Comment, CommentUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Commenter = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
            {
                string command = $"UPDATE ShowComments SET Comment = @Comment, CommentUpdateDate = getdate() WHERE ID = @ID AND FK_ViewerID_Commenter = (select ID from Viewers where FK_MSToken = @MSToken) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", showCommentID);
                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@Comment", comment);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_ShowComment_by_ViewerID_Commenter

        //-----------------------UPDATE SHOW SESSION SECTION---------------------
        public async Task<bool> UPDATE_ShowSession_by_SessionID(Guid id, int views, int likes, int comments)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments " +
            //"  WHERE ID = @ID ", _conn))
            {
                string command = $"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments  WHERE ID = @ID ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Views", views);
                cmd.Parameters.AddWithValue("@Likes", likes);
                cmd.Parameters.AddWithValue("@Comments", comments);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_ShowSession_by_SessionID

        public async Task<bool> UPDATE_ShowSession_to_END_SESSION_by_SessionID(Guid id, int views, int likes, int comments, DateTime sessionEndDate)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments, SessionEndDate = getdate() WHERE  FK_ShowID = @FK_ShowID AND ID = @ID ", _conn))
            {
                string command = $"UPDATE ShowSessions SET Views = @Views, Likes = @Likes, Comments = @Comments, SessionEndDate = getdate() WHERE  FK_ShowID = @FK_ShowID AND ID = @ID ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Views", views);
                cmd.Parameters.AddWithValue("@Likes", likes);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@SessionEndDate", sessionEndDate);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_ShowSession_to_END_SESSION_by_SessionID


        //-----------------------UPDATE SHOW SESSION JOIN SECTION---------------------
        public async Task<bool> UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID(Guid MSToken, Guid id)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new Sqlcmd($"UPDATE ShowSessionJoins SET SessionLeaveDate = getdate() WHERE ID = @ID AND FK_ViewerID_ShowViewer = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
            {
                string command = $"UPDATE ShowSessionJoins SET SessionLeaveDate = getdate() WHERE ID = @ID AND FK_ViewerID_ShowViewer = (select ID from Viewers where FK_MSToken = @MSToken) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                int ret = await cmd.ExecuteNonQueryAsync();
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
        }//End of UPDATE_ShowSessionJoin_to_LEAVE_SESSION_by_SessionID

    }
}