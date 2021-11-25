

namespace Tennis.MessageGenerator
{
    public abstract class NeqAdvanceScoreGnr : IMsgGnr
    {
        private Player _player1;
        private Player _player2;
       

        public NeqAdvanceScoreGnr(Player player1, Player player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public abstract string Generate();
        protected string Postfix
        {
            get
            {
                return this._player1.Score > this._player2.Score ?
               _player1.Name :
               _player2.Name;
            }
           
        }
    }
}
