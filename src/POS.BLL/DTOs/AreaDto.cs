using System;

namespace POS.BLL.DTOs
{
    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public int TableCount { get; set; }
        public int OccupiedCount { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
