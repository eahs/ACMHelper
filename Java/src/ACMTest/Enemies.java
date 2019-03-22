import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class Enemies {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.print("How many seats: ");
        String input = scan.nextLine();

        int n = ACM.toInteger(input);

        int res = IntStream.rangeClosed(1, (int)Math.pow(2,n))
                                        .mapToObj(x -> ACM.padLeft(ACM.toBase(x, 2), n, "0"))
                                        .filter(s -> !s.contains("00"))
                                        .collect(Collectors.toList()).size();

        System.out.println("Number of arrangements :" + res);

    }

}