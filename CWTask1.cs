Вариант 14. Задание 1.
namespace ConsoleApp2
{
    public struct GuessGame
    {
        private int secretNumber;
        private bool Guessed;
        private int times;
        private int bestRecord;
        public GuessGame(int number)
        {
            secretNumber = number;
            Guessed = false;
            times = 0;
            bestRecord = Int32.MaxValue;
        }
        public void StartGame()
        {
            while (!Guessed)
            {
                Console.Write("Введите ваше число: ");
                int guessedNumber = Convert.ToInt32(Console.ReadLine());
                times++;
                if (guessedNumber == secretNumber)
                {
                    Guessed = true;
                    if (times < bestRecord)
                    {
                        bestRecord = times;
                    }
                    Console.WriteLine($"Число {secretNumber} угадано,  Количество попыток: {times}. Рекорд: {bestRecord}");
                }
                else
                {
                    if (guessedNumber < secretNumber)
                    {
                        Console.WriteLine("Загаданное число больше.");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число меньше.");
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int secretNumber = random.Next(0, 11);
            GuessGame game = new GuessGame(secretNumber);
            game.StartGame();
        }
    }
}
