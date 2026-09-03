using System;

namespace POS.BLL.DTOs
{
    public class ModifierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsSelected { get; set; } = false;

        public override string ToString()
        {
            return $"{Name} (+{Price:N0} đ)";
        }
    }
}
