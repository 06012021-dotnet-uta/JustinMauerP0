using System;
using AutoPartStoreDbContext;
using System.Collections.Generic;

namespace AutoPartStore
{
    class Program
    {
        static List<Item> checkOut = new List<Item>();
        
        static void Main(string[] args)
        {
           
            AutoPartsPlusDBContext context = new AutoPartsPlusDBContext();
            
            Aps aps = new Aps(context);
            


            Customer customer = aps.login();
            if (customer == null)
            {
                aps.login();
            }
            customer.customerInfo();

            Item item = new Item();

            do
            {
                item = CustomerCheckoutProcess(aps, customer);
                checkOut.Add(item);

            } while(item != null);

        }

        public static void ViewEngineItemList()
        {
            System.Console.WriteLine("");
            for(int i = 1; i <= Enum.GetNames(typeof(Engine)).Length / 3; i++)
            {
                if(i % 3 == 0)
                    System.Console.WriteLine(i + ") " +(Engine)i + "\t\t" + (i + 5) + ") "
                                            + (Engine)(i + 5) + "\t\t"+ (i + 10) + ")" + (Engine)(i + 10));
                else
                    System.Console.WriteLine(i + ") " +(Engine)i + "\t\t" + (i + 5) + ") "
                                            + (Engine)(i + 5) + "\t\t"+ (i + 10) + ")" + (Engine)(i + 10));
            }
        }
        
         public static Item CustomerCheckoutProcess(Aps aps, Customer customer)
         {
            
            Item item = new Item();
            int storeChoice;
            bool storeChoiceCheck = true;
            do{
                System.Console.WriteLine("\nSelect Store To Shop From:\n1.) Savannah\t\t4.) Macon\t\t7.) Athens"
                                   + "\n2.) Augusta\t\t5.) Cobb\t\t8.)Lawrenceville"
                                   + "\n3.) Columbus\t\t6.) Roswell\t\t9.) Atlanta");
                storeChoiceCheck = Int32.TryParse(Console.ReadLine(), out storeChoice);
                
            } while(!storeChoiceCheck);
            storeChoice = storeChoice * 10;


        // So create full menu items with generec name list make a for each loop to cycle through enum value part types
            int partChoice;
            bool partChoiceCheck; 
            do{
                    System.Console.WriteLine("\nSelect Product Type:\n1.) Engine Part\t\t\t4.) Brake System Part"
                                   + "\n2.) Interior Part\t\t5.) Suspension Part"
                                   + "\n3.) Exterior Part\t\t6.) Exhaust Part");
                partChoiceCheck = Int32.TryParse(Console.ReadLine(), out partChoice);
                // If part choice is correct proceed to next screen to see part
                // list to choose from
                
            } while(!partChoiceCheck);

            int partSelection;
            // Display designated part choices
            switch(partChoice)
            {
                case 1: Console.Clear();
                        bool engineCheck;
                        do 
                        {
                            ViewEngineItemList();
                            // Show part from database
                            engineCheck = Int32.TryParse(Console.ReadLine(), out partSelection);
                            Enum str = (Engine)partSelection;
                            Console.Clear();
                            string str2 = str.ToString();
                            // Select item from item list given by the store
                           item = aps.getEngineItem(str2, storeChoice);
                           if (item == null)
                           {
                               CustomerCheckoutProcess(aps, customer);
                           }
                        //    checkOut.Add(item);
                        //    item.printPart();
                        } while(!engineCheck);
                        break;
            }

            checkOut.Add(item);

            string checkoutOrder;
            do{
                System.Console.WriteLine("Would you like to checkout or order Another part? (C/O)");
                checkoutOrder = Console.ReadLine();
            }
            while(checkoutOrder.ToUpper() != "C" && checkoutOrder.ToUpper() != "O");

            if (checkoutOrder.ToUpper() == "C")
            {
                // Checkout method
                aps.CheckOutCustomer(checkOut, customer,  storeChoice);
                // Sign out after checkout
                aps.login();
                checkOut = new List<Item>();
                // Empty Checkout List
            }
            else if(checkoutOrder.ToUpper() == "O")
            {
                 AutoPartsPlusDBContext context = new AutoPartsPlusDBContext();
            
                aps = new Aps(context);
                item = CustomerCheckoutProcess(aps, customer);
            }

            return item;
         }

         public void CheckCart()
         {
             for(int i = 0; i< checkOut.Count; i++)
                {
                    System.Console.WriteLine("PartNum: " + checkOut[i].PartNumber +"Part: " + checkOut[i].Part + " Desc: " + checkOut[i].PartDescription + " $" + checkOut[i].Price);
                }
                
                System.Console.WriteLine("Total: $" + CartPrice());
         }
    
        // Create a menu to return home or order cart - not finished
         

         public double CartPrice()
         {
             double total = 0;
             for(int i = 0; i < checkOut.Count; i++)
             {
                 total += checkOut[i].Price;
             }

             return total;
         }

    }
}
