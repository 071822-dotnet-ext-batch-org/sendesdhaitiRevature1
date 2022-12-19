using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using MS.MODELS;
using MS.ACTIONS;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;//to use reflaection to iterate through class
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography.X509Certificates;
//namespace MS.REPO.CONTEXT
namespace MS.REPO
{
    public interface Idbaccess
    {
        Task<List<MintSoupToken>> GET_ALL_MintSoupTokens(Guid mstoken);
        Task<List<Store>> GetStoresAsync(Guid mstoken);
        Task<List<Store>> GetmyStoresAsync(Guid mstoken);
        Task<List<Person>> GET_ALL_Persons();
        Task<List<Email>> GET_ALL_Emails(Guid personID);
        Task<Order> GET_MOST_RECENT_ORDER_by_PERSON_and_STOREID(Guid fk_personID, Guid fk_storeID);
        Task<Person> GET_myMOST_RECENT_PERSON_by_mstokenID(Guid mstoken);
        Task<List<Product>> get_products();
        Task<List<Product>> get_products(string category);
        Task<List<Product>> get_products(int type);
        Task<List<Product>> get_products(string category, int type);
        Task<List<Product>> get_products_by_name(string name);
        Task<List<Product>> get_products(string category,string name, int type);
        Task<Store> Get_my_Store_by_personidAsync(Guid personid);
    }

    public class dbaccess : Idbaccess
    {
        private readonly IDBCONNECTION connection;
        private readonly Imsactions actions;

        public dbaccess(IDBCONNECTION conn, Imsactions act)
        {
            this.connection = conn;
            this.actions = act;
        }

