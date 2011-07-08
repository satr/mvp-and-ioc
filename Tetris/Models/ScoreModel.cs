using System;

namespace Tetris.Models
{
    public class ScoreModel
    {
        public int TotalScore { get; private set; }
        public int CurrentScore { get; private set; }

        public void AddBrick()
        {
            CurrentScore++;
            TotalScore++;
        }

        public void Init()
        {
            TotalScore = 0;
            ResetCurrentScore();
        }

        public void ResetCurrentScore()
        {
            CurrentScore = 0;
        }
    }
}