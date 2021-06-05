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

            // Initialize player class references
            PlayerDerivedClass player1 = rpsGame.Welcome();
            PlayerDerivedClass player2 = rpsGame.CreateComputer();

            // Do loop handles if the player wants to play again
            do
            {
                // Do loop to handle round
                do
                {
                    // Player Choice
                    player1.rpsChoice = rpsGame.PlayerSelection(player1);
                    
                    // CPU Choice
                    player2.rpsChoice = rpsGame.CpuChoice();

                    Random rand = new Random();
                    int cpuChoice = rand.Next(1,4);

                    // Display player choices
                    Console.WriteLine($"\n{player1.Fname} choice is\t{player1.rpsChoice} " + (RpsChoice)player1.rpsChoice);
                    Console.WriteLine($"{player2.Fname} choice is\t{player2.rpsChoice} " + (RpsChoice)player2.rpsChoice);

                    switch(rpsGame.GetRoundWinner(player1.rpsChoice, player2.rpsChoice))
                    {
                        case 0: Console.WriteLine("\tTie!");
                                break;
                        case 1: Console.WriteLine($"\t{player1.Fname} Wins This Round!");
                                player1.winCount++;
                                break;
                        case 2: Console.WriteLine($"\t{player2.Fname} Wins This Round!");
                                player2.winCount++;
                                break;
                        
                    }

                } while(player1.winCount < 2 && player2.winCount < 2);
            } while(rpsGame.EndOfGame(player1, player2));

            Console.WriteLine("\t\tGAMEOVER");
        } 
    }
}

