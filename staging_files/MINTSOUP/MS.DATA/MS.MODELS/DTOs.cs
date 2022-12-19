using System;
using static MS.MODELS.Statuses;

namespace MS.MODELS
{
	public class CreateShowDTO
	{
        public Guid personID { get; set; }
        public string storename { get; set; } = "";
        public string image { get; set; } = "";
        public int privacyLevel { get; set; }
        public CreateShowsAddressDTO? address { get; set; }
    }

    public class CreateShowsAddressDTO
    {
        public string? street { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public int areacode { get; set; }
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
        public Guid storeID { get; set; }
        public List<Guid> productIDs { get; set; } = new();
        public ProductType type { get; set; }
        public string category { get; set; } = "";
        public decimal amount { get; set; }
        public string desc { get; set; } = "";
        public OrderStatus orderStatus { get; set; }
        public List<OrderProductsDTO> products { get; set; } = new();
        public OrderInvoiceDTO? invoice { get; set; } 
    }

    public class OrderProductsDTO
    {
        public Guid personID { get; set; }
        public Guid orderID { get; set; }
        public Guid productID { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; }
    }
    public class OrderInvoiceDTO
    {
        public string storename { get; set; } = "";
        public string payment_method { get; set; } = "";
        public int card_number { get; set; }
        public int quantity { get; set; }
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

    public class GetProductsDTO
    {
        public string? category { get; set; }
        public int? type { get; set; }
        public string? name { get; set; }
    }
}

