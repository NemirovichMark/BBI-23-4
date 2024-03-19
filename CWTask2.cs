namespace ConsoleApp2
{
public abstract class Game
    {
        public abstract void StartGame(int min, int max);
    }

    public class GuessGame : Game
    {
        private int secretNumber;
        private bool isGuessed;
        private int attempts;
        private int bestRecord;

        public GuessGame()
        {
            secretNumber = 0;
            isGuessed = false;
            attempts = 0;
            bestRecord = Int32.MaxValue;
        }
    }
}
