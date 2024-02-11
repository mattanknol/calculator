namespace Calculator.App
{
    internal class Program
    {
        private const string _exitOption = "0";
        private const string _exitKeyword = "exit";
        private static readonly Dictionary<string, Interpreter> _menu = new()
        {
            ["1"] = new InfixInterpreter()
        };

        static void Main()
        {
            var menuChoice = InterpreterMenu();
            if (menuChoice == _exitOption)
            {
                return;
            }
            ReadEvalPrintLoop(_menu[menuChoice]);
        }

        private static void ReadEvalPrintLoop(Interpreter interpreter)
        {
            Console.Clear();
            Console.WriteLine($"Type '{_exitKeyword}' to exit the REPL prompt");
            Console.WriteLine();
            while (true)
            {
                Console.Write("= ");
                var calculation = Console.ReadLine() ?? _exitKeyword;
                if (calculation == _exitKeyword)
                {
                    return;
                }
                try
                {
                    var result = interpreter.Interpret(calculation);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string InterpreterMenu()
        {
            foreach (var menuItem in _menu)
            {
                Console.WriteLine($"{menuItem.Key}\t{menuItem.Value}");
            }
            Console.WriteLine($"{_exitOption}\tExit");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter selection: ");
                var choice = Console.ReadLine() ?? _exitOption;
                if (choice == _exitOption || _menu.ContainsKey(choice))
                {
                    return choice;
                }
            }
        }
    }
}
