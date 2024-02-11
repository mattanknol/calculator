namespace Calculator.Lexer
{
	public class LexicalException : Exception
	{
        public Character Character { get; }

        public LexicalException(Character character) { Character = character; }
		public LexicalException(Character character, string message) : base(message) { Character = character; }
		public LexicalException(Character character,string message, Exception inner) : base(message, inner) { Character = character; }
	}
}
