namespace Calculator.Lexer.Definitions
{
    public class WhitespaceTokenDefinition : ITokenDefinition
    {
        private static readonly HashSet<char> _characters = [' ', '\t', '\r', '\n'];

        public bool IsMatch(string text) => !string.IsNullOrEmpty(text) && text.All(_characters.Contains);
        public Token CreateToken(Character start, string text) => new(TokenType.Whitespace, start, text);
    }
}
