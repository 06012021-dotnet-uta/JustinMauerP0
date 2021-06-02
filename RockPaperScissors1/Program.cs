using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RpsChoice {
            Rock = 1,   
            Paper = 2,  
            Scissors = 3 
        }
        
        static void Main(string[] args)
        {
           
            // Display introduction
            Console.WriteLine("\tWelcome to Rock-Paper-Scissors\nEnter Your Choice:");
           
            
        
            int p1Int;
            bool successfulConversion = false;
            
            do {
                // Promt user to input choice
                System.Console.Write("\n1. Rock\n2. Paper\n3. Scissors\n");
                // Initialize choice
                string p1Choice = Console.ReadLine();
            
                
                successfulConversion = Int32.TryParse(p1Choice, out p1Int);
                
                // check if user inputs number out of bounds
                if (p1Int > 3 || p1Int < 1)
                {
                    Console.WriteLine($"You input {p1Int}. This is not a valid choice!");
                }
                else if (!successfulConversion)
                {
                    Console.WriteLine($"You put in {p1Choice}. This is not a valid choice!");
                }

            }   while(!successfulConversion  || (p1Int < 1 || p1Int > 3));

            // Test successfule conversion
            // if (successfulConversion == true)
            //     Console.WriteLine($"the conversion was {successfulConversion} and the player chose {p1Int}");
            // else
            //     Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {p1Int}");
            
            // Generate cpu choice with random integer
            Random rand = new Random();
            int cpuChoice = rand.Next(1,4);

            // Test to see if we have both choices
            Console.WriteLine($"Player choice is {p1Int} " + RpsChoice[p1Int]);
            Console.WriteLine($"Computer choice is {cpuChoice}");

            if (p1Int == 1 && cpuChoice == 2
                    || p1Int == 2 && cpuChoice == 3
                    || p1Int == 3 && cpuChoice == 1 ) Console.WriteLine("Computer Wins");
            else if (p1Int == cpuChoice)
                Console.WriteLine("Tie Game!");
            else
                Console.WriteLine("Player Wins!");            
        }
    }
}

// Get player name
// Loop for another game
