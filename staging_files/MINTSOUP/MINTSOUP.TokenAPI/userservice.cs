using System;
using System.Data.SqlClient;


namespace MINTSOUP.TokenAPI
{
    public class userservice : Iuserservice
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public userservice(IConfiguration config)
        {
            _config = config;


            if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production", StringComparison.InvariantCultureIgnoreCase))
            {
                _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
            }
            else
            {
                _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
            }

        }

        public enum CHECKSTATUS
        {
            TRUE,
            FALSE
        }

        public enum USERROLE
        {
            Viewer,
            Admin,
            NO_USER_FOUND
        }


        /// <summary>
        /// This checks if a viewer exists using their email, if they do, return true as well as their user role (Viewer or Admin)
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>returns true/false and that user's role if found</returns>
        public async Task<(CHECKSTATUS, USERROLE)> CHECK_IF_Viewer_IS_ADMIN_by_Email(string? Email)
        {
            using (SqlCommand command = new SqlCommand($"SELECT Role FROM Viewers Where Email = @Email", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    if (ret.GetString(0) == USERROLE.Viewer.ToString())
                    {
                        _conn.Close();
                        return (CHECKSTATUS.TRUE, USERROLE.Viewer);

                    }
                    else if (ret.GetString(0) == USERROLE.Admin.ToString())
                    {
                        _conn.Close();
                        return (CHECKSTATUS.TRUE, USERROLE.Admin);

                    }
                    else
                    {
                        _conn.Close();
                        return (CHECKSTATUS.TRUE, USERROLE.Viewer);
                    }
                }
                else
                {
                    _conn.Close();
                    return (CHECKSTATUS.FALSE, USERROLE.NO_USER_FOUND);
                }
            }
        }//End of CHECK_Viewer_by_Email





    }
}

