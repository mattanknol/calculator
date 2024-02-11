namespace Calculator.Lexer.Tests
{
    public class DefaultScannerTests
    {
        [Fact]
        public void Scan_NotNull()
        {
            var scanner = new DefaultScanner("1");

            var result = scanner.Scan().ToList();

            Assert.NotNull(result);
            Assert.NotNull(result.First());
        }

        [Fact]
        public void Scan_Empty()
        {
            var scanner = new DefaultScanner("");

            var result = scanner.Scan().ToList();

            Assert.NotEmpty(result);
            Assert.Equal(Character.EndOfStream, result.First().Char);
        }

        [Fact]
        public void Scan_SingleCharacter()
        {
            var scanner = new DefaultScanner("1");

            var result = scanner.Scan().ToList();

            var character = result.First();
            Assert.Equal('1', character.Char);
            Assert.Equal(0, character.Position);
            Assert.Equal(1, character.LineNumber);
            Assert.Equal(1, character.ColumnNumber);
        }

        [Fact]
        public void Scan_MultiLine()
        {
            var scanner = new DefaultScanner("1\r\n23");

            var result = scanner.Scan().ToList();

            var character = result.Skip(4).First();
            Assert.Equal('3', character.Char);
            Assert.Equal(4, character.Position);
            Assert.Equal(2, character.LineNumber);
            Assert.Equal(2, character.ColumnNumber);
        }
    }
}
