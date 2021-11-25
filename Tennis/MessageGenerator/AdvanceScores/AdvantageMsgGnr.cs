

namespace Tennis.MessageGenerator
{
    public class AdvantageMsgGnr : NeqAdvanceScoreGnr
    {
        public AdvantageMsgGnr(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string Generate()
        {
            return $"Advantage {this.Postfix}";
        }
    }
}
