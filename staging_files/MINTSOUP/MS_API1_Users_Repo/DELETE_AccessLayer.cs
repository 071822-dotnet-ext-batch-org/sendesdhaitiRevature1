using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MS_API1_Users_Model;
using Models;

namespace MS_API1_Users_Repo
{
    public interface IDELETE_AccessLayer
    {
        Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myViewer_by_auth0ID(string? Auth0ID);
        Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myLike_on_ShowSession_by_auth0ID(string? Auth0ID, Guid? sessionID);
    }

    public class DELETE_AccessLayer : IDELETE_AccessLayer
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public DELETE_AccessLayer(IConfiguration config)
        {
            _config = config;


            if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
            {
                _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
            }
            else
            {
                _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
            }

        }
        public async Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myViewer_by_auth0ID(string? Auth0ID)
        {
            if ((Auth0ID?.GetType() == typeof(string)))
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM Viewers Where Auth0ID = @Auth0ID", _conn))
                {
                    command.Parameters.AddWithValue("Auth0ID", Auth0ID);
                    _conn.Open();

                    int ret = await command.ExecuteNonQueryAsync();
                    if (ret > 0)
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.DELETED;
                    }
                    else
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.NOT_DELETED;
                    }
                }
            }
            else
            {
                return CHECK_AccessLayer.CHECKSTATUS.NO_AUTH0;
            }
        }//End of DELETE_myViewer_by_auth0ID

        public async Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myLike_on_ShowSession_by_auth0ID(string? Auth0ID, Guid? sessionID)
        {
            if ((Auth0ID?.GetType() == typeof(string)))
            {
                using (SqlCommand command = new SqlCommand($"DELETE FROM ShowLikes " + 
                                " Where FK_ViewerID_Liker = ( select ID from Viewers where Auth0ID = @Auth0ID ) " + 
                                " AND FK_ShowSessionID = @FK_ShowSessionID ", _conn))
                {
                    command.Parameters.AddWithValue("Auth0ID", Auth0ID);
                    command.Parameters.AddWithValue("FK_ShowSessionID", sessionID);
                    _conn.Open();

                    int ret = await command.ExecuteNonQueryAsync();
                    if (ret > 0)
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.DELETED;
                    }
                    else
                    {
                        _conn.Close();
                        return CHECK_AccessLayer.CHECKSTATUS.NOT_DELETED;
                    }
                }
            }
            else
            {
                return CHECK_AccessLayer.CHECKSTATUS.NO_AUTH0;
            }
        }//END of DELETE_myLike_on_ShowSession_by_auth0ID





    }
}