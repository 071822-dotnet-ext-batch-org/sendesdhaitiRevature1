using System;
using System.Data;
using Npgsql;

namespace MS_API1_Users_Repo
{
    public class DBCONNECTION : IDBCONNECTION
    {
        private static void TestConnection()
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                }
                else
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                }
            }
        }
        public static bool isConnectionValid()
        {
            bool check = false;
            using (NpgsqlConnection connection = GetConnection())
            {
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                    check = true;
                }
                else
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is NOT Connected");
                    check = false;
                }
            }
            return check;
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost; Port=5432; Username=msadmin; Password=@Arcade30; Database=mintsoupdatadb;");
        }

        public NpgsqlConnection GETDBCONNECTION()
        {
            return GetConnection();
        }
        public DBCONNECTION()
        {
            TestConnection();
        }
    }
}

