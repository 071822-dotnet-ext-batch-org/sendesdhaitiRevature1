using System;
using static MS.MODELS.Statuses;

namespace MS.MODELS
{
	public class CreateShowDTO
	{
        public Guid personID { get; set; }
        public string storename { get; set; } = "";
        public string image { get; set; } = "";
        public Privacylevel privacyLevel { get; set; }
    }

    public class CreateProductDTO
    {
        public Guid personID { get; set; }
        public Guid storeID { get; set; }
        public ProductType type { get; set; }
        public string category { get; set; } = "";
        public string name { get; set; } = "";
        public decimal price { get; set; }
        public string description { get; set; } = "";
        public ProductStatus status { get; set; }
    }

    public class CreateClientDTO
    {
        public Guid personID { get; set; }
        public Guid storeid { get; set; }
    }

    public class CreateOrderDTO
    {
        public Guid personID { get; set; }
        public Guid productID { get; set; }
        public ProductType type { get; set; }
        public string category { get; set; } = "";
        public decimal amount { get; set; }
        public string desc { get; set; } = "";
        public OrderStatus orderStatus { get; set; }
    }

    public class CreateCommentDTO
    {
        public Guid personID { get; set; }
        public Guid storeid { get; set; }
    }

    public class CreateLikeonStoreDTO
    {
        public Guid personID { get; set; }
        public Guid storeid { get; set; }
    }

    public class CreateLikeonCommentDTO
    {
        public Guid personID { get; set; }
        public Guid commentID { get; set; }
    }
}

