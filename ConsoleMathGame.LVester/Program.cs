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

                List<int> scores = new List<int>();

                while (true)
                {
                    Console.WriteLine(@"
                        N - New Game
                        S - Scoreboard
                        Q - Quit Game");



                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine(@"What game mode would you like to play?:
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division");
                    Console.WriteLine("-------------------------------------------------");

                    var (gameMode, op) = Helpers.GetGameMode();

                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"You have chosen {gameMode}. How many rounds do you want to go?");

                    string rounds = Console.ReadLine();
                    rounds = Helpers.ValidateInput(rounds);

                    scores.Add(Game(op, Int32.Parse(rounds)));

                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"Your score this round: {scores.Last()}");
                    Console.WriteLine($"Best score so far: {scores.Max()}");
                    Console.WriteLine("-------------------------------------------------");
                }
            }

            int Game(string symbol, int rounds)
            {
                int score = 0;

                HashSet<string> askedQuestions = new HashSet<string>();

                for (int i = 0; i < rounds; i++)
                {
                    var (firstNumber, secondNumber) = Helpers.GenerateNumbers(symbol, askedQuestions);

                    Console.WriteLine($"What is {firstNumber} {symbol} {secondNumber}?");
                    var playerAnswer = Helpers.ValidateInput(Console.ReadLine());

                    int correctAnswer = Helpers.GetCorrectAnswer(symbol, firstNumber, secondNumber);
                    bool isAnswerCorrect = Int32.Parse(playerAnswer) == correctAnswer;

                    if (isAnswerCorrect)
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                        Console.WriteLine($"Wrong! The correct answer is {correctAnswer}.");
                }

                Console.WriteLine($"Your final score is {score} out of {rounds}.");
                return score;
            }   
        }
    }
}
