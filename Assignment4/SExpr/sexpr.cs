/* Grammer
sexp ::= symbol
      | number
      | ( sexp* )
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

interface IToken {
    String pp();
} 

class Lpar : IToken {
    public static Lpar LPAR=new Lpar();

    public String pp() {
	return "(";
    }
}

class Rpar : IToken {
    public static Rpar RPAR=new Rpar();

    public String pp() {
	return ")";
    }
}

class Symbol : IToken { 
    public readonly String name;

    public Symbol(String s) {
	this.name = s;
    }

    public String pp() {
	return this.name;
    }
}

class NumberCst : IToken { 
    public readonly int val;

    public NumberCst(int cst) {
	this.val = cst;
    }

    public String pp() {
	return this.val.ToString();
    }
}

class SExpr {

    public static int ScanNumber(Char ch, TextReader rd) {
	String res = ch.ToString();
	for (;;) {
	    int raw=rd.Peek(); // Only peek.
	    if (raw == -1) break; 
	    ch = (char)raw;
	    if (Char.IsDigit(ch)) {
		res += ch.ToString();
		rd.Read(); // Consume char from reader
	    }
	    else break; // Return number after loop.
	}
	return Int32.Parse(res);
    }

    public static Symbol ScanSymbol(Char ch, TextReader rd) {
	String res = ch.ToString();
	for (;;) {
	    int raw=rd.Peek();
	    if (raw == -1) break;
	    ch = (char)raw;	    
	    if (Char.IsWhiteSpace(ch) || ch == '(' || ch == ')')  // LPar and RPar are not valid symbols.
		break; // Return number after loop.	    
	    res += ch.ToString();
	    rd.Read(); // Consume char
	}
	return new Symbol(res);
    }
    
    public static IEnumerator<IToken> Tokenize(TextReader rd) {
	for (;;) { 
	    int raw = rd.Read();
	    char ch = (char)raw;
	    if (raw == -1)
		yield break;
	    else if (Char.IsWhiteSpace(ch))
	    { }
	    else if (Char.IsDigit(ch))
		yield return new NumberCst(ScanNumber(ch, rd));
	    else switch (ch) {
		    case '(':
			yield return Lpar.LPAR; break;
		    case ')': 
			yield return Rpar.RPAR; break;
		    case '-':
			    yield return ScanSymbol(ch,rd); break;// negative number, or symbol
		    default:
			yield return ScanSymbol(ch, rd);
			break;
		}
	}
    }

    public static void ParseSexp(IEnumerator<IToken> ts) {
	if (ts.Current is Symbol) {
	    Console.Write(ts.Current.pp());
	} else if (ts.Current is NumberCst) {
	    Console.Write(ts.Current.pp());
	} else if (ts.Current is Lpar) {
	    Console.Write(ts.Current.pp()); // Write (
	    Advance(ts);
	    while (!(ts.Current is Rpar)) {
		ParseSexp(ts);
		Advance(ts);
	    }
	    Console.Write(ts.Current.pp()); // Write )
	} else 
	    throw new ArgumentException("Parse error");
    }

    private static void Advance(IEnumerator<IToken> ts) {
	if (!ts.MoveNext())
	    throw new ArgumentException("Unexpected eof");
    }
    
    public static void Main(String[] args) {
	Console.WriteLine ("SExpr Top Down parser");
	String[] exs = { "42",
			 "x",
			 "(define x 42)",
			 "(+ x (* x 1))",
			 "()",
			 "(())",
			 "((()))",
			 "((f))",
			 "(define (fac n) (if (= n 0) 1 (* n (fac (- n 1)))))" };
	IEnumerable<IEnumerator<IToken>> tss = exs.Select(ex => Tokenize(new StringReader(ex)));
	foreach (var ts in tss) {
	    Advance(ts);
	    ParseSexp(ts);
	    Console.WriteLine();
	}
    }

}
