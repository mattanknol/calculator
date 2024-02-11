using Calculator.Lexer;

namespace Calculator.Parser
{
    internal static class InfixToPostfixConverter
    {
        public static List<Token> Convert(IEnumerable<ExtendedToken> tokens)
        {
            var result = new List<Token>();
            var stack = new Stack<ExtendedToken>();
            foreach (var token in tokens)
            {
                if (token.TokenType == TokenType.Delimiter && token.Value == "(")
                {
                    stack.Push(token);
                }
                else if (token.TokenType == TokenType.Delimiter && token.Value == ")")
                {
                    while (stack.TryPop(out var tmp) && !(tmp.TokenType == TokenType.Delimiter && tmp.Value == "("))
                    {
                        result.Add(tmp);
                    }
                }
                else if (token.TokenType == TokenType.Operator)
                {
                    while (stack.TryPeek(out var tmp) &&
                        (tmp.Precedence > token.Precedence || (tmp.Precedence == token.Precedence && token.Associativity == Associativity.Left)))
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
                else
                {
                    result.Add(token);
                }
            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }
    }

    internal class ExtendedToken(Token token, int precedence, Associativity associativity)
        : Token(token.TokenType, token.Start, token.Value)
    {
        public int Precedence { get; } = precedence;
        public Associativity Associativity { get; } = associativity;
    }

    internal enum Associativity { None, Left, Right }
}
