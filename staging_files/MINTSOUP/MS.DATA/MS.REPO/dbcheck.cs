using System;
using MS.ACTIONS;
using MS.MODELS;
using Npgsql;

namespace MS.REPO
{
	public interface Idbcheck
	{
        Task<bool> CHECK_IF_PERSON_EXISTS(Guid personID);

    }

    public class dbcheck:Idbcheck
    {
        private readonly IDBCONNECTION connection;
        private readonly Imsactions actions;

        public dbcheck(IDBCONNECTION conn, Imsactions act)
        {
            this.connection = conn;
            this.actions = act;
        }


        public async Task<bool> CHECK_IF_PERSON_EXISTS(Guid personID)
        {
            string cmdstring = $"SELECT * from check_if_person_exists_with_personID(@personID)";
            bool check = false;
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@personID", personID);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                if(ret.Read())
                {
                    check = ret.GetBoolean(0);
                }
                npgsqlConnection.Close();

            }
            return check;
        }
    }//END of DB CHECK
}

