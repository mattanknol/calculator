namespace Calculator.App.Tests
{
    public class InfixInterpreterTests
    {
        [Theory()]
        [InlineData("1", 1)]
        [InlineData("1 + 2", 3)]
        [InlineData("3 - 2", 1)]
        [InlineData("5 + 4 - 3 * 2 / 1", 3)]
        public void Interpret_WhenSimpleCalculation_CorrectResult(string input, decimal expected)
        {
            var interpreter = new InfixInterpreter();

            var result = interpreter.Interpret(input);

            Assert.Equal(expected, result);
        }
    }
}
