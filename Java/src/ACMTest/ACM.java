import java.util.*;
import java.util.function.Predicate;
import java.util.stream.Collectors;

import static javafx.application.Platform.exit;

public class ACM
{
    private static List<Integer> primeList = null;
    private static int maxPrime = -1;

    // Generate primes equal to or below n
    public static List<Integer> generatePrimes (int n)
    {
        boolean prime[] = new boolean[n + 1];
        Arrays.fill(prime, true);
        for (int p = 2; p * p <= n; p++) {
            if (prime[p]) {
                for (int i = p * 2; i <= n; i += p) {
                    prime[i] = false;
                }
            }
        }
        List<Integer> primeNumbers = new LinkedList<>();
        for (int i = 2; i <= n; i++) {
            if (prime[i]) {
                primeNumbers.add(i);
            }
        }

        if (((primeList == null) || (n > maxPrime))) {
            primeList = primeNumbers;
            maxPrime = n;
        }

        return primeNumbers;
    }

    // Get prime factors for a number n
    public static List<Integer> getPrimeFactors (int n)
    {
        List<Integer> factors = new ArrayList<Integer>();
        if (((primeList == null) || (n > maxPrime))) {
            System.out.println("You must call ACM.GeneratePrimes(n) for the highest n you expect to need to check at least once befor" +
                    "e using this method.");
            exit();
        }

        while (n > 1) {
            for (int i = 0; i < primeList.size(); i++) {
                if (n % primeList.get(i) == 0) {
                    factors.add(primeList.get(i));
                    n /= primeList.get(i);
                    break;
                }

            }

        }

        return factors;
    }

