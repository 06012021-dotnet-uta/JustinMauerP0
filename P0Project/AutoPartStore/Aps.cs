using System;
using System.Collections.Generic;
using AutoPartStoreDbContext;
using System.Linq;

namespace AutoPartStore
{
    public class Aps:IAps
    {
        
        private AutoPartsPlusDBContext _context;

        public Aps(AutoPartsPlusDBContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Method prompts user to login and returns the given <see cref="Customer"/>
        /// or prompts the user to enter information to create a new customer.
        /// </summary>
        /// <returns></returns>
        public Customer login()
        {
            System.Console.WriteLine("\n\tWELCOME TO  Auto Parts Plus!\n");
            string rt;
            Customer customer;
            AutoPartStoreDbContext.Customer dbCustomer;

            do 
            {   
                System.Console.WriteLine("Are you a returning customer?(Y/N)");

                rt = Console.ReadLine();
                rt = rt.Trim().ToUpper();
            } while(rt != "Y" && rt != "N");

            if (rt == "Y")
            {
                bool breakName = false;
                do
                {

                    System.Console.WriteLine("Enter last name: ");
                    string lastName = Console.ReadLine().Trim();

                    dbCustomer = GetCustomerByLastName(lastName);
                    if (dbCustomer == null)
                        breakName = false;
                    else
                    {
                        System.Console.WriteLine(dbCustomer.LastName.ToString() + " Found");
                        breakName = true;
                    }


                } while (!breakName);

                bool breakPass = false;
                int passCount = 5;
                do
                {
                    System.Console.WriteLine("Enter password: ");
                    string pass = Console.ReadLine().Trim();
                    if (pass == dbCustomer.Password)
                    {
                        Console.Clear();
                        System.Console.WriteLine("\t\tWelcome Back " + dbCustomer.FirstName + " " + dbCustomer.LastName);
                        breakPass = true;
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid password " + --passCount + " attempts remaining");
                        breakPass = false;
                    }

                } while (!breakPass && passCount > 0);

                if (passCount != 0)
                {  
                    customer = new Customer(dbCustomer.CustomerId,
                                            dbCustomer.FirstName,
                                            dbCustomer.LastName,
                                            dbCustomer.PhoneNumber,
                                            dbCustomer.Email,
                                            dbCustomer.City,
                                            dbCustomer.StateName,
                                            dbCustomer.CarYear,
                                            dbCustomer.CarMake,
                                            dbCustomer.CarModel);
                    
                    
                    return customer;
                }
                else
                    customer = login();

            }
            else   // Prompt the user to create an account
            {
                string guest;
                AutoPartStoreDbContext.Customer cust;
                // See store inventory with (S)
                do{
                    System.Console.WriteLine("Register an account or continue as guest?(R/G/S)");
                    guest = Console.ReadLine();
                    guest = guest.Trim().ToUpper();
                } while(guest != "R" && guest != "G" && guest != "S");

                if (guest == "R")
                    using(_context)
                    {
                        cust = CustomerRegistration();
                        _context.Customers.Add(cust);
                        _context.SaveChanges();
                        
                        customer = new Customer(cust.CustomerId,
                                            cust.FirstName,
                                            cust.LastName,
                                            cust.PhoneNumber,
                                            cust.Email,
                                            cust.City,
                                            cust.StateName,
                                            cust.CarYear,
                                            cust.CarMake,
                                            cust.CarModel);

                    }
                else if (guest == "G")
                {
                    cust = GuestCustomerRegistration();
                    _context.Customers.Add(cust);
                    _context.SaveChanges();

                    customer = new Customer(cust.CustomerId,
                                            cust.FirstName,
                                            cust.LastName,
                                            cust.PhoneNumber,
                                            cust.Email,
                                            cust.City,
                                            cust.StateName,
                                            cust.CarYear,
                                            cust.CarMake,
                                            cust.CarModel);                    

                }
                else
                {
                    bool storeChecker = true;
                    int storeChoice;
                    do
                    {
                        System.Console.WriteLine("See Store Inventory For:\n1.) Savannah\t\t4.) Macon\t\t7.) Athens"
                                    + "\n2.) Augusta\t\t5.) Cobb\t\t8.)Lawrenceville"
                                    + "\n3.) Columbus\t\t6.) Roswell\t\t9.) Atlanta");
                        storeChecker = Int32.TryParse(Console.ReadLine(), out storeChoice);

                    } while(!storeChecker);
                    storeChoice = storeChoice * 10;
                    
                    var storeItems = _context.StoreInventories.Where(s => s.StoreId == storeChoice).ToList();
                    decimal totalInventory = 0;
                    for(int i = 0; i < storeItems.Count; i++)
                    {
                        totalInventory += storeItems[i].Price;
                    }

                    System.Console.WriteLine("Store Number: " + storeChoice + "\tLocation: " + (StoreNum)storeChoice
                                            + "\nTotal Parts:" + storeItems.Count + "\tTotal Inventory: $" + totalInventory);
                    
                    int selectOrderHistory = 0;
                  //  bool sohCheck = true;
                    do
                    {
                        System.Console.WriteLine("\n1.) See Order History 2.)LogOut");
                        Int32.TryParse(Console.ReadLine(), out selectOrderHistory);
                    } while(selectOrderHistory != 1 && selectOrderHistory != 2);

                    if (selectOrderHistory == 1)
                    {
                        
                        var orderHistory = _context.StoreOrders.ToList();
                        System.Console.WriteLine("Store Choice: " + storeChoice);
                        for(int i = 0; i < orderHistory.Count; i++)
                        {
                             if (orderHistory[i].StoreId == storeChoice)
                             {
                                 System.Console.WriteLine("Customer: " + orderHistory[i].CustomerId + " Store: " + orderHistory[i].Store
                                                      + " Total Items: " + orderHistory[i].TotalItems + " $" + orderHistory[i].TotalPrice
                                                      + " Date: " + orderHistory[i].OrderDate.ToString().Substring(0,9));
                             }
                            
                        }

                    }
                    if (selectOrderHistory == 2)
                        return null;
                   
                    Console.ReadLine();
                    
                    // Figure out what to do with customer value
                    return null;
                }
            }
            
          //  return null;    
            return customer;

        }

        /// <summary>
        /// This class returns a customer from the db using <see cref="AutoPartStoreDbContext"/>
        /// Customer class matching the LastName variable. It returns a null Customer if the n
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns AutoPartStoreDbContext></returns>
        /// <returns > </returns>
        public AutoPartStoreDbContext.Customer GetCustomerByLastName(string lastName)
        {
            AutoPartStoreDbContext.Customer customer;
            
            try
            {
                var customerNameFound = _context.Customers.Where(s => s.LastName == lastName).ToList();
                    
                customer = customerNameFound[0];

                if (lastName.Equals(customer.LastName))
                    return customer;
                else
                {
                    customer = null;
                    return customer;
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("Last Name Not Found");
                customer = null;
                return customer;
            }
        }

        /// <summary>
        /// Register a guest customer
        /// </summary>
        /// <returns></returns>
        public AutoPartStoreDbContext.Customer GuestCustomerRegistration()
        {
            AutoPartStoreDbContext.Customer customer = new AutoPartStoreDbContext.Customer();
            
            bool isYear = false;
            int checkYear;
            
            customer.PhoneNumber = EnterPhoneNumber();

            
            // Do loop to check if year is valid int and length
            do {
                System.Console.Write("\nEnter Car Year: ");
                isYear = Int32.TryParse(Console.ReadLine(), out checkYear);
                
                if (checkYear.ToString().Length != 4)
                {
                    System.Console.WriteLine("\t !!Invalid Year!!");
                    isYear = false;
                }
                else if ((int)(Math.Floor((double)checkYear / 100)) != 19 && (int)(Math.Floor((double)checkYear / 100)) != 20)
                {
                    System.Console.WriteLine("\t !!No Parts In Stock For Vehicle Year!!");
                    isYear = false;
                }
                else
                {
                    customer.CarYear = checkYear;
                    isYear = true;
                }
            }
            while(!isYear);

            System.Console.Write("Enter Car Make: ");
            customer.CarMake = Console.ReadLine().Trim();

            System.Console.Write("Enter Car Model: ");
            customer.CarModel = Console.ReadLine().Trim();

            customer.FirstName = "Guest";
            customer.LastName = "Customer";
            customer.City = "    -    ";
            customer.Email = "    -    ";
            customer.Password = "    -    ";
            customer.StateName = "    -    ";

            return customer;
        }

        /// <summary>
        /// Registers a new <see cref="AutoPartStoreDbContext.Customer"/>.
        /// </summary>
        /// <returns></returns>
        public AutoPartStoreDbContext.Customer CustomerRegistration()
        {
            
            AutoPartStoreDbContext.Customer customer = new AutoPartStoreDbContext.Customer();
            // Register new customer information
            System.Console.Write("Enter First Name: ");
            customer.FirstName = Console.ReadLine();

            System.Console.Write("Enter Last Name: ");
            customer.LastName = Console.ReadLine();

            // Do while structures to give uniform phone number output
            // probably don't need it.
            
            

            customer.PhoneNumber = EnterPhoneNumber();

            string email1;
            string email2;
            bool emailCheck = true;
            
            // Do while loop to make sure email is correct
            do {
                System.Console.Write("\nEnter Email: ");
                email1 = Console.ReadLine();
                email1 = email1.Trim();

                System.Console.Write("Re-Enter Email: ");
                email2 = Console.ReadLine();
                email2 = email2.Trim();
                if (email1.Equals(email2))
                {
                    customer.Email = email1;
                    emailCheck = true;
                }
                else
                {
                    System.Console.WriteLine("\t !!Emails Do Not Match!!");
                    emailCheck = false;
                }
            }
            while(!emailCheck);

            string pw1;
            string pw2;
            bool pwCheck = true;
            do{
                System.Console.Write("Enter Password: ");
                pw1 = Console.ReadLine();
                System.Console.Write("Re-Enter Password: ");
                pw2 = Console.ReadLine();
                if (pw1.Equals(pw2))
                {
                    customer.Password = pw1;
                    pwCheck = true;
                }
                else
                {
                    System.Console.WriteLine("\t !!Passwords Do Not Match!!");
                    pwCheck = false;
                    
                }
            }
            while(!pwCheck);

            System.Console.Write("Enter City: ");
            customer.City = Console.ReadLine();

            System.Console.Write("Enter State: ");
            customer.StateName = Console.ReadLine();

            bool isYear = false;
            int checkYear;
            
            // Do loop to check if year is valid int and length
            do {
                System.Console.Write("Enter Car Year: ");
                isYear = Int32.TryParse(Console.ReadLine(), out checkYear);
                
                if (checkYear.ToString().Length != 4)
                {
                    System.Console.WriteLine("\t !!Invalid Year!!");
                    isYear = false;
                }
                else if ((int)(Math.Floor((double)checkYear / 100)) != 19 && (int)(Math.Floor((double)checkYear / 100)) != 20)
                {
                    System.Console.WriteLine("\t !!No Parts In Stock FOr Vehicle Year!!");
                    isYear = false;
                }
                else
                {
                    customer.CarYear = checkYear;
                    isYear = true;
                }
            }
            while(!isYear);

            System.Console.Write("Enter Car Make: ");
            customer.CarMake = Console.ReadLine().Trim();

            System.Console.Write("Enter Car Model: ");
            customer.CarModel = Console.ReadLine().Trim();

            return customer;
        }

        /// <summary>
        /// This method formats the users phone number entry
        /// </summary>
        /// <returns>String</returns>
        public string EnterPhoneNumber()
        {
            string phone = "(";
            System.Console.Write("Enter phone Number: " + phone);
            int[] p1 = new int[10];
            string rnd = "";
            bool isNum = false;
            int counter = 0;

            do{
                
                rnd = Char.ToString(Console.ReadKey().KeyChar);
                if (rnd.Equals(Char.ToString('#')))
                    continue;
                isNum = Int32.TryParse(rnd, out p1[counter]);
                if (isNum)
                {
                    phone += p1[counter];
                    counter++;   
                }
                else
                    isNum = false;

            }while(!isNum || counter < 3);
            phone += ") ";
            Console.Write(") ");

            counter = 0;
            do{
                
                rnd = Char.ToString(Console.ReadKey().KeyChar);
                isNum = Int32.TryParse(rnd, out p1[counter + 3]);
                if (isNum)
                {
                    phone += p1[counter + 3];
                    counter++;   
                }
                else
                    isNum = false;

            }while(!isNum || counter < 3);
            

            phone += " - ";
            Console.Write(" - ");
            counter = 0;
            
            do{
                
                rnd = Char.ToString(Console.ReadKey().KeyChar);
                isNum = Int32.TryParse(rnd, out p1[counter + 6]);
                if (isNum)
                {
                    phone += p1[counter + 6];
                    counter++;   
                }
                else
                    isNum = false;

            }while(!isNum || counter < 4);
            
            phone += "\n";
            return phone;
        }

    /// <summary>
    /// Returns a list of the given item name at the store
    /// given in the parameter.
    /// </summary>
    /// <param name="part"></param>
    /// <param name="sId"></param>
    /// <returns></returns>
    public Item getEngineItem(string part, int sId)
    {
        _context = new AutoPartsPlusDBContext();

        System.Console.WriteLine("Select " + part + ": ");
        Item apsItem = new Item();
        int itemChoice;
        bool itemChoiceChecker = true;
        try
            {
                var si = _context.StoreInventories.Where(s => s.StoreId == sId).ToList();
                var il = new List<AutoPartStoreDbContext.Item>();
                for(int i = 0; i < si.Count; i++)
                {
                    var sil = _context.Items.Where(s => s.PartId == si[i].PartId).ToList();
                    if(sil[0].Part == part)
                        il.Add(sil[0]);
                    
                }

                for(int i = 0; i < il.Count; i++)
                {
                    if (i % 2 == 0)
                        System.Console.Write((i + 1) + ") " + il[i].PartId + " " + il[i].Part + " "
                                            + il[i].PartDescription + " " + il[i].PartLocation + " $"
                                            + il[i].Price + "\t");
                    else
                        System.Console.WriteLine((i + 1) + ") " + il[i].PartId + " " + il[i].Part + " "
                                            + il[i].PartDescription + " " + il[i].PartLocation + " $"
                                            + il[i].Price + "\t");
                } 
                System.Console.WriteLine("\nSelect 0 to return");
               do
               {
                   itemChoiceChecker = Int32.TryParse(Console.ReadLine(), out itemChoice);
                   if (itemChoice == 0)
                   {
                       apsItem = new Item();
                       return apsItem;
                   }
                   
                   {

                   }
               } while(!itemChoiceChecker);
               itemChoice--;
                apsItem = new Item(il[itemChoice].PartId, il[itemChoice].PartNumber,
                                   il[itemChoice].Part, il[itemChoice].PartDescription,
                                   ((double)il[itemChoice].Price), il[itemChoice].PartLocation);

            }   
            catch (Exception e )
            {
                System.Console.WriteLine(e.ToString());
            }


        return apsItem;
    }

    // Can't figure out how to update since the table StoreInventory only holds foreign keys
    /// <summary>
    /// Creates an order list of the customer parts being ordered
    /// </summary>
    /// <param name="checkOut"></param>
    /// <param name="customer"></param>
    /// <param name="storeChoice"></param>
    public void CheckOutCustomer(List<Item> checkOut, Customer customer, int storeChoice)
    {
        decimal orderPrice = (decimal)OrderPriceTotal(checkOut);
        AutoPartStoreDbContext.StoreOrder storeOrder = new AutoPartStoreDbContext.StoreOrder();
        storeOrder.CustomerId = customer.CustomerId;
        storeOrder.StoreId = storeChoice;
        storeOrder.TotalItems = checkOut.Count;
        storeOrder.TotalPrice = orderPrice;
        storeOrder.OrderDate = DateTime.Today;

        _context.StoreOrders.Add(storeOrder);
        _context.SaveChanges();
        
        

        AutoPartStoreDbContext.OrderList orderList = new AutoPartStoreDbContext.OrderList();
    
                

        for(int i = 0; i < checkOut.Count; i++)
        {
        
        }

        
        _context.SaveChanges();

    }

    /// <summary>
    /// Gets total price of the checkout cart.
    /// </summary>
    /// <param name="checkOut"></param>
    /// <returns></returns>
    public double OrderPriceTotal(List<Item> checkOut)
    {
        double totalPrice = 0;
        for(int i = 0; i < checkOut.Count; i++)
        {
            totalPrice += checkOut[i].Price;
        }


        return totalPrice;
    }
        
    }//End of class

}//End of namespace