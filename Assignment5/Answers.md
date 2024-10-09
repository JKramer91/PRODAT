# Assignment 5 answers

## 6.1)

### c 
Yes, the result is as expected. 

The code is 
```
let add x = let f y = x+y in f end
in let addtwo = add 2
    in let x = 77 in addtwo 5 end
    end
end
```

The result of running the code is ``` 7 ```. This is also what we expect, since we partially apply the function with ``` 2 ``` and binding it to the ```addTwo``` variable. Then we define ``` in let x = 77 ```, but this is thrown away, since we call ```addTwo ``` with ```5 ```, after it has been partially applied to ```2```. Thus, ```5 + 2``` evaluates to ```7```. 


### d
The code is 
```
let add x = let f y = x+y in f end
    in add 2 end
```
And the result is 

```
> ParseAndRunHigher.run ParseAndRunHigher.ex13;;
val it: HigherFun.value =
  Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])
```

By providing ```2``` to the add-function, we have only partially applied the function, since it contains the ```f```-function in its body, which expects an argument ```y```. What happened in the other examples was that we called add with 2 arguments, as to propagate the second argument to the inner function ```f```. Here, we get the closure of the function ```f``` as a result, where we see that ```Int 2``` is bound to ```x```, and the function closure ```f```, that still needs an ```y``` to be completely applied. 

# 6.5 part 1

## Exampl2 fails 
The error message from running the example was:
```
ParseAndType.inferType ParseAndType.exampl2;;
System.Exception: type error: circularity 
```

The circularity consists in the fact that g is applied to g within f, and we cannot know the type of g at this point. There is the restriction the types but be finite and non-circular. In this case, the example is ill-typed. 

## Exampl4 fails:
The error message we got was
```
 ParseAndType.inferType ParseAndType.exampl4;;
System.Exception: type error: bool and int
```

The issue arises because `f` is invoked with `42`, and the function then attempts to evaluate whether the argument is 'true'. Now, while `42` is famously the answer to life, the universe, and everything, it's still an `int`. Expecting to decide if this number is `true` is a bit optimistic. 