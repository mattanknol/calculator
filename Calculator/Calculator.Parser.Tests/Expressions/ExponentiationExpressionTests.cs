namespace Calculator.Parser.Tests.Expressions
{
    public class ExponentiationExpressionTests
    {
        [Fact]
        public void Evaluate_Positive()
        {
            var leftOperand = new ValueExpression(2);
            var rightOperand = new ValueExpression(3);
            var expression = new ExponentiationExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Evaluate_Zero()
        {
            var leftOperand = new ValueExpression(2);
            var rightOperand = new ValueExpression(0);
            var expression = new ExponentiationExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Evaluate_Negative()
        {
            var leftOperand = new ValueExpression(2);
            var rightOperand = new ValueExpression(-3);
            var expression = new ExponentiationExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(0.125m, result);
        }
    }
}
