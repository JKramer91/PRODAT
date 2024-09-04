import java.util.Map;

public class Main {
    public static void main(String[] args) {
        Expr e = new Add(new CstI(17), new Var("z"));
        System.out.println(e.toString());
        Expr e2 = new Mul(new CstI(2), new Sub(new Var("v"), new Add(new Var("w"), new Var("z"))));
        System.out.println(e2.toString());
        Expr e3 = new Sub(new CstI(12), new Var("x"));
        System.out.println(e3.toString());
        Expr e4 = new Sub(new Var("V"), new Add(new Var("w"), new Var("z"))).simplify();
        System.out.println(e4.toString());
        Expr e13 = new Add(new Var("x"), new CstI(0));
        System.out.println("Expect simplified to X: " + e13.simplify().toString());
        Expr e14 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
        System.out.println("Expect simplified to X: " + e14.simplify().toString());
    }
}

abstract class Expr {
    abstract public int eval(Map<String, Integer> env);

    abstract public Expr simplify();
}

class CstI extends Expr {
    protected final int i;

    public CstI(int i) {
        this.i = i;
    }

    public int eval(Map<String, Integer> env) {
        return i;
    }

    @Override
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

    @Override
    public Expr simplify() {
        return this;
    }

    @Override
    public String toString() {
        return "Var \"" + name + "\"";
    }
}

abstract class Binop extends Expr {
    protected final Expr e1;
    protected final Expr e2;

    public Binop(Expr e1, Expr e2) {
        this.e1 = e1;
        this.e2 = e2;
    }
}

class Add extends Binop {
    public Add(Expr e1, Expr e2) {
        super(e1, e2);
    }

    public int eval(Map<String, Integer> env) {
        return e1.eval(env) + e2.eval(env);
    }

    @Override
    public Expr simplify() {
        Expr se1 = e1.simplify();
        Expr se2 = e2.simplify();

        if (se1 instanceof CstI && ((CstI) se1).i == 0)
            return se2;
        if (se2 instanceof CstI && ((CstI) se2).i == 0)
            return se1;

        return new Add(se1, se2);
    }

    @Override
    public String toString() {
        return "Add (" + e1 + ", " + e2 + ")";
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
    public Expr simplify() {
        Expr se1 = e1.simplify();
        Expr se2 = e2.simplify();

        if (se2 instanceof CstI && ((CstI) se2).i == 0)
            return se1;
        if (se1.equals(se2))
            return new CstI(0);

        return new Sub(se1, se2);
    }

    @Override
    public String toString() {
        return "Sub (" + e1 + ", " + e2 + ")";
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
    public Expr simplify() {
        Expr se1 = e1.simplify();
        Expr se2 = e2.simplify();
        if (se1 instanceof CstI) {
            int value1 = ((CstI) se1).i;
            if (value1 == 0 || (se2 instanceof CstI && ((CstI) se2).i == 0))
                return new CstI(0);
            if (value1 == 1)
                return se2;
        }
        if (se2 instanceof CstI) {
            int value2 = ((CstI) se2).i;
            if (value2 == 0 || (se1 instanceof CstI && ((CstI) se1).i == 0))
                return new CstI(0);
            if (value2 == 1)
                return se1;
        }
        return new Mul(se1, se2);
    }

    @Override
    public String toString() {
        return "Mul (" + e1 + "* " + e2 + ")";
    }
}
