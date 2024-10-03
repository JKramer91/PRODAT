
module FunLex
open (*Microsoft.*) FSharp.Text.Lexing
open Util
open FunPar/// Rule Token
val Token: lexbuf: LexBuffer<char> -> token
/// Rule SkipComment
val SkipComment: lexbuf: LexBuffer<char> -> token
