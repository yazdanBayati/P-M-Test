

namespace PM.Algorithms
{
    public static class FactorialHelper
    {
        public static long CalacFactorial(int number)
        {
           if(number == 1)
            {
                return 1;
            }
            long factorial = number;
            while(number > 1)
            {
                factorial *= --number;
            }

            return factorial;
        }
    }
}
