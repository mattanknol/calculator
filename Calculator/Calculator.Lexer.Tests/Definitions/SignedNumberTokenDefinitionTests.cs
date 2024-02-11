namespace Calculator.Lexer.Tests.TokenDefinitions
{
    public class SignedNumberTokenDefinitionTests
    {
        [Theory]
        [InlineData("1", true)]
        [InlineData("1.23", true)]
        [InlineData("-1.23e04", true)]
        [InlineData("1.23e+4", true)]
        [InlineData("1.23e-4", true)]
        [InlineData("-1234", true)]
        [InlineData("1234.56", true)]
        [InlineData("1234.56e07", true)]
        [InlineData("-1234.56e+7", true)]
        [InlineData("1234.56e-7", true)]
        [InlineData("01", false)]
        [InlineData("1,234", false)]
        [InlineData("1,234.56", false)]
        [InlineData("1,234,567.89", false)]
        public void IsMatch(string input, bool expected)
        {
            var definition = new SignedNumberTokenDefinition();

            var result = definition.IsMatch(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateToken()
        {
            var definition = new SignedNumberTokenDefinition();

            var result = definition.CreateToken(Character.Empty, "-1");

            Assert.NotNull(result);
            Assert.Equal(TokenType.Number, result.TokenType);
            Assert.Equal("-1", result.Value);
        }
    }
}
