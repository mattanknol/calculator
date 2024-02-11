using Calculator.Lexer;

namespace Calculator.Parser
{
    public interface IParser
    {
        public Expression Parse(IEnumerable<Token> tokens);
        public void AddDefinition<T>()
            where T : ExpressionDefinition, new();
    }
}
