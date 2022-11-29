using Npgsql;

namespace MS_API1_Users_Repo
{
    public interface IDBCONNECTION
    {
        NpgsqlConnection GETDBCONNECTION();
    }
}