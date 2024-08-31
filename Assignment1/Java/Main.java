import java.util.Map;

public class Main {
    public static void main(String[] args) {
        Expr e = new Add(new CstI(17), new Var("z"));
        System.out.println(e.toString());
        Expr e2 = new Mul(new CstI(2), new Sub(new Var("v"), new Add(new Var("w"), new Var("z"))));
        System.out.println(e2.toString());
        Expr e3 = new Sub(new CstI(12), new Var("x"));
        System.out.println(e3.toString());
        Expr e4 = new Sub(new Var("V"), new Add(new Var("w"), new Var("z")));
        System.out.println(e4.toString());
    }
}

abstract class Expr {
    abstract public int eval(Map<String, Integer> env);

    public abstract Expr simplify();
}

class CstI extends Expr {
    protected final int i;

    public CstI(int i) {
        this.i = i;
    }

    public int eval(Map<String, Integer> env) {
        return i;
    }

    public Expr simplify() {
        return this;
    }

    @Override
    public String toString() {
        return "CstI " + i;

    }
}

class Var extends Expr {
    protected final String name;

    public Var(String name) {
        this.name = name;
    }

    public int eval(Map<String, Integer> env) {
        return env.get(name);
    }

    public Expr simplify() {
        return this;
    }

    @Override
    public String toString() {
        return "Var " + "\"" + name + "\"";

    }
}

abstract class Binop extends Expr {
    protected final Expr e1;
    protected final Expr e2;

    public Binop(Expr e1, Expr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }

    @Override
    public abstract Expr simplify();
}

class Add extends Binop {
    public Add(Expr e1, Expr e2) {
        super(e1, e2);
    }

    public int eval(Map<String, Integer> env) {
        return e1.eval(env) + e2.eval(env);
    }

    @Override
    public String toString() {
        return "Add (" + e1 + ", " + e2 + ")";

    }

    @Override
    public Expr simplify() {
        throw new UnsupportedOperationException("Unimplemented method 'simplify'");
    }
}

class Sub extends Binop {
    public Sub(Expr e1, Expr e2) {
        super(e1, e2);
    }

    public int eval(Map<String, Integer> env) {
        return e1.eval(env) - e2.eval(env);
    }

    @Override
    public String toString() {
        return "Sub (" + e1 + ", " + e2 + ")";

    }

    @Override
    public Expr simplify() {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'simplify'");
    }
}

class Mul extends Binop {
    public Mul(Expr e1, Expr e2) {
        super(e1, e2);
    }

    public int eval(Map<String, Integer> env) {
        return e1.eval(env) * e2.eval(env);
    }

    @Override
    public String toString() {
        return "Mul (" + e1 + "* " + e2 + ")";

    }

    @Override
    public Expr simplify() {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'simplify'");
    }

}