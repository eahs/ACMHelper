import java.util.*;

public class Main {

    public static void main(String[] args) {

        // Prime number stuff
        List<Integer> primes = ACM.generatePrimes(5000);
        List<Integer> primeFactors = ACM.getPrimeFactors(88); // [2, 2, 2, 11]

        // Parsing input

        int num = ACM.toInteger("1");
        long num2 = ACM.toLong("2");
        double val = ACM.toDouble("6.5");

        // Turn a string into an integer list
        // ex.  List<Integer> nums = ACM.toIntegerList(scan.nextLine());
        List<Integer> nums = ACM.toIntegerList("1 2 3 4 5");

        // Reverse a string
        String s = "taco";
        s = ACM.reverseString(s);  // "ocat"

        // Base conversion
        String output = ACM.toBase(42, 2); // 101010
        String roman = ACM.toRoman(57);  // LVII

        String everything = ACM.convertBase("101010", 2, 10); // 42

        // one hundred and twenty-three million four hundred and fifty-six thousand seven hundred and eighty-nine
        String numberwords = ACM.toWords(123456789);

        double result = ACM.evaluate("3 * (4 + 3)");  // 21

        String a = "the cat in the hat", b = "I left the cat in the garage";
        String common = ACM.longestCommonSubstring(a, b);  // "the cat in the "
    }
}
