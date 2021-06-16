using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class StoreInventory
    {
        public int StoreId { get; set; }
        public int PartId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal? InventoryValue { get; set; }
        public virtual Item Part { get; set; }
        public virtual Store Store { get; set; }

        public StoreInventory()
        {
            
        }
    }
}
