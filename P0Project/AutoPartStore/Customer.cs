namespace AutoPartStore
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    //    public string accountName { get; set;}
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string city {get; set;}
        public string state {get; set;}
        public int carYear { get; set; }
        public string carMake { get; set; }
        public string carModel{ get; set; }
        private string _password;
        
        public string MyPassword 
        { 
            get 
            {
                return this._password;
            } 
            set
            {
                _password = value;
            }
        }

        // Guest Customer Enter year make and model
        public Customer()
        {

        }

        public Customer(string phoneNumber, string email, int carYear, string carMake, string carModel)
        {
            this.phoneNumber = phoneNumber;
            this.carYear = carYear;
            this.carMake = carMake;
            this.carModel = carModel;
            this.firstName = "Guest";
            this.lastName = "Customer";
            this.email = email;
            this.city = "-";
            this.state = "-";
            this._password = carYear + "-guest-" + carModel;

        }

        public Customer(int customerId, string firstName, string lastName, string phoneNumber, string email, string city, string state, int carYear, string carMake, string carModel)
        {
            CustomerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.city = city;
            this.state = state;
            this.carYear = carYear;
            this.carMake = carMake;
            this.carModel = carModel;
            
        }

        public void customerInfo()
        {
            System.Console.WriteLine("Customer\t\t\tCar\nName:\t"
                            + firstName + " " + lastName
                            + "\t\tYear:\t" + carYear
                            + "\nEmail:\t" + email
                            + "\t\tMake:\t" + carMake
                            + "\nPhone:\t" + phoneNumber
                            + "\t\tModel:\t" + carModel 
                            + "\nCity:\t" + city
                            + "\nState:\t" + state);
        }

        public void carInfo()
        {
            System.Console.WriteLine("\nCar Info:\nYear:\t" + carYear
                            + "\nMake:\t" + carMake
                            + "\nModel:\t" + carModel);
        }
    }
}