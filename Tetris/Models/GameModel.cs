using Tetris.Common;

namespace Tetris.Models
{
    public class GameModel
    {
        public event TetrisActionEventHandler OnFinished;
        private const int MaxVerticalPosition = 50;

        public GameModel()
        {
            CurrentVerticalPosition = 0;
        }

        public int CurrentVerticalPosition { get; private set; }

        public bool IsBrickGotDown { get; set; }

        public void ChangeBrickState()
        {
            if (++CurrentVerticalPosition >= MaxVerticalPosition)
            {
                IsBrickGotDown = true;
            }
            if(!IsFilled)
                return;
            if (OnFinished != null)
                OnFinished();
        }

        public void Init()
        {
            IsBrickGotDown = IsFilled = false;
            CurrentVerticalPosition = 0;
        }

        private bool IsFilled { get; set; }
    }
}