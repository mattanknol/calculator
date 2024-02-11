namespace Calculator.Lexer.Tests.Definitions
{
    public class AsteriskTokenDefinitionTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("*", true)]
        public void IsMatch(string input, bool expected)
        {
            var definition = new AsteriskTokenDefinition();

            var result = definition.IsMatch(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateToken()
        {
            var definition = new AsteriskTokenDefinition();

            var result = definition.CreateToken(Character.Empty, "*");

            Assert.NotNull(result);
            Assert.Equal(TokenType.Operator, result.TokenType);
            Assert.Equal("*", result.Value);
        }
    }
}
