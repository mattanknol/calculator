using Calculator.Parser.Definitions;

namespace Calculator.Parser
{
    public static class ExtensionMethods
    {
        public static void AddExpressionDefinitions(this IParser parser)
        {
            parser.AddDefinition<ValueExpressionDefinition>();
            parser.AddDefinition<AddExpressionDefinition>();
            parser.AddDefinition<SubtractExpressionDefinition>();
            parser.AddDefinition<MultiplyExpressionDefinition>();
            parser.AddDefinition<DivideExpressionDefinition>();
            parser.AddDefinition<ExponentiationExpressionDefinition>();
        }

        public static decimal Exponentiation(this decimal number, decimal exponent)
        {
            if (exponent == 0)
            {
                return 1m;
            }
            if (exponent < 0)
            {
                exponent *= -1;
                var result = 1 / number;
                for (int i = 1; i < exponent; i++)
                {
                    result /= number;
                }
                return result;
            }
            else
            {
                var result = number;
                for (int i = 1; i < exponent; i++)
                {
                    result *= number;
                }
                return result;
            }
        }
    }
}
