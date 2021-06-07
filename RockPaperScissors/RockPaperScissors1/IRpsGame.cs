namespace RockPaperScissors1
{
    public interface IRpsGame
    {
        PlayerDerivedClass Welcome();
        PlayerDerivedClass CreateComputer();
        int CpuChoice();
        int PlayerSelection(PlayerDerivedClass player);
        int GetRoundWinner(int p1Choice, int p2Choice);
        bool EndOfGame(PlayerDerivedClass player1, PlayerDerivedClass player2);
        
    }
}