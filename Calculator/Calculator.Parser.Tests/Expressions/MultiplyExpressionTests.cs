namespace Calculator.Parser.Tests.Expressions
{
    public class MultiplyExpressionTests
    {
        [Fact]
        public void Evaluate()
        {
            var leftOperand = new ValueExpression(3);
            var rightOperand = new ValueExpression(2);
            var expression = new MultiplyExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(6, result);
        }
    }
}
