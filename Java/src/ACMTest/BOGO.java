import java.util.Arrays;
import java.util.List;
import java.util.Scanner;


public class BOGO {

    public static void main (String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.print("Enter purchase: ");
        String input = scan.nextLine();

        List<Character> chars = ACM.toCharacterList(input);

        // Do 3 separate filters on the chars list to find S, M, L
        int small = ACM.filterList(chars, c -> c == 'S').size();
        int medium = ACM.filterList(chars, c -> c == 'M').size();
        int large = ACM.filterList(chars, c -> c == 'L').size();

        int total = small * 2 + medium * 3 + large * 5;

        if (small == 2) total -= 2;
        if (medium == 2) total -= 3;
        if (large == 2) total -= 5;

        System.out.println("Price: $" + total);

    }
}
