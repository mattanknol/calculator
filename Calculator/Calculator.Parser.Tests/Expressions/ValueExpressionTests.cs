namespace Calculator.Parser.Tests.Expressions
{
    public class ValueExpressionTests
    {
        [Fact]
        public void Evaluate()
        {
            var expression = new ValueExpression(1);
            var context = new ExpressionContext();

            var result = expression.Evaluate(context);

            Assert.Equal(1, result);
        }
    }
}
