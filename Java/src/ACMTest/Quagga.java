import java.util.*;

public class Quagga {
    public static void main (String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.print("Enter dice numbers: ");
        String input = scan.nextLine();

        List<Integer> nums = ACM.toIntegerList(input);

        boolean quagga =    ((nums.get(0)*10 + nums.get(1)) % nums.get(2) == 0) ||
                            ((nums.get(1)*10 + nums.get(1)) % nums.get(2) == 0) ||
                            ((nums.get(0)*10 + nums.get(2)) % nums.get(1) == 0) ||
                            ((nums.get(2)*10 + nums.get(0)) % nums.get(1) == 0) ||
                            ((nums.get(1)*10 + nums.get(2)) % nums.get(0) == 0) ||
                            ((nums.get(2)*10 + nums.get(1)) % nums.get(0) == 0);

        quagga = quagga && !nums.contains(1);

        if (quagga)
            System.out.println("That's a QUAGGA!");
        else
            System.out.println("Sorry, no QUAGGA.");

    }
}
