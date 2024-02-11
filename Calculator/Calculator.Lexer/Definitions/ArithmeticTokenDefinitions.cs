namespace Calculator.Lexer.Definitions
{
    public class PlusTokenDefinition() : ArithmeticTokenDefinition("+") { /* Empty */ }
    public class MinusTokenDefinition() : ArithmeticTokenDefinition("-") { /* Empty */ }
    public class AsteriskTokenDefinition() : ArithmeticTokenDefinition("*") { /* Empty */ }
    public class SlashTokenDefinition() : ArithmeticTokenDefinition("/") { /* Empty */ }
    public class CircumflexTokenDefinition() : ArithmeticTokenDefinition("^") { /* Empty */ }

    public abstract class ArithmeticTokenDefinition(string op) : ITokenDefinition
    {
        public bool IsMatch(string text) => text == op;
        public Token CreateToken(Character start, string text) => new(TokenType.Operator, start, text);
    }
}
