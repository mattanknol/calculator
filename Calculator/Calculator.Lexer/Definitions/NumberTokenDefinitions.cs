using System.Text.RegularExpressions;

namespace Calculator.Lexer.Definitions
{
    public partial class NumberTokenDefinition : ITokenDefinition
    {
        [GeneratedRegex(@"^(0|[1-9]\d*(\.\d+)?([eE][\-+]?\d+)?)$")]
        private static partial Regex NumberRegex();

        public bool IsMatch(string text) => NumberRegex().IsMatch(text);
        public Token CreateToken(Character start, string text) => new(TokenType.Number, start, text);
    }

    public partial class SignedNumberTokenDefinition : ITokenDefinition
    {
        [GeneratedRegex(@"^(0|\-?[1-9]\d*(\.\d+)?([eE][\-+]?\d+)?)$")]
        private static partial Regex NumberRegex();

        public bool IsMatch(string text) => NumberRegex().IsMatch(text);
        public Token CreateToken(Character start, string text) => new(TokenType.Number, start, text);
    }
}
