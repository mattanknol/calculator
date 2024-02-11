namespace Calculator.Parser.Tests
{
    internal static class Tokens
    {
        public static Token EndOfStream => new(TokenType.EndOfStream, Character.Empty);
        public static Token Whitespace => new(TokenType.Whitespace, Character.Empty, " ");
        public static Token NumberToken(string value) => new(TokenType.Number, Character.Empty, value);
        public static Token PlusToken => new(TokenType.Operator, Character.Empty, "+");
        public static Token MinusToken => new(TokenType.Operator, Character.Empty, "-");
        public static Token AsteriskToken => new(TokenType.Operator, Character.Empty, "*");
        public static Token SlashToken => new(TokenType.Operator, Character.Empty, "/");
        public static Token CircumflexToken => new(TokenType.Operator, Character.Empty, "^");
        public static Token LeftParenthesis => new(TokenType.Delimiter, Character.Empty, "(");
        public static Token RightParenthesis => new(TokenType.Delimiter, Character.Empty, ")");
    }
}
