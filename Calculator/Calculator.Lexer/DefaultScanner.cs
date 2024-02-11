namespace Calculator.Lexer
{
    public class DefaultScanner(string text) : IScanner
    {
        public IEnumerable<Character> Scan()
        {
            int position = 0;
            int lineNumber = 1;
            int columnNumber = 1;
            while (position != text.Length)
            {
                var current = text[position];
                yield return new(current, position++, lineNumber, columnNumber++);
                if (current == '\n')
                {
                    lineNumber++;
                    columnNumber = 1;
                }
            }
            yield return new(Character.EndOfStream, position, lineNumber, columnNumber);
        }
    }
}
