using System.Collections.Generic;
namespace AutoPartStore
{
    public class StoreInventory
    {
        public int StoreId { get; set; }

        public int PartId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double InventoryValue { get; set; }
        
    }
}