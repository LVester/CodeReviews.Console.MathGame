namespace ConsoleMathGame.LVester
{
    internal class Helpers
    {
        public static void WaitForMainMenuChoice()
        {
            while (true)
            {
                var input = Console.ReadLine().Trim().ToUpper();

                switch (input)
                {
                    case "N":
                        return;
                    case "S":
                        //Scoreboard feature is not implemented yet

                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please choose a valid option");
                        break;
                }
            }
        }

        public static (string gameMode, string op) GetGameMode()
        {
            while (true)
            {
                var input = Console.ReadLine().Trim().ToUpper();

                switch (input)
                {
                    case "A": return ("Addition", "+");
                    case "S": return ("Subtraction", "-");
                    case "M": return ("Multiplication", "*");
                    case "D": return ("Division", "/");
                    default:
                        Console.WriteLine("Invalid input. Please choose a valid option");
                        break;
                }
            }
        }

        public static string ValidateInput(string input)
        {
            while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
            {
                Console.WriteLine("Please enter a valid number for rounds:");
                input = Console.ReadLine();
            }
            return input;
        }

        public static int GetCorrectAnswer(string op, int firstNumber, int secondNumber)
        {
            return op switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
            };
        }

        public static (int firstNumber, int secondNumber) GenerateNumbers(string op, HashSet<string> askedQuestions)
        {
            var rand = new Random();

            int firstNumber;
            int secondNumber;

            do
            {
                if (op == "/")
                {
                    do
                    {
                        firstNumber = rand.Next(1, 12);
                        secondNumber = rand.Next(2, 12);
                    } while (firstNumber % secondNumber != 0);
                }
                else
                {
                    firstNumber = rand.Next(1, 9);
                    secondNumber = rand.Next(1, 9);
                }
            } while (!askedQuestions.Add($"{firstNumber}{op}{secondNumber}"));

            return (firstNumber, secondNumber);
        }

        
    }
}
