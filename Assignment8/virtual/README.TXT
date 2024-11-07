Illustrating the Java Virtual Machine and the .NET Common Language Runtime
--------------------------------------------------------------------------

The folder virtual contains the files mentioned below:


A. Folder Selsort, contains an implementation of selection sort in
   Java as well as C#.

   This will compile the C# version. In folder Selsort

     dotnet build

   and leaves a Selsort.dll in folder

     bin/Debug/net8.0/Selsort.dll

   You can run the program with

     dotnet run 

   To disassemble Selsort.dll, you need the dotnet tool ilspycmd
   installed. To check if ilspycmd is already installed:

     % dotnet tool list -g
     Package Id      Version         Commands
     ----------------------------------------
     ilspycmd        8.2.0.7535      ilspycmd

   If not installed use

     dotnet tool install --global ilspycmd

   The tool ilspycmd goes in folder ~/.dotnet/tools and the path
   should be included in your PATH environment variable.

   You can disassemble its .NET Common Language Runtime bytecode into
   text file Selsort.il:

     ilspycmd -il -o Selsort.il bin/Debug/net8.0/Selsort.dll 

   This creates folder Selsort.il containing the disassembled file
   Selsort.il.

   This will compile the Java version and then disassemble its Java
   Virtual Machine bytecode into text file Selsort.jvmbytecode. In
   folder Selsort:

     javac Selsort.java
     javap -verbose -c Selsort > Selsort.jvmbytecode

B. The programs CircularQueue.java and CircularQueue.cs implement a
   generic class CircularQueue<T>.  Compiling and then disassembling
   them to bytecode shows that the type parameters such as T have been
   erased in the Java bytecode, whereas they are preserved in the .NET
   Common Language Runtime bytecode, although renamed to !T or similar.

   In folder CircularQueue:

     dotnet build
     dotnet run

     ilspycmd -il -o CircularQueue.il bin/Debug/net8.0/CircularQueue.dll

     javac CircularQueue.java 
     javap -verbose -c CircularQueue > CircularQueue.jvmbytecode

C. The programs StringConcatSpeed.java and StringConcatSpeed.cs
   demonstrate how repeated string concatenation using the (+)
   operator is very slow and stresses the garbage collector.

   This will compile and run the C# program

     dotnet build
     dotnet run

   This will compile and run the Java program

     javac StringConcatSpeed.java
     java StringConcatSpeed

D. The program Square is in folder Square and to compile, run and
   inspect IL code, see below

     dotnet build
     dotnet run

     ilspycmd -il -o Square.il bin/Debug/net8.0/Square.dll

   Then try build with release option and investigate IL code.

     dotnet build -c Release
     ilspycmd -il -o Square.il bin/Release/net8.0/Square.dll

E. For program ex13:

     dotnet build -c Release
     dotnet run 2025
     ilspycmd -il -o Ex13.il bin/Release/net8.0/ex13.dll

     javac ex13.java
     java ex13 2025
     javap -c ex13
    
