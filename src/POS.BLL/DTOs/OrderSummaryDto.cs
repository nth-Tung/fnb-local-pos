namespace POS.BLL.DTOs
{
    public class OrderSummaryDto
    {
        public decimal RawTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalTotal { get; set; }
    }
}
