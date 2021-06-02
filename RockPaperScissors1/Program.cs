// Day 2 Assignment:
// Get player name - Completed
// Loop for another game - Completed
// Play 3 games find best of - Completed
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
            Console.Write("\tWelcome to Rock-Paper-Scissors\nEnter Your Name:");
           
            // Prompt the user to enter name
            string name = Console.ReadLine();
            Console.Write($"\n{name} enter your choice: ");
            bool playAgain = true;
            
            

            // Do loop handles if the player wants to play again
            do
            {
                int p1WinCount = 0;
                int cpuWinCount = 0;
                int p1Int;
                bool successfulConversion = false;  

                // Do loop handles best of 3
                do
                {
                    // Do loop handles each round
                    do {
                        
                        // Promt user to input choice
                        System.Console.Write("\n1. Rock\n2. Paper\n3. Scissors\n");
                        
                        // Initialize choice
                        string p1Choice = Console.ReadLine();
                    
                        successfulConversion = Int32.TryParse(p1Choice, out p1Int);
                        
                        // check if user inputs number out of bounds
                        if (p1Int > 3 || p1Int < 1)
                        {
                            Console.WriteLine($"{name}, you put in {p1Int}. This is not a valid choice!");
                        }
                        else if (!successfulConversion)
                        {
                            Console.WriteLine($"{name}, you put in {p1Choice}. This is not a valid choice!");
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
                    Console.WriteLine($"\n{name} choice is\t{p1Int} " + (RpsChoice)p1Int);
                    Console.WriteLine($"Computer choice is\t{cpuChoice} " + (RpsChoice)cpuChoice);

                    // Check to see who wins each round
                    if (p1Int == 1 && cpuChoice == 2
                            || p1Int == 2 && cpuChoice == 3
                            || p1Int == 3 && cpuChoice == 1 )
                    {
                        Console.WriteLine("\tComputer Wins This Round!");
                        cpuWinCount++;
                    }
                    else if (p1Int == cpuChoice)
                        Console.WriteLine("\tTie!");
                    else
                    {
                        Console.WriteLine($"\t{name} Wins This Round!");  
                        p1WinCount++;
                    }
                } while(p1WinCount < 2 && cpuWinCount < 2);
    
                // Display total wins
                Console.WriteLine("\nComputer Total Wins: " + cpuWinCount);
                Console.WriteLine($"{name} Total Wins:   " + p1WinCount);

                // Display winner
                if (cpuWinCount > p1WinCount)
                    Console.WriteLine("\n\tCOMPUTER WON THE MATCH!");
                else
                {
                    string nameUp = name.ToUpper();
                    Console.WriteLine($"\n\t{nameUp} WON THE MATCH!");
                }

                // Prompt asking if user wants to play again
                Console.WriteLine("Would you like to play again?(Y/N)");
                string playAgainChoice = Console.ReadLine();

                if(playAgainChoice.ToUpper().Equals("Y"))
                    playAgain = true;
                else
                    playAgain = false;

            } while(playAgain);

            Console.WriteLine("\t\tGAMEOVER");
        } 
    }
}

