using Calculator.Lexer.Definitions;

namespace Calculator.Lexer
{
    public static class ExtensionMethods
    {
        public static void AddInfixDefinitions(this ITokenizer tokenizer)
        {
            tokenizer.AddDefinition<WhitespaceTokenDefinition>();
            tokenizer.AddDefinition<NumberTokenDefinition>();
            tokenizer.AddDefinition<PlusTokenDefinition>();
            tokenizer.AddDefinition<MinusTokenDefinition>();
            tokenizer.AddDefinition<AsteriskTokenDefinition>();
            tokenizer.AddDefinition<SlashTokenDefinition>();
            tokenizer.AddDefinition<CircumflexTokenDefinition>();
            tokenizer.AddDefinition<ParenthesesTokenDefinition>();
        }

        public static void AddPostfixDefinitions(this ITokenizer tokenizer)
        {
            tokenizer.AddDefinition<WhitespaceTokenDefinition>();
            tokenizer.AddDefinition<SignedNumberTokenDefinition>();
            tokenizer.AddDefinition<PlusTokenDefinition>();
            tokenizer.AddDefinition<MinusTokenDefinition>();
            tokenizer.AddDefinition<AsteriskTokenDefinition>();
            tokenizer.AddDefinition<SlashTokenDefinition>();
            tokenizer.AddDefinition<CircumflexTokenDefinition>();
        }
    }
}
