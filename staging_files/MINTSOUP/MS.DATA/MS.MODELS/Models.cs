//using System.Data.Entity;

using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics.Metrics;

namespace MS.MODELS;

public class MintSoupToken
{
    [Key]
    public Guid mstokenID { get; set; }
    public string? email { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public DateTime added { get; set; }
    public DateTime updated { get; set; }
    public virtual List<Person> createdpeople { get; set; } 

}

public class MSTLocationData
{
    public Guid id { get; set; }
    public string? asn { get; set; }
    public string? city { get; set; }
    public string? continent_code { get; set; }
    public string? country { get; set; }
    public int country_area { get; set; }
    public string? country_calling_code { get; set; }
    public string? country_capital { get; set; }
    public string? country_code { get; set; }
    public string? country_code_iso3 { get; set; }
    public string? country_name { get; set; }
    public int country_population { get; set; }
    public string? country_tld { get; set; }
    public string? currency { get; set; }
    public string? currency_name { get; set; }
    public bool in_eu { get; set; }
    public string? ip { get; set; }
    public string? languages { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
    public string? network { get; set; }
    public string? org { get; set; }
    public string? postal { get; set; }
	public string? region { get; set; }
    public string? region_code { get; set; }
    public string? timezone { get; set; }
    public string? utc_offset { get; set; }
    public string? version { get; set; }


    public DateTime added { get; set; }
    public DateTime updated { get; set; }
    public Guid fk_mstokenID { get; set; }
}

public class Person
{
    [Key]
    public  Guid personID { get; set; }
    public  string? username { get; set; }
    public  string? image { get; set; }
    public  string? aboutme { get; set; }
    //Collection navigation property: A navigation property that contains references to many related entities.
    public Statuses.Role role { get; set; }
    public Statuses.ViewerMembership membership { get; set; }
    public  DateTime added { get; set; }
    public  DateTime updated { get; set; }
    public  Guid fk_mstokenID { get; set; }
    public  virtual List<Email> emails { get; set; } 
    public  virtual List<Address> addresses { get; set; }
    public  virtual List<Store> stores { get; set; }
    //public virtual List<Order>? orders { get; set; }
}

public class Email
{
    [Key]
    public  Guid emailID { get; set; }
    //Reference navigation property: A navigation property that holds a reference to a single related entity.
    public  string? email { get; set; }
    public  DateTime added { get; set; }
    public  DateTime updated { get; set; }
    public Guid fk_personID { get; set; }
}

public class Address
{
    [Key]
    public  Guid addressID { get; set; }
    public  string? street { get; set; }
    public  string? city { get; set; }
    public  string? state { get; set; }
    public  string? country { get; set; }
    public  int areacode { get; set; }
    public  DateTime added { get; set; }
    public  DateTime updated { get; set; }
    public  Guid fk_personID { get; set; }
}

public class Store
{
    public Guid storeID { get; set; }
    public string? storename { get; set; }
    public string? storeimage { get; set; }
    public int clients { get; set; }
    public int views { get; set; }
    public int likes { get; set; }
    public int comments { get; set; }
    public float rating { get; set; }
    public int rank { get; set; }
    public Statuses.Privacylevel privacylevel { get; set; }
    public Statuses.StoreStatus storestatus { get; set; }

    public DateTime added { get; set; }
    public DateTime updated { get; set; }
    public Guid fk_personID { get; set; }
    public virtual List<Product>? products { get; set; }
    public virtual  List<Client>? storesclients { get; set; }
    public virtual List<Order>? orders { get; set; }
    public virtual List<StoreComment>? storecomments { get; set; }
}

public class Product
{
    public Guid productID { get; set; }
    public Statuses.ProductType type { get; set; }
    public string? category { get; set; }
    public string? name { get; set; }
    public decimal price { get; set; }
    public string? description { get; set; }
    public Statuses.ProductStatus productstatus { get; set; }
    public DateTime added { get; set; }
    public DateTime updated { get; set; }
    public Guid fk_storeID { get; set; }
}

public class Category
{
    public Guid categoryID { get; set; }
    public Statuses.ProductType type { get; set; }
    public string? category { get; set; }
    public DateTime added { get; set; }
    public DateTime updated { get; set; }
}

public class Order
{
    public Guid orderID { get; set; }
    public Statuses.ProductType type { get; set; }
    public string? category { get; set; }
    public decimal amount { get; set; }
    public string? description { get; set; }
    public Statuses.OrderStatus? orderstatus { get; set; }
    public DateTime added { get; set; }
    public DateTime updated { get; set; }

    public Guid fk_personID { get; set; }
    public Guid fk_productID { get; set; }
}

public class Client
{
    public Guid clientID { get; set; }
    public Statuses.ClientStatus clientstatus { get; set; }

    public DateTime added { get; set; }
    public DateTime updated { get; set; }

    public Guid fk_personID { get; set; }
    public Guid fk_storeID { get; set; }
}

public class StoreLike
{
    public Guid likeID { get; set; }
    public Statuses.LikeStatus likestatus { get; set; }

    public DateTime added { get; set; }
    public DateTime updated { get; set; }

    public Guid fk_personID { get; set; }
    public Guid fk_storeID { get; set; }
}

public class StoreComment
{
    public Guid commentID { get; set; }
    public string? comment { get; set; }
    public int likes { get; set; }

    public DateTime added { get; set; }
    public DateTime updated { get; set; }

    public Guid fk_personID { get; set; }
    public Guid fk_storeID { get; set; }
}

public class StoreCommentLike
{
    public Guid commentlikeID { get; set; }
    public Statuses.LikeStatus likestatus { get; set; }

    public DateTime added { get; set; }
    public DateTime updated { get; set; }

    public Guid fk_personID { get; set; }
    public Guid fk_storeID { get; set; }
}


public class Statuses
{
    [Flags]
    public enum Role
    {
        Viewer,
        Admin
    }

    public enum ViewerMembership
    {
        Free,
        Premium,
        Exclusive,
        Platinum
    }

    public enum Privacylevel
    {
        Public,
        Private
    }

    public enum StoreStatus
    {
        great,
        good,
        moderate,
        fair,
        bad,
        deactivated,
        banned
    }

    public enum ProductType
    {
        Product,
        Service
    }

    public enum ProductStatus
    {
        Active,
        Pending,
        Inactive
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        Declined,
        Canceled
    }

    public enum ClientStatus
    {
        Current,
        Pass
    }

    public enum LikeStatus
    {
        Liked,
        NotLiked
    }

}
