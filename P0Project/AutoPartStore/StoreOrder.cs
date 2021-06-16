using System.Collections.Generic;

namespace AutoPartStore
{
    public class StoreOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        
        public StoreNum _StoreNumber { get; set;}

        public List<StoreItem> ItemList { get; set; }

        public double TotalPrice { get; set; }
        
    }
}