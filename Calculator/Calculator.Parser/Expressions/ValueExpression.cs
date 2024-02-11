namespace Calculator.Parser.Expressions
{
    public class ValueExpression(decimal value) : Expression
    {
        protected decimal _value = value;

        public override decimal Evaluate(IExpressionContext context) => _value;
    }
}
