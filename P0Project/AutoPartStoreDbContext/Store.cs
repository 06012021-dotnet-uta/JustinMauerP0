using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class Store
    {
        public Store()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int StoreId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
