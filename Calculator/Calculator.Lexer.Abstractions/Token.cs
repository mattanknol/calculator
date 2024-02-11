namespace Calculator.Lexer
{
    public class Token(TokenType tokenType, Character start, string? value = null)
    {
        public TokenType TokenType { get; } = tokenType;
        public Character Start { get; } = start;
        public string? Value { get; } = value;

        public override string? ToString()
        {
            return string.IsNullOrEmpty(Value) || Value[0] == Character.EndOfStream ? $"{TokenType}" : $"{TokenType} : {Value}";
        }
    }
}
