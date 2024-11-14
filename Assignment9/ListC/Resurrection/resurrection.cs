// http://www.c-sharpcorner.com/article/resurrection-and-the-net-garbage-collector/
using System;
public class B { 
  static public A IntA = new A(1);

}

public class A { 
  private int x;
  public void DoIt() { 
    Console.WriteLine( "DoIt, Value : {0}", x ); 
  }

  public A(int x) {
    this.x = x;
  }

  ~A() {
    if (this.x == 1000) {
      Console.WriteLine( "Enter destructor with value : {0}", x );       
      B.IntA = this;
      B.IntA.DoIt();
      Console.WriteLine( "Exit destructor with value : {0}", x );             
    }
  }
}

public class Test { 
  static void Main() {
    B.IntA.DoIt();

    // Generate garbage
    for (int i = 1000; i < 10000; i++) {
      A dummy = new A(i);
    }
    
    GC.Collect();
    GC.WaitForPendingFinalizers();
    B.IntA.DoIt(); 
  }
}

