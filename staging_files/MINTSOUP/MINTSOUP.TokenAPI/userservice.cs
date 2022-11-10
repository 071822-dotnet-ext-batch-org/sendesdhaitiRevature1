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

        public async Task<bool> CHECK_IF_EMAIL_EXISTS(string Email)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM MintSoupTokens Where Email = @Email", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
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
        }//End of CHECK_IF_EMAIL_EXISTS

        public async Task<bool> CHECK_IF_USERNAME_EXISTS(string Username)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM MintSoupTokens Where Username = @Username", _conn))
            {
                command.Parameters.AddWithValue("@Username", Username);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
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
        }//End of CHECK_IF_USERNAME_EXISTS


        public async Task<bool> CREATE_USER_ON_SIGNUP(string Email, string Username, string Password)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO MintSoupTokens ( Email, Username, Password) VALUES( @Email, @Username, @Password)", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
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
        }//End of CREATE_USER_ON_SIGNUP

        public async Task<Guid?> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password)
        {
            using (SqlCommand command = new SqlCommand($"SELECT ID FROM Viewers Where MSToken = (select ID from MintSoupTokens where Email = @Email AND Password = @Password) ", _conn))
            {
                Guid? myToken = null;
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    myToken = ret.GetGuid(0);
                    _conn.Close();
                    return myToken;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }//End of LOGIN_USER_to_get_TOKEN_w_email

        public async Task<Guid?> LOGIN_USER_to_get_TOKEN_w_username(string Username, string Password)
        {
            using (SqlCommand command = new SqlCommand($"SELECT ID FROM Viewers Where MSToken = (select ID from MintSoupTokens where Username = @Username AND Password = @Password) ", _conn))
            {
                Guid? myToken = null;
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    myToken = ret.GetGuid(0);
                    _conn.Close();
                    return myToken;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }//End of LOGIN_USER_to_get_TOKEN_w_username


        public async Task<bool> CHANGE_PASSWORD_w_email_and_token(string Email, string Password)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE MintSoupTokens SET Password = @Password Where Email = @Email ", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);
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
        }//End of CHANGE_PASSWORD_w_email_and_token




        


        





    }
}

