using Calculator.Lexer;

namespace Calculator.Parser
{
    public class InfixParser : IParser
    {
        private readonly List<ExpressionDefinition> _definitions = [];

        public void AddDefinition<T>()
            where T : ExpressionDefinition, new()
        {
            var definition = new T();
            _definitions.Add(definition);
        }

        public Expression Parse(IEnumerable<Token> tokens)
        {
            var parser = new RecursiveDescentParser(tokens.Where(t => t.TokenType != TokenType.Whitespace));
            var extendedTokens = parser.Parse();
            var postfix = InfixToPostfixConverter.Convert(extendedTokens);
            var postfixParser = new PostfixParser(_definitions);
            return postfixParser.ParseInternal(postfix);
        }

        private static int GetOperatorPrecedence(Token token)
        {
            return token.Value switch
            {
                "+" => 1,
                "-" => 1,
                "*" => 2,
                "/" => 2,
                "^" => 3,
                _ => throw new ParseException($"Unknown operator '{token.Value}'")
            };
        }

        private static Associativity GetOperatorAssociativity(Token token)
        {
            return token.Value == "^" ? Associativity.Right : Associativity.Left;
        }

        private class RecursiveDescentParser(IEnumerable<Token> tokens)
        {
            private readonly List<ExtendedToken> _result = [];
            private readonly IEnumerator<Token> _enumerator = tokens.GetEnumerator();

            public List<ExtendedToken> Parse()
            {
                if (_result.Count > 0)
                {
                    return _result;
                }
                if (!_enumerator.MoveNext())
                {
                    throw new ArgumentException("Tokens should not be empty", nameof(tokens));
                }
                Start();
                return _result;
            }

            private void Error(string message)
            {
                throw new ParseException(message);
            }

            private void Error(TokenType expectedType, string? expectedValue = null)
            {
                var tmp = new Token(expectedType, Character.Empty, expectedValue);
                Error($"Unexpected Token: '{_enumerator.Current}', expected: '{tmp}'");
            }

            private bool Check(TokenType tokenType, string? value = null)
            {
                if (_enumerator.Current.TokenType != tokenType)
                {
                    return false;
                }
                return value is null || _enumerator.Current.Value == value;
            }

            private void Return(Token? token = null)
            {
                token ??= _enumerator.Current;
                var precedence = (token.TokenType == TokenType.Operator) ? GetOperatorPrecedence(token) : 0;
                var associativity = (token.TokenType == TokenType.Operator) ? GetOperatorAssociativity(token) : Associativity.None;
                _result.Add(new(token, precedence, associativity));
            }

            private void Next()
            {
                var current = _enumerator.Current;
                if (!_enumerator.MoveNext() && current.TokenType != TokenType.EndOfStream)
                {
                    Error("End of stream without EndOfStream token");
                }
            }

            private void Match(TokenType tokenType, string? value = null)
            {
                if (!Check(tokenType, value))
                {
                    Error(tokenType, value);
                }
                Return();
                Next();
            }

            private bool CheckAndMatch(TokenType tokenType, string? value = null)
            {
                if (!Check(tokenType, value))
                {
                    return false;
                }
                Return();
                Next();
                return true;
            }

            // Grammar
            private void Start()
            {
                Exp();
                if (!Check(TokenType.EndOfStream))
                {
                    Error(TokenType.EndOfStream);
                }
            }

            private void Exp()
            {
                Term();
                while (CheckAndMatch(TokenType.Operator, "+") || CheckAndMatch(TokenType.Operator, "-"))
                {
                    Term();
                }
            }

            private void Term()
            {
                Power();
                while (CheckAndMatch(TokenType.Operator, "*") || CheckAndMatch(TokenType.Operator, "/"))
                {
                    Power();
                }
            }

            private void Power()
            {
                Factor();
                while (CheckAndMatch(TokenType.Operator, "^"))
                {
                    Factor();
                }
            }

            private void Factor()
            {
                if (CheckAndMatch(TokenType.Delimiter, "("))
                {
                    Exp();
                    Match(TokenType.Delimiter, ")");
                }
                else
                {
                    SignedNumber();
                }
            }

            private void SignedNumber()
            {
                if (Check(TokenType.Operator, "-"))
                {
                    var start = _enumerator.Current.Start;
                    Next();
                    if (!Check(TokenType.Number))
                    {
                        Error(TokenType.Number);
                    }
                    Return(new(TokenType.Number, start, $"-{_enumerator.Current.Value}"));
                    Next();
                }
                else
                {
                    Match(TokenType.Number);
                }
            }
        }
    }
}
