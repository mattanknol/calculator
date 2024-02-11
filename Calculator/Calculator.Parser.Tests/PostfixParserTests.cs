namespace Calculator.Parser.Tests
{
    public class PostfixParserTests
    {
        [Fact]
        public void Parse_WhenEmpty_ParseException()
        {
            var tokens = new List<Token> { Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = Record.Exception(() => parser.Parse(tokens));

            Assert.IsType<ParseException>(result);
        }

        [Fact]
        public void Parse_WhenNonEmpty_NotNull()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.NotNull(result);
        }

        [Fact]
        public void Parse_WhenWhitespace_IgnoreWhitespace()
        {
            var tokens = new List<Token> { Tokens.Whitespace, Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenNumberToken_ValueExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenNegativeNumberToken_ValueExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("-2"), Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenPlusToken_AddExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.NumberToken("2"), Tokens.PlusToken, Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<AddExpression>(result);
        }

        [Fact]
        public void Parse_WhenMinusToken_SubtractExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("3"), Tokens.NumberToken("2"), Tokens.MinusToken, Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<SubtractExpression>(result);
        }

        [Fact]
        public void Parse_WhenAsteriskToken_MultiplyExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("3"), Tokens.NumberToken("2"), Tokens.AsteriskToken, Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<MultiplyExpression>(result);
        }

        [Fact]
        public void Parse_WhenSlashToken_DivideExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("6"), Tokens.NumberToken("2"), Tokens.SlashToken, Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<DivideExpression>(result);
        }

        [Fact]
        public void Parse_WhenCircumflexToken_ExponentiationExpression()
        {
            var tokens = new List<Token> { Tokens.NumberToken("2"), Tokens.NumberToken("3"), Tokens.CircumflexToken, Tokens.EndOfStream };
            var parser = CreatePostfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ExponentiationExpression>(result);
        }

        private static PostfixParser CreatePostfixParser()
        {
            var parser = new PostfixParser();
            parser.AddExpressionDefinitions();
            return parser;
        }
    }
}
