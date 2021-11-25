using System;
using System.Collections.Generic;
using System.Text;
using Tennis.MessageGenerator.StartersScores;

namespace Tennis
{
    public class EqStarterScoreGnr : StarterScoreGnr
    {
        public EqStarterScoreGnr(int score):base(score)
        {
        }

        public override string Generate()
        {
            return $"{_translator[_score]}-All";
        }
    }
}
