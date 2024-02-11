namespace Calculator.Parser
{
    public abstract class BinaryExpression(Expression operandLeft, Expression operandRight) : Expression()
    {
        protected readonly Expression _operandLeft = operandLeft;
        protected readonly Expression _operandRight = operandRight;
    }
}
