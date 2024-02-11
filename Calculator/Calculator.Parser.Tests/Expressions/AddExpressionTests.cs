namespace Calculator.Parser.Tests.Expressions
{
    public class AddExpressionTests
    {
        [Fact]
        public void Evaluate()
        {
            var leftOperand = new ValueExpression(1);
            var rightOperand = new ValueExpression(2);
            var expression = new AddExpression(leftOperand, rightOperand);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(3, result);
        }
    }
}
