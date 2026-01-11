namespace ConsoleMathGame.LVester
{
    internal class Helpers
    {
        public static string ValidateInput(string input)
        {
            while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
            {
                Console.WriteLine("Please enter a valid number for rounds:");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
