namespace Calculator.Parser
{
    public abstract class Expression
    {
        public abstract decimal Evaluate(IExpressionContext context);
    }
}
