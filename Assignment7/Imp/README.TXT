Compiling and loading the naive imperative evaluator (Imp/README.TXT)
---------------------------------------------------------------------

A. Loading and running the naive imperative language

   dotnet fsi Naive.fs

   open Naive;;
   run ex1;;
   run ex2;;

B. Use e.g., gcc to compile:

   gcc array.c

   and then execute the result program a.out in a terminal.

   ./a.out
   11 22
   22 22
   11 22

C. To run Parameters example

   dotnet build Parameters.csproj
   dotnet run 11 22
