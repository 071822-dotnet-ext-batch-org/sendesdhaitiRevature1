using System;
using System.Data.SqlClient;
using MINTSOUP.TokenAPI.Controllers;
using static MINTSOUP.TokenAPI.Controllers.MyToken;
using Npgsql;
using System.Data;


namespace MINTSOUP.TokenAPI
{
    public class userservice : Iuserservice
    {
        //private readonly IConfiguration _config;
        private readonly IMSAlgos algos;
        //private NpgsqlConnection _conn;

        public userservice(IMSAlgos _algo)
        {
            //_config = config;
            algos = _algo;
            TestConnection();


            //if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
            //}
            //else
            //{
            //    _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
            //}

        }
        private static void TestConnection()
        {
            using(NpgsqlConnection connection = GetConnection())
            {
                if(connection.State == ConnectionState.Open)
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                }
                else
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost; Port=5432; Username=msadmin; Password=@Arcade30; Database=mintsoupdatadb;");
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
            public MyMintSoupToken() { }
            public MyMintSoupToken(Guid _id, string _em, string _us, DateTime _ds, DateTime _ls)
            {
                //Console.WriteLine($"This is the token constructor for {_em}");
                id = _id;
                email = _em;
                username = _us;
                dateSignedUp = _ds;
                lastSignedIn = DateTime.Now;
            }
            public MyMintSoupToken(Guid _id, string _em, string _us, string _ph, string _ps, DateTime _ds, DateTime _ls)
            {
                //Console.WriteLine($"This is the token constructor for {_em}");
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
            using (NpgsqlConnection _conn = GetConnection())
            {
                string command = $"SELECT * FROM MintSoupTokens Where Email = @Email";
                using var cmd  = new NpgsqlCommand(command, _conn);
                cmd.Parameters.AddWithValue("@Email", Email.ToLowerInvariant());
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
            using (NpgsqlConnection _conn = GetConnection())// ($"SELECT TOP(1) * FROM MintSoupTokens Where Username = @Username", _conn))
            {
                string command = $"SELECT * FROM MintSoupTokens Where Username = @Username";
                using var cmd = new NpgsqlCommand(command, _conn);
                cmd.Parameters.AddWithValue("@Username", Username.ToLowerInvariant());

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
            using (NpgsqlConnection _conn = GetConnection())// ($"INSERT INTO MintSoupTokens ( Email, Username, Password_Hash, Password_Salt) VALUES( @Email, @Username, @Password_Hash, @Password_Salt)", _conn))
            {
                string command = $"INSERT INTO MintSoupTokens ( Email, Username, Password_Hash, Password_Salt) VALUES( @Email, @Username, @Password_Hash, @Password_Salt)";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Email", Email.ToLowerInvariant());
                cmd.Parameters.AddWithValue("@Username", Username.ToLowerInvariant());
                cmd.Parameters.AddWithValue("@Password_Hash", Password_Hash);
                cmd.Parameters.AddWithValue("@Password_Salt", Password_Salt);
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
        }//End of CREATE_USER_ON_SIGNUP

        public async Task<bool> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password)
        {
            using (NpgsqlConnection _conn = GetConnection()) //($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Email = @Email ", _conn))
            {
                string command = $"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Email = @Email ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Email", Email.ToLowerInvariant());
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
            using (NpgsqlConnection _conn = GetConnection()) //($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Username = @Username", _conn))
            {
                string command = $"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Username = @Username";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Username", Username.ToLowerInvariant());
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                using (NpgsqlConnection _conn = GetConnection()) //($"SELECT ID, Email, Username, DateSignedUp, LastSignedIn FROM MintSoupTokens WHERE Email = @Email ", _conn))
                {
                    string command = $"SELECT ID, Email, Username, DateSignedUp, LastSignedIn FROM MintSoupTokens WHERE Email = @Email ";
                    using var cmd = new NpgsqlCommand(command, _conn);

                    cmd.Parameters.AddWithValue("@Email", Email.ToLowerInvariant());
                    _conn.Open();

                    NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                    if (ret.Read())
                    {
                        MyMintSoupToken myToken = new MyMintSoupToken(
                        ret.GetGuid(0),
                        ret.GetString(1),
                        ret.GetString(2),
                        ret.GetDateTime(3),
                        ret.GetDateTime(4)
                            );
                        //Console.WriteLine($"{myToken?.Id}, {myToken?.Email}, {myToken?.Username} was gotten from token at {DateTime.Now} to LOGIN with '{Email}'");
                        _conn.Close();
                        return myToken;
                    }
                    else
                    {
                        _conn.Close();
                        Console.WriteLine($"No token was found - {Email}");
                        return null;
                    }
                }

            }
            else if ((Email == null) && (Username != null))
            {
                using (NpgsqlConnection _conn = GetConnection()) //($"SELECT ID, Email, Username, DateSignedUp, LastSignedIn FROM MintSoupTokens where Username=@Username ", _conn))
                {
                    string command = $"SELECT ID, Email, Username, DateSignedUp, LastSignedIn FROM MintSoupTokens where Username=@Username ";
                    using var cmd = new NpgsqlCommand(command, _conn);

                    cmd.Parameters.AddWithValue("@Username", Username.ToLowerInvariant());
                    _conn.Open();

                    NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                    if (ret.Read())
                    {
                        MyMintSoupToken myToken = new MyMintSoupToken(
                            ret.GetGuid(0),
                            ret.GetString(1),
                            ret.GetString(2),
                            ret.GetDateTime(3),
                            ret.GetDateTime(4)
                            );
                        //Console.WriteLine($"{myToken?.Id}, {myToken?.Email}, {myToken?.Username} was gotten from token at {DateTime.Now} to LOGIN with '{Username}'");
                        _conn.Close();
                        return myToken;
                    }
                    else
                    {
                        _conn.Close();
                        Console.WriteLine($"No token was found - {Username}");
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
            using (NpgsqlConnection _conn = GetConnection()) //($"UPDATE MintSoupTokens SET Password = @Password Where Email = @Email ", _conn))
            {
                string command = $"UPDATE MintSoupTokens SET Password = @Password Where Email = @Email ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Email", Email.ToLowerInvariant());
                cmd.Parameters.AddWithValue("@Password", Password);
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
        }//End of CHANGE_PASSWORD_w_email_and_token




        


        





    }
}

