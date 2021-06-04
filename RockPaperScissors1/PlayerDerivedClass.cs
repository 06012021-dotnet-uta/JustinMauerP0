namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        
        private int myAge;
        public string Street { get; set; }
        public string State { get; set;}
     //   public string City {get: set;}

        public int MyAge{
            get
            {
                return this.myAge;
            }
            set
            {
                if (value <125 && value > 0)
                    this.myAge = value;
            }
        }

        public PlayerDerivedClass() : base()
        {
        //    this.fname = "derivedClassfname";
        //    this.lname = "derivedClasslname";
        }

        // Must create all overload constructors
        public PlayerDerivedClass(string fname, string lname) : base(fname, lname)
        {
        //    this.fname = fname;
        //    this.lname = lname;
        }

        public PlayerDerivedClass(string fname, string lname, int age) : base(fname, lname)
        {
            this.myAge = 0;
        }
        
    }
}