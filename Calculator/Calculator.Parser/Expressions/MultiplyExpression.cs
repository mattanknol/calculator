﻿namespace Calculator.Parser.Expressions
{
    public class MultiplyExpression(Expression operandLeft, Expression operandRight) : BinaryExpression(operandLeft, operandRight)
    {
        public override decimal Evaluate(IExpressionContext context)
        {
            var leftValue = _operandLeft.Evaluate(context);
            var rightValue = _operandRight.Evaluate(context);
            return leftValue * rightValue;
        }
    }
}
