namespace Calculator.Parser.Tests.Expressions
{
    public class SubtractExpressionTests
    {
        [Fact]
        public void Evaluate()
        {
            var leftOperand = new ValueExpression(3);
            var rightOperand = new ValueExpression(2);
            var expression = new SubtractExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(1, result);
        }
    }
}
