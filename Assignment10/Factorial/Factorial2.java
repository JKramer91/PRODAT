// The factorial function in continuation-passing style, in Java.
// sestoft@itu.dk * 2009-10-24

// A Cont object is a continuation: it has a method k that given the
// result of a subcomputation will return the final result:
import java.util.function.Function;

// Initial call to facc, factorial in continuation-passing style, with
// the identity continuation as argument:

class Factorial2 {
  public static void main(String[] args) {
    int n = Integer.parseInt(args[0]);
    System.out.println(facc(n, v -> v));
  }

  // A continuation-passing version of factorial.  This is a straight
  // translation of the functional (F#) version:

  static int facc(final int n, final Function<Integer,Integer> k) {
    if (n == 0) 
      return k.apply(1);
    else
	return facc(n-1, v -> k.apply(n*v));
  }
}
