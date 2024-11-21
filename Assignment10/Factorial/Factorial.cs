// The factorial function in continuation-passing style, in C#.
// sestoft@itu.dk * 2009-10-24
// nh@itu.dk * 2023-11-12

// A Cont object is a continuation: it has a method k that given the
// result of a subcomputation will return the final result:

using System;

// Initial call to facc, factorial in continuation-passing style, with
// the identity continuation as argument:

class Factorial {
  public static void Main(String[] args) {
    int n = Int32.Parse(args[0]);
    Console.WriteLine(facc(n, v => v));
  }

  // A continuation-passing version of factorial.  This is a straight
  // translation of the functional (F#) version:
  static int facc(int n, Func<int,int> k) {
    if (n == 0) 
      return k(1);
    else
	return facc(n-1, v => k(n*v));
  }
}

