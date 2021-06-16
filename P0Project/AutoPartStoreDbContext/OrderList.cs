using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class OrderList
    {
        public OrderList()
        {
        }

        public int OrderId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual StoreOrder Order { get; set; }
        public virtual Item Part { get; set; }

        
    }
}
