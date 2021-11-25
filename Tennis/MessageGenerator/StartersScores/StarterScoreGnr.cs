using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.MessageGenerator.StartersScores
{
    
    public abstract class StarterScoreGnr:IMsgGnr
    {
        protected int _score;

        protected Dictionary<int, string> _translator = new Dictionary<int, string>() { { 0, "Love" }, { 1, "Fifteen" }, { 2, "Thirty" }, { 3, "Forty" } };

        public StarterScoreGnr(int score)
        {
            Validate(score);
            _score = score;
        }

        private void Validate(int score)
        {
            if(score < 0 || score > 3)
            {
                throw new Exception("Invalid Score");
            }
        }

        public abstract string Generate();
        
    }
}
