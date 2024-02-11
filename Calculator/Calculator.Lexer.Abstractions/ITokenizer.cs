namespace Calculator.Lexer
{
    public interface ITokenizer
    {
        public IEnumerable<Token> Tokenize(IScanner scanner);
        public void AddDefinition<T>()
            where T : ITokenDefinition, new();
    }
}
