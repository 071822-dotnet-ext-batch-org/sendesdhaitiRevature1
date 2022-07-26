using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MS_API1_Users_Repo
{

    public class CREATE_AccessLayer : ICREATE_AccessLayer
    {
        private readonly IDBCONNECTION _conn;
        public CREATE_AccessLayer(IDBCONNECTION c)
        {
            this._conn = c;
        }

        //public CREATE_AccessLayer(IConfiguration config)
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
        //-----------------------CREATE FRIEND SECTION---------------------
        public async Task<bool> CREATE_Friend_by_FriendieID(Guid MSToken, Guid viewerID_Friendie)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO Friends ( FK_ViewerID_Friender, FK_ViewerID_Friendie ) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ViewerID_Friendie ) ", _conn))
            {
                string command = $"INSERT INTO Friends ( FK_ViewerID_Friender, FK_ViewerID_Friendie ) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ViewerID_Friendie ) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ViewerID_Friendie", viewerID_Friendie);
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
        }//End of CREATE_Friend_by_FriendieID

        //-----------------------CREATE FOLLOWER SECTION---------------------
        public async Task<bool> CREATE_aFollow_to_Viewer_by_viewerID(Guid MSToken, Guid followieID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ViewerID_Followie) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ViewerID_Followie ) ", _conn))
            {
                string command = $"INSERT INTO Followers (FK_ViewerID_Follower, FK_ViewerID_Followie) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ViewerID_Followie ) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ViewerID_Followie", followieID);
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
        }//End of CREATE_aFollow_to_Viewer_by_followieID


        public async Task<bool> CREATE_aFollow_to_Show_with_showID(Guid MSToken, Guid FollowieID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ShowID_Followie) VALUES( (select ID from Viewers where FK_MSToken = MSToken) , @FK_ShowID_Followie) ", _conn))
            {
                string command = $"INSERT INTO Followers (FK_ViewerID_Follower, FK_ShowID_Followie) VALUES( (select ID from Viewers where FK_MSToken = MSToken) , @FK_ShowID_Followie) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Followie", FollowieID);
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
        }//End of CREATE_aFollow_to_Show_with_showID


        //-----------------------CREATE SHOW SECTION---------------------
        public async Task<bool> CREATE_myShow_by_MSToken(Guid MSToken, string showName, string showImage, Models.PrivacyLevel privacyLevel)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO Shows (FK_ViewerID_Owner, ShowName, ShowImage, PrivacyLevel) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @ShowName, @ShowImage, @PrivacyLevel) ", _conn))
            {
                string command = $"INSERT INTO Shows (FK_ViewerID_Owner, ShowName, ShowImage, PrivacyLevel) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @ShowName, @ShowImage, @PrivacyLevel) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@ShowName", showName);
                cmd.Parameters.AddWithValue("@ShowImage", showImage);
                cmd.Parameters.AddWithValue("@PrivacyLevel", privacyLevel);
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
        }//End of CREATE_myShow_by_MSToken

        //-----------------------CREATE SHOW SUBSCRIPTION SECTION---------------------
        public async Task<bool> CREATE_mySubscription_to_Show_by_MSToken_showID(Guid MSToken, Guid showID, Models.SubscriberMembershipStatus MembershipStatus)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO Subscribers (FK_ViewerID_Subscriber, FK_ShowID_Subscribie, MembershipStatus) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowID_Subscribie, @FK_ShowSessionID, @MembershipStatus) ", _conn))
            {
                string command = $"INSERT INTO Subscribers (FK_ViewerID_Subscriber, FK_ShowID_Subscribie, MembershipStatus) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowID_Subscribie, @FK_ShowSessionID, @MembershipStatus) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Subscribie", showID);
                cmd.Parameters.AddWithValue("@MembershipStatus", MembershipStatus);
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
        }//End of CREATE_myShowSubscription_by_MSToken_

        //-----------------------CREATE SHOW LIKE SECTION---------------------
        public async Task<bool> CREATE_ShowLike_by_ShowSessionID(Guid MSToken, Guid ShowSessionID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowLikes (FK_ViewerID_Liker, FK_ShowSessionID) VALUES( (select ID from Viewers where FK_MSToken = @MSToken), @FK_ShowSessionID) ", _conn))
            {
                string command = $"INSERT INTO ShowLikes (FK_ViewerID_Liker, FK_ShowSessionID) VALUES( (select ID from Viewers where FK_MSToken = @MSToken), @FK_ShowSessionID) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@FK_ShowID_Likie", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSessionID);
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
        }//End of CREATE_ShowLike_by_ShowSessionID

        //-----------------------CREATE SHOW COMMENT SECTION---------------------
        public async Task<bool> CREATE_ShowComment_by_showSessionID(Guid MSToken, Guid showSessionID_ShowCommentie, string comment)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowComments (FK_ViewerID_Commenter, FK_ShowSessionID, Comment) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowSessionID, @Comment) ", _conn))
            {
                string command = $"INSERT INTO ShowComments (FK_ViewerID_Commenter, FK_ShowSessionID, Comment) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowSessionID, @Comment) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", showSessionID_ShowCommentie);
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
        }//End of CREATE_ShowComment_by_showSessionID

        //-----------------------CREATE SHOW COMMENT SECTION---------------------
        public async Task<bool> CREATE_myLike_to_ShowComment_by_CommetID(Guid MSToken, Guid showCommentID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowCommentLikes (FK_ViewerID_Liker, FK_ShowCommentID) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowCommentID) ", _conn))
            {
                string command = $"INSERT INTO ShowCommentLikes (FK_ViewerID_Liker, FK_ShowCommentID) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowCommentID) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Commentie", showCommentID);
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
        }//End of CREATE_ShowCommentLike_by_ViewerID_CommentLiker

        //-----------------------CREATE SHOW DONATION SECTION---------------------
        public async Task<bool> CREATE_myDonation_to_Show_by_ShowID(Guid MSToken, Guid fk_showID_Subscribie, decimal Amount, string Note)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowDonations (FK_ViewerID_Donater, FK_ShowID_Donatie, Amount, Note) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowID_Donatie, @Amount, @Note) ", _conn))
            {
                string command = $"INSERT INTO ShowDonations (FK_ViewerID_Donater, FK_ShowID_Donatie, Amount, Note) VALUES( (select ID from Viewers where FK_MSToken = @MSToken) , @FK_ShowID_Donatie, @Amount, @Note) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Donatie", fk_showID_Subscribie);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Note", Note);
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
        }//End of CREATE_ShowDonation_by_ShowID

        //-----------------------CREATE SHOW SESSION SECTION---------------------
        public async Task<bool> CREATE_myShowSession_by_ShowID(Guid MSToken, Guid showID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowSessions (FK_ShowID ) VALUES( (select ID from Shows where FK_ViewerID_Owner = (select ID from Viewers where MSToken = @MSToken) ) ) ", _conn))
            {
                string command = $"INSERT INTO ShowSessions (FK_ShowID ) VALUES( (select ID from Shows where FK_ViewerID_Owner = (select ID from Viewers where MSToken = @MSToken) ) ) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID", showID);
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
        }//End of CREATE_ShowSession_by_ShowID

        //-----------------------CREATE SHOW SESSION JOIN SECTION---------------------
        public async Task<bool> CREATE_myJoin_to_ShowSession_by_ShowSessionID(Guid MSToken, Guid ShowSessionID)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//SqlCommand($"INSERT INTO ShowSessionJoins (FK_ShowSessionsID, FK_ViewerID_ShowViewer) VALUES(@FK_ShowSessionsID, (select ID from Viewers where FK_MSToken = @MSToken)) ", _conn))
            {
                string command = $"INSERT INTO ShowSessionJoins (FK_ShowSessionsID, FK_ViewerID_ShowViewer) VALUES(@FK_ShowSessionsID, (select ID from Viewers where FK_MSToken = @MSToken)) ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@FK_ShowSessionsID", ShowSessionID);
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
        }//End of CREATE_ShowSessionJoin_by_ShowSessionID




    }
}