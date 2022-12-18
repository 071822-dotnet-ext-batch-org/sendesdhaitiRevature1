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
        private readonly IMSAlgos algos;

        public userservice(IMSAlgos _algo)
        {
            algos = _algo;
            TestConnection();
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

        

        public async Task<bool> CHECK_IF_EMAIL_EXISTS(string Email)
        {
            bool check = false;
            using (NpgsqlConnection _conn = GetConnection())
            {
                string command = $"SELECT * from CHECK_if_mstoken_exists_by_email(@Email) ";
                var cmd  = new NpgsqlCommand(command, _conn);
                cmd.Parameters.AddWithValue("@Email", Email);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    check = ret.GetBoolean(0);
                    Console.WriteLine($"The check was {check}");
                }
                _conn.Close();
            }
            return check;
        }//End of CHECK_IF_EMAIL_EXISTS

        public async Task<bool> CHECK_IF_USERNAME_EXISTS(string Username)
        {
            bool check = false;
            using (NpgsqlConnection _conn = GetConnection())// ($"SELECT TOP(1) * FROM MintSoupTokens Where Username = @Username", _conn))
            {
                string command = $"SELECT * from CHECK_if_mstoken_exists_by_username(@Username) ";
                var cmd = new NpgsqlCommand(command, _conn);
                cmd.Parameters.AddWithValue("@Username", Username);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    check = ret.GetBoolean(0);
                    Console.WriteLine($"The check was {check}");
                }
                _conn.Close();
            }
            return check;
        }//End of CHECK_IF_USERNAME_EXISTS


        public async Task<bool> CREATE_USER_ON_SIGNUP(string Email, string Username, string Password)
        {
            bool check = false;
            using (NpgsqlConnection _conn = GetConnection())// ($"INSERT INTO MintSoupTokens ( Email, Username, Password_Hash, Password_Salt) VALUES( @Email, @Username, @Password_Hash, @Password_Salt)", _conn))
            {
                string command = $" SELECT * from signup(@Email, @Username, @Password) ;";
                var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    check = ret.GetBoolean(0);
                }
                _conn.Close();
            }
            return check;
        }//End of CREATE_USER_ON_SIGNUP

        public async Task<MintSoupToken?> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password)
        {
            bool success = false;
            MintSoupToken token = new MintSoupToken(); 
            using (NpgsqlConnection _conn = GetConnection()) //($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Email = @Email ", _conn))
            {
                string command = $"SELECT * from  login_with_email_and_password(@Email, @Password) ; ";
                var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    token = new MintSoupToken(
                        ret.GetGuid(0),
                        ret.GetString(1),
                        ret.GetString(2)
                        );
                    success = true;
                }
                else
                {
                    success = false;
                }
                _conn.Close();
            }
            if(!success)
            {
                return null;
            }
            return token;
        }//End of LOGIN_USER_to_get_TOKEN_w_email

        public async Task<MintSoupToken?> LOGIN_USER_to_get_TOKEN_w_username(string Username, string Password)
        {
            bool success = false;
            MintSoupToken token = new MintSoupToken(); 
            using (NpgsqlConnection _conn = GetConnection()) //($"SELECT Password_Hash , Password_Salt FROM MintSoupTokens where Email = @Email ", _conn))
            {
                string command = $"SELECT * from login_with_username_and_password(@Username, @Password) ; ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@Username", Username.ToLowerInvariant());
                cmd.Parameters.AddWithValue("@Password", Password.ToLowerInvariant());
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    token = new MintSoupToken(
                        ret.GetGuid(0),
                        ret.GetString(1),
                        ret.GetString(2)
                        );
                    success = true;
                }
                else
                {
                    success = false;
                }
                _conn.Close();
            }
            if(!success)
            {
                return null;
            }
            return token;
        }//End of LOGIN_USER_to_get_TOKEN_w_username







        


        





    }
}

