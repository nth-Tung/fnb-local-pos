using System;
using System.Collections.Generic;

namespace POS.BLL.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductType { get; set; } = "SINGLE";
        public bool IsActive { get; set; } = true;

        public List<int> ModifierIds { get; set; } = new List<int>();
        public int ModifierCount { get; set; } = 0;

        public override string ToString()
        {
            return $"{Name} ({Price:N0} đ)";
        }
    }
}
