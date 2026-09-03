using System;

namespace POS.BLL.DTOs
{
    public class TableDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; } = "EMPTY"; // 'EMPTY', 'OCCUPIED', 'PRINTED'
        public long? CurrentOrderId { get; set; }
        public string OrderNumber { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime? OccupiedSince { get; set; }
        public string CreatedBy { get; set; }
        public int ItemCount { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

        public int OccupiedMinutes
        {
            get
            {
                if (OccupiedSince.HasValue)
                {
                    return Math.Max(0, (int)(DateTime.Now - OccupiedSince.Value).TotalMinutes);
                }
                return 0;
            }
        }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case "OCCUPIED":
                        return "Có khách";
                    case "PRINTED":
                        return "Đã in bill";
                    default:
                        return "Bàn trống";
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({AreaName}) - {StatusText}";
        }
    }
}
