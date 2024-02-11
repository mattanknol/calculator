using Calculator.Lexer;
using Calculator.Parser.Expressions;

namespace Calculator.Parser.Definitions
{
    public class ValueExpressionDefinition : ExpressionDefinition
    {
        public override int OperandCount => 0;
        public override bool IsMatch(Token token) => token.TokenType == TokenType.Number;

        protected override Expression CreateExpressionInner(Token token, Expression[] operands)
        {
            if (decimal.TryParse(token.Value, out var number))
            {
                return new ValueExpression(number);
            }
            try
            {
                if (double.TryParse(token.Value, out var scientificNumber))
                {
                    return new ValueExpression(Convert.ToDecimal(scientificNumber));
                }
            }
            catch (OverflowException)
            {
                // throw exception below
            }
            throw new ParseException($"Token value cannot be convert to a decimal");
        }
    }
}
