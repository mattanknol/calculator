using Calculator.Lexer;

namespace Calculator.Parser
{
    public class PostfixParser : IParser
    {
        private readonly List<ExpressionDefinition> _definitions = [];

        public PostfixParser() { /* Empty */ }

        internal PostfixParser(List<ExpressionDefinition> definitions)
            : this()
        {
            _definitions = definitions;
        }

        public void AddDefinition<T>()
            where T : ExpressionDefinition, new()
        {
            var definition = new T();
            _definitions.Add(definition);
        }

        public Expression Parse(IEnumerable<Token> tokens)
        {
            return ParseInternal(tokens.Where(t => t.TokenType != TokenType.Whitespace));
        }

        internal Expression ParseInternal(IEnumerable<Token> tokens)
        {
            Stack<Expression> stack = [];
            foreach (var token in tokens)
            {
                if (token.TokenType == TokenType.EndOfStream)
                {
                    break;
                }
                var definition = GetExpressionDefinition(token);
                if (definition.OperandCount == 0)
                {
                    stack.Push(definition.CreateExpression(token, []));
                }
                else
                {
                    var operands = new Expression[definition.OperandCount];
                    for (int i = definition.OperandCount - 1; i >= 0; i--)
                    {
                        operands[i] = stack.Pop();
                    }
                    stack.Push(definition.CreateExpression(token, operands));
                }
            }
            if (stack.Count != 1)
            {
                throw new ParseException("Expression tree could not be created!");
            }
            return stack.Peek();
        }

        private ExpressionDefinition GetExpressionDefinition(Token token)
        {
            var definition = _definitions.FirstOrDefault(definition => definition.IsMatch(token));
            return definition ?? throw new ParseException($"Unknown token: '{token}'");
        }
    }
}
