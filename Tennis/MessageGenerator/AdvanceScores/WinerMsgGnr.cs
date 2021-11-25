

namespace Tennis.MessageGenerator
{
    public class WinerMsgGnr : NeqAdvanceScoreGnr
    {

        public WinerMsgGnr(Player player1, Player player2):base(player1, player2)
        {
        }
       
        public override string Generate()
        {
            return $"Win for {this.Postfix}";
        }
    }
}
