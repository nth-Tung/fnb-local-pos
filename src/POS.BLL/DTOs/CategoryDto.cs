using System;

namespace POS.BLL.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int ProductCount { get; set; } = 0;

        public override string ToString()
        {
            return Name;
        }
    }
}
