using Calculator.Lexer;
using Calculator.Parser.Expressions;

namespace Calculator.Parser.Definitions
{
    public class SubtractExpressionDefinition : ExpressionDefinition
    {
        public override int OperandCount => 2;
        public override bool IsMatch(Token token) => token.TokenType == TokenType.Operator && token.Value == "-";

        protected override Expression CreateExpressionInner(Token token, Expression[] operands)
        {
            return new SubtractExpression(operands[0], operands[1]);
        }
    }
}
