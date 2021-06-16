namespace AutoPartStore
{
    public class OrderList
    {
        public int OrderId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        private double _totalPrice;
        public double TotalPrice{

            get {
                return _totalPrice;
            }
            
            set
            {
                _totalPrice = this.Price * this.Quantity;
            }
        
        }
    }
}