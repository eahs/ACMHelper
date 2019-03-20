using System;
using System.Collections.Generic;
using System.Linq;
using ACMHelper;

namespace ACMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate list of primes less than or equal to 5000
            List<int> primes = ACM.GeneratePrimes(5000);
            List<int> primesFaster = ACM.GeneratePrimesParallel(5000);

            // Parse input strings
            List<int> nums = "1 2 3 4 5 6 7 8 9 10".ToIntegerList();
            List<string> strings = "apple banana carrot".ToStringList();

            int num = "1".ToInteger();
            long num2 = "2".ToLong();
            double val = "6.5".ToDouble();

            // Reverse a string
            String s = "taco";
            s = s.Reverse();  // "ocat"

            // Turn an int into a different arbitrary base (binary = 2, octal = 8, hex = 16)
            string output = 42.ToBase(2);  // 101010
            string roman = 57.ToRoman(); // LVII

            string everything = ACM.ConvertBase("101010", 2, 10); // 42

            // one hundred and twenty-three million four hundred and fifty-six thousand seven hundred and eighty-nine
            string numberwords = 123456789.ToWords();

            int solution = "2 + (3 * 4)".Evaluate();  // 14
        }
    }
}
