using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PM.Algorithms
{
    public static class  PrimeNumberHelper
    {

        public static List<int> GetPrimeNumbersTo(int number)
        {
            bool[] primes = new bool[number + 1];

            for(var i = 0; i< number; i++)
            {
                primes[i] = true;
            }

            for (int p = 2; p * p <= number; p++)
            {
                if (primes[p] == true)
                {
                    RemoveAllMultiples(number, primes, p);
                }
            }

            var result = new List<int>();

            for (var i = 2; i <= number; i++)
            {
                if (primes[i])
                {
                    result.Add(i);
                }
                
            }

            return result;
        }

        public static bool isPrimeNumber(int number)
        {
            if(number == 1)
            {
                return false;
            }
            for(var i = 2; i< number/2; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void RemoveAllMultiples(int number, bool[] primes, int p)
        {
            for (int i = p * p; i <= number; i += p)
            {
                primes[i] = false;
            }
                
        }
    }
}
