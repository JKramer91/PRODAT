# Question 1
The regular expression is ['0'-'9'] - Meaning that we can tokenize 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 . It can only be a single character from this set of characters. ```LexBuffer<char>.LexemeString``` converts the matched digit into a string, which e.g. can later be printed to the console. The characters are processed as a string, where anything else than a non-digit input will trigger an error. 

# Question 2 
(2.1)
A hello.fs and a hello.fsi file is generated during the process. 

(2.2)
There are three states: State 0, 1 and 2. 