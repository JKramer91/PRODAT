// IL code: Square
.class private auto ansi '<Module>'
{
} // end of class <Module>

.class private auto ansi beforefieldinit Square
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
		// Method begins at RVA 0x2050
		// Header size: 1
		// Code size: 20 (0x14)
		.maxstack 8
		.entrypoint

		IL_0000: ldc.r8 6.2
		IL_0009: call float64 Square::Sqr(float64)
		IL_000e: call void [System.Console]System.Console::WriteLine(float64)
		IL_0013: ret
	} // end of method Square::Main

	.method public hidebysig static 
		float64 Sqr (
			float64 x
		) cil managed 
	{
		// Method begins at RVA 0x2065
		// Header size: 1
		// Code size: 4 (0x4)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: ldarg.0
		IL_0002: mul
		IL_0003: ret
	} // end of method Square::Sqr

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x206a
		// Header size: 1
		// Code size: 7 (0x7)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
		IL_0006: ret
	} // end of method Square::.ctor

} // end of class Square

