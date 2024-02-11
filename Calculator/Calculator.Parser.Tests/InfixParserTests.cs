namespace Calculator.Parser.Tests
{
    public class InfixParserTests
    {
        [Fact]
        public void Parse_WhenEmpty_ParseException()
        {
            var tokens = new List<Token> { Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = Record.Exception(() => parser.Parse(tokens));

            Assert.IsType<ParseException>(result);
        }

        [Fact]
        public void Parse_WhenNonEmpty_NotNull()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.NotNull(result);
        }

        [Fact]
        public void Parse_WhenWhitespace_IgnoreWhitespace()
        {
            var tokens = new List<Token> { Tokens.Whitespace, Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenNumberToken_Value()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenPlusToken_Add()
        {
            var tokens = new List<Token> { Tokens.NumberToken("1"), Tokens.PlusToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<AddExpression>(result);
        }

        [Fact]
        public void Parse_WhenMinusToken_Subtract()
        {
            var tokens = new List<Token> { Tokens.NumberToken("3"), Tokens.MinusToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<SubtractExpression>(result);
        }

        [Fact]
        public void Parse_WhenMinusToken_HasLeftAssociativity()
        {
            var tokens = new List<Token> { Tokens.NumberToken("6"), Tokens.MinusToken, Tokens.NumberToken("3"), Tokens.MinusToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var expression = parser.Parse(tokens);
            var result = expression.Evaluate(new ExpressionContext());

            Assert.Equal(1, result);
        }

        [Fact]
        public void Parse_WhenMinusToken_NegativeNumber()
        {
            var tokens = new List<Token> { Tokens.MinusToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ValueExpression>(result);
        }

        [Fact]
        public void Parse_WhenAsteriskToken_Multiply()
        {
            var tokens = new List<Token> { Tokens.NumberToken("3"), Tokens.AsteriskToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<MultiplyExpression>(result);
        }

        [Fact]
        public void Parse_WhenSlashToken_Divide()
        {
            var tokens = new List<Token> { Tokens.NumberToken("6"), Tokens.SlashToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<DivideExpression>(result);
        }

        [Fact]
        public void Parse_WhenSlashToken_HasLeftAssociativity()
        {
            var tokens = new List<Token> { Tokens.NumberToken("12"), Tokens.SlashToken, Tokens.NumberToken("3"), Tokens.SlashToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var expression = parser.Parse(tokens);
            var result = expression.Evaluate(new ExpressionContext());

            Assert.Equal(2, result);
        }

        [Fact]
        public void Parse_WhenCircumflexToken_Exponentiation()
        {
            var tokens = new List<Token> { Tokens.NumberToken("2"), Tokens.CircumflexToken, Tokens.NumberToken("3"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<ExponentiationExpression>(result);
        }

        [Fact]
        public void Parse_WhenCircumflexToken_HasRightAssociativity()
        {
            var tokens = new List<Token> { Tokens.NumberToken("2"), Tokens.CircumflexToken, Tokens.NumberToken("2"), Tokens.CircumflexToken, Tokens.NumberToken("3"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var expression = parser.Parse(tokens);
            var result = expression.Evaluate(new ExpressionContext());

            Assert.Equal(256, result);
        }

        [Fact]
        public void Parse_WhenMultipleWithoutParentheses()
        {
            var tokens = new List<Token> { Tokens.NumberToken("6"), Tokens.MinusToken, Tokens.NumberToken("1"), Tokens.PlusToken, Tokens.NumberToken("2"), Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<AddExpression>(result);
        }

        [Fact]
        public void Parse_WhenMultipleWithParentheses()
        {
            var tokens = new List<Token> { Tokens.NumberToken("6"), Tokens.MinusToken,
                Tokens.LeftParenthesis, Tokens.NumberToken("1"), Tokens.PlusToken, Tokens.NumberToken("2"), Tokens.RightParenthesis, Tokens.EndOfStream };
            var parser = CreateInfixParser();

            var result = parser.Parse(tokens);

            Assert.IsType<SubtractExpression>(result);
        }

        private static InfixParser CreateInfixParser()
        {
            var parser = new InfixParser();
            parser.AddExpressionDefinitions();
            return parser;
        }
    }
}
