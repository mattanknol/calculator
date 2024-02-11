namespace Calculator.Lexer.Tests
{
    public class DefaultTokenizerTests
    {
        [Fact]
        public void Tokenize_NotNull()
        {
            var scanner = new DefaultScanner("1");
            var tokenizer = CreateTokenizer();

            var result = tokenizer.Tokenize(scanner).ToList();

            Assert.NotEmpty(result);
            Assert.NotNull(result.First());
        }

        [Fact]
        public void Tokenize_Empty()
        {
            var scanner = new DefaultScanner("");
            var tokenizer = CreateTokenizer();

            var result = Record.Exception(() => tokenizer.Tokenize(scanner).ToList());

            Assert.IsType<LexicalException>(result);
            Assert.Equal("Ambigious token: ", result.Message);
        }

        [Fact]
        public void Tokenize_Number()
        {
            var scanner = new DefaultScanner("1");
            var tokenizer = CreateTokenizer();

            var result = tokenizer.Tokenize(scanner).Where(token => token.TokenType != TokenType.EndOfStream).ToList();

            Assert.Single(result);
            var token = result[0];
            Assert.Equal(TokenType.Number, token.TokenType);
            Assert.Equal("1", token.Value);
        }

        [Fact]
        public void Tokenize_Plus()
        {
            var scanner = new DefaultScanner("+");
            var tokenizer = CreateTokenizer();

            var result = tokenizer.Tokenize(scanner).Where(token => token.TokenType != TokenType.EndOfStream).ToList();

            Assert.Single(result);
            var token = result[0];
            Assert.Equal(TokenType.Operator, token.TokenType);
            Assert.Equal("+", token.Value);
        }

        [Theory]
        [InlineData("1+2")]
        [InlineData("1 + 2")]
        [InlineData("1    +2")]
        [InlineData("1   + 2")]
        [InlineData("1  +  2")]
        [InlineData("1 +   2")]
        [InlineData("1+    2")]
        public void Tokenize_MultipleTokens(string input)
        {
            var scanner = new DefaultScanner(input);
            var tokenizer = CreateTokenizer();

            var result = tokenizer.Tokenize(scanner).Where(token => token.TokenType != TokenType.Whitespace).ToList();

            Assert.Equal(4, result.Count);
            // Token 1
            var firstToken = result[0];
            Assert.Equal(TokenType.Number, firstToken.TokenType);
            Assert.Equal("1", firstToken.Value);
            // Token 2
            var secondToken = result[1];
            Assert.Equal(TokenType.Operator, secondToken.TokenType);
            Assert.Equal("+", secondToken.Value);
            // Token 3
            var thirdToken = result[2];
            Assert.Equal(TokenType.Number, thirdToken.TokenType);
            Assert.Equal("2", thirdToken.Value);
            // Last token
            var lastToken = result[3];
            Assert.Equal(TokenType.EndOfStream, lastToken.TokenType);
            Assert.Equal(Convert.ToString(Character.EndOfStream), lastToken.Value);
        }

        private static DefaultTokenizer CreateTokenizer()
        {
            var tokenizer = new DefaultTokenizer();
            tokenizer.AddInfixDefinitions();
            return tokenizer;
        }
    }
}
