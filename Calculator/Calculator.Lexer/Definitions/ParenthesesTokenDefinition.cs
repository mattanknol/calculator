namespace Calculator.Lexer.Definitions
{
    public class ParenthesesTokenDefinition : ITokenDefinition
    {
        public bool IsMatch(string text) => (text == "(" || text == ")");
        public Token CreateToken(Character start, string text) => new(TokenType.Delimiter, start, text);
    }
}
