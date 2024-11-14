## Exercise 7.1

### (i)

#### ADD 
Add the two top elements of the stack together, untagged of course. Then, tag the result of adding them together, assign to $SP - 1$ and decrement the stackpointer.

#### CSTI i
Fetch a value from the program array, which is the constant `i`, tag the value and increment the program counter. Then, assign it to $sp+1$, and lastly do $sp++ $ to increment the stackpointer. 

#### NIL
Assign 0 to the $SP + 1$, then increment the $SP$ by $1$. `NIL` does **not** influence the state of the program, where as `CSTI i` does influence or change the state of the program, i.e. the Program Counter.

#### IFZERO 

On the first line, we get `v`from $SP -1$. Then on the next line, hen evaluate whether `v` is $true$ or $false$. If it is a tagged value we untag it, otherwise we just evaluate directly (if not zero). Then all that are not zero, are true. If true, we assign `pc`to `pc`, otherwise (if false), set `pc` to `pc+1`. If there is a jump within pc, and we get true, it means that it will jump. If it is false, it means that we proceed to the next instruction $(pc+1)$ and skip over the jmp instruction.


#### CONS
Allocate a pointer to a word. This has size 2 (`CONSTAG(2,s,sp)`). Takes the CAR and CDR element from the stack, casts the values into words and inserts them into the word pointer. Puts the word on the $SP-1§, and then decrements stackpointer. 


#### CAR
We assign the `word*` word pointer to the current stackpointer. If this pointer is 0, then we return -1. If not zero, then we return first word of the block, i.e. `p[1]`.  


#### SETCAR
In the first line, word `v`is assigned to the $stackpointer-1$. On the second line, we assign a word pointer to the current stack pointer. Finally we assign `p[1]` to `v`. So we take the pointer, the value, and update what we have in the heap and leave nothing on the stack. We assume that stack before is $s,p,v$ and then stack after will be $s$.


### (ii)
#### Length

First thing: Bit shift 2 to the right.
```tttt tttt nnnn nnnn nnnn nnnn nnnn nngg``` -> 
```00tt tttt ttnn nnnn nnnn nnnn nnnn nn```
Afterwards, the result of this is bitwise ANDed with ```0x003FFFFF``` 

Thus, we do the following: 

$$
\text{00tt \, tttt \, ttnn \, nnnn \, nnnn \, nnnn  \, nnnn \, nnnn}\\
\& \\
\text{0000 \, 0000 \, 0011 \, 1111 \,1111 \, 1111 \, 1111 \, 1111}
$$

This is to isolate the 22 length bits, thus giving us the length value.

#### Color
We take our string
```tttt tttt nnnn nnnn nnnn nnnn nnnn nngg``` and we do the bitwise conjunction with  ```3```. 

Because it needs to be a 32-bit word, we pad the binary $3$ (which is $11_b$) with 0s and therefore get the sequence
```0000 0000 0000 0000 0000 0000 0000 0011 ```

Thus, we do the following: 

$$
\text{tttt \, tttt \, ttnn \, nnnn \, nnnn \, nnnn  \, nnnn \, nnnn}\\
\& \\
\text{0000 \, 0000 \, 0000 \, 0000 \,0000 \, 0000 \, 0000 \, 0011}
$$

This is to isolate the gg, which represents the color.

#### Paint 

```
#define Paint(hdr, color) (((hdr)&(˜3))|(color))

```
tttt tttt nnnn nnnn nnnn nnnn nnnn nngg

First, we do bitwise conjunction with NOT 3. Thus, if 3 is 

$$\text{0000 0000 0000 0000 0000 0000 0000 0011}$$

NOT 3 becomes

$$\text{1111 1111 1111 1111 1111 1111 1111 1100}$$

So we get: 
$$
\text{tttt \, tttt \, ttnn \, nnnn \, nnnn \, nnnn  \, nnnn \, nnnn}\\
\& \\
\text{1111 \, 1111 \, 1111 \, 1111 \,1111 \, 1111 \, 1111 \, 1100}
$$

And then we do bitwise disjunction with color. Since color only occupies the 2 least-significant bits, we know that all other 30 bits are padded with 0s, and thus doing disjunction with this value will only change the 2 least-significant bits.

So assume we have the color $10$: 

Then the final result is: 
$$
\text{tttt \, tttt \, ttnn \, nnnn \, nnnn \, nnnn  \, nnnn \, nnnn}\\
\& \\
\text{1111 \, 1111 \, 1111 \, 1111 \,1111 \, 1111 \, 1111 \, 1100}
|
\text{0000 \, 0000 \, 0000 \, 0000 \,0000 \, 0000 \, 0000 \, 0010}
$$


### (iii)
#### a - When is allocated called
Allocate is only called once in the abstract machine, which is in the CONS case.
#### b - Interaction between mutator and GC 
However, there is another indirect interaction between the mutator and the garbage collector: within the ```allocate()``` function, a garbage collection cycle is initiated if memory is insufficient.


### (iv) 
`collect` is used by the allocate function. It collects when there is no free space, as we mentioned above. 

