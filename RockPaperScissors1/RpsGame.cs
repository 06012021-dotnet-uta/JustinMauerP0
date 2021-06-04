using System;
namespace RockPaperScissors1
{
    public class RpsGame
    {
        
        
        public string WelcomeMessage()
        {
            // User choice to play another player or computer?
             
            string welcome = "\tWelcome to Rock-Paper-Scissors\nEnter Your First Name: ";
            return welcome;
        }

        public string GetPlayerName(string playerInput)
        {
            string name = playerInput.Trim();
            return name;
        }

        // Generate random CPU choice
        public int CpuChoice()
        {
            Random rand = new Random();
            int cpuChoice = rand.Next(1,4);
            return cpuChoice;
        }

        // Player selection method
        public int PlayerSelection(PlayerDerivedClass player)
        {
            // Promt user to input choice
            Console.Write($"{player.Fname} choose:\n1. Rock\n2. Paper\n3. Scissors\n");
            
            // Initialize choice declare player int
            string playerChoice = Console.ReadLine();
            int playerInt;

            // If-else to handle int input
            if(Int32.TryParse(playerChoice, out playerInt))
            {
                // If-else to handle bounds
                if (playerInt > 3 || playerInt < 1)
                {
                   Console.WriteLine($"{player.Fname}, you put in {playerInt}. This is not a valid choice!"); 
                   
                   playerInt = PlayerSelection(player);
                }
                else
                    return playerInt;
            }
            else
            {
                Console.WriteLine($"{player.Fname}, you put in {playerChoice}. This is not a valid choice!");
                playerInt = PlayerSelection(player);
            }

            // Return player choice 
            return playerInt;

        }

    }

}