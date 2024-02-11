namespace Calculator.Lexer
{
    public interface ITokenDefinition
    {
        public bool IsMatch(string text);
        public Token CreateToken(Character start, string text);
    }
}
