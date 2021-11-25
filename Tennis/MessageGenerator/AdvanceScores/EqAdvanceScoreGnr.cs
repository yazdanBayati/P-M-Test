using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.MessageGenerator
{
    public class EqAdvanceScoreGnr : IMsgGnr
    {
        public string Generate()
        {
            return "Deuce";
        }
    }
}
