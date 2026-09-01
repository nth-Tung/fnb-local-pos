namespace POS.BLL.DTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ItemKey { get; set; }
        public string ParentKey { get; set; }
        public string Note { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;
    }
}
