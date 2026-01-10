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
                Console.WriteLine(@"What game would you like to play? Choose one from the options below:
                    A - Addition
                    S - Subtraction
                    M - Multiplication
                    D - Division
                    Q - Quit the game");
                Console.WriteLine("-------------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToUpper())
                {
                    case "A":
                        Game("Addition", "+");
                        break;
                    case "S":
                        Game("Subtraction", "-");
                        break;
                    case "M":
                        Game("Multiplication", "*");
                        break;
                    case "D":
                        Game("Division", "/");
                        break;
                    case "Q":
                        Console.WriteLine("Thank you for playing! Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please restart the game and choose a valid option.");
                        break;
                }
            }

            void Game(string gameMode, string symbol)
            {
                Console.WriteLine($"You chose the {gameMode} Game!");

                var rand = new Random();
                int score = 0;

                int firstNumber;
                int secondNumber;

                for (int i = 0; i < 2; i++)
                {
                    firstNumber = rand.Next(1, 9);
                    secondNumber = rand.Next(1, 9);
                    int correctAnswer = 0;

                    Console.WriteLine($"What is {firstNumber} {symbol} {secondNumber}?");
                    var playerAnswer = Console.ReadLine();

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

                Console.WriteLine($"Your final score is {score} out of 2.");
            }

            void AdditionGame()
            {
                Console.WriteLine("You chose the Addition Game!");

                var rand = new Random();
                int score = 0;

                int firstNumber;
                int secondNumber;

                for (int i = 0; i < 5; i++)
                {
                    firstNumber = rand.Next(1, 9);
                    secondNumber = rand.Next(1, 9);

                    Console.WriteLine($"What is {firstNumber} + {secondNumber}?");
                    var result = Console.ReadLine();

                    if (Int32.Parse(result) == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {firstNumber + secondNumber}.");
                    }

                    if(i == 4) Console.WriteLine($"Your final score is {score} out of 5.");
                }
            }
            void SubtractionGame()
            {
                Console.WriteLine("You chose the Subtraction Game!");
            }
            void MultiplicationGame()
            {
                Console.WriteLine("You chose the Multiplication Game!");
            }
            void DivisionGame()
            {
                Console.WriteLine("You chose the Division Game!");
            }
        }
    }
}
