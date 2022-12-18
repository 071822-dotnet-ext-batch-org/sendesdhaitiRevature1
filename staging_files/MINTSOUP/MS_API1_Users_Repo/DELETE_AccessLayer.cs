using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MS_API1_Users_Model;
using Models;
using Npgsql;

namespace MS_API1_Users_Repo
{


    public class DELETE_AccessLayer : IDELETE_AccessLayer
    {
        private readonly IDBCONNECTION _conn;
        public DELETE_AccessLayer(IDBCONNECTION c)
        {
            this._conn = c;
        }
        //private readonly IConfiguration _config;
        //private readonly SqlConnection _conn;

        //public DELETE_AccessLayer(IConfiguration config)
        //{
        //    _config = config;


        //    if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
        //    }
        //    else
        //    {
        //        _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
        //    }

        //}

        public async Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myViewer_by_MSToken(Guid? MSToken)
        {
            if ((MSToken?.GetType() == typeof(string)))
            {
                using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//= new Sqlcmd($"DELETE FROM Viewers Where FK_MSToken = @MSToken", _conn))
                {
                    string command = $"DELETE FROM Viewers Where FK_MSToken = @MSToken";
                    using var cmd = new NpgsqlCommand(command, _conn);

                    cmd.Parameters.AddWithValue("MSToken", MSToken);
                    _conn.Open();

                    int ret = await cmd.ExecuteNonQueryAsync();
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
                return CHECK_AccessLayer.CHECKSTATUS.NO_MSTOKEN;
            }
        }//End of DELETE_myViewer_by_MSToken

        public async Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myLike_on_ShowSession_by_MSToken(Guid? MSToken, Guid sessionID)
        {
            if ((MSToken?.GetType() == typeof(string)))
            {
                using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())//= new Sqlcmd($"DELETE FROM ShowLikes " + 
                                                                             //" Where FK_ViewerID_Liker = ( select ID from Viewers where FK_MSToken = @MSToken ) " + 
                                                                             //" AND FK_ShowSessionID = @FK_ShowSessionID ", _conn))
                {
                    string command = $"DELETE FROM ShowLikes " +
                                " Where FK_ViewerID_Liker = ( select ID from Viewers where FK_MSToken = @MSToken ) " +
                                " AND FK_ShowSessionID = @FK_ShowSessionID ";
                    using var cmd = new NpgsqlCommand(command, _conn);

                    cmd.Parameters.AddWithValue("MSToken", MSToken);
                    cmd.Parameters.AddWithValue("FK_ShowSessionID", sessionID);
                    _conn.Open();

                    int ret = await cmd.ExecuteNonQueryAsync();
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
                return CHECK_AccessLayer.CHECKSTATUS.NO_MSTOKEN;
            }
        }//END of DELETE_myLike_on_ShowSession_by_MSToken





    }
}