        public async Task<List<MintSoupToken>> GET_ALL_MintSoupTokens(Guid mstoken)
        {
            string cmdstring = $"SELECT mstokenID, email, username, added, updated FROM MintSoupToken ORDER BY added DESC";

            List<MintSoupToken> objs = new();
            List<MintSoupToken> objtoreturn = new();
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    MintSoupToken token = new()
                    {
                        mstokenID = ret.GetGuid(0),
                        email = ret.GetString(1),
                        username = ret.GetString(2),
                        added = ret.GetDateTime(3),
                        updated = ret.GetDateTime(4)
                    };
                    objs.Add(token);
                }
                npgsqlConnection.Close();

            }
            objs.Reverse();
            if (objs.Count > 0)
            {
                foreach (MintSoupToken token in objs)
                {
                    List<Person> people = await this.GetPeople_of_mintsouptoken_Async(token.mstokenID);
                    token.createdpeople = people;
                    objtoreturn.Add(token);
                }
            }
            return objtoreturn;
        }

        public async Task<List<Person>> GET_ALL_Persons()
        {
            string cmdstring = $"SELECT personID, username, image, aboutme, role, membership, added, updated, fk_mstokenID FROM Person ORDER BY added DESC";
            List<Person> objs = new();
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {

                    Person token = new()
                    {
                        personID = ret.GetGuid(0),
                        username = ret.GetString(1),
                        image = ret.GetString(2),
                        aboutme = ret.GetString(3),
                        role = (Statuses.Role)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(4), typeof(Statuses.Role)),
                        membership = (Statuses.ViewerMembership)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(5), typeof(Statuses.ViewerMembership)),
                        added = ret.GetDateTime(6),
                        updated = ret.GetDateTime(7),
                        fk_mstokenID = ret.GetGuid(8)
                    };
                    objs.Add(token);
                }
                npgsqlConnection.Close();
            }
            return objs;
        }

        public async Task<List<Email>> GET_ALL_Emails(Guid personID)
        {
            string cmdstring = $"SELECT emailID, email, added, updated FROM Email ORDER BY added DESC";
            List<Email> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@personID", personID);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Email token = new()
                    {
                        emailID = ret.GetGuid(0),
                        email = ret.GetString(1),
                        added = ret.GetDateTime(2),
                        updated = ret.GetDateTime(3),
                        fk_personID = ret.GetGuid(4)
                    };
                    objs.Add(token);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }
        

        private async Task<List<Person>> GetPeople_of_mintsouptoken_Async(Guid mstokenID)
        {
            string cmdstring = $"SELECT personID, username, image, aboutme, role, membership, added, updated FROM Person WHERE fk_mstokenID = @mstokenID ORDER BY added DESC";
            List<Person> objs = new();
            List<Person> objtoreturn = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@mstokenID", mstokenID);
                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {

                    Person token = new()
                    {
                        personID = ret.GetGuid(0),
                        //token.email = ret.GetString(1);
                        username = ret.GetString(1),
                        image = ret.GetString(2),
                        aboutme = ret.GetString(3),
                        role = (Statuses.Role)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(4), typeof(Statuses.Role)),
                        membership = (Statuses.ViewerMembership)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(5), typeof(Statuses.ViewerMembership)),
                        added = ret.GetDateTime(6),
                        updated = ret.GetDateTime(7)
                    };
                    //token.fk_mstokenID = ret.GetGuid(8);
                    objs.Add(token);
                }
                npgsqlConnection.Close();
            }
            objs.Reverse();
            if(objs.Count > 0)
            {
                foreach (Person person in objs)
                {
                    List<Email> emails = await this.GetEmails_of_person_Async(person.fk_mstokenID);
                    List<Address> addresses = await this.GetAddresses_of_person_Async(person.fk_mstokenID);
                    person.emails = emails;
                    person.addresses = addresses;
                    objtoreturn.Add(person);
                }
            }
            return objtoreturn;
        }


        private async Task<List<Email>> GetEmails_of_person_Async(Guid personID)
        {
            string cmdstring = $"SELECT * FROM Email WHERE fk_personID = @personID ORDER BY added DESC";
            List<Email> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@personID", personID);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Email token = new()
                    {
                        emailID = ret.GetGuid(0),
                        email = ret.GetString(1),
                        added = ret.GetDateTime(2),
                        updated = ret.GetDateTime(3),
                        fk_personID = ret.GetGuid(4)
                    };
                    objs.Add(token);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        private async Task<List<Address>> GetAddresses_of_person_Async(Guid personID)
        {
            string cmdstring = $"SELECT * FROM Address WHERE fk_personID = @personID ORDER BY added DESC";
            List<Address> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@personID", personID);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Address token = new()
                    {
                        addressID = ret.GetGuid(0),
                        street = ret.GetString(1),
                        city = ret.GetString(2),
                        state = ret.GetString(3),
                        country = ret.GetString(4),
                        areacode = ret.GetInt32(5),
                        added = ret.GetDateTime(6),
                        updated = ret.GetDateTime(7),
                        fk_personID = ret.GetGuid(8)
                    };
                    objs.Add(token);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<List<Store>> GetStoresAsync(Guid mstoken)
        {
            string cmdstring = $"SELECT * from get_all_stores()";
            List<Store> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Store obj = new()
                    {
                        storeID = ret.GetGuid(0),
                        fk_personID = ret.GetGuid(1),
                        storename = ret.GetString(2),
                        storeimage = ret.GetString(3),
                        clients = ret.GetInt32(4),
                        views = ret.GetInt32(5),
                        likes = ret.GetInt32(6),
                        comments = ret.GetInt32(7),
                        rating = ret.GetFloat(8),
                        rank = ret.GetInt32(9),
                        privacylevel = (Statuses.Privacylevel)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(10), typeof(Statuses.Privacylevel)),
                        storestatus = (Statuses.StoreStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(11), typeof(Statuses.StoreStatus)),
                        added = ret.GetDateTime(12),
                        updated = ret.GetDateTime(13)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<List<Store>> GetmyStoresAsync(Guid mstoken)
        {
            string cmdstring = $"SELECT * from get_my_stores(@mstoken)";
            List<Store> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@mstoken", mstoken);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Store obj = new()
                    {
                        storeID = ret.GetGuid(0),
                        fk_personID = ret.GetGuid(1),
                        storename = ret.GetString(2),
                        storeimage = ret.GetString(3),
                        clients = ret.GetInt32(4),
                        views = ret.GetInt32(5),
                        likes = ret.GetInt32(6),
                        comments = ret.GetInt32(7),
                        rating = ret.GetFloat(8),
                        rank = ret.GetInt32(9),
                        privacylevel = (Statuses.Privacylevel)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(10), typeof(Statuses.Privacylevel)),
                        storestatus = (Statuses.StoreStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(11), typeof(Statuses.StoreStatus)),
                        added = ret.GetDateTime(12),
                        updated = ret.GetDateTime(13)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<Store> Get_my_Store_by_personidAsync(Guid personid)
        {
            string cmdstring = $"SELECT * from store where fk_personid = @personid Order BY updated Limit 1 ; ";
            Store objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@personid", personid);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Store obj = new()
                    {
                        storeID = ret.GetGuid(0),
                        fk_personID = ret.GetGuid(1),
                        storename = ret.GetString(2),
                        storeimage = ret.GetString(3),
                        clients = ret.GetInt32(4),
                        views = ret.GetInt32(5),
                        likes = ret.GetInt32(6),
                        comments = ret.GetInt32(7),
                        rating = ret.GetFloat(8),
                        rank = ret.GetInt32(9),
                        privacylevel = (Statuses.Privacylevel)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(10), typeof(Statuses.Privacylevel)),
                        storestatus = (Statuses.StoreStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(11), typeof(Statuses.StoreStatus)),
                        added = ret.GetDateTime(12),
                        updated = ret.GetDateTime(13)
                    };
                    objs = obj;
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<Order> GET_MOST_RECENT_ORDER_by_PERSON_and_STOREID(Guid fk_personID, Guid fk_storeID)
        {
            string cmdstring = $" SELECT * from Order where fk_personID = @fk_personID AND fk_storeID = @fk_storeID Order BY added limit 1";
            Order order = new();
            using (NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@fk_personID", fk_personID);
                command.Parameters.AddWithValue("@fk_storeID", fk_storeID);

                dbconnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    order.orderID = ret.GetGuid(0);
                    order.type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType));
                    order.category = ret.GetString(2);
                    order.amount = ret.GetDecimal(3);
                    order.description = ret.GetString(4);
                    order.orderstatus = (Statuses.OrderStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(5), typeof(Statuses.OrderStatus));
                    order.added = ret.GetDateTime(6);
                    order.updated = ret.GetDateTime(7);
                }
                dbconnection.Close();
            }
            return order;
        }

        public async Task<Person> GET_myMOST_RECENT_PERSON_by_mstokenID(Guid mstoken)
        {
            string cmdstring = $" SELECT * from get_my_person(@mstoken) ";
            Person person = new();
            using (NpgsqlConnection dbconnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, dbconnection);
                command.Parameters.AddWithValue("@mstoken", mstoken);

                dbconnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Person person2 = new()
                    {
                        personID = ret.GetGuid(0),
                        username = ret.GetString(1),
                        image = ret.GetString(2),
                        aboutme = ret.GetString(3),
                        role = (Statuses.Role)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(4), typeof(Statuses.Role)),
                        membership = (Statuses.ViewerMembership)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(5), typeof(Statuses.ViewerMembership)),
                        added = ret.GetDateTime(6),
                        updated = ret.GetDateTime(7),
                        fk_mstokenID = ret.GetGuid(8)
                    };

                    person = person2;
                }
                dbconnection.Close();
            }
            if(person.fk_mstokenID == mstoken)
            {
                person.emails = await GetEmails_of_person_Async(person.personID);
                person.addresses = await GetAddresses_of_person_Async(person.personID);
                person.stores = await GetmyStoresAsync(mstoken);
            }
            return person;
        }

        public async Task<List<Product>> get_products()
        {
            string cmdstring = $"SELECT * from products Order by updated limit 50";
            List<Product> objs = new();

            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<List<Product>> get_products(string category)
        {
            string cmdstring = $"SELECT * from get_products_by_category( @category ) ";
            List<Product> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@category", category);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }


        public async Task<List<Product>> get_products(int type)
        {
            string cmdstring = $"SELECT * from get_products_by_type( @type ) ";
            List<Product> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@type", type);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        public async Task<List<Product>> get_products(string category, int type)
        {
            string cmdstring = $"SELECT * from get_products_by_category_and_type( @category, @type ) ";
            List<Product> objs = new();

            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@type", type);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }


        public async Task<List<Product>> get_products_by_name(string name)
        {
            string cmdstring = $"SELECT * from get_products_by_name( @name ) ";
            List<Product> objs = new();
            //msproperties.
            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@name", name);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }


        public async Task<List<Product>> get_products(string category, string name, int type)
        {
            string cmdstring = $"SELECT * from get_products_by_category_name_and_type( @category, @name, @type ) ";
            List<Product> objs = new();

            using (NpgsqlConnection npgsqlConnection = this.connection.GETDBCONNECTION())
            {
                var command = new NpgsqlCommand(cmdstring, npgsqlConnection);
                command.Parameters.AddWithValue("@category", category);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@type", type);

                npgsqlConnection.Open();
                NpgsqlDataReader ret = await command.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Product obj = new()
                    {
                        productID = ret.GetGuid(0),
                        type = (Statuses.ProductType)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(1), typeof(Statuses.ProductType)),
                        category = ret.GetString(2),
                        name = ret.GetString(3),
                        price = ret.GetDecimal(4),
                        description = ret.GetString(5),
                        productstatus = (Statuses.ProductStatus)this.actions.CONVERT_INT_TO_ENUM_STATUS(ret.GetInt32(6), typeof(Statuses.ProductStatus)),
                        added = ret.GetDateTime(7),
                        updated = ret.GetDateTime(8),
                        fk_storeID = ret.GetGuid(9)
                    };
                    objs.Add(obj);
                }
                npgsqlConnection.Close();

            }
            return objs;
        }

        



    }//END of DB ACCESS
}

