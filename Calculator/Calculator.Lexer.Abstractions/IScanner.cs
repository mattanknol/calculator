namespace Calculator.Lexer
{
    public interface IScanner
    {
        IEnumerable<Character> Scan();
    }
}
