namespace AutoPartStore
{
    public class Item
    {
        public int PartId { get; set; }
        public int PartNumber { get; set; }
        public string Part { get; set; }
        public string PartDescription { get; set; }
        public double Price { get; set; }
        public string PartLocation { get; set; }

        public Item()
        {

        }
        public Item(int partId, int partNumber, string part, string partDescription, double price, string partLocation)
        {
            PartId = partId;
            PartNumber = partNumber;
            Part = part;
            PartDescription = partDescription;
            Price = price;
            PartLocation = partLocation;
        }

        public void printPart()
        {
            System.Console.WriteLine("Part Id:     " + this.PartId
                                   + "\nPart Number: " + this.PartNumber
                                   + "\nPart:        " + this.Part
                                   + "\nDescription: " + this.PartDescription
                                   + "\nPrice:      $" + this.Price
                                   + "\nLocationL    " + this.PartLocation);
        }
    }
}