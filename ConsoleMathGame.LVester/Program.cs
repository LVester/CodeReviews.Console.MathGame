namespace ConsoleMathGame.LVester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

            void Menu()
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Welcome to the Math Game!");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(@"What game mode would you like to play?:
                    A - Addition
                    S - Subtraction
                    M - Multiplication
                    D - Division
                    Q - Quit the game");
                Console.WriteLine("-------------------------------------------------");

                string gameMode = "";
                string symbol = "";

                bool validSelection = true;
                do
                {
                    var gameSelected = Console.ReadLine();
                    validSelection = true;

                    switch (gameSelected.Trim().ToUpper())
                    {
                        case "A":
                            gameMode = "Addition";
                            symbol = "+";
                            break;
                        case "S":
                            gameMode = "Subtraction";
                            symbol = "-";
                            break;
                        case "M":
                            gameMode = "Multiplication";
                            symbol = "*";
                            break;
                        case "D":
                            gameMode = "Division";
                            symbol = "/";
                            break;
                        case "Q":
                            Console.WriteLine("Thank you for playing!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please choose a valid option.");
                            validSelection = false;
                            break;
                    }
                } while (!validSelection);

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"You have chosen {gameMode}. How many rounds do you want to go?");
                
                string rounds = Console.ReadLine();
                rounds = Helpers.ValidateInput(rounds);

                Console.WriteLine("-------------------------------------------------");

                Game(symbol, Int32.Parse(rounds));
            }

            void Game(string symbol, int rounds)
            {
                var rand = new Random();
                int score = 0;

                int firstNumber;
                int secondNumber;

                HashSet<string> askedQuestions = new HashSet<string>();

                for (int i = 0; i < rounds; i++)
                {
                    do
                    {
                        if (symbol == "/")
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
                    } while (!askedQuestions.Add($"{firstNumber}{symbol}{secondNumber}"));

                    int correctAnswer = 0;

                    Console.WriteLine($"What is {firstNumber} {symbol} {secondNumber}?");
                    var playerAnswer = Console.ReadLine();
                    playerAnswer = Helpers.ValidateInput(playerAnswer);

                    switch (symbol)
                    {
                        case "+":
                            correctAnswer = firstNumber + secondNumber;
                            break;
                        case "-":
                            correctAnswer = firstNumber - secondNumber;
                            break;
                        case "*":
                            correctAnswer = firstNumber * secondNumber;
                            break;
                        case "/":
                            correctAnswer = firstNumber / secondNumber;
                            break;
                    }

                    if (Int32.Parse(playerAnswer) == correctAnswer)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                        Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
                }

                Console.WriteLine($"Your final score is {score} out of {rounds}.");
            }
        }
    }
}
