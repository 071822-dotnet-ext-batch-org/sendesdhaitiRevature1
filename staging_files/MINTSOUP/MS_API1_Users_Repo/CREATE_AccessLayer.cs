using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MS_API1_Users_Repo
{

    public class CREATE_AccessLayer : ICREATE_AccessLayer
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
        public async Task<CHECK_AccessLayer.CHECKSTATUS> CREATE_myViewer_by_auth0ID(string? auth0ID, string? email)
        {
            if ((auth0ID != null) && (email != "sendes12@gmail.com"))//register as a normal viewer
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Viewers (Auth0ID, Email) VALUES(@Auth0ID, @Email)", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@Email", email);
                    _conn.Open();

                    int ret = await command.ExecuteNonQueryAsync();
                    if (ret > 0)
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.SAVED;
                    }
                    else
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.NOT_SAVED;
                    }
                }
            }
            else if ((auth0ID != null) && (email == "sendes12@gmail.com"))//register as an admin
            {
                bool checkIfSavedAsAdmin = await this.CREATE_Admin_by_auth0ID(auth0ID, email);
                //Continue if saved
                if (!checkIfSavedAsAdmin) { return CHECK_AccessLayer.CHECKSTATUS.NOT_SAVED; }
                using (SqlCommand command = new SqlCommand($"INSERT INTO Viewers (Auth0ID, Email) VALUES(@Auth0ID, @Email)", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@Email", email);
                    _conn.Open();

                    int ret = await command.ExecuteNonQueryAsync();
                    if (ret > 0)
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.SAVED;
                    }
                    else
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.NOT_SAVED;
                    }
                }
                

            }
            else
            {
                return CHECK_AccessLayer.CHECKSTATUS.NO_AUTH0;
            }
        }//End of CREATE_Viewer_by_auth0ID

        //-----------------------CREATE ADMIN SECTION---------------------
        public async Task<bool> CREATE_Admin_by_auth0ID(string? auth0ID, string? email)
        {
            if (auth0ID != null)
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Admins (Auth0ID, Email) VALUES(@Auth0ID, @Email)", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@Email", email);
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
        public async Task<bool> CREATE_Friend_by_FriendieID(string? auth0ID, Guid? viewerID_Friendie)
        {
            if ((viewerID_Friendie != null) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Friends ( FK_ViewerID_Friender, FK_ViewerID_Friendie ) VALUES( (select ID from Viewers where Auth0ID = @Auth0ID) , @FK_ViewerID_Friendie ) ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ViewerID_Friendie", viewerID_Friendie);
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
        }//End of CREATE_Friend_by_FriendieID

        //-----------------------CREATE FOLLOWER SECTION---------------------
        public async Task<bool> CREATE_aFollow_to_Viewer_by_viewerID(string? auth0ID, Guid? followieID)
        {
            if ((auth0ID != null) && (followieID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ViewerID_Followie) VALUES( (select ID from Viewers where Auth0ID = @Auth0ID) , @FK_ViewerID_Followie ) ", _conn))
                {
                    command.Parameters.AddWithValue("@Auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ViewerID_Followie", followieID);
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
        }//End of CREATE_aFollow_to_Viewer_by_followieID


        public async Task<bool> CREATE_aFollow_to_Show_with_showID(string? Auth0ID, Guid? FollowieID)
        {
            if ((Auth0ID != null) && (FollowieID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Followers (FK_ViewerID_Follower, FK_ShowID_Followie) VALUES(@FK_ViewerID_Follower, @FK_ShowID_Followie) ", _conn))
                {
                    command.Parameters.AddWithValue("@FK_ViewerID_Follower", Auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID_Followie", FollowieID);
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
        }//End of CREATE_aFollow_to_Show_with_showID


        //-----------------------CREATE SHOW SECTION---------------------
        public async Task<bool> CREATE_myShow_by_auth0ID(string? auth0ID, string? showName, string? showImage, Models.PrivacyLevel? privacyLevel)
        {
            if (auth0ID != null)
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Shows (FK_ViewerID_Owner, ShowName, ShowImage, PrivacyLevel) VALUES( (select ID from Viewers where Auth0ID = @Auth0ID) , @ShowName, @ShowImage, @PrivacyLevel) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@ShowName", showName);
                    command.Parameters.AddWithValue("@ShowImage", showImage);
                    command.Parameters.AddWithValue("@PrivacyLevel", privacyLevel);
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
        }//End of CREATE_myShow_by_auth0ID

        //-----------------------CREATE SHOW SUBSCRIPTION SECTION---------------------
        public async Task<bool> CREATE_mySubscription_to_Show_by_auth0ID_showID(string? auth0ID, Guid? showID, Models.SubscriberMembershipStatus? MembershipStatus)
        {
            if ((showID?.GetType() != typeof(Guid)) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO Subscribers (FK_ViewerID_Subscriber, FK_ShowID_Subscribie, MembershipStatus) VALUES( (select ID from Viewers where Auth0ID = @Auth0ID) , @FK_ShowID_Subscribie, @FK_ShowSessionID, @MembershipStatus) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID_Subscribie", showID);
                    command.Parameters.AddWithValue("@MembershipStatus", MembershipStatus);
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
        }//End of CREATE_myShowSubscription_by_auth0ID_

        //-----------------------CREATE SHOW LIKE SECTION---------------------
        public async Task<bool> CREATE_ShowLike_by_ShowSessionID(string? Auth0ID, Guid? ShowSessionID)
        {
            if ((ShowSessionID?.GetType() != typeof(Guid)) && (Auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowLikes (FK_ViewerID_Liker, FK_ShowSessionID) VALUES( (select ID from Viewers where Auth0ID = @Auth0ID), @FK_ShowSessionID) ", _conn))
                {
                    command.Parameters.AddWithValue("@FK_ShowID_Likie", Auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowSessionID", ShowSessionID);
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
        }//End of CREATE_ShowLike_by_ShowSessionID

        //-----------------------CREATE SHOW COMMENT SECTION---------------------
        public async Task<bool> CREATE_ShowComment_by_showSessionID(string? auth0ID, Guid? showSessionID_ShowCommentie, string? comment)
        {
            if ((showSessionID_ShowCommentie?.GetType() != typeof(Guid)) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowComments (FK_ViewerID_Commenter, FK_ShowSessionID, Comment) VALUES( (select ID from Viewers where Auth0ID = @auth0ID) , @FK_ShowSessionID, @Comment) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowSessionID", showSessionID_ShowCommentie);
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
        }//End of CREATE_ShowComment_by_showSessionID

        //-----------------------CREATE SHOW COMMENT SECTION---------------------
        public async Task<bool> CREATE_myLike_to_ShowComment_by_CommetID(string? auth0ID, Guid? showCommentID)
        {
            if ((showCommentID?.GetType() != typeof(Guid)) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowCommentLikes (FK_ViewerID_Liker, FK_ShowCommentID) VALUES( (select ID from Viewers where Auth0ID = @auth0ID) , @FK_ShowCommentID) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID_Commentie", showCommentID);
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
        public async Task<bool> CREATE_myDonation_to_Show_by_ShowID(string? auth0ID, Guid? fk_showID_Subscribie, decimal? Amount, string Note)
        {
            if ((fk_showID_Subscribie?.GetType() == typeof(Guid)) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowDonations (FK_ViewerID_Donater, FK_ShowID_Donatie, Amount, Note) VALUES( (select ID from Viewers where Auth0ID = @auth0ID) , @FK_ShowID_Donatie, @Amount, @Note) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID_Donatie", fk_showID_Subscribie);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@Note", Note);
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
        }//End of CREATE_ShowDonation_by_ShowID

        //-----------------------CREATE SHOW SESSION SECTION---------------------
        public async Task<bool> CREATE_myShowSession_by_ShowID(string? auth0ID, Guid? showID)
        {
            if ((showID?.GetType() != typeof(Guid)) && (auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowSessions (FK_ShowID ) VALUES( (select ID from Shows where FK_ViewerID_Owner = (select ID from Viewers where Auth0ID = @auth0ID) ) ) ", _conn))
                {
                    command.Parameters.AddWithValue("@auth0ID", auth0ID);
                    command.Parameters.AddWithValue("@FK_ShowID", showID);
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
        public async Task<bool> CREATE_myJoin_to_ShowSession_by_ShowSessionID(string? Auth0ID, Guid? ShowSessionID)
        {
            if ((ShowSessionID?.GetType() != typeof(Guid)) && (Auth0ID != null))
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO ShowSessionJoins (FK_ShowSessionsID, FK_ViewerID_ShowViewer) VALUES(@FK_ShowSessionsID, (select ID from Viewers where Auth0ID = @auth0ID)) ", _conn))
                {
                    command.Parameters.AddWithValue("@FK_ShowSessionsID", ShowSessionID);
                    command.Parameters.AddWithValue("@Auth0ID", Auth0ID);
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
        }//End of CREATE_ShowSessionJoin_by_ShowSessionID




    }
}