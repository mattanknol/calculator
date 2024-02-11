namespace Calculator.Lexer
{
    public class DefaultTokenizer : ITokenizer
    {
        private readonly List<ITokenDefinition> _definitions = [];

        public void AddDefinition<T>()
            where T : ITokenDefinition, new()
        {
            _definitions.Add(new T());
        }

        public IEnumerable<Token> Tokenize(IScanner scanner)
        {
            var current = string.Empty;
            var startOfCurrent = Character.Empty;
            var currentDefinitions = new List<ITokenDefinition>(_definitions);
            foreach (var character in scanner.Scan())
            {
                if (startOfCurrent == Character.Empty)
                {
                    startOfCurrent = character;
                }
                var next = current + character.Char;
                var nextDefinitions = currentDefinitions.Where(definition => definition.IsMatch(next)).ToList();
                if (nextDefinitions.Count == 0)
                {
                    if (currentDefinitions.Count == 0) throw new LexicalException(startOfCurrent, $"Unknown token: '{current}'");
                    if (currentDefinitions.Count > 1) throw new LexicalException(startOfCurrent, $"Ambigious token: '{current}'");
                    yield return currentDefinitions[0].CreateToken(startOfCurrent, current);
                    current = Convert.ToString(character.Char);
                    startOfCurrent = character;
                    currentDefinitions = _definitions.Where(definition => definition.IsMatch(current)).ToList();
                    continue;
                }
                current = next;
                currentDefinitions = nextDefinitions;
            }
            if (current.Length != 1 || current[0] != Character.EndOfStream)
            {
                throw new LexicalException(startOfCurrent, $"Character stream ended unexpectedly: '{current}'");
            }
            yield return new Token(TokenType.EndOfStream, startOfCurrent, current);
        }
    }
}
