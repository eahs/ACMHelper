﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            List<int> factors = ACM.GetPrimeFactors(38);  // [2, 19]

            int fact = 88;
            List<int> factors2 = fact.GetPrimeFactors();  // [2, 2, 2, 11]

            int gpf = 4997.GreatestPrimeFactor();  // 263

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
            string everything2 = "101010".ConvertBase(2, 10); // 42

            // one hundred and twenty-three million four hundred and fifty-six thousand seven hundred and eighty-nine
            string numberwords = 123456789.ToWords();

            int solution = "2 + (3 * 4)".Evaluate();  // 14

            string longest = "apple car banana grapefruit".ToStringList().OrderByDescending(sp => sp.Length).First();

            string a = "the cat in the hat", b = "I left the cat in the garage";
            string common = ACM.LongestCommonSubstring(a, b);  // "the cat in the "

            // Generates all possible substrings of a string
            List<string> allSubstrings = "i love cats".FindAllSubstrings().ToList();
            string prefix = "the cat in the hat:the cat loves me:the cat eats mice".ToStringList(":").ShortestCommonPrefix(); // "the cat"


            // Greatest common divisor (biggest number that divides 12 and 8)
            int gcd = ACM.GreatestCommonDivisor(12, 8);  // 4

            // Least common multiple (first number that is a multiple of a and b)
            int lcm = ACM.LeastCommonMultiple(2, 7);  // 14

            // Check if two lists contain indentical elements (order matters)
            List<int> aq = 123456789.ToIntegerList();  // [1,2,3,4,5,6,7,8,9]
            List<int> bq = 123456789.ToIntegerList();  // [1,2,3,4,5,6,7,8,9]
            List<int> cq = 987654321.ToIntegerList();  // [9,8,7,6,5,4,3,2,1]

            bool equals = aq.SequenceEqual(bq);   // true because both lists have same numbers in same sequence
            bool equals2 = aq.SequenceEqual(cq);  // false, same numbers but different order
            bool equals3 = aq.All(k => cq.Contains(k)) && aq.Count == cq.Count;


            List<int> digits = 12345.ToIntegerList();
            int least = digits.Min();

            // Rotate a list
            List<int> rotateLeft = nums.Rotate(2);
            List<int> rotateRight = nums.Rotate(-2);

            // Generate permutations of a list
            List<int> plist = 1234.ToIntegerList();

            var permutations = plist.Permute().ToList();

            foreach (var permutation in permutations)
            {
                List<int> perm = permutation.ToList();
            }

            List<int> blist = 12344321.ToIntegerList();
            bool increasing = blist.IsIncreasing(0, 3);

            int revint = 12345.Reverse();

            bool res = 123457789.ToIntegerList().IsIncreasing();
        }
    }
}
