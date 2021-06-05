namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        
        private int myAge;
        public string Street { get; set; }
        public string State { get; set;}
        public int winCount {get; set;}
        public int rpsChoice {get; set;}

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

        }

        
        public PlayerDerivedClass(string fname, string lname) : base(fname, lname)
        {
        
        }

        public PlayerDerivedClass(string fname, string lname, int age) : base(fname, lname)
        {
            this.myAge = 0;
        }
        
    }
}