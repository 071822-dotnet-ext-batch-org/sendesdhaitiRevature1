using System;
using System.Data.SqlClient;


namespace MINTSOUP.TokenAPI
{
    public class userservice : Iuserservice
    {
        private readonly IConfiguration _config;
        private readonly IMSAlgos algos;
        private readonly SqlConnection _conn;

        public userservice(IConfiguration config, IMSAlgos _algo)
        {
            _config = config;
            algos = _algo;


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
        /// This is the model to represent a token
        /// </summary>
        public class MyMintSoupToken
        {
            private static Guid id;
            private static string? email;
            private static string? username;
            private static string? password_Hash;
            private static string? password_Salt;
            private static DateTime dateSignedUp;
            private static DateTime lastSignedIn;

            public  Guid Id { get => id; set => id = value; }
            public  string? Email { get => email; set => email = value; }
            public  string? Username { get => username; set => username = value; }
            public  string? Password_Hash { get => password_Hash; set => password_Hash = value; }
            public  string? Password_Salt { get => password_Salt; set => password_Salt = value; }
            public  DateTime DateSignedUp { get => dateSignedUp; set => dateSignedUp = value; }
            public  DateTime LastSignedIn { get => lastSignedIn; set => lastSignedIn = value; }
            public MyMintSoupToken(Guid _id, string _em, string _us, string _ph, string _ps, DateTime _ds, DateTime _ls)
            {
                Console.WriteLine($"This is the token constructor {email}");
                id = _id;
                email = _em;
                username = _us;
                password_Hash = _ph;
                password_Salt = _ps;
                dateSignedUp = _ds;
                lastSignedIn = DateTime.Now;
            }

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


        public async Task<bool> CREATE_USER_ON_SIGNUP(string Email, string Username, string Password_Hash, string Password_Salt)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO MintSoupTokens ( Email, Username, Password_Hash, Password_Salt) VALUES( @Email, @Username, @Password_Hash, @Password_Salt)", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password_Hash", Password_Hash);
                command.Parameters.AddWithValue("@Password_Salt", Password_Salt);
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

        public async Task<bool> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password)
        {
            using (SqlCommand command = new SqlCommand($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Email = @Email ", _conn))
            {
                command.Parameters.AddWithValue("@Email", Email);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    bool verification = this.algos.VerifyPassword(Password, ret.GetString(0), ret.GetString(1));
                    if(verification == true)
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
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }//End of LOGIN_USER_to_get_TOKEN_w_email

        public async Task<bool> LOGIN_USER_to_get_TOKEN_w_username(string Username, string Password)
        {
            using (SqlCommand command = new SqlCommand($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Username = @Username", _conn))
            {
                command.Parameters.AddWithValue("@Username", Username);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    bool verification = this.algos.VerifyPassword(Password, ret.GetString(0), ret.GetString(1));
                    if (verification == true)
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
                else
                {
                    _conn.Close();
                    return false;
                }
            }
        }//End of LOGIN_USER_to_get_TOKEN_w_username

        public async Task<MyMintSoupToken?> GET_MY_TOKEN_w_email_or_username(string? Email, string? Username)
        {
            if ((Email != null) && (Username == null))
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM MintSoupTokens where Email = @Email", _conn))
                {
                    command.Parameters.AddWithValue("@Email", Email);
                    _conn.Open();

                    SqlDataReader ret = await command.ExecuteReaderAsync();
                    if (ret.Read())
                    {
                        MyMintSoupToken myToken = new MyMintSoupToken(
                            ret.GetGuid(0),
                            ret.GetString(1),
                            ret.GetString(2),
                            ret.GetString(3),
                            ret.GetString(4),
                            ret.GetDateTime(5),
                            ret.GetDateTime(6)
                            );
                        return myToken;
                    }
                    else
                    {
                        _conn.Close();
                        return null;
                    }
                }

            }
            else if ((Email == null) && (Username != null))
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM MintSoupTokens where Username = @Username", _conn))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    _conn.Open();

                    SqlDataReader ret = await command.ExecuteReaderAsync();
                    if (ret.Read())
                    {
                        MyMintSoupToken myToken = new MyMintSoupToken(
                            ret.GetGuid(0),
                            ret.GetString(1),
                            ret.GetString(2),
                            ret.GetString(3),
                            ret.GetString(4),
                            ret.GetDateTime(5),
                            ret.GetDateTime(6)
                            );
                        return myToken;
                    }
                    else
                    {
                        _conn.Close();
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }

        }//END of GET_MY_TOKEN_w_email_or_username


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

