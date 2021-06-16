using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class Item
    {
        public int PartId { get; set; }
        public int PartNumber { get; set; }
        public string Part { get; set; }
        public string PartDescription { get; set; }
        public decimal Price { get; set; }
        public string PartLocation { get; set; }
    }
}
