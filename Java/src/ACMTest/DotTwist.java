import com.sun.javafx.geom.Vec3d;

import java.util.*;

public class DotTwist {

    public static void main (String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.print("Enter three coordinates: ");
        String input = scan.nextLine();

        int[] a = ACM.toIntegerArray(input);
        int[] b = a.clone();  // Make a copy of a

        Arrays.sort(b);

        int soln = a[0]*b[0] + a[1]*b[1] + a[2]*b[2];

        System.out.println("Dot twist: " + soln);
    }
}
