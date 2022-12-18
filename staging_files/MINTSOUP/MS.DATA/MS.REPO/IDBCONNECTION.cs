using Npgsql;

namespace MS.REPO
{
    public interface IDBCONNECTION
    {
        NpgsqlConnection GETDBCONNECTION();
        bool isConnectionValid();
    }
}