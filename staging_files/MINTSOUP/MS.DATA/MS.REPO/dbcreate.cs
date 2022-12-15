using System;
using MS.MODELS;
using MS.ACTIONS;
using Npgsql;
using Npgsql.Internal;
using System.Data;
using System.Xml.Linq;

namespace MS.REPO
{
	public interface Idbcreate
	{
        Task<bool> CREATE_STORE(Guid personID, string storename, string image, Statuses.Privacylevel privacyLevel);
        Task<bool> CREATE_PRODUCT(Guid storeID, Statuses.ProductType type, string category, string name, decimal price, string description, Statuses.ProductStatus status);
        Task<bool> CREATE_CLIENT(Guid personID, Guid storeid);
        Task<bool> CREATE_ORDER(Guid personID, Guid productID, Statuses.ProductType type, string category, decimal amount, string desc, Statuses.OrderStatus orderStatus);

    }

	public class dbcreate : Idbcreate
    {
        private readonly IDBCONNECTION connection;
        public dbcreate(IDBCONNECTION conn)
        {
            this.connection = conn;
        }

        public async Task<bool> CREATE_STORE(Guid personID, string storename, string image, Statuses.Privacylevel privacyLevel)
        {
            string cmdstring = $" SELECT * from create_store(@personID, @storename, @image, @pl)";
            bool check = false;
            using(NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@personID", personID);
                command.Parameters.AddWithValue("@storename", storename);
                command.Parameters.AddWithValue("@image", image);
                command.Parameters.AddWithValue("@pl", privacyLevel);

                dbconnection.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if(ret > 0)
                {
                    check = true;
                }
                dbconnection.Close();
            }
            return check;
        }//END

        public async Task<bool> CREATE_PRODUCT( Guid storeID, Statuses.ProductType type, string category, string name, decimal price, string description, Statuses.ProductStatus status)
        {
            string cmdstring = $" SELECT * from create_product(@storeID,  @type, @category, @name, @price, @description, @status)";
            bool check = false;
            using (NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@storeID", storeID);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@status", status);

                dbconnection.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    check = true;
                }
                dbconnection.Close();
            }
            return check;
        }//END

        public async Task<bool> CREATE_CLIENT(Guid personID, Guid storeid)
        {
            string cmdstring = $" SELECT * from create_client(@personID, @storeid)";
            bool check = false;
            using (NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@personID", personID);
                command.Parameters.AddWithValue("@storeid", storeid);

                dbconnection.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    check = true;
                }
                dbconnection.Close();
            }
            return check;
        }//END

        public async Task<bool> CREATE_ORDER(Guid personID, Guid productID , Statuses.ProductType type, string category, decimal amount, string desc, Statuses.OrderStatus orderStatus)
        {
            string cmdstring = $" SELECT * from create_order(@personID, @productID, @type, @category, @amount , @desc , @orderStatus)";
            bool check = false;
            using (NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@personID", personID);
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@desc", desc);
                command.Parameters.AddWithValue("@orderStatus", orderStatus);

                dbconnection.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    check = true;
                }
                dbconnection.Close();
            }
            return check;
        }//END
    }
}

