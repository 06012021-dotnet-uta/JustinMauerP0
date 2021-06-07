using System;
using Xunit;
using RockPaperScissors1;

namespace rpsGameTest1
{
    class Program
    {
        [Theory]
        [InlineData(1,2)]
        public void EvaluateRoundWinner(int a, int b)
        {
            IRpsGame game = new RockPaperScissors1.RpsGame();

            int result = game.GetRoundWinner(a,b);

            Assert.Equals(2, result);
        }
    }
}
