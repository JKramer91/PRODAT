// IL code: Selsort

	.method public hidebysig static 
		void SelectionSort (
			int32[] arr
		) cil managed 
	{
		// Method begins at RVA 0x20b8
		// Header size: 12
		// Code size: 57 (0x39)
		.maxstack 4
		.locals init (
		[0] int32,   // local variable 0 (i)
        [1] int32,   // local variable 1 (least)
        [2] int32,   // local variable 2 (tmp)
        [3] int32    // local variable 3 (j)
		)

		IL_0000: ldc.i4.0 // load 0 on stack as a 4-byte integer. 
		IL_0001: stloc.0 // Store 0 on index 0. (i= 0)
		IL_0002: br.s IL_0032 // Unconditional jump to start of for-loop
		// loop start (head: IL_0032)
			IL_0004: ldloc.0 // Load first local var (i) which is at index 0 on top of the stack. 
			IL_0005: stloc.1 //  Pops top value from the stack into local variable. (int least = i;)
			IL_0006: ldloc.0 // Load i onto the stack
			IL_0007: ldc.i4.1  // Load constant 1 on the stack 
			IL_0008: add // add i and 1 to increment i (j= i+1) -> 
			IL_0009: stloc.3 // Store the result of i + 1 in local variable 3 (j = i + 1) 
			IL_000a: br.s IL_001a // Unconditional to inner loop 
			// loop start (head: IL_001a)
				IL_000c: ldarg.0 // Load the array 'arr' onto the stack
				IL_000d: ldloc.3 // Load the value of j (from local 3) onto the stack
				IL_000e: ldelem.i4 // Load the element at index j from 'arr' onto the stack
				IL_000f: ldarg.0 // Load the array "arr" onto the stack. 
				IL_0010: ldloc.1 // Load value from least (from local 1) onto the stack.
				IL_0011: ldelem.i4 // arr[least]. Load the element at index 'least' from 'arr' onto the stack
				IL_0012: bge.s IL_0016  // if arr[least] >= arr[j] (Flip around the comparison)

				IL_0014: ldloc.3 // Load j onto top of stack
				IL_0015: stloc.1  // Store j in least 

				IL_0016: ldloc.3 //Load j onto top of stack (local var 3)
				IL_0017: ldc.i4.1 // Load constant 1 on top of stack
				IL_0018: add // Add j and 1 (j++)
				IL_0019: stloc.3 // Store the updated value of j back into local 3

				IL_001a: ldloc.3 // Load j on top of stack 
				IL_001b: ldarg.0 // Load 'arr' onto the stack 
				IL_001c: ldlen // Load the length of the array 
				IL_001d: conv.i4  // Convert array length (long to int32)
				IL_001e: blt.s IL_000c //  if j < arr.Length (continue to loop start in inner loop)
			// end loop

			IL_0020: ldarg.0 // Load 'arr' onto the stack 
			IL_0021: ldloc.0 // Load i onto the stack
			IL_0022: ldelem.i4 // load element at index i from arr onto the stack (arr[i])
			IL_0023: stloc.2 // Store the value at arr[i] in local variable 2 (tmp = arr[i])			
			IL_0024: ldarg.0 // load arr onto the stack 
			IL_0025: ldloc.0 // Load i (from local 0)
			IL_0026: ldarg.0 // Load arr onto top of stack
			IL_0027: ldloc.1 // Load least onto top of stack
			IL_0028: ldelem.i4 // arr[least]
			IL_0029: stelem.i4 // Store value of arr[least] into arr[i]. (arr[i] = arr[least])
			IL_002a: ldarg.0 // Load arr onto top of stack
			IL_002b: ldloc.1 // Load least onto top of stack
			IL_002c: ldloc.2 // Load the value of tmp
			IL_002d: stelem.i4 // Load tmp into arr[least]
			IL_002e: ldloc.0 // Load i onto top of stack
			IL_002f: ldc.i4.1 // Load constant 1 onto top of stack
			IL_0030: add // increment i by 1 (i++;)
			IL_0031: stloc.0 Store the updated value of i back into local 0 (i++)

			IL_0032: ldloc.0  //Load i (from local 0)
			IL_0033: ldarg.0 //Load the array 'arr' onto the stack
			IL_0034: ldlen //Load the length of the array onto the stack
			IL_0035: conv.i4 //Convert the array length (long) to int32
			IL_0036: blt.s IL_0004 // Branch back to IL_0004 (Outer loop) if i < arr.Length.
		// end loop

		IL_0038: ret (Return when done with all loops)
	} // end of method Selsort::SelectionSort 

	