using Calculator.Lexer;
using Calculator.Parser;

namespace Calculator.App
{
    public class InfixInterpreter : Interpreter
    {
        protected override ITokenizer CreateTokenizer()
        {
            var tokenizer = new DefaultTokenizer();
            tokenizer.AddInfixDefinitions();
            return tokenizer;
        }

        protected override IParser CreateParser()
        {
            var parser = new InfixParser();
            parser.AddExpressionDefinitions();
            return parser;
        }
    }
}
