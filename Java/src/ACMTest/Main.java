import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class Main {

    public static void main(String[] args) {

        // Prime number stuff
        List<Integer> primes = ACM.generatePrimes(5000);
        List<Integer> primeFactors = ACM.getPrimeFactors(88); // [2, 2, 2, 11]
        int gpf = ACM.greatestPrimeFactor(4997);  // 4962

        // Parsing input

        int num = ACM.toInteger("1");
        long num2 = ACM.toLong("2");
        double val = ACM.toDouble("6.5");

        // Turn a string into an integer list
        // ex.  List<Integer> nums = ACM.toIntegerList(scan.nextLine());
        List<Integer> nums = ACM.toIntegerList("1 2 3 4 5 6 7 8 9 10");

        List<List<Integer>> permutations = ACM.permute(nums);

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

        String rgx = ACM.regexReplace("aabbba", "[a]+", m -> m.group().length()+"");

        String rev = ACM.regexReplace("monkeyCATtacoBOAT", "[A-Z]+", m -> ACM.reverseString(m.group()));

        List<Integer> list = ACM.toIntegerList("1 2 2 3 3 3 4 4 4 4 5 5 5 5 5");
        int freq = Collections.frequency(list,4); // 4 appears 4 times in the list
        int max = Collections.max(list);

        List<Integer> addme = IntStream.rangeClosed(1, 5).boxed().collect(Collectors.toList()); // [1,2,3,4,5]
        int sum = ACM.sumList(addme); // 1 + 2 + 3 + 4 + 5 = 15

        Collections.sort(list);
        Collections.reverse(list);

        //Creating LocalTime by providing input arguments
        LocalTime time1 = LocalTime.of(12, 25, 0);
        System.out.println("Specific Time of Day="+time1);

        LocalTime time2 = time1.plus(3600, ChronoUnit.SECONDS);  // Add 3600 seconds to 12:25PM

        System.out.println(time2.format(DateTimeFormatter.ofPattern("HH:mm")));  // 13:25
        System.out.println(time2.format(DateTimeFormatter.ofPattern("hh:mm a"))); // 12:25PM


    }
}
