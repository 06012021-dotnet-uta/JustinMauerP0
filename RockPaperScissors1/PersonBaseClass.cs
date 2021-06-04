using System;

namespace RockPaperScissors1
{
    public class PersonBaseClass
    {
        private string fname;
        private string lname;
        private string myCountry;
        
        public string Fname
        {
            get
            {
                return fname;
                
            }
            set
            {
                if(value.Length > 20 || value.Length < 1)
                {
                    throw new InvalidOperationException("that name is invalid");
                }
                else 
                    fname = value;
            }
        } 

        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                if(value.Length > 20 || value.Length < 1)
                {
                    throw new InvalidOperationException("that name is invalid");
                }
                else
                    lname = value;

            }
        }


        // This is a property. It includes the getter and setter
        public string MyCountry
        {
            get // returns private variable
            {
                return myCountry;
            }
        
            set 
            {
                if (value != null)
                    myCountry = value;
                else
                    System.Console.WriteLine("There was no country submitted.");                

            }
        }

         

        // No argument Constructor
        public PersonBaseClass()
        {
            fname = "defaultFName";
            lname = "defaultLName";
        }
        
        // Override Constructo Insatiating Values
        public PersonBaseClass(string first, string last)
        {
            this.fname = first;
            this.lname = last;
        }


    }
}