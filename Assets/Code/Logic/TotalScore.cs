namespace Code.Logic
{
    public class TotalScore
    {
        public int CurrentScore => _currentScore;

        private int _currentScore;

        public TotalScore()
        {
            ResetScore();
        }

        public void AddPoint()
        {
            _currentScore++;
        }

        public void AddPoints(int amount)
        {
            if (amount < 0) return;

            _currentScore += amount;
        }

        public void ResetScore()
        {
            _currentScore = 0;
        }
    }
}