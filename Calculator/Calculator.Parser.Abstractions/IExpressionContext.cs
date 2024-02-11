namespace Calculator.Parser
{
    public interface IExpressionContext
    {
        public void SetValue(string identifier, decimal value);
        public decimal GetValue(string identifier);
    }
}
