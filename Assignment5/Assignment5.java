package Assignment5;

import java.util.Arrays;

public class Assignment5 {

    static int[] xs = { 3, 5, 12 };
    static int[] ys = { 2, 3, 4, 7 };

    public static void main(String[] args) {
        var res = Assignment5.merge(xs, ys);
        System.out.println(Arrays.toString(res));
    }

    static int[] merge(int[] xs, int[] ys) {
        int[] result = new int[xs.length + ys.length];
        int rP = 0, xP = 0, yP = 0;
        while (xP != xs.length && yP != ys.length) {
            if (xs[xP] <= ys[yP]) {
                result[rP++] = xs[xP++];
            } else {
                result[rP++] = ys[yP++];
            }
        }
        if (xP == xs.length) {
            for (int i = yP; i < ys.length; i++) {
                result[rP++] = ys[i];
            }
        }
        if (yP == ys.length) {
            for (int i = xP; i < xs.length; i++) {
                result[rP++] = xs[i];
            }
        }
        return result;
    }
}
