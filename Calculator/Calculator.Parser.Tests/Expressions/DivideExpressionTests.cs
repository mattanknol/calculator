namespace Calculator.Parser.Tests.Expressions
{
    public class DivideExpressionTests
    {
        [Fact]
        public void Evaluate()
        {
            var leftOperand = new ValueExpression(6);
            var rightOperand = new ValueExpression(2);
            var expression = new DivideExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(3, result);
        }
    }
}
