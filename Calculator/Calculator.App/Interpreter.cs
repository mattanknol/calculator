using Calculator.Lexer;
using Calculator.Parser;

namespace Calculator.App
{
    public abstract class Interpreter
    {
        protected readonly ITokenizer _tokenizer;
        protected readonly IParser _parser;

        protected Interpreter()
        {
            _tokenizer = CreateTokenizer();
            _parser = CreateParser();
        }

        protected virtual IScanner CreateScanner(string text) => new DefaultScanner(text);
        protected abstract ITokenizer CreateTokenizer();
        protected abstract IParser CreateParser();

        public decimal Interpret(string text)
        {
            var scanner = CreateScanner(text);
            var tokens = _tokenizer.Tokenize(scanner);
            var expression = _parser.Parse(tokens);
            var context = new ExpressionContext();
            return expression.Evaluate(context);
        }
    }
}
