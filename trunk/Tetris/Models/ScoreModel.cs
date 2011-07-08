using System;

namespace Tetris.Models
{
    public class ScoreModel
    {
        public int Total { get; private set; }
        public int CurrentScore { get; private set; }

        public void AddBrick()
        {
            CurrentScore++;
            Total++;
        }

        public void Init()
        {
            Total = 0;
            ResetCurrentScore();
        }

        public void ResetCurrentScore()
        {
            CurrentScore = 0;
        }
    }
}