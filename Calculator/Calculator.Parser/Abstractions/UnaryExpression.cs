namespace Calculator.Parser
{
    public abstract class UnaryExpression(Expression operand) : Expression()
    {
        protected readonly Expression _operand = operand;
    }
}
