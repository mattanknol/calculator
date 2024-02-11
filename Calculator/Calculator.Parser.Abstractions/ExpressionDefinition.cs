using Calculator.Lexer;

namespace Calculator.Parser
{
    public abstract class ExpressionDefinition
    {
        public abstract int OperandCount { get; }
        public abstract bool IsMatch(Token token);
        protected abstract Expression CreateExpressionInner(Token token, Expression[] operands);

        public Expression CreateExpression(Token token, Expression[] operands)
        {
            if (!IsMatch(token))
            {
                throw new ParseException($"Unknown token: {token}");
            }
            if (operands.Length != OperandCount)
            {
                throw new ParseException($"Should have {OperandCount} operands provided");
            }
            return CreateExpressionInner(token, operands);
        }
    }
}
