# Calculator
Hobby exercise to create a calculator with a lexer/parser.

## EBNF
### Infix
Grammar for calculations with infix operators, with operator precedence and associativity.

```ebnf
start = ws , exp , ws , end ;
exp = { exp , ws , ( "+" | "-" ) } , ws , term ;
term = { term , ws , ( "*" | "/" ) } , ws , power ;
power = factor , ws , { "^" , ws , power } ;
(* TODO: Unary *)
(* TODO: Functions *)
factor = "(" , ws , exp , ws , ")" | signed number ;
signed number = [ "-" ] , number ; (* this is actually an unary operator with the highest precedence *)
number = integer , [ fraction ] , [ exponent ] ; (* this will be a token, hence separation from sign *)
exponent = ( "e" | "E" ) , [ "+" | "-" ] , digits ;
fraction = "." , digits ;
integer = "0" | nz-digit , { digit } ;
digits = digit , { digit } ;
digit = "0" | nz-digit ;
nz-digit = "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" ;
ws = { whitespace } ;
whitespace = " " | "\t" | "\r" | "\n" ;
end = ? end of stream character ? ; (* needed to prevent invalid syntax after valid syntax that might otherwise not be caught *)
```

Rewritten to be used in a recursive descent parser, only the relevant part is shown here (without whitespaces):

```ebnf
start = exp , end ;
exp = term , { ( "+" | "-" ) , term } ;
term = power , { ( "*" | "/" ) , power } ;
power = factor , { "^" , factor } ;
(* TODO: Unary *)
(* TODO: Functions *)
factor = "(" , exp , ")" | signed number ;
signed number = [ "-" ] , number ;
```

### Postfix
Grammar for calculations with postfix operators.

```ebnf
start = { whitespace } , exp , { whitespace } , end ;
exp = binary | unary | signed number ;
binary = exp , ws , exp , ws , binary op ;
binary op = "+" | "-" | "*" | "/" | "^" ;
unary = exp , ws , unary op ;
unary op = ;
(* TODO: Functions *)
signed number = [ "-" ] , integer , [ fraction ] , [ exponent ] ;
exponent = ( "e" | "E" ) , [ "+" | "-" ] , digits ;
fraction = "." , digits ;
integer = "0" | nz-digit , { digit } ;
digits = digit , { digit } ;
digit = "0" | nz-digit ;
nz-digit = "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" ;
ws = whitespace , { whitespace } ;
whitespace = " " | "\t" | "\r" | "\n" ;
end = ? end of stream character ? ; (* needed to prevent invalid syntax after valid syntax that might otherwise not be caught *)
```

## Tokens
- Number: 
	- **Infix:** unsigned numbers
	- **Postfix:** signed number
- Operator:
	- **All:** + - * / ^
- Whitespace
	- **All:** _space_ \t \r \n
- Delimiter:
	- **Infix:** ( )
- Keyword:
	- **All:** functions
- Identifier:
	- **All:** variables
- Where are constants (like pi) going: keyword, identifier or literal?

## References
- https://www.json.org/json-en.html (EBNF)
- https://parsingintro.sourceforge.net/
- https://www.geeksforgeeks.org/convert-infix-expression-to-postfix-expression/
- https://www.booleanworld.com/building-recursive-descent-parsers-definitive-guide/
- https://www.codeproject.com/Articles/24125/Parsing-Algebraic-Expressions-Using-the-Interprete
