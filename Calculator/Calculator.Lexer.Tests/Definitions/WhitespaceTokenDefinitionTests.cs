namespace Calculator.Lexer.Tests.Definitions
{
    public class WhitespaceTokenDefinitionTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData(" ", true)]
        [InlineData("  ", true)]
        [InlineData(" \t ", true)]
        [InlineData("\r\n", true)]
        public void IsMatch(string input, bool expected)
        {
            var definition = new WhitespaceTokenDefinition();

            var result = definition.IsMatch(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData(" \t ")]
        [InlineData("\r\n")]
        public void GenerateToken(string input)
        {
            var definition = new WhitespaceTokenDefinition();

            var result = definition.CreateToken(Character.Empty, input);

            Assert.NotNull(result);
            Assert.Equal(TokenType.Whitespace, result.TokenType);
            Assert.Equal(input, result.Value);
        }
    }
}
