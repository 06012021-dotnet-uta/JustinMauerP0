using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPartStoreDbContext
{
    public partial class Customer
    {
        public Customer()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public Customer(int customerId, string firstName, string lastName, string phoneNumber, string email, string city, string stateName, int carYear, string carMake, string carModel, string password, ICollection<StoreOrder> storeOrders)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            City = city;
            StateName = stateName;
            CarYear = carYear;
            CarMake = carMake;
            CarModel = carModel;
            Password = password;
            StoreOrders = storeOrders;
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StoreOrder> StoreOrders { get; set; }

    }
}
