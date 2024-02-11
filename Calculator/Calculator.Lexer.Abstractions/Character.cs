namespace Calculator.Lexer
{
    public record class Character(char Char, int Position, int LineNumber, int ColumnNumber)
    {
        private const char _endOfStream = '\0';
        private static readonly Character _empty = new(default, default, default, default);

        public static char EndOfStream => _endOfStream;
        public static Character Empty => _empty;

        public override string? ToString() => $"Ln: {LineNumber}   Col: {ColumnNumber}   Pos: {Position}   Char: {(int)Char}";
    }
}
