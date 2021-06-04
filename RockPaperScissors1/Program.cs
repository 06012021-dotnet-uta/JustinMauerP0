// Assignment:
// Create different classes to handle functionalities
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
            RpsGame rpsGame = new RpsGame();
        //    Console.Write("\tWelcome to Rock-Paper-Scissors\nEnter Your Name:");
           
            // Welcome message
            Console.Write(rpsGame.WelcomeMessage());

            PlayerDerivedClass player1 = new PlayerDerivedClass();

            // Prompt the user to enter name
            player1.Fname = rpsGame.GetPlayerName(Console.ReadLine());
            System.Console.Write("Enter Your Last Name: ");
            player1.Lname = rpsGame.GetPlayerName(Console.ReadLine());
            
            string name = player1.Fname + " " + player1.Lname;
            bool playAgain = true;

            // Do loop handles if the player wants to play again
            do
            {
                int p1WinCount = 0;
                int cpuWinCount = 0;
                int p1Choice;
                int cpuChoice; 

                // Do loop handles best of 3
                do
                {
                    // Player Choice
                    p1Choice = rpsGame.PlayerSelection(player1);
                    
                    // CPU Choice
                    cpuChoice = rpsGame.CpuChoice();

                    // Display player choices
                    Console.WriteLine($"\n{name} choice is\t{p1Choice} " + (RpsChoice)p1Choice);
                    Console.WriteLine($"Computer choice is\t{cpuChoice} " + (RpsChoice)cpuChoice);

                    // Check to see who wins each round
                    if (p1Choice == 1 && cpuChoice == 2
                            || p1Choice == 2 && cpuChoice == 3
                            || p1Choice == 3 && cpuChoice == 1 )
                    {
                        Console.WriteLine("\tComputer Wins This Round!");
                        cpuWinCount++;
                    }
                    else if (p1Choice == cpuChoice)
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

