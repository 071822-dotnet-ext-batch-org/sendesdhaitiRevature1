using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
// using MS_API1_Users_Model;
namespace MS_API1_Users_Repo;

public class CHECK_AccessLayer : ICHECK_AccessLayer
{
    private readonly IConfiguration _config;
    private readonly SqlConnection _conn;

    public CHECK_AccessLayer(IConfiguration config)
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
    public enum CHECKSTATUS
    {
        TRUE,
        FALSE,
        NO_AUTH0,
        EMPTY_OBJ,
        NULL,
        SAVED,
        NOT_SAVED,
        DELETED,
        NOT_DELETED
    }

    //-----------------------CHECK VIEWER SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Viewer_by_Email(string? Email)
    {
        using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where Email = @Email", _conn))
        {
            command.Parameters.AddWithValue("@Email", Email);
            _conn.Open();

            SqlDataReader ret = await command.ExecuteReaderAsync();
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

    public async Task<CHECKSTATUS> CHECK_Viewer_by_MSToken(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where MSToken = @MSToken", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Viewer_by_MSToken

    public async Task<CHECKSTATUS> CHECK_Viewer_by_viewerID(string? MSToken, Guid? ViewerID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where ID = @ID", _conn))
            {
                command.Parameters.AddWithValue("@ID", ViewerID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Viewer_by_viewerID

    //-----------------------CHECK ADMIN SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Admin_by_Email(string? Email)
    {
        using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where Email = @Email", _conn))
        {
            command.Parameters.AddWithValue("@Email", Email);
            _conn.Open();

            SqlDataReader ret = await command.ExecuteReaderAsync();
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

    public async Task<CHECKSTATUS> CHECK_Admin_by_MSToken(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where MSToken = @MSToken", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Admin_by_MSToken

    //-----------------------CHECK FRIEND SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Friend_by_FriendID_Freinder(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Friends Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Friend_by_ViewerID_Freinder

    //-----------------------CHECK FOLLOWER SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_Follow_by_FollowID_Follower(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Followers Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Follow_by_ViewerID_Follower

    //-----------------------CHECK SHOWS SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_Shows(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_Shows

    public async Task<CHECKSTATUS> CHECK_if_YOU_have_ANY_Shows(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where FK_ViewerID_Owner = @FK_ViewerID_Owner ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Owner", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Show_by_ShowOwnerID

    public async Task<CHECKSTATUS> CHECK_if_Show_EXISTS_by_ShowName(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Shows Where ShowName = @ShowName ", _conn))
            {
                command.Parameters.AddWithValue("@ShowName", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_Show_by_ShowOwnerID

    //-----------------------CHECK SHOW SUBSCRIBERS SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_Subscribers(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_Shows

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_ANY_Subscriptions(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ViewerID_Owner = @FK_ViewerID_Owner ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_Owner", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_made_ANY_Subscriptions


    /// <summary>
    /// THis method checks to see if my show has been subscribed to. This uses my show's ID and I must have a Auth0 ID to check
    /// </summary>
    /// <param name="MSToken"></param>
    /// <param name="OBJID"></param>
    /// <returns>returns a CHECKSTATUS type</returns>
    public async Task<CHECKSTATUS> CHECK_if_YOURSHOW_has_ANY_Subscribers(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ShowID_Subscribie =  myShowtoCheck_if_it_has_Subscribers ", _conn))
            {
                command.Parameters.AddWithValue("@myShowtoCheck_if_it_has_Subscribers", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOURSHOW_has_ANY_Subscribers

    //-----------------------GET SHOW LIKES SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_LikesOnShowSession(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_LikesOnShowSession

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_ANY_LikesOnShowSession(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where MSToken = @MSToken ) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_made_ANY_LikesOnShowSession


    //-----------------------CHECK SHOW COMMENTS SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_CommentsOnShowSession(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_CommentsOnShowSession

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_THIS_CommentOnShowSession(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowComments Where ID = @ID AND FK_ViewerID_Commenter = ( select ID FROM Viewers Where MSToken = @MSToken ) ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_made_THIS_CommentOnShowSession

    //-----------------------CHECK SHOW DONATIONS SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Where FK_Wallets_ShowID = " +
            " (select ID from Shows Where FK_ViewerID_Owner = ( select ID FROM Viewers Where MSToken = @MSToken )) ", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_Donations_on_MYShow_with_MSToken

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_THIS_Donation_to_a_Show(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowDonations Where ID = @ID AND FK_ViewerID_Donater = ( select ID FROM Viewers Where MSToken = @MSToken ) ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_made_THIS_Donation_to_a_Show

    //-----------------------CHECK SHOW SESSIONS SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_ShowSessions(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_ShowSessions

    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_ShowSessions_on_aShow(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Where FK_ShowID = @FK_ShowID ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_ShowSessions_on_aShow

    //-----------------------CHECK SHOW COMMENT LIKES SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_there_are_ANY_LikesOnShowComment(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowCommentID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_there_are_ANY_LikesOnShowComment

    public async Task<CHECKSTATUS> CHECK_if_YOU_made_A_LikeOnShowComment(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = ( select ID FROM Viewers Where MSToken = @MSToken ) ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowCommentID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_made_A_LikeOnShowComment

    //-----------------------CHECK WALLET SECTION---------------------
    public async Task<CHECKSTATUS> CHECK_if_YOU_Own_the_storesWallet(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Show Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers where MSToken = @MSToken) ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_Own_the_storesWallet

    public async Task<CHECKSTATUS> CHECK_if_YOU_Own_the_personalWallet(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Viewer Where ID = @ID AND FK_ViewerID_WalletOwner = (select ID from Viewers where MSToken = @MSToken) ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
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
        }
        else
        {
            return CHECKSTATUS.NO_AUTH0;
        }
    }//End of CHECK_if_YOU_Own_the_personalWallet




}
