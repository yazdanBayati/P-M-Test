using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Helpers;

namespace Tennis.MessageGenerator
{
    public static class MsgGnrFactory
    {
        public static IMsgGnr Build(Player player1, Player player2)
        {
            if(player1.Score >2 && player2.Score >2)
            {
                if (player1.Score == player2.Score)
                {
                    return new EqAdvanceScoreGnr();
                }
                else
                {
                    var diff = NumberHelper.FindDifference(player1.Score, player2.Score);

                    if(diff > 1)
                    {
                        return new WinerMsgGnr(player1, player2);
                    }
                    else
                    {
                        return new AdvantageMsgGnr(player1, player2);
                    }
                        
                }
            }
            else if(player1.Score > 3 || player2.Score > 3) // diff will be more than 1
            {
                return new WinerMsgGnr(player1, player2);
            }
            else
            {
                if (player1.Score == player2.Score)
                {
                    return new EqStarterScoreGnr(player1.Score);
                }
                else
                {
                    return new NeqStarterScoreGnr(player1.Score, player2.Score);
                }
            }
        }
       
    }
}
