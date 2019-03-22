import java.util.*;
import java.util.stream.Collectors;

public class Quokka {

    public static void main (String[] args)
    {
        Scanner scan = new Scanner(System.in);

        System.out.print("Dice: ");
        String input = scan.nextLine();

        List<Integer> nums = ACM.toIntegerList(input);

        // Create a new list that contains num values that are even
        // The second parameter is a predicate, a single argument function that returns true or false
        // name_of_parameter -> true or false calculation using name_of_parameter
        List<Integer> a = ACM.filterList(nums, num -> num % 2 == 0);  // Get the even numbers
        List<Integer> b = ACM.filterList(nums, num -> num % 2 == 1);  // Get the odd numbers

        int result = a.size() * ACM.sumList(a) + b.size() * ACM.sumList(b);

        System.out.println("Profit: $" + result);
    }
}
