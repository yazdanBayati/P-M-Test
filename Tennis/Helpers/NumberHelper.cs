using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.Helpers
{
    public static class NumberHelper
    {
        public static int FindDifference(int nr1, int nr2)
        {
            return Math.Abs(nr1 - nr2);
        }
    }
}
