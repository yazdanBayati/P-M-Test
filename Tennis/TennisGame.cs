using System;
using Tennis.MessageGenerator;

namespace Tennis
{
    public class TennisGame
    {
        public string Name { get; private set; }

        private Player Player1;
        private Player Player2;

        public TennisGame(string name, Player player1, Player player2)
        {
            this.Validate(player1, player2);
            this.Name = name;
            this.Player1 = player1;
            this.Player2 = player2;

        }

        private void Validate(Player player1, Player player2)
        {
            if(player1 == null || player2 == null)
            {
                throw new Exception("players can not be null");
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this.Player1.Name)
            {
                this.Player1.SetScore();
            }
            else
            {
                this.Player2.SetScore();
            }
        }

        public string GetScore()
        {
            var msgGenerator = MsgGnrFactory.Build(this.Player1, this.Player2);
            return msgGenerator.Generate();
        }

    }
}
