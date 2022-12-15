using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MS.REPO
{
    public class DBCONNECTION : IDBCONNECTION
    {
        private readonly IConfiguration __config__;

        public DBCONNECTION(IConfiguration config)
        {
            __config__ = config;
        }

        private void TestConnection()
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is Connected");
                }
                else
                {
                    Console.WriteLine($"AT {DateTime.Now} The Connection is NOT Connected");
                }
            }
        }
        public bool isConnectionValid()
        {
            bool check = false;
            using (NpgsqlConnection connection = this.GetConnection())
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

        private NpgsqlConnection GetConnection()
        {

            if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
            {
                return new NpgsqlConnection(__config__["ConnectionStrings:Development"]);
                //return new NpgsqlConnection("Host=localhost;Database=msadmin;Username=msadmin;Password=@Arcade30;");
            }
            else
            {
                return new NpgsqlConnection(__config__["ConnectionStrings:Production"]);
            }

        }

        public NpgsqlConnection GETDBCONNECTION()
        {
            return GetConnection();
        }

    }
}

