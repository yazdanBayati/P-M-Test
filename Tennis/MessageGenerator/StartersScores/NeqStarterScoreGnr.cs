using System;
using System.Collections.Generic;
using System.Text;
using Tennis.MessageGenerator.StartersScores;

namespace Tennis
{
    public class NeqStarterScoreGnr : StarterScoreGnr
    {

        private int _score2;
        public NeqStarterScoreGnr(int score1, int score2):base(score1)
        {
            this.Validate(score2);
            _score2 = score2;
        }

        private void Validate(int score)
        {
            if (score < 0 || score > 3)
            {
                throw new Exception("second score is not valid");
            }
        }



        public override string  Generate()
        {
            return $"{_translator[_score]}-{_translator[_score2]}";
        }
    }
}
