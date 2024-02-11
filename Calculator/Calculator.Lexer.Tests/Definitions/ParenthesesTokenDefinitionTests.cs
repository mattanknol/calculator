namespace Calculator.Lexer.Tests.Definitions
{
    public class ParenthesesTokenDefinitionTests
    {
        [Theory]
        [InlineData("(", true)]
        [InlineData(")", true)]
        public void IsMatch(string input, bool expected)
        {
            var definition = new ParenthesesTokenDefinition();

            var result = definition.IsMatch(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("(", "(")]
        [InlineData(")", ")")]
        public void GenerateToken(string input, string expected)
        {
            var definition = new ParenthesesTokenDefinition();

            var result = definition.CreateToken(Character.Empty, input);

            Assert.NotNull(result);
            Assert.Equal(TokenType.Delimiter, result.TokenType);
            Assert.Equal(expected, result.Value);
        }
    }
}
