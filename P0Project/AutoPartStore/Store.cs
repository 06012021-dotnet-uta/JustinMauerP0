using System;
using System.Collections.Generic;

namespace AutoPartStore
{
    public class Store
    {
       public int StoreId { get; set; }
        public StoreNum _StoreNum { get; set;}
     //   public List<StoreItem> ItemList {get; set;}
        public string PhoneNumber { get; set; }
        public string GA { get; set; }
        public string City { 

            get {
                return Enum.GetName(_StoreNum);
            } 
        
            set {

                value = Enum.GetName(_StoreNum);
            }
        
        }



    }
}