    // Given an input string containing numbers separated by spaces, returns a list
    public static List<Integer> toIntegerList (String input)
    {
        return Arrays.stream(input.split("\\s"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());
    }

    public static int[] toIntegerArray (String input)
    {
        return Arrays.stream(input.split("\\s"))
                .mapToInt(Integer::parseInt)
                .toArray();
    }

    public static List<String> toStringList (String input)
    {
        return Arrays.stream(input.split("\\s"))
                .collect(Collectors.toList());

    }

    // Given a string as input, returns an int
    public static int toInteger (String input)
    {
        return Integer.parseInt(input);
    }

    public static long toLong (String input)
    {
        return Long.parseLong(input);
    }

    public static double toDouble (String input)
    {
        return Double.parseDouble(input);
    }

    // Generates a list of all the permutations of a list
    public static <T> List<List<T>> permute (ArrayList<T> list)
    {
        return null;
    }

    // Reverses a string
    public static String reverseString (String input)
    {
        StringBuilder sb = new StringBuilder(input);

        return sb.reverse().toString();
    }

    // Converts a number to an arbitrary base
    public static String toBase(int number, int numberBase)
    {
        return convertBase(number + "", 10, numberBase);
    }

    // Converts a number string from a particular base (fromBase) to another base (toBase)
    public static String convertBase (String from, int fromBase, int toBase)
    {
        return Integer.toString(Integer.parseInt(from, fromBase), toBase);
    }

    final private  static String[] units = {"zero","one","two","three","four",
            "five","six","seven","eight","nine","ten",
            "eleven","twelve","thirteen","fourteen","fifteen",
            "sixteen","seventeen","eighteen","nineteen"};
    final private static String[] tens = {"","","twenty","thirty","forty","fifty",
            "sixty","seventy","eighty","ninety"};

    // Converts a number into the english equivalent
// e.g. 132 = One hundred thirty two
    public static String toWords(int n)
    {
        //
        if( n < 20)  return units[n];
        if( n < 100) return tens[n/10] + ((n % 10 > 0)? "-" + toWords(n % 10):"");
        if( n < 1000) return units[n/100] + " hundred" + ((n % 100 > 0)?" and " + toWords(n % 100):"");
        if( n < 1000000) return toWords(n / 1000) + " thousand" + ((n % 1000 > 0)? " " + toWords(n % 1000):"") ;
        if (n < 1000000000) return toWords(n / 1000000) + " million" + ((n % 1000000 > 0)? " " + toWords(n % 1000000):"") ;
        return toWords(n / 1000000000) + " billion" + ((n % 1000000000 > 0)? " " + toWords(n % 1000000000):"") ;

    }

    // Converts a number into roman numerals
    public static String toRoman(int number)
    {
        if (number < 1 || number > 3999)
            return "Invalid Roman Number Value";
        String s = "";
        while (number >= 1000) {
            s += "M";
            number -= 1000;        }
        while (number >= 900) {
            s += "CM";
            number -= 900;
        }
        while (number >= 500) {
            s += "D";
            number -= 500;
        }
        while (number >= 400) {
            s += "CD";
            number -= 400;
        }
        while (number >= 100) {
            s += "C";
            number -= 100;
        }
        while (number >= 90) {
            s += "XC";
            number -= 90;
        }
        while (number >= 50) {
            s += "L";
            number -= 50;
        }
        while (number >= 40) {
            s += "XL";
            number -= 40;
        }
        while (number >= 10) {
            s += "X";
            number -= 10;
        }
        while (number >= 9) {
            s += "IX";
            number -= 9;
        }
        while (number >= 5) {
            s += "V";
            number -= 5;
        }
        while (number >= 4) {
            s += "IV";
            number -= 4;
        }
        while (number >= 1) {
            s += "I";
            number -= 1;
        }
        return s;
    }

    // Returns the index of the max element in a list, -1 if empty
    public static int maxIndex (List list)
    {
        return list.indexOf(Collections.max(list));
    }

    // Returns the index of the min element in a list, -1 if empty
    public static int minIndex (List list)
    {
        return list.indexOf(Collections.min(list));
    }

    // Evaluates a string math expression and returns a result
    public static double evaluate(final String str) {
        return new Object() {
            int pos = -1, ch;

            void nextChar() {
                ch = (++pos < str.length()) ? str.charAt(pos) : -1;
            }

            boolean eat(int charToEat) {
                while (ch == ' ') nextChar();
                if (ch == charToEat) {
                    nextChar();
                    return true;
                }
                return false;
            }

            double parse() {
                nextChar();
                double x = parseExpression();
                if (pos < str.length()) throw new RuntimeException("Unexpected: " + (char)ch);
                return x;
            }

            // Grammar:
            // expression = term | expression `+` term | expression `-` term
            // term = factor | term `*` factor | term `/` factor
            // factor = `+` factor | `-` factor | `(` expression `)`
            //        | number | functionName factor | factor `^` factor

            double parseExpression() {
                double x = parseTerm();
                for (;;) {
                    if      (eat('+')) x += parseTerm(); // addition
                    else if (eat('-')) x -= parseTerm(); // subtraction
                    else return x;
                }
            }

            double parseTerm() {
                double x = parseFactor();
                for (;;) {
                    if      (eat('*')) x *= parseFactor(); // multiplication
                    else if (eat('/')) x /= parseFactor(); // division
                    else return x;
                }
            }

            double parseFactor() {
                if (eat('+')) return parseFactor(); // unary plus
                if (eat('-')) return -parseFactor(); // unary minus

                double x;
                int startPos = this.pos;
                if (eat('(')) { // parentheses
                    x = parseExpression();
                    eat(')');
                } else if ((ch >= '0' && ch <= '9') || ch == '.') { // numbers
                    while ((ch >= '0' && ch <= '9') || ch == '.') nextChar();
                    x = Double.parseDouble(str.substring(startPos, this.pos));
                } else if (ch >= 'a' && ch <= 'z') { // functions
                    while (ch >= 'a' && ch <= 'z') nextChar();
                    String func = str.substring(startPos, this.pos);
                    x = parseFactor();
                    if (func.equals("sqrt")) x = Math.sqrt(x);
                    else if (func.equals("sin")) x = Math.sin(Math.toRadians(x));
                    else if (func.equals("cos")) x = Math.cos(Math.toRadians(x));
                    else if (func.equals("tan")) x = Math.tan(Math.toRadians(x));
                    else throw new RuntimeException("Unknown function: " + func);
                } else {
                    throw new RuntimeException("Unexpected: " + (char)ch);
                }

                if (eat('^')) x = Math.pow(x, parseFactor()); // exponentiation

                return x;
            }
        }.parse();
    }

    public static String longestCommonSubstring(String a, String b)
    {
        StringBuilder sb = new StringBuilder();
        if (a == null || a.isEmpty() || b == null || b.isEmpty())
            return "";

// ignore case
        a = a.toLowerCase();
        b = b.toLowerCase();

// java initializes them already with 0
        int[][] num = new int[a.length()][b.length()];
        int maxlen = 0;
        int lastSubsBegin = 0;

        for (int i = 0; i < a.length(); i++) {
            for (int j = 0; j < b.length(); j++) {
                if (a.charAt(i) == b.charAt(j)) {
                    if ((i == 0) || (j == 0))
                        num[i][j] = 1;
                    else
                        num[i][j] = 1 + num[i - 1][j - 1];

                    if (num[i][j] > maxlen) {
                        maxlen = num[i][j];
                        // generate substring from str1 => i
                        int thisSubsBegin = i - num[i][j] + 1;
                        if (lastSubsBegin == thisSubsBegin) {
                            //if the current LCS is the same as the last time this block ran
                            sb.append(a.charAt(i));
                        } else {
                            //this block resets the string builder if a different LCS is found
                            lastSubsBegin = thisSubsBegin;
                            sb = new StringBuilder();
                            sb.append(a.substring(lastSubsBegin, i + 1));
                        }
                    }
                }
            }}

        return sb.toString();
    }

    public static int greatestCommonDivisor (int a, int b)
    {

        // Always set to positive
        a = ( a > 0) ? a : -a;
        b = ( b > 0) ? b : -b;

        while(a != b)
        {
            if(a > b)
                a -= b;
            else
                b -= a;
        }

        return a;
    }

    public static int leastCommonMultiple (int a , int b)
    {
        return (a / greatestCommonDivisor(a, b)) * b;
    }

    public static int sumList (List<Integer> list) {

        int sum = list.stream().mapToInt(Integer::intValue).sum();

        return sum;
    }

    // Returns a portion of a list according to some filter (equivalent to C# Where)
    // ACM.filterList(nums, num -> num % 2 == 0)
    public static <T> List<T> filterList (List<T> list, Predicate<T> filter)
    {
        return list.stream().filter(filter).collect(Collectors.toList());
    }

    public static List<Character> toCharacterList(final String str) {
        return str.chars().mapToObj(e->(char)e).collect(Collectors.toList());
    }
}
