using System;
using System.Collections.Generic;
using System.Linq;

namespace ACMHelper
{
    public static class ACM
    {
        /* Returns a list of primes up to n */
        public static List<int> GeneratePrimes(int n)
        {
            var primes = new List<int>();
            for (var i = 2; i <= n; i++)
            {
                var ok = true;
                foreach (var prime in primes)
                {
                    if (prime * prime > i)
                        break;
                    if (i % prime == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                    primes.Add(i);
            }
            return primes;
        }

        /* Returns a list of primes up to n using parallelization */
        public static List<int> GeneratePrimesParallel(int n)
        {
            var sqrt = (int)Math.Sqrt(n);
            var lowestPrimes = GeneratePrimes(sqrt);
            var highestPrimes = (Enumerable.Range(sqrt + 1, n - sqrt)
                                      .AsParallel()
                                      .Where(i => lowestPrimes.All(prime => i % prime != 0)));
            return lowestPrimes.Concat(highestPrimes).ToList();
        }

        /* Given an input string containing numbers separated by spaces, returns a list of ints */
        public static List<int> ToIntegerList (this string input)
        {
            return input.Split(" ").Select(n => Convert.ToInt32(n)).ToList();
        }

        /* Given an input string containing numbers separated by spaces, returns a list of strings */
        public static List<string> ToStringList(this string input)
        {
            return input.Split(" ").ToList();
        }


        public static int ToInteger (this string input)
        {
            return Convert.ToInt32(input);
        }

        /*
            List<int> nums = ACM.ReadIntegerList();

            var permutations = nums.Permute().ToList();

            foreach (var permutation in permutations)
            {
                List<int> perm = permutation.ToList();
            }
        */
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var remainingItems = list.AllExcept(startingElementIndex);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return startingElement.Concat(permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null)
            {
                yield break;
            }

            foreach (var item in secondSequence)
            {
                yield return item;
            }
        }

        private static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
        {
            if (sequence == null)
            {
                yield break;
            }

            var index = 0;

            foreach (var item in sequence.Where(item => index++ != indexToSkip))
            {
                yield return item;
            }
        }

        /* Reverses a string - e.g. 
         *      s = "blah"; 
         *      string rev = s.Reverse();  
         *      ... rev contains "halb"
         */
        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /// <summary>
        /// Converts the given decimal number to the numeral system with the
        /// specified radix (in the range [2, 36]).
        /// </summary>
        /// <param name="decimalNumber">The number to convert.</param>
        /// <param name="numberBase">The radix of the destination numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        public static string ToBase(this int decimalNumber, int numberBase)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (numberBase < 2 || numberBase > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % numberBase);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / numberBase;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        public static string ToWords(this int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
