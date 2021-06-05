using System;
namespace RockPaperScissors1
{
    public class RpsGame
    {
        /// <summary>
        /// This method displays a welcome message to the 
        /// user and prompts them to enter their first
        /// and last name. It then returns a new 
        /// <see cref="PlayerDerivedClass"/> object.
        /// </summary>
        /// <returns></returns>
        public PlayerDerivedClass Welcome()
        {
            // Display Welcome Message And Get User Description
            PlayerDerivedClass player = new PlayerDerivedClass();
            System.Console.Write("\tWelcome to Rock-Paper-Scissors\nEnter Your First Name: ");
            player.Fname = Console.ReadLine();
            System.Console.Write("Enter Your Last Name: ");
            player.Lname = Console.ReadLine();

            return player;
        }
        /// <summary>
        /// This method prompts the user to enter
        /// a name for a new <see cref="PlayerDerivedClass"/>
        /// and then returns the object.
        /// </summary>
        /// <returns></returns>
        public PlayerDerivedClass CreateComputer()
        {
            PlayerDerivedClass player = new PlayerDerivedClass();
            System.Console.Write("Enter Computer Name: ");
            player.Fname = Console.ReadLine();
            player.Lname = "-";

            return player;
        }

        /// <summary>
        /// Returns a random integer between 1-3 inclusive 
        /// 
        /// </summary>
        /// <returns></returns>
        public int CpuChoice()
        {
            Random rand = new Random();
            int cpuChoice = rand.Next(1,4);
            return cpuChoice;
        }

        /// <summary>
        /// Displays a message to the <see cref="PlayerDerivedClass"/> user to select
        /// an option then returns the int value of that option.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int PlayerSelection(PlayerDerivedClass player)
        {
            // Prompt user to input choice
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

        /// <summary>
        /// This method decides who the winner is.
        /// 0 = tie
        /// 1 = p1Choice won
        /// 2 = p2Choice won
        /// </summary>
        /// <param name="p1Choice"></param>
        /// <param name="p2Choice"></param>
        /// <returns></returns>
        public int GetRoundWinner(int p1Choice, int p2Choice)
        {
            if (p1Choice == 1 && p2Choice == 2
                            || p1Choice == 2 && p2Choice == 3
                            || p1Choice == 3 && p2Choice == 1 )
                return 2;        
            else if (p1Choice == p2Choice)
                return 0;
            else
             return 1;
            
        }

        /// <summary>
        /// This method displays each <see cref="PlayerDerivedClass"/>
        /// players win count and the winner of the entire game.
        /// Returns true if the user chooses to play again or false
        /// if the user chooses to stop the program.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public bool EndOfGame(PlayerDerivedClass player1, PlayerDerivedClass player2)
        {
            bool playAgain = false;

            // Display total wins
            Console.WriteLine($"{player1.Fname} Total Wins:\t" + player1.winCount);
            Console.WriteLine($"\n{player2.Fname} Total Wins:\t" + player2.winCount);
            
            // Display winner
            if (player2.winCount > player1.winCount)
                Console.WriteLine($"\n\t{player2.Fname.ToUpper()} WON THE MATCH!");
            else
                Console.WriteLine($"\n\t{player1.Fname.ToUpper().ToUpper()} WON THE MATCH!");
            
            // Prompt asking if user wants to play again
            string playAgainChoice;
            do
            {   
                Console.WriteLine("Would you like to play again?(Y/N)");
                playAgainChoice = Console.ReadLine();
                playAgainChoice = playAgainChoice.ToUpper();
            } while (playAgainChoice != "Y" && playAgainChoice != "N");
            
            if(playAgainChoice == "Y")
            {
                player1.winCount = 0;
                player2.winCount = 0;
                playAgain = true;
            
            }else
                playAgain = false;



            return playAgain;
        }

    }

}