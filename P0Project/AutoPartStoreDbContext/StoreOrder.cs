using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class StoreOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}
