﻿using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Npgsql;
// using MS_API1_Users_Model;
namespace MS_API1_Users_Repo;

public class CHECK_AccessLayer : ICHECK_AccessLayer
{
    //private readonly IConfiguration _config;
    //private readonly SqlConnection _conn;
    private readonly IDBCONNECTION _conn;
    public CHECK_AccessLayer(IDBCONNECTION c)
    {
        this._conn = c;
    }

    //public CHECK_AccessLayer(IConfiguration config)
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

    public enum CHECKSTATUS
    {
        TRUE,
        FALSE,
        SAVED,
        NOT_SAVED,
        GOTTEN,
        NOT_GOTTEN,
        DELETED,
        NOT_DELETED,
        NO_MSTOKEN,
    }

    //-----------------------CHECK VIEWER SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Viewer_by_Email(string Email)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where Email = @Email", _conn))
        {
            string command = $"SELECT * FROM Viewers Where Email = @Email";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@Email", Email);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Viewer_by_Email

    public async Task<CHECKSTATUS> CHECK_Viewer_by_MSToken(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where FK_MSToken = @MSToken", _conn))
        {
            string command = $"SELECT * FROM Viewers Where FK_MSToken = @MSToken";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Viewer_by_MSToken

    public async Task<CHECKSTATUS> CHECK_Viewer_by_username(string username)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where ID = @ID", _conn))
        {
            string command = $"SELECT * FROM Viewers Where Username = @Username";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@Username", username);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Viewer_by_viewerID

    //-----------------------CHECK ADMIN SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Admin_by_Email(string Email)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where Email = @Email", _conn))
        {
            string command = $"SELECT * FROM Admins Where Email = @Email";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@Email", Email);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Admin_by_Email

    public async Task<CHECKSTATUS> CHECK_Admin_by_MSToken(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where FK_MSToken = @MSToken", _conn))
        {
            string command = $"SELECT * FROM Admins Where FK_MSToken = @MSToken";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Admin_by_MSToken

    //-----------------------CHECK FRIEND SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Friend_by_FriendID_Freinder(Guid MSToken, Guid FriendieViewerID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ", _conn))
        {
            string command = $"SELECT * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Friendie = @FK_ViewerID_Friendie ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@FK_ViewerID_Friendie", FriendieViewerID);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Friend_by_ViewerID_Freinder

    //-----------------------CHECK FOLLOWER SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Follow_by_FollowID_Follower(Guid MSToken, Guid FollowieViewerID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Followie = @FK_ViewerID_Followie ", _conn))
        {
            string command = $"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Followie = @FK_ViewerID_Followie ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@FK_ViewerID_Followie", FollowieViewerID);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Follow_by_ViewerID_Follower

    //-----------------------CHECK SHOWS SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_Shows(Guid? MSToken)
    {
        if (MSToken == null) { return 0; }
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM Shows ", _conn))
        {
            string command = $"SELECT * FROM Shows ";
            using var cmd = new NpgsqlCommand(command, _conn);

            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;
            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_Shows

    public async Task<int> CHECK_if_YOU_have_ANY_Shows(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
        {
            string command = $"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers where FK_MSToken = @MSToken) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_Show_by_ShowOwnerID

    public async Task<CHECKSTATUS> CHECK_if_Show_EXISTS_by_ShowName(string showName)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Shows Where ShowName = @ShowName ", _conn))
        {
            string command = $"SELECT * FROM Shows Where ShowName = @ShowName ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@ShowName", showName);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_Show_by_ShowOwnerID

    //-----------------------CHECK SHOW SUBSCRIBERS SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_Subscribers()
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers ", _conn))
        {
            string command = $"SELECT * FROM Subscribers ";
            using var cmd = new NpgsqlCommand(command, _conn);

            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_Shows

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
        {
            string command = $"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_ANY_Subscriptions

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions_To_This_Show(Guid MSToken, Guid ShowID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT Top(1) * FROM Subscribers Where ID = @ID AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ", _conn))
        {
            string command = $"SELECT * FROM Subscribers Where ID = @ID AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@ID", ShowID);
            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_ANY_Subscriptions


    /// <summary>
    /// THis method checks to see if my show has been subscribed to. This uses my show's ID and I must have a Auth0 ID to check
    /// </summary>
    /// <param name="MSToken"></param>
    /// <param name="OBJID"></param>
    /// <returns>returns a CHECKSTATUS type</returns>
    public async Task<int> CHECK_if_this_SHOW_has_ANY_Subscribers(Guid ShowId)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where  FK_ShowID_Subscribie =  @myShowtoCheck_if_it_has_Subscribers  ", _conn))
        {
            string command = $"SELECT * FROM Subscribers Where  FK_ShowID_Subscribie =  @myShowtoCheck_if_it_has_Subscribers  ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@myShowtoCheck_if_it_has_Subscribers", ShowId);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;
            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_YOURSHOW_has_ANY_Subscribers

    //-----------------------GET SHOW LIKES SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_LikesOnShowSession(Guid ShowSession)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID ", _conn))
        {
            string command = $"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSession);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;
            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_LikesOnShowSession

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_ANY_LikesOnShowSession(Guid MSToken, Guid ShowSession)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT Top(1) * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ", _conn))
        {
            string command = $"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSession);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_ANY_LikesOnShowSession


    //-----------------------CHECK SHOW COMMENTS SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_CommentsOnShowSession(Guid ShowSession)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID ", _conn))
        {
            string command = $"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSession);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;
            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_CommentsOnShowSession

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_THIS_CommentOnShowSession(Guid MSToken, Guid CommentID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowComments Where ID = @ID AND FK_ViewerID_Commenter = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ", _conn))
        {
            string command = $"SELECT * FROM ShowComments Where ID = @ID AND FK_ViewerID_Commenter = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@ID", CommentID);
            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_THIS_CommentOnShowSession

    //-----------------------CHECK SHOW DONATIONS SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Where FK_Wallets_ShowID = (select ID from Wallets_Show where FK_ViewerID_WalletOwner = (select ID from Viewers where FK_MSToken = @MSToken))  ", _conn))
        {
            string command = $"SELECT * FROM ShowDonations Where FK_Wallets_ShowID = (select ID from Wallets_Show where FK_ViewerID_WalletOwner = (select ID from Viewers where FK_MSToken = @MSToken))  ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_THIS_Donation_to_a_Show(Guid MSToken, Guid ShowDonationID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowDonations Where ID = @ID AND FK_ViewerID_Donater = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ", _conn))
        {
            string command = $"SELECT * FROM ShowDonations Where ID = @ID AND FK_ViewerID_Donater = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@ID", ShowDonationID);
            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_THIS_Donation_to_a_Show

    //-----------------------CHECK SHOW SESSIONS SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_ShowSessions(Guid MSToken)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions", _conn))
        {
            string command = $"SELECT * FROM ShowSessions";
            using var cmd = new NpgsqlCommand(command, _conn);

            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_ShowSessions

    public async Task<int> CHECK_if_there_are_ANY_ShowSessions_on_aShow(Guid ShowID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Where FK_ShowID = @FK_ShowID ", _conn))
        {
            string command = $"SELECT * FROM ShowSessions Where FK_ShowID = @FK_ShowID ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@FK_ShowID", ShowID);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_ShowSessions_on_aShow

    //-----------------------CHECK SHOW COMMENT LIKES SECTION---------------------
    public async Task<int> CHECK_if_there_are_ANY_LikesOnShowComment(Guid ShowComment)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID", _conn))
        {
            string command = $"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@FK_ShowCommentID", ShowComment);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_there_are_ANY_LikesOnShowComment

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_A_LikeOnShowComment(Guid MSToken, Guid ShowCommentID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ", _conn))
        {
            string command = $"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where FK_MSToken = @MSToken ) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@FK_ShowCommentID", ShowCommentID);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_made_A_LikeOnShowComment

    //-----------------------CHECK WALLET SECTION---------------------
    public async Task<int> CHECK_if_YOU_Own_the_showsWallet(Guid MSToken, Guid ShowWalletID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Show Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers Where FK_MSToken = @MSToken) ", _conn))
        {
            string command = $"SELECT * FROM Wallets_Show Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers Where FK_MSToken = @MSToken) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@ID", ShowWalletID);
            _conn.Open();

            int ret = await cmd.ExecuteNonQueryAsync();
            int result = 0;

            if (ret > 0)
            {
                result = ret;
                _conn.Close();
                return result;
            }
            else
            {
                _conn.Close();
                return result;
            }
        }
    }//End of CHECK_if_YOU_Own_the_storesWallet

    public async Task<CHECKSTATUS> CHECK_if_YOU_Own_the_personalWallet(Guid MSToken, Guid ViewersWalletID)
    {
        using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Viewer Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers Where FK_MSToken = @MSToken) ", _conn))
        {
            string command = $"SELECT * FROM Wallets_Viewer Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers Where FK_MSToken = @MSToken) ";
            using var cmd = new NpgsqlCommand(command, _conn);

            cmd.Parameters.AddWithValue("@MSToken", MSToken);
            cmd.Parameters.AddWithValue("@ID", ViewersWalletID);
            _conn.Open();

            NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
            if (ret.Read())
            {
                _conn.Close();
                return CHECKSTATUS.TRUE;
            }
            else
            {
                _conn.Close();
                return CHECKSTATUS.FALSE;
            }
        }
    }//End of CHECK_if_YOU_Own_the_personalWallet




}
