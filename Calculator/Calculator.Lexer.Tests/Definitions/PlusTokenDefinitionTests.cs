namespace Calculator.Lexer.Tests.TokenDefinitions
{
    public class PlusTokenDefinitionTests
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("+", true)]
        public void IsMatch(string input, bool expected)
        {
            var definition = new PlusTokenDefinition();

            var result = definition.IsMatch(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateToken()
        {
            var definition = new PlusTokenDefinition();

            var result = definition.CreateToken(Character.Empty, "+");

            Assert.NotNull(result);
            Assert.Equal(TokenType.Operator, result.TokenType);
            Assert.Equal("+", result.Value);
        }
    }
}
