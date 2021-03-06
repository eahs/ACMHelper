﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ACMHelper
{
    public static class ACM
    {
        private static List<int> primeList = null;
        private static int maxPrime = -1;

        /// <summary>
        /// Returns a list of prime numbers less than or equal to n
        /// </summary>
        /// <param name="n">Max number</param>
        /// <returns></returns>
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

            if (primeList == null || n > maxPrime)
            {
                primeList = primes;
                maxPrime = n;
            }
            return primes;
        }

        /// <summary>
        /// Returns a list of prime factors for n
        /// </summary>
        /// <param name="n">Number to factor</param>
        /// <returns></returns>
        public static List<int> GetPrimeFactors(this int n)
        {
            List<int> factors = new List<int>();

            if (primeList == null || n > maxPrime)
            {
                throw new Exception("You must call ACM.GeneratePrimes(n) for the highest n you expect to need to check at least once before using this method.");
            }

            while (n > 1)
            {
                for (int i = 0; i < primeList.Count; i++)
                {
                    if (n % primeList[i] == 0)
                    {
                        factors.Add(primeList[i]);
                        n /= primeList[i];
                        break;
                    }
                }
            }

            return factors;
        }

        /// <summary>
        /// Greatest Prime Factor
        /// </summary>
        /// <param name="n">Number to factor</param>
        /// <returns></returns>
        public static int GreatestPrimeFactor(this int n)
        {
            if (n == 1) return 1;

            if (primeList == null || n > maxPrime)
            {
                throw new Exception("You must call ACM.GeneratePrimes(n) for the highest n you expect to need to check at least once before using this method.");
            }

            int max = 2, current = 0;
            foreach (int p in primeList)
            {
                current = n % p;
                if (current == 0 & p > max)
                    max = p;

                if (p > n) break;
            }

            return max;
        }

        /* Returns a list of primes up to n using parallelization */
        public static List<int> GeneratePrimesParallel(int n)
        {
            var sqrt = (int)Math.Sqrt(n);
            var lowestPrimes = GeneratePrimes(sqrt);
            var highestPrimes = (Enumerable.Range(sqrt + 1, n - sqrt)
                                      .AsParallel()
                                      .Where(i => lowestPrimes.All(prime => i % prime != 0)));
            var result = lowestPrimes.Concat(highestPrimes).ToList();

            if (primeList == null || n > maxPrime)
            {
                primeList = result;
                maxPrime = n;
            }

            return result;
        }

        /// <summary>
        /// Given an input string containing numbers separated by spaces, returns a list of ints
        /// </summary>
        /// <param name="input">Input string delimeted by delimeter string</param>
        /// <param name="delimeter">String that separates each number int the input - default is a space</param>
        /// <returns></returns>
        public static List<int> ToIntegerList (this string input, string delimeter = " ")
        {
            return input.Split(delimeter).Select(n => Convert.ToInt32(n)).ToList();
        }

        /// <summary>
        /// Given an input string containing numbers separated by spaces, returns a list of longs
        /// </summary>
        /// <param name="input">Input string delimeted by delimeter string</param>
        /// <param name="delimeter">String that separates each number int the input - default is a space</param>
        /// <returns></returns>
        public static List<long> ToLongList(this string input, string delimeter = " ")
        {
            return input.Split(delimeter).Select(n => Convert.ToInt64(n)).ToList();
        }

        /// <summary>
        /// Given an input string containing numbers separated by spaces, returns a list of longs
        /// </summary>
        /// <param name="input">Input string delimeted by delimeter string</param>
        /// <param name="delimeter">String that separates each number int the input - default is a space</param>
        /// <returns></returns>
        public static List<BigInteger> ToBigIntegerList(this string input, string delimeter = " ")
        {
            return input.Split(delimeter).Select(n => BigInteger.Parse(n)).ToList();
        }


        /// <summary>
        /// Given an integer splits the integer into it's individual digits and returns a list of ints
        /// </summary>
        /// <param name="input">Input int</param>
        /// <returns></returns>
        public static List<int> ToIntegerList (this int input)
        {
            return input.ToString()
                        .ToCharArray()
                        .Select(p => Convert.ToInt32(p + ""))
                        .ToList();
        }


        /// <summary>
        /// Given an input string containing numbers separated by spaces, returns a list of strings
        /// </summary>
        /// <param name="input">Input string delimeted by delimeter string</param>
        /// <param name="delimeter">String that separates each number int the input - default is a space</param>
        /// <returns></returns>
        public static List<string> ToStringList(this string input, string delimeter = " ")
        {
            return input.Split(delimeter).ToList();
        }


        public static int ToInteger (this string input)
        {
            return Convert.ToInt32(input);
        }

        public static long ToLong(this string input)
        {
            return Convert.ToInt64(input);
        }

        public static double ToDouble(this string input)
        {
            return Convert.ToDouble(input);
        }

        /// <summary>
        /// Returns the shortest common prefix among a list of strings
        /// </summary>
        /// <param name="list">List of strings to look through</param>
        /// <returns></returns>
        public static string ShortestCommonPrefix(this List<string> list)
        {
            string commonPrefix = new string(
                                            list.First()
                                                .Substring(0, list.Min(s => s.Length))
                                                .TakeWhile((c, i) => list.All(s => s[i] == c)).ToArray()
                                         );

            return commonPrefix;
        }

        /// <summary>
        /// Returns a list of every substring that can be generated from a string
        /// </summary>
        /// <param name="s">String to generate list from</param>
        /// <returns></returns>
        public static IEnumerable<string> FindAllSubstrings(this string s)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string ss = s.Substring(i, j - i + 1);
                    list.Add(ss);
                }
            }
            return list;
        }

        /// <summary>
        /// Returns the longest common substring that exists inside both a and b
        /// </summary>
        /// <param name="a">First string</param>
        /// <param name="b">Second string</param>
        /// <returns></returns>
        public static string LongestCommonSubstring(string a, string b)
        {
            var substringsOfA = a.FindAllSubstrings();
            var substringsOfB = b.FindAllSubstrings();
            var commonSubstrings = substringsOfA.Intersect(substringsOfB);

            return commonSubstrings.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        /*
            List<int> nums = Console.ReadLine().ToIntegerList();

            var permutations = nums.Permute().ToList();

            foreach (var permutation in permutations)
            {
                List<int> perm = permutation.ToList();
            }
        */
        /// <summary>
        /// Returns an Enumerable of Enumerables - All permutations of the original list
        /// </summary>
        /// <param name="sequence">Source list</param>
        /// <param name="indexToSkip">Index you want to remove</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns an Enumerable of Enumerables - All possible combinations of size k as picked from a list of possibilities
        /// </summary>
        /// <param name="data">Source list</param>
        /// <param name="k">number of objects to choose from list</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Choose<T>(this IEnumerable<T> data, int k)
        {
            int size = data.Count();

            IEnumerable<IEnumerable<T>> Runner(IEnumerable<T> list, int n)
            {
                int skip = 1;
                foreach (var headList in list.Take(size - k + 1).Select(h => new T[] { h }))
                {
                    if (n == 1)
                        yield return headList;
                    else
                    {
                        foreach (var tailList in Runner(list.Skip(skip), n - 1))
                        {
                            yield return headList.Concat(tailList);
                        }
                        skip++;
                    }
                }
            }

            return Runner(data, k);
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

        /// <summary>
        /// Returns a list of everything except a particular index
        /// </summary>
        /// <param name="sequence">Source list</param>
        /// <param name="indexToSkip">Index you want to remove</param>
        /// <returns></returns>
        public static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
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

        /// <summary>
        /// Determines whether the list is strictly increasing (that is each number is larger than the previous)
        /// </summary>
        /// <param name="list">List of integers</param>
        /// <returns></returns>
        public static bool IsIncreasing<T>(this IEnumerable<T> list, int startIndex = 0, int endIndex = -1) where T : IComparable
        {
            List<T> seq = list.ToList();

            if (endIndex == -1)
                endIndex = seq.Count - 1;

            for (int i = startIndex; i < endIndex; i++)
            {                
                if (Comparer<T>.Default.Compare(seq[i], seq[i + 1]) >= 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a single row of a 2D array
        /// </summary>
        /// <param name="row">Row to return</param>
        /// <returns></returns>
        public static IEnumerable<T> GetRow<T>(this T[,] array, int row)
        {
            for (int i = 0; i <= array.GetUpperBound(1); ++i)
                yield return array[row, i];
        }

        /// <summary>
        /// Returns a single column of a 2D array
        /// </summary>
        /// <param name="row">Row to return</param>
        /// <returns></returns>
        public static IEnumerable<T> GetColumn<T>(this T[,] array, int column)
        {
            for (int i = 0; i <= array.GetUpperBound(0); ++i)
                yield return array[i, column];
        }

        /// <summary>
        /// Returns the sum of a 2D array
        /// </summary>
        /// <returns></returns>
        public static int Sum(this int[,] array)
        {
            return array.Cast<int>().Sum();
        }


        /// <summary>
        /// Reverses a string - e.g. "taco" => "ocat"
        /// </summary>
        /// <param name="input">string to reverse</param>
        /// <returns></returns>
        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /// <summary>
        /// Reverses an integer -> 1234 => 4321
        /// </summary>
        /// <param name="input">int to reverse</param>
        /// <returns></returns>
        public static int Reverse(this int input)
        {
            int sum = 0;

            do
            {
                sum *= 10;
                sum += input % 10;
                input /= 10;
            } while (input > 0);

            return sum;
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

        /// <summary>
        /// Converts the given decimal number to the numeral system with the
        /// specified radix (in the range [2, 36]).
        /// </summary>
        /// <param name="fromBase">The base of the number string you are converting from.</param>
        /// <param name="toBase">The base you are converting to (in the range [2, 36]).</param>
        /// <returns></returns>
        public static string ConvertBase(this string number, int fromBase, int toBase)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string result = number;
            int val = 0, place = 1;

            try
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    val += Digits.IndexOf(number[i]) * place;
                    place *= fromBase;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Number must be formatted as a numeric string.");
            }

            return val.ToBase(toBase);
        }

        /// <summary>
        /// Converts the given integer to a string representing the Ordinal representation
        /// Example: 1 = 1st, 2 = 2nd, 3 = 3rd, 4 = 4th, etc.
        /// </summary>
        /// <param name="n">The number you are finding the ordinal place representation for.</param>
        /// <returns></returns>
        public static string ToNthPlace(this int n)
        {
            string num = n.ToString();

            if (num.EndsWith("1")) return n + "st";
            if (num.EndsWith("2")) return n + "nd";
            if (num.EndsWith("3")) return n + "rd";

            return n + "th";
        }

        /// <summary>
        /// Converts the given integer number to an english version of the word
        /// Example: 
        ///     "1234".ToWords() -> "One thousand two hundred thirty four"
        /// </summary>
        /// <param name="n">The number you are converting to an english word.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts the given integer number to roman numerals.
        /// <c>string roman = 57.ToRoman(); -> "LVII"</c>
        /// </summary>
        /// <param name="n">The number you are converting to a Roman numerals.</param>
        /// <returns></returns>
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

        public static int Evaluate (this string expression)
        {
            NCalc.Expression ex = new NCalc.Expression(expression);
            return ex.Evaluate().ToString().ToInteger();
        }

        /// <summary>
        /// Finds the largest number that both a and b can be evenly divided by
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns></returns>
        public static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Finds the smallest number that is a multiple of both a and b
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns></returns>
        public static int LeastCommonMultiple(int a, int b)
        {
            return (a / GreatestCommonDivisor(a, b)) * b;
        }

        /// <summary>
        /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        /// You may assume that each input would have exactly one solution.
        ///
        /// Example:
        /// Given nums = [2, 7, 11, 15], target = 9,
        ///
        /// Because nums[0] + nums[1] = 2 + 7 = 9,
        /// return [0, 1].
        /// </summary>
        /// <param name="nums">List of integers to search</param>
        /// <param name="target">Integer you are trying to match</param>
        /// <returns></returns>
        public static int[] TwoSum(List<int> nums, int target)
        {
            for (var i = 0; i < nums.Count; i++)
            {
                for (var j = nums.Count - 1; j > i; j--)
                {
                    if (i != j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return new int[] { };
        }

        /// <summary>
        /// Given a list, rotates the list such that each element is shifted offset places to the left.
        ///
        /// Rotate 1 each time:
        /// List<int> {1,2,3,4,5} => {2,3,4,5,1} => {3,4,5,1,2} => {4,5,1,2,3}        
        ///  
        /// </summary>
        /// <param name="list">List of integers to rotate</param>
        /// <param name="leftOffset">Places to the left to rotate</param>
        /// <returns></returns>
        public static List<T> Rotate<T>(this List<T> list, int leftOffset = 1)
        {
            int offset = leftOffset % list.Count;
            if (offset < 0)
            {
                offset *= -1;
                return list.Skip(list.Count - offset).Take(offset).Concat(list.Take(list.Count - offset)).ToList();
            }
            return list.Skip(offset).Concat(list.Take(offset)).ToList();
        }
    }
}
