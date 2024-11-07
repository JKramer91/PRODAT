// IL code: CircularQueue
.class private auto ansi '<Module>'
{
} // end of class <Module>

.class private auto ansi beforefieldinit CircularQueue`1<T>
	extends [System.Runtime]System.Object
{
	.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = (
		01 00 01 00 00
	)
	.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableAttribute::.ctor(uint8) = (
		01 00 00 00 00
	)
	.param type T
		.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableAttribute::.ctor(uint8) = (
			01 00 02 00 00
		)
	// Fields
	.field private initonly !T[] items
	.field private int32 count
	.field private int32 deqAt

	// Methods
	.method public hidebysig specialname rtspecialname 
		instance void .ctor (
			int32 capacity
		) cil managed 
	{
		// Method begins at RVA 0x2050
		// Header size: 1
		// Code size: 35 (0x23)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: ldc.i4.0
		IL_0002: stfld int32 class CircularQueue`1<!T>::count
		IL_0007: ldarg.0
		IL_0008: ldc.i4.0
		IL_0009: stfld int32 class CircularQueue`1<!T>::deqAt
		IL_000e: ldarg.0
		IL_000f: call instance void [System.Runtime]System.Object::.ctor()
		IL_0014: nop
		IL_0015: nop
		IL_0016: ldarg.0
		IL_0017: ldarg.1
		IL_0018: newarr !T
		IL_001d: stfld !0[] class CircularQueue`1<!T>::items
		IL_0022: ret
	} // end of method CircularQueue`1::.ctor

	.method public hidebysig 
		instance !T Dequeue () cil managed 
	{
		// Method begins at RVA 0x2074
		// Header size: 12
		// Code size: 113 (0x71)
		.maxstack 3
		.locals init (
			[0] bool,
			[1] !T,
			[2] !T,
			[3] !T
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld int32 class CircularQueue`1<!T>::count
		IL_0007: ldc.i4.0
		IL_0008: cgt
		IL_000a: stloc.0
		IL_000b: ldloc.0
		IL_000c: brfalse.s IL_0064

		IL_000e: nop
		IL_000f: ldarg.0
		IL_0010: ldarg.0
		IL_0011: ldfld int32 class CircularQueue`1<!T>::count
		IL_0016: ldc.i4.1
		IL_0017: sub
		IL_0018: stfld int32 class CircularQueue`1<!T>::count
		IL_001d: ldarg.0
		IL_001e: ldfld !0[] class CircularQueue`1<!T>::items
		IL_0023: ldarg.0
		IL_0024: ldfld int32 class CircularQueue`1<!T>::deqAt
		IL_0029: ldelem !T
		IL_002e: stloc.1
		IL_002f: ldarg.0
		IL_0030: ldfld !0[] class CircularQueue`1<!T>::items
		IL_0035: ldarg.0
		IL_0036: ldfld int32 class CircularQueue`1<!T>::deqAt
		IL_003b: ldloca.s 2
		IL_003d: initobj !T
		IL_0043: ldloc.2
		IL_0044: stelem !T
		IL_0049: ldarg.0
		IL_004a: ldarg.0
		IL_004b: ldfld int32 class CircularQueue`1<!T>::deqAt
		IL_0050: ldc.i4.1
		IL_0051: add
		IL_0052: ldarg.0
		IL_0053: ldfld !0[] class CircularQueue`1<!T>::items
		IL_0058: ldlen
		IL_0059: conv.i4
		IL_005a: rem
		IL_005b: stfld int32 class CircularQueue`1<!T>::deqAt
		IL_0060: ldloc.1
		IL_0061: stloc.3
		IL_0062: br.s IL_006f

		IL_0064: ldstr "Queue empty"
		IL_0069: newobj instance void [System.Runtime]System.ApplicationException::.ctor(string)
		IL_006e: throw

		IL_006f: ldloc.3
		IL_0070: ret
	} // end of method CircularQueue`1::Dequeue

	.method public hidebysig 
		instance void Enqueue (
			!T x
		) cil managed 
	{
		// Method begins at RVA 0x20f4
		// Header size: 12
		// Code size: 85 (0x55)
		.maxstack 3
		.locals init (
			[0] bool
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld int32 class CircularQueue`1<!T>::count
		IL_0007: ldarg.0
		IL_0008: ldfld !0[] class CircularQueue`1<!T>::items
		IL_000d: ldlen
		IL_000e: conv.i4
		IL_000f: clt
		IL_0011: stloc.0
		IL_0012: ldloc.0
		IL_0013: brfalse.s IL_0049

		IL_0015: nop
		IL_0016: ldarg.0
		IL_0017: ldfld !0[] class CircularQueue`1<!T>::items
		IL_001c: ldarg.0
		IL_001d: ldfld int32 class CircularQueue`1<!T>::deqAt
		IL_0022: ldarg.0
		IL_0023: ldfld int32 class CircularQueue`1<!T>::count
		IL_0028: add
		IL_0029: ldarg.0
		IL_002a: ldfld !0[] class CircularQueue`1<!T>::items
		IL_002f: ldlen
		IL_0030: conv.i4
		IL_0031: rem
		IL_0032: ldarg.1
		IL_0033: stelem !T
		IL_0038: ldarg.0
		IL_0039: ldarg.0
		IL_003a: ldfld int32 class CircularQueue`1<!T>::count
		IL_003f: ldc.i4.1
		IL_0040: add
		IL_0041: stfld int32 class CircularQueue`1<!T>::count
		IL_0046: nop
		IL_0047: br.s IL_0054

		IL_0049: ldstr "Queue full"
		IL_004e: newobj instance void [System.Runtime]System.ApplicationException::.ctor(string)
		IL_0053: throw

		IL_0054: ret
	} // end of method CircularQueue`1::Enqueue

} // end of class CircularQueue`1

.class private auto ansi beforefieldinit TestCircularQueue
	extends [System.Runtime]System.Object
{
	// Methods
	.method public hidebysig static 
		void Main (
			string[] args
		) cil managed 
	{
		.custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = (
			01 00 01 00 00
		)
		// Method begins at RVA 0x2158
		// Header size: 12
		// Code size: 93 (0x5d)
		.maxstack 2
		.entrypoint
		.locals init (
			[0] class CircularQueue`1<float64>
		)

		IL_0000: nop
		IL_0001: ldc.i4.2
		IL_0002: newobj instance void class CircularQueue`1<float64>::.ctor(int32)
		IL_0007: stloc.0
		IL_0008: ldloc.0
		IL_0009: ldc.r8 1.2
		IL_0012: callvirt instance void class CircularQueue`1<float64>::Enqueue(!0)
		IL_0017: nop
		IL_0018: ldloc.0
		IL_0019: ldc.r8 3.4
		IL_0022: callvirt instance void class CircularQueue`1<float64>::Enqueue(!0)
		IL_0027: nop
		IL_0028: ldloc.0
		IL_0029: callvirt instance !0 class CircularQueue`1<float64>::Dequeue()
		IL_002e: call void [System.Console]System.Console::WriteLine(float64)
		IL_0033: nop
		IL_0034: ldloc.0
		IL_0035: ldc.r8 5.6
		IL_003e: callvirt instance void class CircularQueue`1<float64>::Enqueue(!0)
		IL_0043: nop
		IL_0044: ldloc.0
		IL_0045: callvirt instance !0 class CircularQueue`1<float64>::Dequeue()
		IL_004a: call void [System.Console]System.Console::WriteLine(float64)
		IL_004f: nop
		IL_0050: ldloc.0
		IL_0051: callvirt instance !0 class CircularQueue`1<float64>::Dequeue()
		IL_0056: call void [System.Console]System.Console::WriteLine(float64)
		IL_005b: nop
		IL_005c: ret
	} // end of method TestCircularQueue::Main

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x21c1
		// Header size: 1
		// Code size: 8 (0x8)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
		IL_0006: nop
		IL_0007: ret
	} // end of method TestCircularQueue::.ctor

} // end of class TestCircularQueue

